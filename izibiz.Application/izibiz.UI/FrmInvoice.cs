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
using izibiz.MODEL.DbModels;
using izibiz.CONTROLLER;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.Model;

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
            btnTakeInv.Text = Lang.getInvoice;
            btnIncomingInvGetState.Text = Lang.updateState;
            //panelDraftInvoices butonlar
            btnSendDraftInv.Text = Lang.send;
            btnLoadPortal.Text = Lang.loadPortal;
            rdZip.Text = Lang.withZip;
            rdUnzip.Text = Lang.withUnzip;
            //
            btnFilterList.Text = Lang.listFilter;
            #endregion
        }

        private void addViewButtonToDatagridView()
        {
            tableGrid.Columns.Clear();
            //pdf goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconPdf,
                Name = EI.GridBtnClmName.previewPdf.ToString(),
                HeaderText = Lang.preview
            });
            //xml goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconXml,
                Name = EI.GridBtnClmName.previewXml.ToString(),
                HeaderText = Lang.preview,
            });
        }



        private void dataGridChangeColoumnHeaderText()
        {

            tableGrid.Columns[EI.Invoice.status.ToString()].HeaderText = Lang.status;

            tableGrid.Columns[EI.Invoice.statusDesc.ToString()].HeaderText = Lang.statusDesc;

            tableGrid.Columns[EI.Invoice.gibStatusCode.ToString()].HeaderText = Lang.gibStatusCode;

            tableGrid.Columns[EI.Invoice.gibStatusDescription.ToString()].HeaderText = Lang.gibSatusDescription;

            tableGrid.Columns[EI.Invoice.ID.ToString()].HeaderText = Lang.id;

            tableGrid.Columns[EI.Invoice.uuid.ToString()].HeaderText = Lang.uuid;

            tableGrid.Columns[EI.Invoice.direction.ToString()].HeaderText = Lang.invType;

            tableGrid.Columns[EI.Invoice.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableGrid.Columns[EI.Invoice.profileid.ToString()].HeaderText = Lang.profileid;

            tableGrid.Columns[EI.Invoice.type.ToString()].HeaderText = Lang.type;

            tableGrid.Columns[EI.Invoice.suplier.ToString()].HeaderText = Lang.supplier;

            tableGrid.Columns[EI.Invoice.senderVkn.ToString()].HeaderText = Lang.sender;

            tableGrid.Columns[EI.Invoice.receiverVkn.ToString()].HeaderText = Lang.receiver;

            tableGrid.Columns[EI.Invoice.cDate.ToString()].HeaderText = Lang.cDate;

            tableGrid.Columns[EI.Invoice.envelopeIdentifier.ToString()].HeaderText = Lang.envelopeIdentifier;

            tableGrid.Columns[EI.Invoice.senderAlias.ToString()].HeaderText = Lang.from;

            tableGrid.Columns[EI.Invoice.receiverAlias.ToString()].HeaderText = Lang.to;


            tableGrid.Columns[EI.Invoice.draftFlagDesc.ToString()].HeaderText = Lang.isDraftFlag;

        }






        private void gridUpdateList(List<Invoices> gridListInv)
        {
            tableGrid.DataSource = null;

            if (gridListInv.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                foreach (Invoices inv in gridListInv)
                {
                    inv.statusDesc = invoiceStatusDescWrite(inv.status, inv.gibStatusCode);
                    if (inv.draftFlag != null)
                    {
                        if (inv.draftFlag.Equals(nameof(EI.ActiveOrPasive.Y)))
                        {
                            inv.draftFlagDesc = Lang.yes;
                        }
                        else if (inv.draftFlag.Equals(nameof(EI.ActiveOrPasive.N)))
                        {
                            inv.draftFlagDesc = Lang.no;
                        }
                    }
                }

                addViewButtonToDatagridView();
                tableGrid.DataSource = gridListInv;
                dataGridChangeColoumnHeaderText();

                //gridde taslak faturaları lısletemıyorsak
                if (!gridDirection.Equals(nameof(EI.InvDirection.DRAFT)))
                {
                    tableGrid.Columns[nameof(EI.Invoice.draftFlagDesc)].Visible = false;
                }
                tableGrid.Columns[nameof(EI.Invoice.draftFlag)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.direction)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.stateNote)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.status)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.gibStatusDescription)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.content)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.folderPath)].Visible = false;

            }
        }




        private void itemComingListInvoice_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.incomingInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            gridDirection = nameof(EI.InvDirection.IN);
            btnTakeInv.Visible = true;
            grpFilter.Visible = true;
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
            btnTakeInv.Visible = true;
            grpFilter.Visible = true;
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
            btnTakeInv.Visible = true;
            grpFilter.Visible = true;
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
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show(Lang.dbFault + " " + ex.InnerException.Message, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
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








        public string invoiceStatusDescWrite(string status, int gibStatusCode)
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
            string rowUuid;
            List<string> verifiredInvList = new List<string>();
            List<string> description = new List<string>();

            string desc = Interaction.InputBox(Lang.writeDescription, Lang.addDescription, "Reasen");

            foreach (DataGridViewRow row in tableGrid.SelectedRows)
            {
                rowUuid = row.Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                DateTime dt = DateTime.Parse(row.Cells[nameof(EI.Invoice.cDate)].Value.ToString());
                TimeSpan fark = DateTime.Today - dt;

                if (row.Cells[nameof(EI.Invoice.profileid)].Value == null || row.Cells[nameof(EI.Invoice.profileid)].Value.ToString() == EI.InvoiceProfileid.TEMELFATURA.ToString())//temel faturaysa
                {
                    if (tableGrid.SelectedRows.Count == 1)  //secılı fatura sayısı 1 ise
                    {
                        MessageBox.Show((row.Cells[nameof(EI.Invoice.ID)].Value.ToString()) + " " + Lang.warningBasicInvoice);
                    }
                }
                else if (fark.TotalDays > 8)//8 gün geçmis
                {
                    if (tableGrid.SelectedRows.Count == 1)  //secılı fatura sayısı 1 ise
                    {
                        MessageBox.Show((row.Cells[nameof(EI.Invoice.ID)].Value.ToString()) + " " + Lang.warning8Day);
                    }
                }
                else if (row.Cells[nameof(EI.Invoice.status)].Value == null || row.Cells[nameof(EI.Invoice.status)].Value.ToString() != EI.SubStatusType.WAIT_APPLICATION_RESPONSE.ToString())//olan varsa
                {
                    if (tableGrid.SelectedRows.Count == 1)  //secılı fatura sayısı 1 ise
                    {
                        MessageBox.Show((row.Cells[nameof(EI.Invoice.ID)].Value.ToString()) + " " + Lang.warningHasAnswer);
                    }
                }
                else//fatura cevap gondermeye uygunsa,fatura uuid oldugu kabul lıstesi olustur
                {
                    //uygun olan ınv u controllerdakı dakı Inv listesine aktarıyoruz
                    Singl.invoiceControllerGet.createInvListWithUuid(row.Cells[nameof(EI.Invoice.uuid)].Value.ToString());
                    Singl.invoiceDalGet.getInvoice(rowUuid, nameof(EI.InvDirection.IN)).stateNote = nameof(EI.StateNote.SENDRESPONSE);//db ye cevap gonderıldı dıye not edılır
                    description.Add(desc);
                    verifiredInvList.Add(rowUuid);
                }
            }

            if (verifiredInvList.Count == 0) //hicbiri krıterlere uygun degılse
            {
                if (tableGrid.SelectedRows.Count != 1)
                {
                    MessageBox.Show(Lang.warningHasAnswer + Lang.warningBasicInvoice + Lang.warningHasAnswer);
                }
            }
            else//valid fatura varsa 
            {
                if (Singl.invoiceControllerGet.sendInvoiceResponse(state, description) == 0)  //yanıt gonderme basarılıysa
                {
                    Singl.invoiceDalGet.dbSaveChanges();  //db ye yazılan not kaydedılir
                    MessageBox.Show(string.Join(Environment.NewLine, verifiredInvList) + Environment.NewLine + "nolu faturalara yanıt gonderıldı");
                }
                else//yanıt gonderme ıslemı basarısızsa
                {
                    MessageBox.Show("yanıt gonderme ıslemı basarısız tektar deneyın");
                }
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
            DateTime dt = DateTime.Parse(row.Cells[nameof(EI.Invoice.cDate)].Value.ToString());
            TimeSpan difference = DateTime.Today - dt;

            if (difference.Days > 8   //fatura yuklendıkten sonra 8 gun gecmısse
                 || row.Cells[nameof(EI.Invoice.gibStatusCode)].Value.Equals(1300) || row.Cells[nameof(EI.Invoice.gibStatusCode)].Value.Equals(1215)
                 || row.Cells[nameof(EI.Invoice.gibStatusCode)].Value.Equals(1230)
                 || Convert.ToInt32(row.Cells[nameof(EI.Invoice.gibStatusCode)].Value) < 1100
                 || Convert.ToInt32(row.Cells[nameof(EI.Invoice.gibStatusCode)].Value) > 1200)

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
                uuid = tableGrid.Rows[i].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
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
                uuid = tableGrid.Rows[i].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
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

                string uuid = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                //PDF göruntule butonuna tıkladıysa
                if (e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewPdf)].Index)
                {
                    ////pdf ıcın getınvoicewithtype metodu cagırılcak
                    string filepath = Singl.invoiceControllerGet.getInvoiceType(uuid, nameof(EI.DocumentType.PDF), gridDirection);
                    if (filepath != null)
                    {
                        System.Diagnostics.Process.Start(filepath);
                    }
                }
                //XML göruntule butonuna tıkladıysa
                else if (e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewXml)].Index)
                {
                    string xmlPath = Singl.invoiceControllerGet.checkInvFolderOnDisk(uuid, gridDirection);
                    FrmView previewInvoices = new FrmView(xmlPath, nameof(EI.DocumentType.XML));
                    previewInvoices.ShowDialog();
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
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private IdXmlModel createInvListWithNewId(string seriName, bool isSendWithZip)
        {
            //verılmek ıstenen ıd on ekıye aıt yenı ıd serıal arr olusturulur
            string[] newIdArr = InvoiceIdSetSerilaze.createNewInvId(seriName, tableGrid.SelectedRows.Count);
            string[] xmlWithNewIdArr = new string[tableGrid.SelectedRows.Count];

            int cnt = 0;
            foreach (DataGridViewRow row in tableGrid.SelectedRows)
            {
                string uuidRow = row.Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                //YENI ID ILE INVLİST OLUSTURULMASI
                //diskten kaydettıgım contentı cekıyorum
                //bu contentdekı ıd yı  xmlChangeIdValue fonk ıle ıd degıstırıyorum
                //ıd sı degıstırılmıs contentı ,ıstege gore zıpleyıp, ınvoiceliste aktarıyorum

                string xmlPath = Singl.invoiceControllerGet.checkInvFolderOnDisk(uuidRow, gridDirection);
                string rowXmlWithNewId = XmlControl.xmlChangeIdValue(xmlPath, newIdArr[cnt]);
                Singl.invoiceControllerGet.createInvListWithContent(isSendWithZip, rowXmlWithNewId);

                xmlWithNewIdArr[cnt] = rowXmlWithNewId;

                cnt++;
            }
            IdXmlModel idXmlModel = new IdXmlModel();
            idXmlModel.idArr = newIdArr;
            idXmlModel.xmlContentArr = xmlWithNewIdArr;

            return idXmlModel;
        }


        private void btnSendDraftInv_Click(object sender, EventArgs e)
        {
            try
            {
                bool valid = true;
                bool isSendWithZip = true;
                int selectedInvCount = tableGrid.SelectedRows.Count;



                //zipli gonderme kontrolu
                if (rdUnzip.Checked) //ikisini de ısaretlememisse zipli gonderılır
                {
                    isSendWithZip = false;
                }

                //aynı kısıye gıdecek faturalar secılı mı kontrolu
                string receiverVkn = tableGrid.SelectedRows[0].Cells[nameof(EI.Invoice.receiverVkn)].Value.ToString();
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    if (row.Cells[nameof(EI.Invoice.receiverVkn)].Value != null && row.Cells[nameof(EI.Invoice.receiverVkn)].Value.ToString() != receiverVkn) //vkn farklı ıse
                    {

                        MessageBox.Show("sadece aynı kısıye olan faturaları bırlıkte gonderebılırsınız");
                        valid = false; break;
                    }
                    //Status note nullsa veya load degılse
                    //else if (row.Cells[nameof(EI.Invoice.stateNote)].Value == null || row.Cells[nameof(EI.Invoice.stateNote)].Value.ToString() != nameof(EI.StatusType.LOAD))
                    //{
                    //    MessageBox.Show("faturayı once portala yukleyınız");
                    //    valid = false; break;
                    //}
                }

                if (valid) //uymayan fatura durumu yoksa
                {
                    //db den getırılen serı Namelerı comboboxda sectır
                    FrmDialogSelectItem frmDialogSelectSeriName = new FrmDialogSelectItem(true, "");
                    if (frmDialogSelectSeriName.ShowDialog() == DialogResult.OK)
                    {

                        FrmDialogSelectItem frmDialogIdSelectAlias = new FrmDialogSelectItem(false, receiverVkn);
                        ////gb  sectır
                        if (frmDialogIdSelectAlias.ShowDialog() == DialogResult.OK)
                        {
                            IdXmlModel idXmlModel = createInvListWithNewId(frmDialogSelectSeriName.selectedValue, isSendWithZip);

                            //send inv 
                            if (Singl.invoiceControllerGet.sendInvoice(frmDialogIdSelectAlias.selectedValue, isSendWithZip) == 0)
                            {
                                for (int rowCnt = 0; rowCnt < selectedInvCount; rowCnt++)
                                {
                                    string uuidRow = tableGrid.SelectedRows[rowCnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                                    Invoices invoice = Singl.invoiceDalGet.getInvoice(uuidRow, nameof(EI.InvDirection.DRAFT));
                                    invoice.ID = idXmlModel.idArr[rowCnt];
                                    invoice.direction = nameof(EI.InvDirection.OUT);
                                    invoice.stateNote = nameof(EI.StatusType.SEND);
                                    invoice.folderPath = FolderControl.createXmlPath(uuidRow, nameof(EI.InvDirection.OUT)); // yenı path db ye yazılır
                                    invoice.content = idXmlModel.xmlContentArr[rowCnt];

                                    //eskı folderPathdekı dosyayı konumdan sıler
                                    FolderControl.deleteFileFromPath(invoice.folderPath);
                                    //yenı id eklenmıs xmli diske kaydet
                                    FolderControl.writeFileOnDiskWithString(invoice.content, invoice.folderPath);
                                }

                                //db ye, en son olusturulan yenı ınv id serisinin son itemi ıle serı no ve yıl guncelle
                                Singl.invIdSerilazeDalGet.updateLastAddedInvIdSeri(idXmlModel.idArr[selectedInvCount - 1]);

                                //db guncellemeleri kaydet
                                Singl.invoiceDalGet.dbSaveChanges();

                                //datagrıd listesini guncelle
                                gridUpdateList(Singl.invoiceDalGet.getInvoiceList(gridDirection));

                                MessageBox.Show("basarılı");
                            }
                        }
                        frmDialogIdSelectAlias.Dispose();
                    }
                    frmDialogSelectSeriName.Dispose();
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
                if (rdUnzip.Checked) //ikisini de isaretmemısse zıplı gonderılır
                {
                    isSendWithZip = false;
                }

                //db den getırılen serı Namelerı comboboxda sectır
                FrmDialogSelectItem frmDialogIdSeriName = new FrmDialogSelectItem(true, "");
                if (frmDialogIdSeriName.ShowDialog() == DialogResult.OK)
                {
                    IdXmlModel idXmlModel = createInvListWithNewId(frmDialogIdSeriName.selectedValue, isSendWithZip); //load ınvda  direction degıstırmıyoruz o yuzden false

                    if (Singl.invoiceControllerGet.loadInvoice(isSendWithZip) == 0) //     int returnCode = 0 / basarılıysa
                    {

                        for (int rowCnt = 0; rowCnt < tableGrid.SelectedRows.Count; rowCnt++)
                        {
                            string uuidRow = tableGrid.SelectedRows[rowCnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                            //db verileri guncelle
                            Invoices invoice = Singl.invoiceDalGet.getInvoice(uuidRow, nameof(EI.InvDirection.DRAFT));
                            invoice.ID = idXmlModel.idArr[rowCnt];
                            invoice.cDate = DateTime.Now;
                            invoice.status = nameof(EI.StatusType.LOAD) + " - " + nameof(EI.SubStatusType.SUCCEED);
                            invoice.gibStatusCode = -1;
                            invoice.stateNote = nameof(EI.StatusType.LOAD);
                            invoice.content = idXmlModel.xmlContentArr[rowCnt];
                            //yenı id eklenmıs xmli diske kaydet
                            FolderControl.writeFileOnDiskWithString(invoice.content, invoice.folderPath);
                        }

                        //eger islem basarılı ise db guncellemeleri kaydet
                        Singl.invoiceDalGet.dbSaveChanges();

                        // db den cekılen taslak faturaları datagrıdde listele
                        gridUpdateList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.DRAFT)));

                        MessageBox.Show(Lang.successLoad);//"yukleme basarılı"

                    }

                    frmDialogIdSeriName.Dispose();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnTakeInv_Click(object sender, EventArgs e)
        {
            try
            {
                //servisten yenı faturaları cek db ye kaydet ve datagridde göster
                gridUpdateList(Singl.invoiceControllerGet.getInvoiceListOnService(gridDirection));
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



        private void btnFilterList_Click(object sender, EventArgs e)
        {
            try
            {
                //servisten tarih aralığına uygun faturaları getır
                gridUpdateList(Singl.invoiceDalGet.getInvoiceListOnFilter(gridDirection, timeStartFilter.Value.Date, timeFinishFilter.Value.Date));
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

        private void btnIncomingInvGetState_Click_1(object sender, EventArgs e)
        {
            try
            {
                btnSentInvAgainSent.Enabled = false;
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
    }

}

