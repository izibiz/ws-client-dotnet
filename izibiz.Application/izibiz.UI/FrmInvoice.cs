using izibiz.CONTROLLER.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using izibiz.SERVICES.serviceOib;
using izibiz.UI.Properties;
using Microsoft.VisualBasic;
using izibiz.CONTROLLER;
using izibiz.CONTROLLER.Singleton;
using izibiz.COMMON;
using izibiz.COMMON.Language;
using izibiz.MODEL.Model;

namespace izibiz.UI
{
    public partial class FrmInvoice : Form
    {

        private int invoiceType;

        public FrmInvoice()
        {
            InitializeComponent();
        }


        private void FrmInvoice_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
        }



        private void localizationItemTextWrite()
        {
            //dil secimini sorgula
            if (Settings.Default.language == "English")
            {
                Lang.Culture = new CultureInfo("en-US");
            }
            else
            {
                Lang.Culture = new CultureInfo("");
            }
            #region writeAllFormItem
            //eleman text yazdır
            this.Text = Lang.formInvoice;
            itemIncomingInvoice.Text = Lang.incomingInvoice;
            itemComingListInvoice.Text = Lang.listInvoice;
            itemSentInvoice.Text = Lang.sentInvoice;
            itemDraftInvoice.Text = Lang.draftInvoice;
            itemDraftNewInvoice.Text = Lang.newInvoice;
            itemSentInvoiceList.Text = Lang.listInvoice;
            itemDraftInvoiceList.Text = Lang.listDraftInvoice;
            //panelSentInvoices butonlar
            btnSentInvGetState.Text = Lang.updateState;
            btnSentInvAgainSent.Text = Lang.againSent;
            btnFaultyInvoices.Text = Lang.faulty;
            //panelIncomingInvoices butonlar
            btnAccept.Text = Lang.accept;
            btnReject.Text = Lang.reject;
            btnGetInvoiceIncoming.Text = Lang.getInvoice;
            btnIncomingInvGetState.Text = Lang.updateState;
            #endregion
        }

