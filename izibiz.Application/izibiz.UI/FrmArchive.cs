using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.COMMON.Language;
using izibiz.CONTROLLER;
using izibiz.CONTROLLER.Model;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbTablesModels;
using izibiz.SERVICES.serviceArchive;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace izibiz.UI
{
    public partial class FrmArchive : Form
    {


        private string gridMenuType;



        public FrmArchive()
        {
            InitializeComponent();
        }

        private void FrmArchive_Load(object sender, EventArgs e)
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

            //raporlananlar

            itemArchiveInvoices.Text = Lang.eArchiveInvoices;
            btnFilterArchiveReports.Text = Lang.getReported;
            btnArchiveView.Text = Lang.preview;
            rdViewXml.Text = Lang.signedXml;
            btnSendMail.Text = Lang.sendToMail;
            btnArchiveGetState.Text = Lang.updateState;
            btnArchiveCancel.Text = Lang.cancel;
            btnGetSignedXmlArchive.Text = Lang.takeSignedXml;
            //arsıv raporları
            itemGetReportList.Text = Lang.archiveReport;
            btnGetSingedXml.Text = Lang.takeSignedXml;
            //taslak arsıv
            itemDraftArchive.Text = Lang.draftArchives;
            btnSendDraftArchive.Text = Lang.send;
            btnDeleteDraftArchive.Text = Lang.delete;

            this.Text = Lang.formArchive;
            btnTakeArchiveInv.Text = Lang.takeInvoice;
            btnHomePage.Text = Lang.homePage;
            itemArchiveNewCreated.Text = Lang.newInvoice;
            #endregion

        }






        private void gridArchiveChangeColoumnHeaderText()
        {
            tableArchiveGrid.Columns[EI.Invoice.ID.ToString()].HeaderText = Lang.id;

            tableArchiveGrid.Columns[EI.Invoice.uuid.ToString()].HeaderText = Lang.uuid;

            tableArchiveGrid.Columns[EI.Invoice.reportFlagDesc.ToString()].HeaderText = Lang.reportState;

            tableArchiveGrid.Columns[EI.Invoice.totalAmount.ToString()].HeaderText = Lang.totalAmount;

            tableArchiveGrid.Columns[EI.Invoice.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableArchiveGrid.Columns[EI.Invoice.profileId.ToString()].HeaderText = Lang.profileid;

            tableArchiveGrid.Columns[EI.Invoice.invoiceType.ToString()].HeaderText = Lang.type;

            tableArchiveGrid.Columns[EI.Invoice.eArchiveType.ToString()].HeaderText = Lang.eArchiveType;

            tableArchiveGrid.Columns[EI.Invoice.sendingType.ToString()].HeaderText = Lang.sendingType;

            tableArchiveGrid.Columns[EI.Invoice.senderName.ToString()].HeaderText = Lang.senderName;

            tableArchiveGrid.Columns[EI.Invoice.senderVkn.ToString()].HeaderText = Lang.senderVkn;

            tableArchiveGrid.Columns[EI.Invoice.receiverVkn.ToString()].HeaderText = Lang.receiverVkn;

            tableArchiveGrid.Columns[EI.Invoice.currencyCode.ToString()].HeaderText = Lang.currencyCode;

            tableArchiveGrid.Columns[EI.Invoice.status.ToString()].HeaderText = Lang.status;

            tableArchiveGrid.Columns[EI.Invoice.statusCode.ToString()].HeaderText = Lang.statusCode;

            tableArchiveGrid.Columns[EI.Invoice.mailStatus.ToString()].HeaderText = Lang.mailStatus;
        }




        private void gridArchiveUpdateList(List<ArchiveInvoices> archiveList)
        {
            pnlArchive.Visible = false;
            pnlArchiveReport.Visible = false;
            pnlDraftArchive.Visible = false;

            tableArchiveGrid.DataSource = null;
            tableArchiveGrid.Columns.Clear();

            if (archiveList.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                if (gridMenuType == EI.Invoice.DraftArchive.ToString()) //taslak ıse
                {
                    addViewButtonToDatagridView();
                }
                else  //draft arcıve degılse
                {
                    foreach (ArchiveInvoices arc in archiveList)
                    {
                        if (arc.reportFlag)
                        {
                            arc.reportFlagDesc = Lang.yes;
                        }
                        else
                        {
                            arc.reportFlagDesc = Lang.no;
                        }
                    }
                }
                tableArchiveGrid.DataSource = archiveList;
                gridArchiveChangeColoumnHeaderText();

                tableArchiveGrid.Columns[nameof(EI.Invoice.reportFlag)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.draftFlag)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.stateNote)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.folderPath)].Visible = false;

                if (gridMenuType == EI.Invoice.DraftArchive.ToString()) //taslak ıse
                {
                    tableArchiveGrid.Columns[nameof(EI.Invoice.reportFlagDesc)].Visible = false;
                }

            }
        }






        private void btnArchiveView_Click(object sender, EventArgs e)
        {
            try
            {
                string uuid = tableArchiveGrid.SelectedRows[0].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                string docType = EI.DocumentType.XML.ToString();

                if (rdViewHtml.Checked) //html
                {
                    string xmlContent = Singl.archiveControllerGet.getArchiveContentXml(uuid);
                    if (xmlContent != null)
                    {
                        FrmView previewInvoices = new FrmView(xmlContent, nameof(EI.Invoice.ArchiveInvoices));
                        previewInvoices.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(Lang.cantGetContent);//content dıskten sılınmıs ve servısten getırılemedı
                    }
                }
                else  //html degılse
                {
                    if (rdViewXml.Checked) //imzalı xml ise
                    {
                        docType = EI.DocumentType.XML.ToString();
                    }
                    else //hicbirini secmezse pdf  görüntülenecektır
                    {
                        docType = EI.DocumentType.PDF.ToString();
                    }
                    /////////////
                    byte[] content = Singl.archiveControllerGet.getReadFromEArchive(uuid, docType);
                    if (content != null)
                    {
                        string path = FolderControl.inboxFolderArchive + uuid + "." + docType;
                        FolderControl.writeFileOnDiskWithByte(content, path);
                        System.Diagnostics.Process.Start(path);
                    }
                    else
                    {
                        MessageBox.Show(Lang.cantGetContent);//content dıskten sılınmıs ve servısten getırılemedı
                    }
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)  //archive req error
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



        private void btnTakeArchiveInv_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridMenuType == nameof(EI.Invoice.ArchiveInvoices))
                {
                    //servisten yenı faturaları cek db ye kaydet.. hata var mı
                    string errorMessage = Singl.archiveControllerGet.getArchiveListOnServiceAndSaveDb();

                    if (errorMessage == null)//islem basarılı sekılde kaydedılmısse
                    {
                        gridArchiveUpdateList(Singl.archiveInvoiceDalGet.getArchiveList(false));
                    }
                    else //islem basarızsa
                    {
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (gridMenuType == nameof(EI.ArchiveReports.ArchiveReports))
                { 
                    
                    //servisten yenı faturaları cek db ye kaydet.. hata var mı
                    string errorMessage = Singl.archiveControllerGet.getReportListOnServiceAndSaveDb();

                    if (errorMessage == null)//islem basarılı sekılde kaydedılmısse
                    {
                        gridReportUpdateList(Singl.ArchiveReportsDalGet.getReportList());
                    }
                    else //islem basarızsa
                    {
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Lang.dbFault + " " + ex.InnerException.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
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





        private void tableArchiveGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (tableArchiveGrid.SelectedRows.Count > 1)
            {
                btnArchiveView.Enabled = false;
                //    btnSendMail.Enabled = false;
            }
            else
            {
                btnArchiveView.Enabled = true;
                //  btnSendMail.Enabled = true;
            }
        }




        private void tableArchiveGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                #region panelVisiblity
                if (gridMenuType == EI.Invoice.ArchiveInvoices.ToString())//arsıv ınvoices
                {
                    pnlArchive.Visible = true;
                    pnlDraftArchive.Visible = false;
                    pnlArchiveReport.Visible = false;
                }
                else if (gridMenuType == EI.ArchiveReports.ArchiveReports.ToString()) //arsıv report
                {
                    pnlArchive.Visible = false;
                    pnlDraftArchive.Visible = false;
                    pnlArchiveReport.Visible = true;
                }
                else //taslak archıve
                {
                    pnlDraftArchive.Visible = true;
                    pnlArchiveReport.Visible = false;
                    pnlArchive.Visible = false;
                }
                #endregion

                try
                {
                    if (!gridMenuType.Equals(nameof(EI.Invoice.ArchiveInvoices))) //grid durumu arsıv raporlarında degılse
                    {
                        if (e.ColumnIndex == tableArchiveGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)].Index)
                        {

                            // imzalı contentı getır
                            string content;
                            if (gridMenuType.Equals(nameof(EI.ArchiveReports.ArchiveReports))) //arsıv raporlarında  ıse
                            {
                                content = Singl.archiveControllerGet.getArchiveReportXml(tableArchiveGrid.Rows[e.RowIndex].Cells[nameof(EI.ArchiveReports.reportNo)].Value.ToString());

                                if (content != null) //servisten veya dıskten getırlebılmısse
                                {
                                    FrmView previewInvoices = new FrmView(content, gridMenuType);
                                    previewInvoices.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show(Lang.cantGetContent);//content dıskten sılınmıs ve servısten getırılemedı
                                }
                            }
                            else  //taslak arsıv ıse
                            {
                                content = Singl.archiveControllerGet.getArchiveContentXml(tableArchiveGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.uuid)].Value.ToString());

                                if (content != null) //servisten veya dıskten getırlebılmısse
                                {
                                    FrmView previewInvoices = new FrmView(content, nameof(EI.Invoice.ArchiveInvoices)); //taslak fatura olsa turu arsıvdır
                                    previewInvoices.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show(Lang.cantGetContent);//content dıskten sılınmıs ve servısten getırılemedı
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
        }






        private void btnArchiveCancel_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> validRowUuidList = new List<string>();
                List<string> unvalidList = new List<string>();
                bool inUnreportedArchive=false;

                //cancelcontentlıst dekı cancel contentlerı foreachle gecerken olusturuyoruz
                foreach (DataGridViewRow row in tableArchiveGrid.SelectedRows)
                {
                    //daha onceden ıptal edılmıs mı
                    if (row.Cells[nameof(EI.Invoice.stateNote)].Value != null && row.Cells[nameof(EI.Invoice.stateNote)].Value.ToString().Contains(nameof(EI.StateNote.IPTAL)))
                    {
                        unvalidList.Add(row.Cells[nameof(EI.Invoice.ID)].Value.ToString());
                    }
                    else
                    {
                        bool reportFlag = true;
                        if (row.Cells[nameof(EI.Invoice.reportFlag)].Value.ToString() != true.ToString())//bu arsıv raporlanmamıs varsa
                        {
                            reportFlag = false;
                            inUnreportedArchive = true;//ıcerısınde raporlanmıs fatura var
                        }

                        //validse cancel contentlerı olustur 
                        Singl.archiveControllerGet.addContentCancelArcOnCancelContentArr(reportFlag,
                            row.Cells[nameof(EI.Invoice.uuid)].Value.ToString(),
                            row.Cells[nameof(EI.Invoice.ID)].Value.ToString());

                        //validse RowUnique yı kaydet
                        validRowUuidList.Add(row.Cells[nameof(EI.Invoice.uuid)].Value.ToString());
                    }
                }

                if (unvalidList.Count != 0)
                {
                    //nolu faturalar daha onceden ıptal edılmıs bunlar ısleme alınmayacak devam etmek istiyor musunuz
                    DialogResult result = MessageBox.Show(string.Join(Environment.NewLine, unvalidList) + Lang.hasNoInvoiceBeforeCanceled, Lang.warning, MessageBoxButtons.YesNo);
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                }
                if(inUnreportedArchive)//icinde raporlanmamıs fatura varsa
                {
                    DialogResult result = MessageBox.Show("Seçili faturalarda raporlanmamıs faturalar vardır,bunlar tamamen silinecektır" +
                        "devam etmek istiyor musunuz?", Lang.warning, MessageBoxButtons.YesNo);
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                }

                //valid fatura varsa
                if (validRowUuidList.Count != 0)
                {
                    string responseErrorMesage = Singl.archiveControllerGet.cancelEarchive();
                    if (responseErrorMesage == null) //return code 0 ise ,basarılı ıse
                    {

                        //valid olanları db de status note iptal yap
                        foreach (string uuid in validRowUuidList)
                        {

                            Singl.archiveInvoiceDalGet.updateArchiveStateNote(uuid, EI.StateNote.IPTAL.ToString());
                        }

                        MessageBox.Show(validRowUuidList + Environment.NewLine + Lang.succCancelSelectedInvoice);//secılı arsıv basarıyla iptal edildi
                    }
                    else
                    {
                        MessageBox.Show(responseErrorMesage, Lang.operationFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Lang.dbFault + " " + ex.InnerException.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    



        private void btnArchiveGetState_Click(object sender, EventArgs e)
        {
            List<string> listUuid = new List<string>();
            List<string> unvalidListId = new List<string>();
            foreach (DataGridViewRow row in tableArchiveGrid.SelectedRows)
            {
                if (row.Cells[nameof(EI.Invoice.statusCode)].Value.Equals(200)) //raporlanmıs fatura ıse
                {
                    listUuid.Add(row.Cells[nameof(EI.Invoice.ID)].Value.ToString());
                }
                else  //raporlanmamıs ıse
                {
                    listUuid.Add(row.Cells[nameof(EI.Invoice.uuid)].Value.ToString());
                }
            }

            if (unvalidListId.Count > 0)  //uygun olmayan fatura varsa
            {     
                MessageBox.Show(string.Join(Environment.NewLine, listUuid) + Environment.NewLine + "raporlandıgı için durum sorgulaması yapılamaz");
            }
            if (listUuid.Count > 0) //uygun fatura varsa
            {
                string resErrorMessage = Singl.archiveControllerGet.getArchiveStatusAndSaveDb(listUuid.ToArray());
          
                if (resErrorMessage == null)
                {
                    MessageBox.Show(Lang.succesful);
                    //string message = string.Join(Environment.NewLine, listUuid) + Environment.NewLine + Lang.noInvUpdated; //nolu faturalar guncellendi           
                    //MessageBox.Show(message);
                }
                else//basarısızsa false dondur
                {
                    MessageBox.Show(resErrorMessage);
                }
            }          
        }






        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {

                List<SendMailModel> sendMailModelList = new List<SendMailModel>();
                foreach (DataGridViewRow row in tableArchiveGrid.SelectedRows)
                {
                    SendMailModel sendMailModel = new SendMailModel();
                    sendMailModel.id = row.Cells[nameof(EI.Invoice.ID)].Value.ToString();
                    sendMailModel.uuid = row.Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                    sendMailModelList.Add(sendMailModel);
                }

                FrmWriteMail frmSelectMail = new FrmWriteMail(sendMailModelList);
                frmSelectMail.ShowDialog();

                if (frmSelectMail.DialogResult == DialogResult.OK)
                {
                    //mail sec dıalog formunda maıl kısımları doldurulan model lıste esıtledık
                    sendMailModelList = frmSelectMail.sendMailModelList;

                    List<string> errorFailedIdMessage = new List<string>();

                    foreach (var model in sendMailModelList)
                    {
                        string responseErrorMessage = Singl.archiveControllerGet.sendArchiveMail(model.uuid, model.mail);
                        if (responseErrorMessage != null)  //islem basarısızsa
                        {
                            errorFailedIdMessage.Add(model.id + "  " + responseErrorMessage);
                        }
                    }
                    if (errorFailedIdMessage.Count > 0) //barasırız olan varsa onu goster
                    {
                        MessageBox.Show(string.Join(Environment.NewLine, errorFailedIdMessage) + Environment.NewLine, Lang.operationFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else  //basarısız yoksa
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
                MessageBox.Show(Lang.dbFault + " " + ex.InnerException.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }





        private void itemArchiveInvoices_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.Invoice.ArchiveInvoices.ToString();
            btnTakeArchiveInv.Visible = true;
            pnlArchive.Visible = false;
            pnlDraftArchive.Visible = false;
            pnlArchiveReport.Visible = false;
            try
            {
                //db dekı raporlanmıs arsıv faturaları getır
                gridArchiveUpdateList(Singl.archiveInvoiceDalGet.getArchiveList(false));
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





        private void itemGetReportList_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.ArchiveReports.ArchiveReports.ToString();
            btnTakeArchiveInv.Visible = true;
            pnlArchive.Visible = false;
            pnlDraftArchive.Visible = false;
            pnlArchiveReport.Visible = false;
            try
            {
                //db dekı raporlanmıs arsıv faturaları getır
                gridReportUpdateList(Singl.ArchiveReportsDalGet.getReportList());
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



        private void addViewButtonToDatagridView()
        {
            tableArchiveGrid.Columns.Clear();
            //html goruntule butonu
            tableArchiveGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconHtml,
                Name = EI.GridBtnClmName.previewHtml.ToString(),
                HeaderText = Lang.preview,
            });
        }



        private void gridReportUpdateList(List<ArchiveReports> archiveReports)
        {
            tableArchiveGrid.DataSource = null;
            tableArchiveGrid.Columns.Clear();

            if (archiveReports.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                addViewButtonToDatagridView();
                tableArchiveGrid.DataSource = archiveReports;
                gridReportsChangeColoumnHeaderText();
            }
        }



        private void gridReportsChangeColoumnHeaderText()
        {
            tableArchiveGrid.Columns[EI.ArchiveReports.reportNo.ToString()].HeaderText = Lang.reportNo;

            tableArchiveGrid.Columns[EI.ArchiveReports.status.ToString()].HeaderText = Lang.reportState;

        }




        private void itemArchiveNewCreated_Click(object sender, EventArgs e)
        {
            FrmCreateInvoice frmCreateInvoice = new FrmCreateInvoice(nameof(EI.Invoice.ArchiveInvoices));
            frmCreateInvoice.Show();
        }






        private void btnGetSingedXml_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> listReportNoSucc = new List<string>();

                foreach (DataGridViewRow row in tableArchiveGrid.SelectedRows)
                {
                    string reportNo = row.Cells[nameof(EI.ArchiveReports.reportNo)].Value.ToString();

                    string signedXmlContent = Singl.archiveControllerGet.getArchiveReportXml(reportNo);
                    if (signedXmlContent != null)
                    {
                        //contentı dıske yazdır
                        FolderControl.writeFileOnDiskWithString(signedXmlContent, FolderControl.inboxFolderArchiveReport + reportNo + "." + nameof(EI.DocumentType.XML));
                        listReportNoSucc.Add(row.Cells[nameof(EI.ArchiveReports.reportNo)].Value.ToString());
                    }
                }

                if (listReportNoSucc.Count > 0)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, listReportNoSucc) + Environment.NewLine + Lang.hasIdArchiveReportSave);//"secılı arsıv raporları basarıyla kaydedıldı"
                }
                else
                {
                    MessageBox.Show(Lang.operationFailed);//"islem basarısız"
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



        private void ıtemDraftArchive_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.Invoice.DraftArchive.ToString();
            btnTakeArchiveInv.Visible = true;
            pnlArchive.Visible = false;
            pnlArchiveReport.Visible = false;
            pnlDraftArchive.Visible = false;
            try
            {
                gridArchiveUpdateList(Singl.archiveInvoiceDalGet.getArchiveList(true));

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







        private void btnCancelDraftArchive_Click(object sender, EventArgs e)
        {
            try
            {
                //taslak oldugu ıcın SADECE db den faturayı sıl
                foreach (DataGridViewRow row in tableArchiveGrid.SelectedRows)
                {
                    string uuid = row.Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                    Singl.archiveInvoiceDalGet.deleteArchive(uuid);
                }             

                pnlDraftArchive.Visible = false;
                gridArchiveUpdateList(Singl.archiveInvoiceDalGet.getArchiveList(true));

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
                MessageBox.Show(ex.ToString());
            }
        }





        private void btnSendDraftArchive_Click(object sender, EventArgs e)
        {
            try
            {
                //db den getırılen serı Namelerı comboboxda sectır
                FrmDialogSelectItem frmDialogSelectSeriName = new FrmDialogSelectItem(true, "");
                if (frmDialogSelectSeriName.ShowDialog() == DialogResult.OK)
                {

                    ArchiveContentPropertiesModel[] archiveModelArr = new ArchiveContentPropertiesModel[tableArchiveGrid.SelectedRows.Count];
                    string seriName = frmDialogSelectSeriName.selectedValue;
                    string[] newIdArr = InvoiceIdSetSerilaze.createNewInvId(seriName, tableArchiveGrid.SelectedRows.Count);
                   

                    for(int cnt=0;cnt<tableArchiveGrid.SelectedRows.Count;cnt++)
                    {
                        ArchiveContentPropertiesModel archiveContentPropertiesModel = new ArchiveContentPropertiesModel();

                        archiveContentPropertiesModel.uuid = tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                        archiveContentPropertiesModel.archiveType = tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.eArchiveType)].Value.ToString();
                       
                        //alınan contenttın ıdsını degıstırerek koy
                        string content = Singl.archiveControllerGet.getArchiveContentXml(archiveContentPropertiesModel.uuid);
                        archiveContentPropertiesModel.content= XmlControl.xmlInvoiceChangeIdValue(content, newIdArr[cnt]);

                        if (tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.receiverMail)].Value != null) //mail gonderılmek ısstenıyorsa
                        {
                            archiveContentPropertiesModel.mail = tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.receiverMail)].Value.ToString();
                        }

                        Singl.archiveControllerGet.addContentPropertiesToList(archiveContentPropertiesModel);

                        archiveModelArr[cnt] = archiveContentPropertiesModel;
                    }

                    string responseErrorMessage = Singl.archiveControllerGet.sendEarchive();
                    if (responseErrorMessage != null)
                    {
                        MessageBox.Show(responseErrorMessage, Lang.operationFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //db de fatura durumunu taslaktan cıkar
                        for (int cnt = 0; cnt < archiveModelArr.Length; cnt++)
                        {
                           
                            string oldFolderPath = Singl.archiveInvoiceDalGet.findArchive(archiveModelArr[cnt].uuid).folderPath;

                            //path degıstır
                            string newFolderPath = FolderControl.inboxFolderArchive + newIdArr[cnt] + "." + nameof(EI.DocumentType.XML);
                    
                            //guncelleme basarılıysa
                            if (Singl.archiveInvoiceDalGet.updateArchiveIdStateNoteDraftFlagFolderPath(archiveModelArr[cnt].uuid,
                                 newIdArr[cnt], EI.StateNote.SEND.ToString(), false, newFolderPath) == 1)
                            {
                                //diskten xmli sil
                                FolderControl.deleteFileFromPath(oldFolderPath);
                               
                                //yenı kontentı dıske kaydet
                                FolderControl.writeFileOnDiskWithString(archiveModelArr[cnt].content, newFolderPath);
                            }
                            else
                            {
                                MessageBox.Show("Db ye kaydetme işlemi basarısız,İşlemi tekrar gerceklestırınız" + tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.ID)].Value.ToString());
                                return;
                            }
                        }

                        //db ye, en son olusturulan yenı ınv id serisinin son itemi ıle serı no ve yıl guncelle
                        Singl.invIdSerilazeDalGet.updateLastAddedInvIdSeri(newIdArr.Last());

                        MessageBox.Show(Lang.succesful);//"Başarılı"
                        gridArchiveUpdateList(Singl.archiveInvoiceDalGet.getArchiveList(true));
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




        private void btnGetSignedXmlArchive_Click(object sender, EventArgs e)
        {
            try
            {
                //gridde secılı arsıvlerın ımzalı xmlını dıske yazar
                List<string> listUnvalidArchive = new List<string>();

                foreach (DataGridViewRow row in tableArchiveGrid.SelectedRows)
                {
                    byte[] content = Singl.archiveControllerGet.getReadFromEArchive(row.Cells[nameof(EI.Invoice.uuid)].Value.ToString(), nameof(EI.DocumentType.XML));
                    if (content != null)
                    {
                        string path = FolderControl.inboxFolderArchive + row.Cells[nameof(EI.Invoice.ID)].Value.ToString() + "." + nameof(EI.DocumentType.XML);
                        FolderControl.writeFileOnDiskWithByte(content, path);
                    }
                    else
                    {
                        listUnvalidArchive.Add(row.Cells[nameof(EI.Invoice.ID)].Value.ToString());
                    }
                }

                if (listUnvalidArchive.Count > 0)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, listUnvalidArchive) + Environment.NewLine + Lang.noGetInvoice);//Seçili arsivler getirilemedi
                }
                else
                {
                    MessageBox.Show(Lang.succesful);//"Başarılı"
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



        private void btnFilterArchiveReports_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> listUuid = Singl.archiveInvoiceDalGet.getArchiveUuidList(false);

                //guncel durumunu db ye yazdır
                Singl.archiveControllerGet.getArchiveStatusAndSaveDb(listUuid.ToArray());

                //db den report flag true  olanları getır
                gridArchiveUpdateList(Singl.archiveInvoiceDalGet.getArchiveReportList());
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
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmArchive_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }




    }
}

