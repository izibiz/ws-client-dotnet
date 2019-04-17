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
using izibiz.COMMON;
using izibiz.COMMON.Language;
using izibiz.MODEL.Model;

namespace izibiz.UI
{
    public partial class FrmInvoice : Form
    {

        private string direction;

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
            btnDownInvIncoming.Text = Lang.getInvoice;
            btnIncomingInvGetState.Text = Lang.updateState;
            //panelDraftInvoices butonlar
            btnSendDraft.Text = Lang.send;
            btnLoadPortal.Text = Lang.loadPortal;
            #endregion
        }

        private void dataGridChangeColoumnName()
        {

            tableGrid.Columns[EI.InvClmName.status.ToString()].HeaderText = Lang.status;

            tableGrid.Columns[EI.InvClmName.statusDesc.ToString()].HeaderText = Lang.statusDesc;

            tableGrid.Columns[EI.InvClmName.gibStatusCode.ToString()].HeaderText = Lang.gibStatusCode;

            tableGrid.Columns[EI.InvClmName.gibStatusDescription.ToString()].HeaderText = Lang.gibSatusDescription;

            tableGrid.Columns[EI.InvClmName.ID.ToString()].HeaderText = Lang.id;

            tableGrid.Columns[EI.InvClmName.uuid.ToString()].HeaderText = Lang.uuid;

            tableGrid.Columns[EI.InvClmName.invType.ToString()].HeaderText = Lang.invType;

            tableGrid.Columns[EI.InvClmName.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableGrid.Columns[EI.InvClmName.profileid.ToString()].HeaderText = Lang.profileid;

            tableGrid.Columns[EI.InvClmName.type.ToString()].HeaderText = Lang.type;

            tableGrid.Columns[EI.InvClmName.suplier.ToString()].HeaderText = Lang.supplier;

            tableGrid.Columns[EI.InvClmName.senderVkn.ToString()].HeaderText = Lang.sender;

            tableGrid.Columns[EI.InvClmName.receiverVkn.ToString()].HeaderText = Lang.receiver;

            tableGrid.Columns[EI.InvClmName.cDate.ToString()].HeaderText = Lang.cDate;

            tableGrid.Columns[EI.InvClmName.envelopeIdentifier.ToString()].HeaderText = Lang.envelopeIdentifier;

            tableGrid.Columns[EI.InvClmName.fromm.ToString()].HeaderText = Lang.from;

            tableGrid.Columns[EI.InvClmName.too.ToString()].HeaderText = Lang.to;

        }




        private void itemComingListInvoice_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.incomingInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            direction = nameof(EI.Direction.IN);
            try
            {
                tableGrid.DataSource = null;
                addViewButtonToDatagridView();
                var invoiceList = Singl.invoiceControllerGet.getIncomingInvoice();
                if (invoiceList.Count == 0)
                {
                    MessageBox.Show(Lang.noShowInvoice);
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
                    tableGrid.Columns[nameof(EI.InvClmName.draftFlag)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.receiverVkn)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.content)].Visible = false;
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show(Lang.dbFault + " " + ex.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }




        private void itemSentInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.sentInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            btnSentInvAgainSent.Enabled = false;
            direction = nameof(EI.Direction.OUT);
            try
            {
                var list = Singl.invoiceControllerGet.getSentInvoice();
                if (list.Count == 0)
                {
                    MessageBox.Show(Lang.noShowInvoice);
                }
                else //yenı fatura varsa
                {
                    foreach (var inv in list)
                    {
                        inv.statusDesc = invoiceIncomingStatusWrite(inv.status, inv.gibStatusCode);
                    }
                    tableGrid.DataSource = null;
                    addViewButtonToDatagridView();
                    tableGrid.DataSource = list;
                    dataGridChangeColoumnName();
                    tableGrid.Columns[EI.InvClmName.status.ToString()].Visible = false;
                    tableGrid.Columns[EI.InvClmName.invType.ToString()].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.receiverVkn)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.draftFlag)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.content)].Visible = false;
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
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


        private void itemDraftInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.draftInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            direction = nameof(EI.Direction.DRAFT);
            try
            {
                tableGrid.DataSource = null;
                addViewButtonToDatagridView();
                var list = Singl.invoiceControllerGet.getDraftInvoice();
                if (list.Count == 0)
                {
                    MessageBox.Show(Lang.noShowInvoice);
                }
                else //yenı fatura varsa
                {
                    foreach (var inv in list)
                    {
                        inv.statusDesc = invoiceIncomingStatusWrite(inv.status, inv.gibStatusCode);
                    }
                    tableGrid.DataSource = null;
                    addViewButtonToDatagridView();
                    tableGrid.DataSource = list;
                    dataGridChangeColoumnName();
                    tableGrid.Columns[nameof(EI.InvClmName.invType)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.draftFlag)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.envelopeIdentifier)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.status)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.gibStatusDescription)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.fromm)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.too)].Visible = false;
                    tableGrid.Columns[nameof(EI.InvClmName.content)].Visible = false;
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show(Lang.dbFault + " " + ex.Message, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          /*  catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }





        private void addViewButtonToDatagridView()
        {
            tableGrid.Columns.Clear();
            //pdf goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconPdf,
                Name = EI.gridBtnClmName.previewPdf.ToString(),
                HeaderText = Lang.preview
            });
            //xml goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconXml,
                Name = EI.gridBtnClmName.previewXml.ToString(),
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
                    Singl.invoiceControllerGet.createInvoiceWithUuid(invoiceCount, uuid, verifiedrow);

                    description[verifiedrow] = desc;
                    verifiedrow++;
                }
            }
            if (verifiedrow > 0)
            {
                Singl.invoiceControllerGet.sendInvoiceResponse(state, description);
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
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
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
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
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



        private void showStateInvoice(string invoiceType, string type)
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
                        string updatedState = Singl.invoiceControllerGet.getInvoiceState(uuid);
                        //modelde guncelle
                        Singl.databaseContextGet.Invoices.Where(x => x.Uuid == uuid && x.type == type).FirstOrDefault().statusDesc = updatedState;
                        //datagrıdde yazdır
                        tableGrid.Rows[i].Cells[nameof(EI.InvClmName.statusDesc)].Value = updatedState;
                    }
                }
                string message;
                if (validList.First() == null) //hicbiri krıterlere uygun degılse
                {
                    if (tableGrid.SelectedRows.Count == 1)//tekli secim
                    {
                        MessageBox.Show(Lang.warningStateShow);
                    }
                    else//coklu secım
                    {
                        message = string.Join(Environment.NewLine, unvalidList);
                        MessageBox.Show(message + Environment.NewLine + Lang.noInvNotUpdated); //nolu faturalar guncellenemedi
                    }
                }
                else//valid fatura varsa modelden datagride guncelle
                {
                    message = string.Join(Environment.NewLine, validList);
                    MessageBox.Show(message + Environment.NewLine + Lang.noInvUpdated); //nolu faturalar guncellendı
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
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


        private void btnIncomingInvGetState_Click(object sender, EventArgs e)
        {
            showStateInvoice(EI.Direction.IN.ToString(), nameof(EI.Direction.IN));
        }

        private void btnSentInvGetState_Click(object sender, EventArgs e)
        {
            btnSentInvAgainSent.Enabled = false;
            showStateInvoice(EI.Direction.OUT.ToString(), nameof(EI.Direction.OUT));
        }






        private void tableGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                #region panelVisiblity
                if (direction == nameof(EI.Direction.IN))//gelen faturalara tıklandıysa
                {
                    panelIncomingInv.Visible = true;
                }
                else if (direction == nameof(EI.Direction.OUT))//giden faturalar
                {
                    panelSentInv.Visible = true;
                }
                else//taslak faturalar
                {
                    panelDraftInv.Visible = true;
                }
                #endregion


                string uuid = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.InvClmName.uuid)].Value.ToString();

                //PDF göruntule butonuna tıkladıysa
                if (e.ColumnIndex == tableGrid.Columns[nameof(EI.gridBtnClmName.previewPdf)].Index)
                {
                    //pdf ıcın getınvoicewithtype metodu cagırılcak
                    string filepath = Singl.invoiceControllerGet.getInvoiceType(uuid, nameof(EI.DocumentType.PDF), direction);
                    System.Diagnostics.Process.Start(filepath);
                }
                //xml göruntule butonuna tıkladıysa
                else if (e.ColumnIndex == tableGrid.Columns[nameof(EI.gridBtnClmName.previewXml)].Index)
                {
                    // xml contenti db de tutuldugu ıcın conent db den cekılecek
                    string content = Singl.invoiceDALGet.getInvoice(uuid, direction).content;
                    FrmPreviewInvoices previewInvoices = new FrmPreviewInvoices(content);
                    previewInvoices.Show();
                }
            }
        }



        private void btnDownInvIncoming_Click(object sender, EventArgs e)
        {
            try
            {
                Singl.invoiceControllerGet.downloadInvoice();
                MessageBox.Show(Lang.downInvSaveFolder); //Gelen faturalar 'D:\\temp\\GELEN\\' klasorune kaydedılmıstır

            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
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
                List<string> uuidArr = new List<string>();

                //ilk secılı rowun receıverını al, karsılastırma yapmak için
                DataGridViewRow gridRow = tableGrid.SelectedRows[0];
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    //aynı kısıye fatura gonderıyo kontrolu //recevierVkn ilk secılen row vkn ile esıt olmalı
                    if (gridRow.Cells[nameof(EI.InvClmName.receiverVkn)].Value != row.Cells[nameof(EI.InvClmName.receiverVkn)].Value)
                    {
                        MessageBox.Show("aynı kısıye olan faturaları bırlıkte gonderebılırsınız");
                        break;
                    }
                    uuidArr.Add(row.Cells[nameof(EI.InvClmName.uuid)].Value.ToString());
                }


                //send inv 
                Singl.invoiceControllerGet.sendInvoice(nameof(EI.Direction.OUT),uuidArr.ToArray(), gridRow.Cells[nameof(EI.InvClmName.senderVkn)].Value.ToString(), 
                    gridRow.Cells[nameof(EI.InvClmName.fromm)].Value.ToString(), gridRow.Cells[nameof(EI.InvClmName.receiverVkn)].Value.ToString(),
                    gridRow.Cells[nameof(EI.InvClmName.too)].Value.ToString());


            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
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
            FrmCreateInvoice frmCreateInvoice = new FrmCreateInvoice();
            frmCreateInvoice.Show();
        }

        private void btnFaultyInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                //db ye yuklenen gıden faturalardan hatalı olanları getır
                List<InvoicesTable> list = Singl.invoiceDALGet.getFaultyInvoices();
                if (list.Count == 0 || list == null)
                {
                    MessageBox.Show(Lang.notFaultyInv); //gosterılecek hatalı fatura yok
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
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
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

        private void btnSendDraft_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> uuidArr = new List<string>();

                //ilk secılı rowun receıverını al, karsılastırma yapmak için
                DataGridViewRow gridRow = tableGrid.SelectedRows[0];
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {   
                    //LOAD INV YAPMIS MI
                    //if (row.Cells[nameof(EI.InvClmName.ID)].Value.ToString().Length !=16)  //fatura ıd atanmıssa
                    //{
                    //    MessageBox.Show("load ınvoice yapamadan send invoice yapamazsınız asagıdakı faturaya " +
                    //        "önce load ınvoice yapınız" + row.Cells[nameof(EI.InvClmName.ID)].Value.ToString());
                    //    break;
                    //}

                    //aynı kısıye fatura gonderıyo kontrolu //recevierVkn ilk secılen row vkn ile esıt olmalı
                    if (gridRow.Cells[nameof(EI.InvClmName.receiverVkn)].Value != row.Cells[nameof(EI.InvClmName.receiverVkn)].Value)
                    {
                        MessageBox.Show("aynı kısıye olan faturaları bırlıkte gonderebılırsınız");
                        break;
                    }
                 
                    uuidArr.Add(row.Cells[nameof(EI.InvClmName.uuid)].Value.ToString());
                }

                //send inv 
                Singl.invoiceControllerGet.sendInvoice(nameof(EI.Direction.DRAFT),uuidArr.ToArray(), gridRow.Cells[nameof(EI.InvClmName.senderVkn)].Value.ToString(),
                     gridRow.Cells[nameof(EI.InvClmName.receiverVkn)].Value.ToString(), gridRow.Cells[nameof(EI.InvClmName.receiverVkn)].Value.ToString(),
                     gridRow.Cells[nameof(EI.InvClmName.receiverVkn)].Value.ToString());

                //db de taslak faturalardan sıl
                //gridRefresh
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnLoadPortal_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> uuidArr = new List<string>();

                //ilk secılı rowun receıverını al, karsılastırma yapmak için
                DataGridViewRow gridRow = tableGrid.SelectedRows[0];
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                  
                    //aynı kısıye fatura gonderıyo kontrolu //recevierVkn ilk secılen row vkn ile esıt olmalı
                    if (gridRow.Cells[nameof(EI.InvClmName.receiverVkn)].Value != row.Cells[nameof(EI.InvClmName.receiverVkn)].Value)
                    {
                        MessageBox.Show("aynı kısıye olan faturaları bırlıkte gonderebılırsınız");
                        break;
                    }

                    uuidArr.Add(row.Cells[nameof(EI.InvClmName.uuid)].Value.ToString());
                    Singl.invoiceControllerGet.

                }

            
            
                //gridRefresh
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}