        private void dataGridChangeColoumnName()
        {
            tableGrid.Columns[EI.InvClmName.ID.ToString()].HeaderText = Lang.id;

            tableGrid.Columns[EI.InvClmName.uuid.ToString()].HeaderText = Lang.uuid;

            tableGrid.Columns[EI.InvClmName.invType.ToString()].HeaderText = Lang.invType;

            tableGrid.Columns[EI.InvClmName.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableGrid.Columns[EI.InvClmName.profileid.ToString()].HeaderText = Lang.profileid;

            tableGrid.Columns[EI.InvClmName.type.ToString()].HeaderText = Lang.type;

            tableGrid.Columns[EI.InvClmName.suplier.ToString()].HeaderText = Lang.supplier;

            tableGrid.Columns[EI.InvClmName.sender.ToString()].HeaderText = Lang.sender;

            tableGrid.Columns[EI.InvClmName.cDate.ToString()].HeaderText = Lang.cDate;

            tableGrid.Columns[EI.InvClmName.envelopeIdentifier.ToString()].HeaderText = Lang.envelopeIdentifier;

            tableGrid.Columns[EI.InvClmName.status.ToString()].HeaderText = Lang.status;

            tableGrid.Columns[EI.InvClmName.statusDesc.ToString()].HeaderText = Lang.statusDesc;

            tableGrid.Columns[EI.InvClmName.gibStatusCode.ToString()].HeaderText = Lang.gibStatusCode;

            tableGrid.Columns[EI.InvClmName.gibStatusDescription.ToString()].HeaderText = Lang.gibSatusDescription;

            tableGrid.Columns[EI.InvClmName.fromm.ToString()].HeaderText = Lang.from;

            tableGrid.Columns[EI.InvClmName.too.ToString()].HeaderText = Lang.to;

        }




        private void itemComingListInvoice_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.incomingInvoice;
            panelSentInvoice.Visible = false;
            panelIncomingInvoice.Visible = true;
            panelConfirmation.Visible = false;
            invoiceType = 1;
            try
            {
                tableGrid.DataSource = null;
                addViewButtonToDatagridView();
                var invoiceList = Singl.instanceInvoiceGet.getIncomingInvoice();
                if (invoiceList.Count == 0)
                {
                    MessageBox.Show("Gösterilecek faturanız yok");
                }
                else
                {
                    foreach (var inv in invoiceList)
                    {
                        inv.statusDesc = invoiceIncomingStatusWrite(inv.status, inv.gibStatusCode);
                    }
                    tableGrid.DataSource = invoiceList;
                    dataGridChangeColoumnName();
                    tableGrid.Columns[nameof(EI.InvClmName.status)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.invType)].Visible = false;
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }




        private void itemSentInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.sentInvoice;
            panelIncomingInvoice.Visible = false;
            panelSentInvoice.Visible = true;
            panelConfirmationSentInv.Visible = false;
            btnSentInvAgainSent.Enabled = false;
            invoiceType = 2;
            try
            {       
                var List = Singl.instanceInvoiceGet.getSentInvoice();
                if (List.Count == 0)
                {
                    MessageBox.Show("Gösterilecek okunmamıs faturanız yok");
                }
                else //yenı fatura varsa
                {
                    foreach (var inv in List)
                    {
                        inv.statusDesc = invoiceIncomingStatusWrite(inv.status, inv.gibStatusCode);
                    }
                    tableGrid.DataSource = null;
                    addViewButtonToDatagridView();
                    tableGrid.DataSource = List;
                    dataGridChangeColoumnName();
                    tableGrid.Columns[EI.InvClmName.status.ToString()].Visible = false;
                    tableGrid.Columns[EI.InvClmName.invType.ToString()].Visible = false;
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                   Singl.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault,"DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void itemDraftInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.draftInvoice;
            panelSentInvoice.Visible = false;
            panelIncomingInvoice.Visible = false;
            invoiceType = 3;
            try
            {
                tableGrid.DataSource = null;
                addViewButtonToDatagridView();
                //gelecek
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                   Singl.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }





        private void addViewButtonToDatagridView()
        {
            tableGrid.Columns.Clear();
            //pdf goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconPdf,
                Name = "PreviewPdf",
                HeaderText = Lang.preview
            });
            //xml goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconXml,
                Name = "PreviewXml",
                HeaderText = Lang.preview,
            });
        }


        public string invoiceIncomingStatusWrite(string status, int gibStatusCode)
        {
            //   string status = invoice.status;
            //  int envelopeOpcode = invoice.gibStatusCode;

            if (gibStatusCode == 1210)
            {
                return "GİB'e gönderildi";
            }
            // RECEIVE
            if (status.Contains(EI.StatusType.RECEIVE.ToString()))
            {
                return "Alındı";
            }
            // LOAD
            if (status.Contains(EI.StatusType.LOAD.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "Yüklendi";
            }
            if (status.Contains(EI.StatusType.LOAD.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "Yüklenemedi";
            }
            // PACKAGE
            if (status.Contains(EI.StatusType.PACKAGE.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "İşleniyor";
            }
            if (status.Contains(EI.StatusType.PACKAGE.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "Yüklendi";
            }
            if (status.Contains(EI.StatusType.PACKAGE.ToString()) && status.Contains(EI.SubStatusType.PROCESSING.ToString()))
            {
                return "Paketleniyor";
            }
            if (status.Contains(EI.StatusType.SIGN.ToString()) && status.Contains(EI.SubStatusType.PROCESSING.ToString()))
            {
                return "İşleniyor";
            }
            if (status.Contains(EI.StatusType.SIGN.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "İmzalandı";
            }
            if (status.Contains(EI.StatusType.SIGN.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "İşleniyor";
            }
            return "Durum Atanması Bekleniyor";
        }



        public string invoiceSendStatusWrite(string status)
        {
            // string status = invoice.status;

            // SEND
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.PROCESSING.ToString()))
            {
                return "İşleniyor";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "Ulaştırıldı";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "Ulaştırılamadı";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_GIB_RESPONSE.ToString()))
            {
                return "GİB'e gönderildi";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_SYSTEM_RESPONSE.ToString()))
            {
                return "Ulaştırıldı";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_APPLICATION_RESPONSE.ToString()))
            {
                return "Ulaştırıldı";
            }
            // ACCEPTED
            if (status.Contains(EI.StatusType.ACCEPTED.ToString()))
            {
                return "Kabul edildi";
            }
            // REJECTED
            if (status.Contains(EI.StatusType.REJECTED.ToString()))
            {
                return "Red edildi";
            }
            // ACCEPT
            if (status.Contains(EI.StatusType.ACCEPT.ToString()))
            {
                return "Kabul";
            }
            // REJECT
            if (status.Contains(EI.StatusType.REJECT.ToString()))
            {
                return "Red";
            }
            return "Durum Atanması Bekleniyor";
        }






        private void invoiceResponseAcceptOrReject(string state)
        {
            int verifiedrow = 0;
            int invoiceCount = tableGrid.SelectedRows.Count;
            string[] description = new string[invoiceCount];


            string desc = Interaction.InputBox(Lang.writeDescription, Lang.addDescription, "Default");

            foreach (DataGridViewRow row in tableGrid.SelectedRows)
            {
                DateTime dt = DateTime.Parse(row.Cells[nameof(EI.InvClmName.cDate)].Value.ToString());
                TimeSpan fark = DateTime.Today - dt;

                if (row.Cells[nameof(EI.InvClmName.profileid)].Value == null || row.Cells[nameof(EI.InvClmName.profileid)].Value.ToString() == EI.InvoiceProfileid.TEMELFATURA.ToString())//temel faturaysa
                {
                    MessageBox.Show((row.Cells[nameof(EI.InvClmName.ID)].Value.ToString()) + " " + Lang.warningBasicInvoice);
                    break;
                }
                else if (fark.TotalDays > 8)//8 gün geçmis
                {
                    MessageBox.Show((row.Cells[nameof(EI.InvClmName.ID)].Value.ToString()) + " " + Lang.warning8Day);
                    break;
                }
                else if (row.Cells[nameof(EI.InvClmName.status)].Value == null || row.Cells[nameof(EI.InvClmName.status)].Value.ToString() != EI.SubStatusType.WAIT_APPLICATION_RESPONSE.ToString())//olan varsa
                {
                    MessageBox.Show((row.Cells[nameof(EI.InvClmName.ID)].Value.ToString()) + " " + Lang.warningHasAnswer);
                    break;
                }
                else//fatura noların oldugu kabul lıstesi olustur
                {
                    string uuid = row.Cells[nameof(EI.InvClmName.uuid)].Value.ToString();
                    Singl.instanceInvoiceGet.createInvoiceWithUuid(invoiceCount, uuid, verifiedrow);

                    description[verifiedrow] = desc;
                    verifiedrow++;
                }
            }
            if (verifiedrow > 0)
            {
                Singl.instanceInvoiceGet.sendInvoiceResponse(state, description);
            }
        }



        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                invoiceResponseAcceptOrReject(EI.InvoiceResponseStatus.KABUL.ToString());
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                invoiceResponseAcceptOrReject(EI.InvoiceResponseStatus.RED.ToString());
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool statusValidCheck(DataGridViewRow row)
        {
            if ((row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value.Equals(1300) || row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value.Equals(1215) || row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value.Equals(1230))
              || (Convert.ToInt32(row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value) < 1100 || (Convert.ToInt32(row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value) > 1200)))
            {
                return false;
            }
            return true;
        }



        private void showStateInvoice(string invoiceType)
        {
            try
            {
                List<string> unvalidList = new List<string>();
                List<string> validList = new List<string>();
                string uuid;

                for (int i = 0; i < tableGrid.SelectedRows.Count; i++)
                {
                    uuid = tableGrid.Rows[i].Cells[nameof(EI.InvClmName.uuid)].Value.ToString();
                    if (!statusValidCheck(tableGrid.SelectedRows[i])) //selectedrows valid degıl ise
                    {
                        unvalidList.Add(uuid);
                    }
                    else //valid ise modelde guncelle
                    {
                        validList.Add(uuid);
                        string updatedState= Singl.instanceInvoiceGet.getInvoiceState(uuid);
                        //modelde guncelle
                        Singl.databaseContextGet.Invoices.Find(uuid).statusDesc = updatedState;
                        //datagrıdde yazdır
                        tableGrid.Rows[i].Cells[nameof(EI.InvClmName.statusDesc)].Value = updatedState;
                    }
                }
                string message;
                if (validList.First() == null) //hicbiri krıterlere uygun degılse
                {
                    if (tableGrid.SelectedRows.Count == 1)//tekli secim
                    {
                        MessageBox.Show("temel fatura veya 8 gün gecmiş faturaların durum sorgulaması yapılamaz");
                    }
                    else//coklu secım
                    {
                        message = string.Join(Environment.NewLine, unvalidList);
                        MessageBox.Show(message + Environment.NewLine + "nolu faturalar uygun degil bu yuzden guncellenmedı");
                    }
                }
                else//valid fatura varsa modelden datagride guncelle
                {                  
                    message = string.Join(Environment.NewLine, validList);
                    MessageBox.Show(message + Environment.NewLine + "nolu faturalar guncellendı");
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                   Singl.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void previewInvoiceType(string type)
        {
            try
            {
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    string id = row.Cells[nameof(EI.InvClmName.ID)].Value.ToString();
                    string filepath = Singl.instanceInvoiceGet.getInvoiceType(id, type);
                    System.Diagnostics.Process.Start(filepath);
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnIncomingInvGetState_Click(object sender, EventArgs e)
        {
            showStateInvoice(EI.InvType.IN.ToString());
        }

        private void btnSentInvGetState_Click(object sender, EventArgs e)
        {
            btnSentInvAgainSent.Enabled = false;
            showStateInvoice(EI.InvType.OUT.ToString());
        }






        private void tableGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                #region panelVisiblity
                if (invoiceType == 1)//gelen faturalara tıklandıysa
                {
                    panelConfirmation.Visible = true;
                }
                else if (invoiceType == 2)//giden faturalar
                {
                    panelConfirmationSentInv.Visible = true;
                }
                #endregion

                //PDF göruntule butonuna tıkladıysa
                if (e.ColumnIndex == tableGrid.Columns["PreviewPdf"].Index)
                {
                    previewInvoiceType(EI.InvoiceDownloadType.PDF.ToString());
                }
                //xml göruntule butonuna tıkladıysa
                else if (e.ColumnIndex == tableGrid.Columns["PreviewXml"].Index)
                {
                    previewInvoiceType(EI.InvoiceDownloadType.XML.ToString());
                }
            }
        }



        private void btnGetInvoiceIncoming_Click(object sender, EventArgs e)
        {
            try
            {
                CONTROLLER.Singleton.Singl.instanceInvoiceGet.downloadInvoice();
                MessageBox.Show("Gelen faturalar 'D:\\temp\\GELEN\\' klasorune kaydedılmıstır");

            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSentInvAgainSent_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {


                }

            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void itemDraftNewInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btnFaultyInvoices_Click(object sender, EventArgs e)
        {
            try
            {          
                //db ye yuklenen gıden faturalardan hatalı olanları getır
                List<Invoices> list= Singl.invoiceDalGet.getFaultyInvoices();
                if (list.Count==0 || list == null)
                {
                    MessageBox.Show("Gösterilecek hatalı faturanız yok");
                }
                else //yenı fatura varsa
                {
                    tableGrid.DataSource = null;
                    addViewButtonToDatagridView();
                    tableGrid.DataSource = list;
                    dataGridChangeColoumnName();
                    tableGrid.Columns[EI.InvClmName.status.ToString()].Visible = false;
                    tableGrid.Columns[EI.InvClmName.invType.ToString()].Visible = false;
                    lblTitle.Text = Lang.faulty;
                    btnSentInvAgainSent.Enabled = true;
                }

            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}

