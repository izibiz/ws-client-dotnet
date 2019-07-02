﻿using izibiz.CONTROLLER.Singleton;
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
using izibiz.MODEL.Data;

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
            //yenı fatura
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

            tableGrid.Columns[EI.Invoice.profileid.ToString()].HeaderText = Lang.profileid;

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
            gridDirection = nameof(EI.InvDirection.OUT);
            btnTakeInv.Visible = true;
            grpFilter.Visible = true;
            try
            {
                //db den cekılen lısteyı datagride aktar
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.OUT)));
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
            gridDirection = nameof(EI.InvDirection.IN);
            btnTakeInv.Visible = true;
            grpFilter.Visible = true;
            try
            {
                //  db den cekılen lısteyı datagride aktar
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.IN)));
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
            gridDirection = nameof(EI.InvDirection.OUT);
            btnTakeInv.Visible = true;
            grpFilter.Visible = true;
            try
            {
                //db den cekılen lısteyı datagride aktar
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.OUT)));
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
            gridDirection = nameof(EI.InvDirection.DRAFT);
            btnTakeInv.Visible = true;
            grpFilter.Visible = true;
            try
            {
                // db den cekılen lısteyı datagride aktar
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.DRAFT)));
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
                else if (row.Cells[nameof(EI.Invoice.status)].Value == null 
                    ||  !row.Cells[nameof(EI.Invoice.status)].Value.ToString().Contains(EI.SubStatusType.WAIT_APPLICATION_RESPONSE.ToString())  
                    || (row.Cells[nameof(EI.Invoice.stateNote)].Value != null  && row.Cells[nameof(EI.Invoice.stateNote)].Value.Equals(nameof(EI.StateNote.SENDRESPONSE)))
                    )    //olan varsa
                {
                    if (tableGrid.SelectedRows.Count == 1)  //secılı fatura sayısı 1 ise
                    {
                        MessageBox.Show((row.Cells[nameof(EI.Invoice.ID)].Value.ToString()) + " " + Lang.warningHasAnswer);
                    }
                }
                else//fatura cevap gondermeye uygunsa,fatura uuid oldugu kabul lıstesi olustur
                {
                    string desc = Interaction.InputBox(Lang.writeDescription, Lang.addDescription, "Reasen");

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
                    MessageBox.Show(string.Join(Environment.NewLine, verifiredInvList) + Environment.NewLine + Lang.sendResponseToInvoice);//"nolu faturalara yanıt gonderıldı"
                }
                else//yanıt gonderme ıslemı basarısızsa
                {
                    MessageBox.Show(Lang.operationFailed);//islem basarısız
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
            List<string> validList = new List<string>();
            string idRow;
            string UuidRow;
            string message;

            for (int i = 0; i < tableGrid.SelectedRows.Count; i++)
            {
                idRow = tableGrid.SelectedRows[i].Cells[nameof(EI.Invoice.ID)].Value.ToString();
                UuidRow = tableGrid.SelectedRows[i].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                if (!statusValidCheck(tableGrid.SelectedRows[i])) //selectedrows valid degıl ise
                {
                    unvalidList.Add(idRow);
                }
                else //valid ise modelde guncelle  
                {
                    validList.Add(idRow);

                    //servisten cekılen ınv responsu modelde guncelle 
                    Singl.invoiceDalGet.updateInvState(UuidRow, direction, Singl.invoiceControllerGet.getInvoiceStatatus(UuidRow));
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
                //ınv listesini  db den datagride getir
                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(direction));

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

                try
                {
                    //PDF göruntule butonuna tıkladıysa
                    if (e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewPdf)].Index)
                    {
                        string uuid = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                        string id = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.ID)].Value.ToString();

                        //pdf ıcın getınvoicewithtype metodu cagırılcak
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
                    //html göruntule butonuna tıkladıysa
                    else if (e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)].Index)
                    {
                        string uuid = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                        string id = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.ID)].Value.ToString();

                        string content = Singl.invoiceControllerGet.getInvoiceContentXml(uuid, gridDirection);
                        if (content != null) //servisten veya dıskten getırlebılmısse
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



        private void btnTakeInvIn_Click(object sender, EventArgs e)
        {
            try
            {
                //servisten yenı faturaları cek db ye kaydet ve datagridde göster
                gridUpdateInvoiceList(Singl.invoiceControllerGet.getInvoiceListOnService(nameof(EI.InvDirection.IN)));
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
                //db den cekılen gıden faturalardan hatalı olanları   datagride aktar
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


        private IdContentModel createInvListWithNewId(string seriName, bool isSendWithZip)
        {
            //verılmek ıstenen ıd on ekıye aıt yenı ıd serıal arr olusturulur
            IdContentModel idContent = new IdContentModel();
            idContent.newIdArr = InvoiceIdSetSerilaze.createNewInvId(seriName, tableGrid.SelectedRows.Count);

            string[] contentArr = new string[idContent.newIdArr.Length];

            int cnt = 0;
            foreach (DataGridViewRow row in tableGrid.SelectedRows)
            {
                string uuidRow = row.Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                //YENI ID ILE INVLİST OLUSTURULMASI
                //diskten kaydettıgım contentı cekıyorum
                //bu contentdekı ıd yı  xmlChangeIdValue fonk ıle ıd degıstırıyorum
                //ıd sı degıstırılmıs contentı ,ıstege gore zıpleyıp, ınvoiceliste aktarıyorum

                string xmlContent = Singl.invoiceControllerGet.getInvoiceContentXml(uuidRow, gridDirection);
                contentArr[cnt] = XmlControl.xmlChangeIdValue(xmlContent, idContent.newIdArr[cnt]);

                Singl.invoiceControllerGet.createInvListWithContent(isSendWithZip, contentArr[cnt]);

                cnt++;
            }
            idContent.newXmlContentArr = contentArr;

            return idContent;
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
                        MessageBox.Show(Lang.selectOnePerson);//sadece aynı kısıye olan faturaları bırlıkte gonderebılırsınız
                        valid = false; break;
                    }
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
                            IdContentModel ıdContentModel = createInvListWithNewId(frmDialogSelectSeriName.selectedValue, isSendWithZip);

                            //send inv 
                            if (Singl.invoiceControllerGet.sendInvoice(frmDialogIdSelectAlias.selectedValue, isSendWithZip) == 0)
                            {
                                for (int rowCnt = 0; rowCnt < selectedInvCount; rowCnt++)
                                {
                                    string uuidRow = tableGrid.SelectedRows[rowCnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                                    Invoices invoice = Singl.invoiceDalGet.getInvoice(uuidRow, nameof(EI.InvDirection.DRAFT));
                                    invoice.ID = ıdContentModel.newIdArr[rowCnt];
                                    invoice.direction = nameof(EI.InvDirection.OUT);
                                    invoice.stateNote = nameof(EI.StatusType.SEND);

                                    Singl.invoiceDalGet.changeInvIdDirectionStateNote();

                                    //eskı folderPathdekı dosyayı konumdan sıler
                                    //get folderpath


                                    FolderControl.deleteFileFromPath(invoice.folderPath);
                                    //yenı folderpath ekle
                                    invoice.folderPath = FolderControl.createInvDocPath(invoice.ID, nameof(EI.InvDirection.OUT), nameof(EI.DocumentType.XML)); // yenı path db ye yazılır
                                    //yenı folderpath ile yenı id eklenmıs xmli diske kaydet
                                    FolderControl.writeFileOnDiskWithString(ıdContentModel.newXmlContentArr[rowCnt], invoice.folderPath);
                                }

                                //db ye, en son olusturulan yenı ınv id serisinin son itemi ıle serı no ve yıl guncelle
                                Singl.invIdSerilazeDalGet.updateLastAddedInvIdSeri(ıdContentModel.newIdArr.Last());

                                //datagrıd listesini guncelle
                                gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(gridDirection));

                                MessageBox.Show(Lang.succesful);//"basarılı"
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
                MessageBox.Show(Lang.operationFailed + ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error); //işlem basarısız
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
                    IdContentModel ıdContentModel = createInvListWithNewId(frmDialogIdSeriName.selectedValue, isSendWithZip); //load ınvda  direction degıstırmıyoruz o yuzden false

                    if (Singl.invoiceControllerGet.loadInvoice(isSendWithZip) == 0) //     int returnCode = 0 / basarılıysa
                    {

                        for (int rowCnt = 0; rowCnt < tableGrid.SelectedRows.Count; rowCnt++)
                        {
                            string uuidRow = tableGrid.SelectedRows[rowCnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                            //db verileri guncelle
                            Invoices invoice = Singl.invoiceDalGet.getInvoice(uuidRow, nameof(EI.InvDirection.DRAFT));
                            invoice.ID = ıdContentModel.newIdArr[rowCnt];
                            invoice.cDate = DateTime.Now;
                            invoice.status = nameof(EI.StatusType.LOAD) + " - " + nameof(EI.SubStatusType.SUCCEED);
                            invoice.gibStatusCode = -1;
                            invoice.stateNote = nameof(EI.StatusType.LOAD);
                            //eskı folderPathdekı dosyayı konumdan sıler
                            FolderControl.deleteFileFromPath(invoice.folderPath);
                            //yenı ıd ile yenı folderpath olustur
                            invoice.folderPath = FolderControl.createInvDocPath(invoice.ID, nameof(EI.InvDirection.DRAFT), nameof(EI.DocumentType.XML));
                            //yenı olust. folderpath ıle xml ı dıske kaydet
                            FolderControl.writeFileOnDiskWithString(ıdContentModel.newXmlContentArr[rowCnt], invoice.folderPath);
                        }

                        //db ye, en son olusturulan yenı ınv id serisinin son itemi ıle serı no ve yıl guncelle
                        Singl.invIdSerilazeDalGet.updateLastAddedInvIdSeri(ıdContentModel.newIdArr.Last());

                        //eger islem basarılı ise db guncellemeleri kaydet
                        using (DatabaseContext databaseContext = new DatabaseContext())
                        {
                            Singl.invoiceDalGet.dbSaveChanges(databaseContext);
                        }

                        // db den cekılen taslak faturaları datagrıdde listele
                        gridUpdateInvoiceList(Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.DRAFT)));

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
                gridUpdateInvoiceList(Singl.invoiceControllerGet.getInvoiceListOnService(gridDirection));
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void btnTakeInvDraft_Click(object sender, EventArgs e)
        {
            //servisten yenı faturaları cek db ye kaydet ve datagridde göster
            gridUpdateInvoiceList(Singl.invoiceControllerGet.getInvoiceListOnService(nameof(EI.InvDirection.DRAFT)));
        }



        private void btnTakeInvOut_Click(object sender, EventArgs e)
        {
            //servisten yenı faturaları cek db ye kaydet ve datagridde göster
            gridUpdateInvoiceList(Singl.invoiceControllerGet.getInvoiceListOnService(nameof(EI.InvDirection.OUT)));
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
                    MessageBox.Show(Lang.noGetInvoice);//Getirilecek Fatura Bulunmadı
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
            panelDraftInv.Visible = false;
            panelIncomingInv.Visible = false;
            panelSentInv.Visible = false;
            btnTakeInv.Visible = false;
            try
            {
                gridUpdateGibUserList(Singl.gibUsersDalGet.getGibUserList());

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
            try
            {
                //Gönderici posta kutusu bilgilerini cekmek istiyor musunuz? Bu işlem en az 15 dk surer.
                DialogResult response = MessageBox.Show(Lang.wantGetUserList, Lang.warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (response == DialogResult.OK)
                {
                    //servisten cek
                    var userList = Singl.invoiceControllerGet.getGibUserList();
                    //db ye kaydet
                    foreach (var user in userList)
                    {
                        Singl.gibUsersDalGet.addGibUser(user.ALIAS, user.IDENTIFIER, user.TITLE);
                    }
                    Singl.gibUsersDalGet.dbSaveChanges();

                    MessageBox.Show(Lang.succesful);
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



        private void FrmInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }





    }

}

