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
using izibiz.MODEL.Entities;
using izibiz.CONTROLLER;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.Model;
using izibiz.MODEL.Data;

namespace izibiz.UI
{
    public partial class FrmInvoice : Form
    {

        private string gridDirection;

        public FrmInvoice()
        {
            InitializeComponent();
            try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
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
            //eleman text yazdýr
            this.Text = Lang.formInvoice;
            lblTitle.Text = Lang.welcome;
            btnHomePage.Text = Lang.homePage;
            itemListGibUserList.Text = Lang.getGibUserList;
            btnFilterList.Text = Lang.listFilter;
            //panelSendInvoices butonlar
            itemSentInvoice.Text = Lang.sentInvoice;
            btnSentInvGetState.Text = Lang.updateState;
            btnSentInvAgainSent.Text = Lang.againSent;
            btnFaultyInvoices.Text = Lang.faulty;
            btnGetSendSignedInvoice.Text = Lang.getSignedXml;
            btnGetRejectedSendInv.Text = Lang.getRejected;
            //panelIncomingInvoices butonlar
            itemIncomingInvoice.Text = Lang.incomingInvoice;
            btnAccept.Text = Lang.accept;
            btnReject.Text = Lang.reject;
            btnTakeInv.Text = Lang.takeInvoice;
            btnIncomingInvGetState.Text = Lang.updateState;
            btnGetRejectedIncomingInv.Text = Lang.getRejected;
            btnWaitResponseGetInv.Text = Lang.waitResponse;
            //panelDraftInvoices butonlar
            btnSendDraftInv.Text = Lang.send;
            btnLoadPortal.Text = Lang.loadPortal;
            rdZip.Text = Lang.withZip;
            rdUnzip.Text = Lang.withUnzip;
            itemDraftInvoice.Text = Lang.draftInvoice;
            //yený fatura
            itemNewInvoice.Text = Lang.newInvoice;
            //gib users
            itemListGibUserList.Text = Lang.gibUserList;
            itemTakeGibUsers.Text = Lang.getGibUserList;
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
                Image = Properties.Resources.iconHtml,
                Name = EI.GridBtnClmName.previewHtml.ToString(),
                HeaderText = Lang.preview,
            });
        }



        private void dataGridChangeColumnHeaderText()
        {

            tableGrid.Columns[EI.Invoice.status.ToString()].HeaderText = Lang.status;

            tableGrid.Columns[EI.Invoice.statusDesc.ToString()].HeaderText = Lang.statusDesc;

            tableGrid.Columns[EI.Invoice.gibStatusCode.ToString()].HeaderText = Lang.gibStatusCode;

            tableGrid.Columns[EI.Invoice.gibStatusDescription.ToString()].HeaderText = Lang.gibSatusDescription;

            tableGrid.Columns[EI.Invoice.ID.ToString()].HeaderText = Lang.id;

            tableGrid.Columns[EI.Invoice.uuid.ToString()].HeaderText = Lang.uuid;

            tableGrid.Columns[EI.Invoice.direction.ToString()].HeaderText = Lang.invType;

            tableGrid.Columns[EI.Invoice.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableGrid.Columns[EI.Invoice.profileId.ToString()].HeaderText = Lang.profileid;

            tableGrid.Columns[EI.Invoice.invoiceType.ToString()].HeaderText = Lang.type;

            tableGrid.Columns[EI.Invoice.suplier.ToString()].HeaderText = Lang.supplier;

            tableGrid.Columns[EI.Invoice.senderVkn.ToString()].HeaderText = Lang.senderVkn;

            tableGrid.Columns[EI.Invoice.receiverVkn.ToString()].HeaderText = Lang.receiverVkn;

            tableGrid.Columns[EI.Invoice.cDate.ToString()].HeaderText = Lang.cDate;

            tableGrid.Columns[EI.Invoice.envelopeIdentifier.ToString()].HeaderText = Lang.envelopeIdentifier;

            tableGrid.Columns[EI.Invoice.senderAlias.ToString()].HeaderText = Lang.fromAlias;

            tableGrid.Columns[EI.Invoice.receiverAlias.ToString()].HeaderText = Lang.toAlias;

            tableGrid.Columns[EI.Invoice.draftFlagDesc.ToString()].HeaderText = Lang.fromPortal;

        }






        private void gridUpdateInvoiceList(List<Invoices> gridListInv)
        {
            tableGrid.DataSource = null;
            tableGrid.Columns.Clear();

            if (gridListInv.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
                lblInformation.Visible = false;
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
                dataGridChangeColumnHeaderText();

                //gridde taslak faturalarý lýsletemýyorsak
                if (!gridDirection.Equals(nameof(EI.Direction.DRAFT)))
                {
                    tableGrid.Columns[nameof(EI.Invoice.draftFlagDesc)].Visible = false;
                }
                tableGrid.Columns[nameof(EI.Invoice.draftFlag)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.direction)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.stateNote)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.status)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.gibStatusDescription)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.folderPath)].Visible = false;

                lblInformation.Text = Lang.clickRowInvoice;
                lblInformation.Visible = true;
            }
        }



        private void gridUpdateGibUserList(List<GibUsers> gridListGibUsers)
        {
            tableGrid.DataSource = null;
            tableGrid.Columns.Clear();

            if (gridListGibUsers.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                tableGrid.DataSource = gridListGibUsers;
                gridChangeGibUsersColumnHeadersText();
            }
        }



        private void gridChangeGibUsersColumnHeadersText()
        {

            tableGrid.Columns[EI.GibUser.aliasPk.ToString()].HeaderText = Lang.toAlias;

            tableGrid.Columns[EI.GibUser.identifier.ToString()].HeaderText = Lang.id;

            tableGrid.Columns[EI.GibUser.title.ToString()].HeaderText = Lang.title;
        }



        private void itemSentInvoice_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.sentInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            btnSentInvAgainSent.Enabled = false;
            gridDirection = nameof(EI.Direction.OUT);
            btnTakeInv.Visible = true;
            grpFilter.Visible = true;
            try
            {
                //db den cekýlen lýsteyý datagride aktar
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.Direction.OUT)));
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
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
        }



        private void itemIncomingInvoice_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.incomingInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            gridDirection = nameof(EI.Direction.IN);
            btnTakeInv.Visible = true;
            grpFilter.Visible = true;
            try
            {
                //  db den cekýlen lýsteyý datagride aktar
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.Direction.IN)));
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
                MessageBox.Show(ex.InnerException.Message.ToString());
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
            gridDirection = nameof(EI.Direction.OUT);
            btnTakeInv.Visible = true;
            grpFilter.Visible = true;
            try
            {
                //db den cekýlen lýsteyý datagride aktar
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.Direction.OUT)));
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
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
        }





        private void itemDraftInvoice_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.draftInvoice;
            panelSentInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelDraftInv.Visible = false;
            gridDirection = nameof(EI.Direction.DRAFT);
            btnTakeInv.Visible = true;
            grpFilter.Visible = true;
            try
            {
                // db den cekýlen lýsteyý datagride aktar
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.Direction.DRAFT)));
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
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
        }



        private void itemNewInvoice_Click(object sender, EventArgs e)
        {
            FrmCreateInvoice frmCreateInvoice = new FrmCreateInvoice(nameof(EI.Invoice.Invoices));
            frmCreateInvoice.Show();
        }



        public string invoiceStatusDescWrite(string status, int gibStatusCode)
        {
            //   string status = invoice.status;
            //  int envelopeOpcode = invoice.gibStatusCode;

            if (gibStatusCode == 1210)
            {
                return "GÝB'e gönderildi";
            }
            // RECEIVE
            if (status.Contains(EI.StatusType.RECEIVE.ToString()))
            {
                return "Alýndý";
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
                return "Ýþleniyor";
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
                return "Ýþleniyor";
            }
            if (status.Contains(EI.StatusType.SIGN.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "Ýmzalandý";
            }
            if (status.Contains(EI.StatusType.SIGN.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "Ýþleniyor";
            }

            // SEND
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.PROCESSING.ToString()))
            {
                return "Ýþleniyor";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "Ulaþtýrýldý";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "Ulaþtýrýlamadý";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_GIB_RESPONSE.ToString()))
            {
                return "GÝB'e gönderildi";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_SYSTEM_RESPONSE.ToString()))
            {
                return "Ulaþtýrýldý";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_APPLICATION_RESPONSE.ToString()))
            {
                return "Ulaþtýrýldý";
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
            return "Durum Atanmasý Bekleniyor";
        }






        private void invoiceResponseAcceptOrReject(string state)
        {
            string rowUuid;
            List<string> verifiredInvList = new List<string>();
            List<string> description = new List<string>();


            foreach (DataGridViewRow row in tableGrid.SelectedRows)
            {
                rowUuid = row.Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                DateTime dt = DateTime.Parse(row.Cells[nameof(EI.Invoice.cDate)].Value.ToString());
                TimeSpan fark = DateTime.Today - dt;

                if (row.Cells[nameof(EI.Invoice.profileId)].Value == null || row.Cells[nameof(EI.Invoice.profileId)].Value.ToString() == EI.Profileid.TEMELFATURA.ToString())//temel faturaysa
                {
                    if (tableGrid.SelectedRows.Count == 1)  //secýlý fatura sayýsý 1 ise
                    {
                        MessageBox.Show((row.Cells[nameof(EI.Invoice.ID)].Value.ToString()) + " " + Lang.warningBasicInvoice);
                    }
                }
                else if (fark.TotalDays > 8)//8 gün geçmis
                {
                    if (tableGrid.SelectedRows.Count == 1)  //secýlý fatura sayýsý 1 ise
                    {
                        MessageBox.Show((row.Cells[nameof(EI.Invoice.ID)].Value.ToString()) + " " + Lang.warning8Day);
                    }
                }
                else if (row.Cells[nameof(EI.Invoice.status)].Value == null
                    || !row.Cells[nameof(EI.Invoice.status)].Value.ToString().Contains(EI.SubStatusType.WAIT_APPLICATION_RESPONSE.ToString())
                    || (row.Cells[nameof(EI.Invoice.stateNote)].Value != null && row.Cells[nameof(EI.Invoice.stateNote)].Value.Equals(nameof(EI.StateNote.SENDRESPONSE)))
                    )    //olan varsa
                {
                    if (tableGrid.SelectedRows.Count == 1)  //secýlý fatura sayýsý 1 ise
                    {
                        MessageBox.Show((row.Cells[nameof(EI.Invoice.ID)].Value.ToString()) + " " + Lang.warningHasAnswer);
                    }
                }
                else//fatura cevap gondermeye uygunsa,fatura uuid oldugu kabul lýstesi olustur
                {
                    string desc = Interaction.InputBox(Lang.writeDescription, Lang.addDescription, "Reasen");

                    //uygun olan ýnv u controllerdaký daký Inv listesine aktarýyoruz
                    Singl.invoiceControllerGet.createInvListWithUuid(row.Cells[nameof(EI.Invoice.uuid)].Value.ToString());
                    Singl.invoiceDalGet.getInvoice(rowUuid, nameof(EI.Direction.IN)).stateNote = nameof(EI.StateNote.SENDRESPONSE);//db ye cevap gonderýldý dýye not edýlýr
                    description.Add(desc);
                    verifiredInvList.Add(rowUuid);
                }
            }

            if (verifiredInvList.Count == 0) //hicbiri krýterlere uygun degýlse
            {
                if (tableGrid.SelectedRows.Count != 1)
                {
                    MessageBox.Show(Lang.warningHasAnswer + Lang.warningBasicInvoice + Lang.warningHasAnswer);
                }
            }
            else//valid fatura varsa 
            {
                if (Singl.invoiceControllerGet.sendInvoiceResponse(state, description) == 0)  //yanýt gonderme basarýlýysa
                {
                    MessageBox.Show(string.Join(Environment.NewLine, verifiredInvList) + Environment.NewLine + Lang.sendResponseToInvoice);//"nolu faturalara yanýt gonderýldý"
                }
                else//yanýt gonderme ýslemý basarýsýzsa
                {
                    MessageBox.Show(Lang.operationFailed);//islem basarýsýz
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
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (difference.Days > 8   //fatura yuklendýkten sonra 8 gun gecmýsse
                 || row.Cells[nameof(EI.Invoice.gibStatusCode)].Value.Equals(1300)
                 || row.Cells[nameof(EI.Invoice.gibStatusCode)].Value.Equals(1215)
                 || row.Cells[nameof(EI.Invoice.gibStatusCode)].Value.Equals(1230)
                 //   || Convert.ToInt32(row.Cells[nameof(EI.Invoice.gibStatusCode)].Value) < 1100
                 || Convert.ToInt32(row.Cells[nameof(EI.Invoice.gibStatusCode)].Value) > 1200)

            {
                return true; //false
            }
            return true;
        }



        private string showStateInvoice(string direction)
        {

            List<string> unvalidList = new List<string>();
            List<string> updatedInvList = new List<string>();
            string idRow;
            string UuidRow;
            string message;

            for (int i = 0; i < tableGrid.SelectedRows.Count; i++)
            {
                idRow = tableGrid.SelectedRows[i].Cells[nameof(EI.Invoice.ID)].Value.ToString();
                UuidRow = tableGrid.SelectedRows[i].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                if (!statusValidCheck(tableGrid.SelectedRows[i])) //selectedrows valid degýl ise
                {
                    unvalidList.Add(idRow);
                }
                else //valid ise modelde guncelle  
                {

                    var invoiceStatus = Singl.invoiceControllerGet.getInvoiceStatatus(UuidRow);
                    //servisten cekýlen ýnv responsu modelde guncelle 
                    if (invoiceStatus != null)//donen status null degýlse
                    {
                        if (Singl.invoiceDalGet.updateInvState(direction, invoiceStatus)) //db ye kaydetme basarýlýysa
                        {
                            updatedInvList.Add(idRow);
                        }
                    }
                }
            }

            if (updatedInvList.Count == 0) //hicbiri guncelenemedýyse
            {
                if (tableGrid.SelectedRows.Count == 1)//tekli secim
                {
                    message = Lang.warningStateShow;
                    //  MessageBox.Show(Lang.warningStateShow);
                }
                else//coklu secým
                {
                    message = string.Join(Environment.NewLine, unvalidList) + Environment.NewLine + Lang.noInvNotUpdated; //nolu faturalar guncellenemedi
                    // MessageBox.Show(string.Join(Environment.NewLine, unvalidList) + Environment.NewLine + Lang.noInvNotUpdated); //nolu faturalar guncellenemedi
                }
            }
            else//guncellenen fatura varsa 
            {
                //ýnv listesini  db den datagride getir
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(direction));

                message = string.Join(Environment.NewLine, updatedInvList) + Environment.NewLine + Lang.noInvUpdated;//nolu faturalar guncellendý
                //  MessageBox.Show(string.Join(Environment.NewLine, validList) + Environment.NewLine + Lang.noInvUpdated); //nolu faturalar guncellendý
            }
            return message;
        }





        private void btnIncomingInvGetState_Click(object sender, EventArgs e)
        {
            try
            {
                string message = showStateInvoice(EI.Direction.IN.ToString());
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
                string message = showStateInvoice(EI.Direction.OUT.ToString());
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
            try
            {
                if (e.RowIndex >= 0)
                {

                    if (gridDirection != nameof(EI.GibUser.GibUsers))
                    {

                        #region panelVisiblity
                        if (gridDirection == nameof(EI.Direction.IN))//gelen faturalara týklandýysa
                        {
                            panelIncomingInv.Visible = true;
                        }
                        else if (gridDirection == nameof(EI.Direction.OUT))//giden faturalar
                        {
                            panelSentInv.Visible = true;
                        }
                        else if (gridDirection == nameof(EI.Direction.DRAFT))//taslak faturalar
                        {
                            panelDraftInv.Visible = true;
                        }
                        #endregion

                        //PDF göruntule butonuna týkladýysa
                        if (e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewPdf)].Index)
                        {
                            string uuid = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                            string id = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.ID)].Value.ToString();

                            //pdf ýcýn getýnvoicewithtype metodu cagýrýlcak
                            byte[] content = Singl.invoiceControllerGet.getInvoiceType(uuid, nameof(EI.DocumentType.PDF), gridDirection);
                            if (content != null)
                            {
                                string path = FolderControl.saveInvDocContentWithByte(content, gridDirection, id, nameof(EI.DocumentType.PDF));
                                System.Diagnostics.Process.Start(path);
                            }
                            else
                            {
                                MessageBox.Show(Lang.cantGetContent);
                            }
                        }
                        //html göruntule butonuna týkladýysa
                        else if (e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)].Index)
                        {
                            string uuid = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                            string id = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.ID)].Value.ToString();

                            string content = Singl.invoiceControllerGet.getInvoiceContentXml(uuid, gridDirection);
                            if (content != null) //servisten veya dýskten getýrlebýlmýsse
                            {
                                FrmView previewInvoices = new FrmView(content, nameof(EI.Invoice.Invoices));
                                previewInvoices.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show(Lang.cantGetContent);
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





        private void btnTakeInvIn_Click(object sender, EventArgs e)
        {
            try
            {
   
                //servisten yený irsaliyeleri cek db ye kaydet ve datagridde göster            
                string errorMessage = Singl.invoiceControllerGet.getInvoiceOnServiceAndSaveDb(nameof(EI.Direction.IN));

                if (errorMessage == null)//islem basarýlý sekýlde kaydedýlmýsse
                {
                    gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.Direction.IN)));
                }
                else //islem basarýzsa
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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




        private void btnSentInvAgainSent_Click(object sender, EventArgs e)
        {
            try
            {
                //btn gonder cagýr
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
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void itemDraftNewInvoice_Click(object sender, EventArgs e)
        {
            FrmCreateInvoice frmCreateInvoice = new FrmCreateInvoice(nameof(EI.Invoice.Invoices));
            frmCreateInvoice.Show();
        }




        private void btnFaultyInvoices_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.faulty;
            panelSentInv.Visible = false;
            btnSentInvAgainSent.Enabled = true;
            try
            {
                //db den cekýlen gýden faturalardan hatalý olanlarý   datagride aktar
                gridUpdateInvoiceList(Singl.invoiceDalGet.getFaultyInvoices());
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
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
        }


        private IdArrContentArrModel createInvListWithNewId(string serialName, bool isSendWithZip)
        {
            //verýlmek ýstenen ýd on ekýye aýt yený ýd serýal arr olusturulur
            IdArrContentArrModel idArrContentArr = new IdArrContentArrModel();
            idArrContentArr.newIdArr = InvoiceIdSetSerilaze.createNewInvId(serialName, tableGrid.SelectedRows.Count);

            idArrContentArr.newXmlContentArr = new string[idArrContentArr.newIdArr.Length];

            int cnt = 0;
            foreach (DataGridViewRow row in tableGrid.SelectedRows)
            {
                string uuidRow = row.Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                //YENI ID ILE INVLÝST OLUSTURULMASI
                //diskten kaydettýgým contentý cekýyorum
                //bu contentdeký ýd yý  xmlChangeIdValue fonk ýle ýd degýstýrýyorum
                //ýd sý degýstýrýlmýs contentý ,ýstege gore zýpleyýp, ýnvoiceliste aktarýyorum

                string xmlContent = Singl.invoiceControllerGet.getInvoiceContentXml(uuidRow, gridDirection);
                idArrContentArr.newXmlContentArr[cnt] = XmlControl.xmlInvoiceChangeIdValue(xmlContent, idArrContentArr.newIdArr[cnt]);

               Singl.invoiceControllerGet.createInvListWithContent(isSendWithZip, idArrContentArr.newXmlContentArr[cnt]);

                cnt++;
            }

            return idArrContentArr;
        }



        private void btnSendDraftInv_Click(object sender, EventArgs e)
        {
            try
            {
                bool valid = true;
                bool isSendWithZip = true;
                int selectedInvCount = tableGrid.SelectedRows.Count;

                //zipli gonderme kontrolu
                if (rdUnzip.Checked) //ikisini de ýsaretlememisse zipli gonderýlýr
                {
                    isSendWithZip = false;
                }

                //ayný kýsýye gýdecek faturalar secýlý mý kontrolu
                string receiverVkn = tableGrid.SelectedRows[0].Cells[nameof(EI.Invoice.receiverVkn)].Value.ToString();
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    if (row.Cells[nameof(EI.Invoice.receiverVkn)].Value != null && row.Cells[nameof(EI.Invoice.receiverVkn)].Value.ToString() != receiverVkn) //vkn farklý ýse
                    {
                        MessageBox.Show(Lang.selectOnePerson);//sadece ayný kýsýye olan faturalarý býrlýkte gonderebýlýrsýnýz
                        valid = false; break;
                    }
                }

                if (valid) //uymayan fatura durumu yoksa
                {
                    //db den getýrýlen serý Namelerý comboboxda sectýr
                    FrmDialogSelectItem frmDialogSelectSeriName = new FrmDialogSelectItem(true, "");
                    if (frmDialogSelectSeriName.ShowDialog() == DialogResult.OK)
                    {

                        FrmDialogSelectItem frmDialogIdSelectAlias = new FrmDialogSelectItem(false, receiverVkn);
                        ////gb  sectýr
                        if (frmDialogIdSelectAlias.ShowDialog() == DialogResult.OK)
                        {
                            IdArrContentArrModel ýdContentModel = createInvListWithNewId(frmDialogSelectSeriName.selectedValue, isSendWithZip);

                            //send inv 
                            if (Singl.invoiceControllerGet.sendInvoice(frmDialogIdSelectAlias.selectedValue, isSendWithZip) == 0)
                            {
                                for (int cnt = 0; cnt < selectedInvCount; cnt++)
                                {
                                    string uuidRow = tableGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                                   
                                    //yený folderpath olustur
                                    string newFolderPath = FolderControl.createInvoiceDocPath(ýdContentModel.newIdArr[cnt], nameof(EI.Direction.OUT),
                                        nameof(EI.DocumentType.XML)); // yený path db ye yazýlýr

                                    string oldFolderPath = Singl.invoiceDalGet.getInvoice(uuidRow, nameof(EI.Direction.DRAFT)).folderPath;


                                    //db de yený id,direction,folderpath,statenote guncellenýr
                                  if (Singl.invoiceDalGet.updateInvIdDirectionFolderPathStateNote(uuidRow, nameof(EI.Direction.DRAFT),
                                       ýdContentModel.newIdArr[cnt], nameof(EI.Direction.OUT), newFolderPath, nameof(EI.StatusType.SEND)) == 1)
                                    {
                                        //eský folderPathdeký dosyayý konumdan sýler
                                        FolderControl.deleteFileFromPath(oldFolderPath);

                                        //yený folderpath ile yený id eklenmýs xmli diske kaydet
                                        FolderControl.writeFileOnDiskWithString(ýdContentModel.newXmlContentArr[cnt], newFolderPath);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Güncel bilgileri Db ye kaydetme iþlemi basarýsýz,Ýþlemi tekrar gerceklestýrýnýz" + tableGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.ID)].Value.ToString());
                                        return;
                                    }
                                }

                                //db ye, en son olusturulan yený ýnv id serisinin son itemi ýle serý no ve yýl guncelle
                                Singl.invIdSerilazeDalGet.updateLastAddedInvIdSeri(ýdContentModel.newIdArr.Last());

                                //datagrýd listesini guncelle
                                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(gridDirection));

                                MessageBox.Show(Lang.succesful);//"basarýlý"
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
                MessageBox.Show(Lang.operationFailed + ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error); //iþlem basarýsýz
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


        private void btnLoadPortal_Click(object sender, EventArgs e)
        {
            try
            {
                bool isSendWithZip = true;
                //zipli gonderme kontrolu
                if (rdUnzip.Checked) //ikisini de isaretmemýsse zýplý gonderýlýr
                {
                    isSendWithZip = false;
                }

                //db den getýrýlen serý Namelerý comboboxda sectýr
                FrmDialogSelectItem frmDialogIdSeriName = new FrmDialogSelectItem(true, "");
                if (frmDialogIdSeriName.ShowDialog() == DialogResult.OK)
                {
                    IdArrContentArrModel idArrContentArrModel = createInvListWithNewId(frmDialogIdSeriName.selectedValue, isSendWithZip); //load ýnvda  direction degýstýrmýyoruz o yuzden false
                    //serviste gonderýlecek ýnvoýcelist createInvListWithNewId fonksýyonu tarafýndan olustuurluyor ve global degýskene aktarýlýyor bu yuzden content parametresý gondermýypruz
                    if (Singl.invoiceControllerGet.loadInvoice(isSendWithZip) == 0) //     int returnCode = 0 / basarýlýysa
                    {

                        for (int rowCnt = 0; rowCnt < tableGrid.SelectedRows.Count; rowCnt++)
                        {
                            string uuidRow = tableGrid.SelectedRows[rowCnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                      
                            //yený ýd ile yený folderpath olustur
                            string newFolderPath = FolderControl.createInvoiceDocPath(idArrContentArrModel.newIdArr[rowCnt], nameof(EI.Direction.DRAFT), nameof(EI.DocumentType.XML));
                            string oldFolderPath = Singl.invoiceDalGet.getInvoice(uuidRow, nameof(EI.Direction.DRAFT)).folderPath;

                            //db verileri guncelle
                           if (Singl.invoiceDalGet.updateInvIdCdateStatusGibCodeStateNoteFolderPath(uuidRow, nameof(EI.Direction.DRAFT),
                              idArrContentArrModel.newIdArr[rowCnt], DateTime.Now, nameof(EI.StatusType.LOAD) + " - " + nameof(EI.SubStatusType.SUCCEED),
                               -1, nameof(EI.StatusType.LOAD), newFolderPath) == 1)
                            {
                                //yený olust. folderpath ýle xml ý dýske kaydet
                                FolderControl.writeFileOnDiskWithString(idArrContentArrModel.newXmlContentArr[rowCnt], newFolderPath);

                                //eský folderPathdeký dosyayý konumdan sýler
                                FolderControl.deleteFileFromPath(oldFolderPath);
                            }
                            else
                            {
                                MessageBox.Show("Güncel bilgileri Db ye kaydetme iþlemi basarýsýz,Ýþlemi tekrar gerceklestýrýnýz" + tableGrid.SelectedRows[rowCnt].Cells[nameof(EI.Invoice.ID)].Value.ToString());
                                return;
                            }
                        }
                        //db ye, en son olusturulan yený ýnv id serisinin son itemi ýle serý no ve yýl guncelle
                        Singl.invIdSerilazeDalGet.updateLastAddedInvIdSeri(idArrContentArrModel.newIdArr.Last());

                        // db den cekýlen taslak faturalarý datagrýdde listele
                        gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.Direction.DRAFT)));

                        MessageBox.Show(Lang.successLoad);//"yukleme basarýlý"
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
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
               
                //servisten yený irsaliyeleri cek db ye kaydet ve datagridde göster            
                string errorMessage = Singl.invoiceControllerGet.getInvoiceOnServiceAndSaveDb(gridDirection);

                if (errorMessage == null)//islem basarýlý sekýlde kaydedýlmýsse
                {
                    gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(gridDirection));
                }
                else //islem basarýzsa
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex+"   "+Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //servisten tarih aralýðýna uygun faturalarý getýr
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceListOnFilter(gridDirection, timeStartFilter.Value.Date, timeFinishFilter.Value.Date));
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



        private void btnTakeInvDraft_Click(object sender, EventArgs e)
        {

            //servisten yený irsaliyeleri cek db ye kaydet ve datagridde göster            
            string errorMessage = Singl.invoiceControllerGet.getInvoiceOnServiceAndSaveDb(nameof(EI.Direction.DRAFT));

            if (errorMessage == null)//islem basarýlý sekýlde kaydedýlmýsse
            {
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.Direction.DRAFT)));
            }
            else //islem basarýzsa
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnTakeInvOut_Click(object sender, EventArgs e)
        {
            
            //servisten yený irsaliyeleri cek db ye kaydet ve datagridde göster            
            string errorMessage = Singl.invoiceControllerGet.getInvoiceOnServiceAndSaveDb(nameof(EI.Direction.OUT));

            if (errorMessage == null)//islem basarýlý sekýlde kaydedýlmýsse
            {
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.Direction.OUT)));
            }
            else //islem basarýzsa
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncomingInvGetState_Click_1(object sender, EventArgs e)
        {
            try
            {
                btnSentInvAgainSent.Enabled = false;
                string message = showStateInvoice(EI.Direction.IN.ToString());
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

        private void btnHomePage_Click(object sender, EventArgs e)
        {
            FrmHome frmHome = new FrmHome();
            frmHome.Show();
            this.Dispose();
        }

        private void btnGetSendSignedInvoice_Click(object sender, EventArgs e)
        {

            try
            {
                //imzali fatura al
                if (Singl.invoiceControllerGet.isGetInvoiceSingnedXml(gridDirection))
                {
                    MessageBox.Show(Lang.succesful); //succesful
                }
                else
                {
                    MessageBox.Show(Lang.noGetInvoice);//Getirilecek Fatura Bulunmadý
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

        private void btnGetRejectedSendInv_Click(object sender, EventArgs e)
        {
            panelSentInv.Visible = false;
            try
            {
                gridUpdateInvoiceList(Singl.invoiceDalGet.getRejectedInvoiceList(gridDirection));

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

        private void btnGetRejectedIncomingInv_Click(object sender, EventArgs e)
        {
            panelIncomingInv.Visible = false;
            try
            {
                gridUpdateInvoiceList(Singl.invoiceDalGet.getRejectedInvoiceList(gridDirection));

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

        private void btnWaitResponseGetInv_Click(object sender, EventArgs e)
        {
            panelIncomingInv.Visible = false;
            try
            {
                gridUpdateInvoiceList(Singl.invoiceDalGet.getWaitResponseInvoiceList(gridDirection));

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






        private void itemListGibUserList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lang.getGibUserList;
            panelDraftInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelSentInv.Visible = false;
            btnTakeInv.Visible = false;
            gridDirection = EI.GibUser.GibUsers.ToString();

            try
            {
                gridUpdateGibUserList(Singl.gibUsersDalGet.getGibUserList(nameof(EI.ProductType.INVOICE)));

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



        private void itemTakeGibUsers_Click(object sender, EventArgs e)
        {
            panelDraftInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelSentInv.Visible = false;
            btnTakeInv.Visible = false;
            gridDirection = EI.GibUser.GibUsers.ToString();
            try
            {
                //Gönderici posta kutusu bilgilerini cekmek istiyor musunuz? Bu iþlem en az 15 dk surer.
                DialogResult response = MessageBox.Show(Lang.wantGetUserList, Lang.warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (response == DialogResult.OK)
                {
                    //servisten cek
                    string errorMessage = Singl.GibUserControllerGet.getGibUserList(nameof(EI.ProductType.INVOICE));
                    if (errorMessage != null)
                    {
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(Lang.succesful);
                    }
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
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void FrmInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tableGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblInformation_Click(object sender, EventArgs e)
        {

        }
    }

}

