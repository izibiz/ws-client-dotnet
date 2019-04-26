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
using Microsoft.VisualBasic;
using izibiz.COMMON;
using izibiz.COMMON.Language;
using izibiz.MODEL.Models;
using izibiz.CONTROLLER;




namespace izibiz.UI
{
    public partial class FrmInvoice : Form
    {

        private string gridDirection;

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
            btnTakeInvIn.Text = Lang.getInvoice;
            btnIncomingInvGetState.Text = Lang.updateState;
            //panelDraftInvoices butonlar
            btnSendDraftInv.Text = Lang.send;
            btnLoadPortal.Text = Lang.loadPortal;
            #endregion
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



        private void dataGridChangeColoumnHeaderText()
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

            tableGrid.Columns[EI.InvClmName.draftFlag.ToString()].HeaderText = Lang.isDraftFlag;

        }



        private void gridUpdateList(List<Invoices> listInv)
        {
            tableGrid.DataSource = null;

            if (listInv.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                foreach (var inv in listInv)
                {
                    inv.statusDesc = invoiceIncomingStatusWrite(inv.status, inv.gibStatusCode);
                }

                addViewButtonToDatagridView();
                tableGrid.DataSource = listInv;
                dataGridChangeColoumnHeaderText();
                
                //gridde taslak faturaları lısletemıyorsak
                if (!gridDirection.Equals(nameof(EI.InvDirection.DRAFT)))
                {
                    tableGrid.Columns[nameof(EI.InvClmName.draftFlag)].Visible = false;
                }

                tableGrid.Columns[nameof(EI.InvClmName.invType)].Visible = false;
                tableGrid.Columns[nameof(EI.InvClmName.state)].Visible = false;
                tableGrid.Columns[nameof(EI.InvClmName.status)].Visible = false;
                tableGrid.Columns[nameof(EI.InvClmName.gibStatusDescription)].Visible = false;
                tableGrid.Columns[nameof(EI.InvClmName.content)].Visible = false;
                tableGrid.Columns[nameof(EI.InvClmName.folderPath)].Visible = false;
            }
        }




        private void itemComingListInvoice_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.incomingInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            gridDirection = nameof(EI.InvDirection.IN);
            try
            {
                //web servıceden okunmamıs faturaları db ye yazdır  db den cekılen lısteyı datagride aktar
                //  gridUpdateList(Singl.invoiceControllerGet.getIncomingInvoice());
                gridUpdateList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.IN)));
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
                MessageBox.Show(Lang.dbFault + " " + ex.InnerException.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(Lang.dataException + ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }




        private void itemSentInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.sentInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            btnSentInvAgainSent.Enabled = false;
            gridDirection = nameof(EI.InvDirection.OUT);
            try
            {
                //db den cekılen lısteyı datagride aktar
                gridUpdateList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.OUT)));
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
                MessageBox.Show(Lang.dbFault + ex.InnerException.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(Lang.dataException + ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
        }


        private void itemDraftInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.draftInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            gridDirection = nameof(EI.InvDirection.DRAFT);
            try
            {
                //web servıceden okunmamıs faturaları db ye yazdır db den cekılen lısteyı datagride aktar
                gridUpdateList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.DRAFT)));
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            //{
            //    MessageBox.Show(Lang.dbFault + " " + ex.InnerException.Message, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(Lang.dataException + ex.InnerException.Message.ToString());
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.InnerException.Message.ToString());
            //}
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
            bool verified = false;
            List<string> description = new List<string>();

            string desc = Interaction.InputBox(Lang.writeDescription, Lang.addDescription, "Reasen");

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
                    //bir kez daha secılı ınvlar kadar donmemesı ıcın foreachın ıcınde ınvArrlerı eklıyoruz
                    Singl.invoiceControllerGet.addInvToStateList(row.Cells[nameof(EI.InvClmName.uuid)].Value.ToString());

                    description.Add(desc);
                    verified = true;
                }
            }
            if (verified)
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
            DateTime dt = DateTime.Parse(row.Cells[nameof(EI.InvClmName.cDate)].Value.ToString());
            TimeSpan difference = DateTime.Today - dt;

            if (difference.Days > 8   //fatura yuklendıkten sonra 8 gun gecmısse
                 || row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value.Equals(1300) || row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value.Equals(1215)
                 || row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value.Equals(1230)
                 || Convert.ToInt32(row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value) < 1100
                 || Convert.ToInt32(row.Cells[nameof(EI.InvClmName.gibStatusCode)].Value) > 1200)
            {
                return false;
            }
            return true;
        }



        private string showStateInvoice(string direction)
        {

            List<string> unvalidList = new List<string>();
            List<string> validList = new List<string>();
            string uuid;
            string message;

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
                    //servisten cekılen ınv responsu modelde guncelle 
                    Singl.invoiceDalGet.updateInvState(uuid, direction, Singl.invoiceControllerGet.getInvoiceState(uuid));
                }
            }

            if (validList.Count == 0) //hicbiri krıterlere uygun degılse
            {
                if (tableGrid.SelectedRows.Count == 1)//tekli secim
                {
                    message = Lang.warningStateShow;
                    //  MessageBox.Show(Lang.warningStateShow);
                }
                else//coklu secım
                {
                    message = string.Join(Environment.NewLine, unvalidList) + Environment.NewLine + Lang.noInvNotUpdated; //nolu faturalar guncellenemedi
                    // MessageBox.Show(string.Join(Environment.NewLine, unvalidList) + Environment.NewLine + Lang.noInvNotUpdated); //nolu faturalar guncellenemedi
                }
            }
            else//valid fatura varsa 
            {
                //db de yapılan degısıklıklerı kaydet
                Singl.invoiceDalGet.dbSaveChanges();
              
                //ınv listesini  db den datagride getir
                gridUpdateList(Singl.invoiceDalGet.getInvoiceList(direction));

                message = string.Join(Environment.NewLine, validList) + Environment.NewLine + Lang.noInvUpdated;//nolu faturalar guncellendı
                //  MessageBox.Show(string.Join(Environment.NewLine, validList) + Environment.NewLine + Lang.noInvUpdated); //nolu faturalar guncellendı
            }
            return message;



        }


        private void btnIncomingInvGetState_Click(object sender, EventArgs e)
        {
            try
            {
                string message = showStateInvoice(EI.InvDirection.IN.ToString());
                MessageBox.Show(message);


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


        private void btnSentInvGetState_Click(object sender, EventArgs e)
        {
            try
            {
                btnSentInvAgainSent.Enabled = false;
                string message = showStateInvoice(EI.InvDirection.OUT.ToString());
                MessageBox.Show(message);
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






        private void tableGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                #region panelVisiblity
                if (gridDirection == nameof(EI.InvDirection.IN))//gelen faturalara tıklandıysa
                {
                    panelIncomingInv.Visible = true;
                }
                else if (gridDirection == nameof(EI.InvDirection.OUT))//giden faturalar
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
                    string filepath = Singl.invoiceControllerGet.getInvoiceType(uuid, nameof(EI.DocumentType.PDF), gridDirection);
                    System.Diagnostics.Process.Start(filepath);
                }
                //xml göruntule butonuna tıkladıysa
                else if (e.ColumnIndex == tableGrid.Columns[nameof(EI.gridBtnClmName.previewXml)].Index)
                {
                    // xml contenti db de tutuldugu ıcın conent db den cekılecek
                    string content = Singl.invoiceDalGet.getInvoice(uuid, gridDirection).content;
                    FrmPreviewInvoices previewInvoices = new FrmPreviewInvoices(content);
                    previewInvoices.Show();
                }
            }
        }



        private void btnTakeInvIn_Click(object sender, EventArgs e)
        {
            try
            {
                //servisten yenı faturaları cek db ye kaydet ve datagridde göster
                gridUpdateList(Singl.invoiceControllerGet.getInvoiceListOnService(nameof(EI.InvDirection.IN)));    
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
                //btn gonder cagır
                btnSendDraftInv_Click(sender, e);
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
            lblTitle.Text = Lang.faulty;
            btnSentInvAgainSent.Enabled = true;
            try
            {
                //db den cekılen gıden faturalardan hatalı olanları   datagride aktar
                gridUpdateList(Singl.invoiceDalGet.getFaultyInvoices());
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
                MessageBox.Show(Lang.dbFault + " " + ex.InnerException.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(Lang.dataException + ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
        }



        private string updateInvWithNewId(string seriName,bool isSendWithZip ,bool isSendInv)
        {
            //verılmek ıstenen ıd on ekıye aıt yenı ıd serıal arr olusturulur
            string[] newIdArr = InvoiceIdSetSerilaze.createNewInvId(seriName, tableGrid.SelectedRows.Count);
            int counter = 0;

            foreach (DataGridViewRow row in tableGrid.SelectedRows)
            {
                string uuidRow = row.Cells[nameof(EI.InvClmName.uuid)].Value.ToString();

                //diskten kaydettıgım contentı cekıyorum
                //bu contentdekı ıd yı  xmlChangeIdValue fonk ıle ıd degıstırıyorum
                //ıd sı degıstırılmıs contentı ,ıstege gore zıpleyıp, ınvoiceliste aktarıyorum
                Singl.invoiceControllerGet.createInvContentCompress(isSendWithZip,
                    XmlSet.xmlChangeIdValue(
                        Singl.invoiceControllerGet.getContentOnDisk(uuidRow, nameof(EI.InvDirection.DRAFT)), newIdArr[counter]));


                //DB 'DE SECİLİ İNVOİCE BILGILERINI GUNCELLE
                Invoices invoice = Singl.invoiceDalGet.getInvoice(uuidRow, nameof(EI.InvDirection.DRAFT));
                invoice.ID = newIdArr[counter];
                if (isSendInv) //send ınv ıse ınv direction out yapılır
                {
                    invoice.invType = nameof(EI.InvDirection.OUT);
                    invoice.state = nameof(EI.StateNote.SEND);
                }
                else //send ınv degılse (load) c date guncelle , durumu load succed yap ve gib code -1 yap
                {                  
                    invoice.cDate= DateTime.Now;
                    invoice.status = nameof(EI.StatusType.LOAD) + " - " + nameof(EI.SubStatusType.SUCCEED);
                    invoice.gibStatusCode= -1;
                    invoice.state = nameof(EI.StateNote.LOAD);
                }

                counter++;
            }

            //son eklenen ınv ıd dondurur
            return newIdArr[counter - 1];
        }


        private void btnSendDraftInv_Click(object sender, EventArgs e)
        {
            try
            {
                bool valid = true;
                string receiverVkn = tableGrid.SelectedRows[0].Cells[nameof(EI.InvClmName.receiverVkn)].Value.ToString();
                List<string> listİtem = new List<string>();
                listİtem.Add("j");

                bool isSendWithZip = true;
                //zipli gonderme kontrolu
                if (rdWithUnzip.Checked) //ikisini de ısaretlememisse zipli gonderılır
                {
                    isSendWithZip = false;
                }


                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    //secılı rowların receiver vkn aynı ıse
                    if (row.Cells[nameof(EI.InvClmName.receiverVkn)].Value != null && row.Cells[nameof(EI.InvClmName.receiverVkn)].Value.ToString() == receiverVkn)
                    {
                        if (row.Cells[nameof(EI.InvClmName.status)].Value == null) //load ınv yapmamıssa, status atanmamıssa
                        {
                            MessageBox.Show("once load ınv yapınız");
                            valid = false; break;
                        }
                    }
                    else //vkn farklı ıse
                    {
                        MessageBox.Show("sadece aynı kısıye olan faturaları bırlıkte gonderebılırsınız");
                        valid = false; break;
                    }
                }

                if (valid) //uymayan fatura durumu yoksa
                {
                    //db den getırılen serı Namelerı comboboxda sectır
                    FrmDialogSelectCombo frmDialogSelectSeriName = new FrmDialogSelectCombo(Singl.invIdSerilazeDalGet.getSeriNames(), true);
                    if (frmDialogSelectSeriName.ShowDialog() == DialogResult.OK)
                    {

                        FrmDialogSelectCombo frmDialogIdSelectAlias = new FrmDialogSelectCombo(listİtem, false);
                        //gb  sectır
                        if (frmDialogIdSelectAlias.ShowDialog() == DialogResult.OK)
                        {
                            string lastIdSerial = updateInvWithNewId(frmDialogSelectSeriName.selectedValue,isSendWithZip,true); //true degerı gonderıyoruz işlem bıttıkten sonra secılı ınvların direction out olacak

                            //send inv 
                            if (Singl.invoiceControllerGet.sendInvoice(frmDialogIdSelectAlias.selectedValue,isSendWithZip) == 0)
                            {
                                //db ye, en son olusturulan yenı ınv id serisinin son itemi ıle serı no ve yıl guncelle
                                Singl.invIdSerilazeDalGet.updateLastAddedInvIdSeri(lastIdSerial);

                                //db guncellemeleri kaydet
                                Singl.invoiceDalGet.dbSaveChanges();

                                //datagrıd listesini guncelle
                                gridUpdateList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.DRAFT)));

                                MessageBox.Show("basarılı");
                            }
                        }
                    }
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show("İşlem Basarısız " + ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                bool isSendWithZip = true;
                //zipli gonderme kontrolu
                if (rdWithUnzip.Checked) //ikisini de isaretmemısse zıplı gonderılır
                {
                    isSendWithZip = false;
                }

                //db den getırılen serı Namelerı comboboxda sectır
                FrmDialogSelectCombo frmDialogIdSeriName = new FrmDialogSelectCombo(Singl.invIdSerilazeDalGet.getSeriNames(), true);
                if (frmDialogIdSeriName.ShowDialog() == DialogResult.OK)
                {
                    updateInvWithNewId(frmDialogIdSeriName.selectedValue, false, isSendWithZip); //load ınvda  direction degıstırmıyoruz o yuzden false

                    if (Singl.invoiceControllerGet.loadInvoice(isSendWithZip) == 0) //     int returnCode = 0 / basarılıysa
                    {                      
                        //eger islem basarılı ise db guncellemeleri kaydet
                        Singl.invoiceDalGet.dbSaveChanges();

                        // db den cekılen taslak faturaları datagrıdde listele
                        gridUpdateList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.DRAFT)));

                        MessageBox.Show(Lang.successLoad);//"yukleme basarılı"
                    }
                }

                frmDialogIdSeriName.Dispose();
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
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnTakeInvDraft_Click(object sender, EventArgs e)
        {
            //servisten yenı faturaları cek db ye kaydet ve datagridde göster
            gridUpdateList(Singl.invoiceControllerGet.getInvoiceListOnService(nameof(EI.InvDirection.DRAFT)));
        }

        private void btnTakeInvOut_Click(object sender, EventArgs e)
        {
            //servisten yenı faturaları cek db ye kaydet ve datagridde göster
            gridUpdateList(Singl.invoiceControllerGet.getInvoiceListOnService(nameof(EI.InvDirection.OUT)));
        }
    }

}

