using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.COMMON.Language;
using izibiz.CONTROLLER.Model;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbModels;
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
            itemArchiveInvoices.Text = Lang.reportInvoice;
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
            btnCancelDraftArchive.Text = Lang.cancel;
            btnGetStateDraftArchive.Text = Lang.updateState;

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

            tableArchiveGrid.Columns[EI.Invoice.totalAmount.ToString()].HeaderText = Lang.totalAmount;

            tableArchiveGrid.Columns[EI.Invoice.draftFlag.ToString()].HeaderText = Lang.isDraftFlag;

            tableArchiveGrid.Columns[EI.Invoice.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableArchiveGrid.Columns[EI.Invoice.profileid.ToString()].HeaderText = Lang.profileid;

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
            tableArchiveGrid.DataSource = null;
            tableArchiveGrid.Columns.Clear();

            if (archiveList.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                if (gridMenuType == EI.Invoice.DraftArchive.ToString())
                {
                    addViewButtonToDatagridView();
                }
                tableArchiveGrid.DataSource = archiveList;
                gridArchiveChangeColoumnHeaderText();

                tableArchiveGrid.Columns[nameof(EI.Invoice.draftFlag)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.stateNote)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.content)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.folderPath)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.rowUnique)].Visible = false;

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
                    string xmlContent = Singl.archiveControllerGet.getArchiveContentXml(uuid, tableArchiveGrid.SelectedRows[0].Cells[nameof(EI.Invoice.rowUnique)].Value.ToString());
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
                    if (rdViewXml.Checked) //xml ise
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
                    //servisten yenı faturaları cek db ye kaydet ve datagridde göster
                    gridArchiveUpdateList(Singl.archiveControllerGet.getArchiveListOnService(true));
                }
                else if (gridMenuType == nameof(EI.ArchiveReports.ArchiveReports))
                {
                    gridReportUpdateList(Singl.archiveControllerGet.getReportListOnService());
                }
                else //taslak  arsıv  faturaysa
                {
                    gridArchiveUpdateList(Singl.archiveControllerGet.getArchiveListOnService(false));
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
                                content = Singl.archiveControllerGet.getArchiveContentXml(tableArchiveGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.uuid)].Value.ToString(),
                                    tableArchiveGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.rowUnique)].Value.ToString());

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
            cancelArchive(false);
        }




        private void getArchiveState()
        {
            try
            {
                List<string> listUuid = new List<string>();

                foreach (DataGridViewRow row in tableArchiveGrid.SelectedRows)
                {
                    listUuid.Add(row.Cells[nameof(EI.Invoice.uuid)].Value.ToString());
                }

                EARCHIVE_INVOICE[] statusResArchiveArr = Singl.archiveControllerGet.getArchiveStatus(listUuid.ToArray());
                if (statusResArchiveArr != null)
                {
                    foreach (EARCHIVE_INVOICE arc in statusResArchiveArr)
                    {
                        Singl.archiveInvoiceDalGet.updateArchiveStatus(arc);
                    }

                    Singl.archiveInvoiceDalGet.dbSaveChanges();
                    string message = string.Join(Environment.NewLine, listUuid) + Environment.NewLine + Lang.noInvUpdated; //nolu faturalar guncellendi           
                    MessageBox.Show(message);
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
            getArchiveState();
        }





        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                string[] idArr = new string[tableArchiveGrid.SelectedRows.Count];
                string[] uuidArr = new string[tableArchiveGrid.SelectedRows.Count];

                for (int cntRow = 0; cntRow < tableArchiveGrid.SelectedRows.Count; cntRow++)
                {
                    idArr[cntRow] = tableArchiveGrid.SelectedRows[cntRow].Cells[nameof(EI.Invoice.ID)].Value.ToString();
                    uuidArr[cntRow] = tableArchiveGrid.SelectedRows[cntRow].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                }

                FrmSelectMail frmSelectMail = new FrmSelectMail(idArr);
                frmSelectMail.ShowDialog();

                if (frmSelectMail.DialogResult == DialogResult.OK)
                {
                    List<string> idSuccesedSendMail = new List<string>();
                    List<string> errorFailedIdMessage = new List<string>();

                    for (int cnt = 0; cnt < frmSelectMail.mailArr.Length; cnt++)
                    {
                        string responseErrorMessage = Singl.archiveControllerGet.sendArchiveMail(uuidArr[cnt], frmSelectMail.mailArr[cnt]);
                        if (responseErrorMessage == null) //return 0
                        {
                            idSuccesedSendMail.Add(uuidArr[cnt]);
                        }
                        else //islem basarısızsa
                        {
                            errorFailedIdMessage.Add(idArr[cnt] + "  " + responseErrorMessage);
                        }
                    }
                    if (idSuccesedSendMail.Count > 0) //basarılı olanları goster
                    {
                        MessageBox.Show(string.Join(Environment.NewLine, idSuccesedSendMail) + Environment.NewLine +Lang.hasIdInvoiceSendMail);//secılı faturalar basarıyla maıl gonderıldı
                    }
                    if (errorFailedIdMessage.Count > 0) //barasırız olanların error textını goster
                    {
                        MessageBox.Show(string.Join(Environment.NewLine, errorFailedIdMessage) + Environment.NewLine, Lang.operationFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            tableArchiveGrid.Columns[EI.ArchiveReports.ID.ToString()].HeaderText = Lang.id;

            tableArchiveGrid.Columns[EI.ArchiveReports.periodStart.ToString()].HeaderText = Lang.periodStart;

            tableArchiveGrid.Columns[EI.ArchiveReports.periodEnd.ToString()].HeaderText = Lang.periodEnd;

            tableArchiveGrid.Columns[EI.ArchiveReports.chapter.ToString()].HeaderText = Lang.chapter;

            tableArchiveGrid.Columns[EI.ArchiveReports.chapterStart.ToString()].HeaderText = Lang.chapterStart;

            tableArchiveGrid.Columns[EI.ArchiveReports.chapterEnd.ToString()].HeaderText = Lang.chapterEnd;

            tableArchiveGrid.Columns[EI.ArchiveReports.archiveInvCount.ToString()].HeaderText = Lang.archiveInvCount;

            tableArchiveGrid.Columns[EI.ArchiveReports.status.ToString()].HeaderText = Lang.reportState;

            tableArchiveGrid.Columns[EI.ArchiveReports.gibSendDate.ToString()].HeaderText = Lang.gibSendDate;

            tableArchiveGrid.Columns[EI.ArchiveReports.gibConfirmationDate.ToString()].HeaderText = Lang.gibConfirmationDate;

            tableArchiveGrid.Columns[EI.ArchiveReports.description.ToString()].HeaderText = Lang.description;

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
                    MessageBox.Show(string.Join(Environment.NewLine, listReportNoSucc) + Environment.NewLine +Lang.hasIdArchiveReportSave);//"secılı arsıv raporları basarıyla kaydedıldı"
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


        private void cancelArchive(bool isDraftArchive)
        {
            try
            {
                List<string> validRowUniqueList = new List<string>();
                List<string> unvalidList = new List<string>();

                //cancelcontentlıst dekı cancel contentlerı foreachle gecerken olusturuyoruz
                for (int cnt = 0; cnt < tableArchiveGrid.SelectedRows.Count; cnt++)
                {
                    //daha onceden ıptal edılmıs mı
                    if (tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.status)].Value != null && tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.status)].Value.ToString().Contains(nameof(EI.StateNote.IPTAL)))
                    {
                        unvalidList.Add(tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.ID)].Value.ToString());
                    }
                    else
                    {
                        //validse cancel contentlerı olustur 
                        Singl.archiveControllerGet.addContentCancelArcOnCancelContentArr(
                            tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString(),
                            tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.ID)].Value.ToString(), isDraftArchive);

                        //validse RowUnique yı kaydet
                        validRowUniqueList.Add(tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.rowUnique)].Value.ToString());
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

                //valid fatura varsa
                if (validRowUniqueList.Count != 0)
                {
                    string responseErrorMesage = Singl.archiveControllerGet.cancelEarchive();
                    if (responseErrorMesage == null) //return code 0 ise ,basarılı ıse
                    {
                        string succList = "";

                        //valid olanları db de status note iptal yap
                        foreach (string rowUnique in validRowUniqueList)
                        {
                            if (isDraftArchive)   //taslaksa db den sil
                            {
                                Singl.databaseContextGet.archiveInvoices.Remove(Singl.archiveInvoiceDalGet.findArchive(rowUnique));
                            }
                            else
                            {
                                Singl.archiveInvoiceDalGet.findArchive(rowUnique).stateNote = EI.StateNote.IPTAL.ToString();
                            }
                            List<string> idList = new List<string>();  //rowUniquiden id leri listele
                            idList.Add(rowUnique.Split('/').First());
                            succList = string.Join(Environment.NewLine, idList);
                        }

                        Singl.databaseContextGet.SaveChanges();
                        MessageBox.Show(succList + Environment.NewLine + Lang.succCancelSelectedInvoice);//secılı arsıv basarıyla iptal edildi
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





        private void btnCancelDraftArchive_Click(object sender, EventArgs e)
        {
            cancelArchive(true);
        }



        private void btnGetStateDraftArchive_Click(object sender, EventArgs e)
        {
            getArchiveState();
        }



        private void btnSendDraftArchive_Click(object sender, EventArgs e)
        {
            try
            {
                //db den getırılen serı Namelerı comboboxda sectır
                FrmDialogSelectItem frmDialogSelectSeriName = new FrmDialogSelectItem(true, "");
                if (frmDialogSelectSeriName.ShowDialog() == DialogResult.OK)
                {

                    string seriName = frmDialogSelectSeriName.selectedValue;

                    List<string> listArchiveContent = new List<string>();
                    List<string> listArchiveType = new List<string>();
                    List<string> listArchiverowUnique = new List<string>();

                    foreach (DataGridViewRow row in tableArchiveGrid.SelectedRows)
                    {
                        if (row.Cells[nameof(EI.Invoice.eArchiveType)].Value == null)
                        {
                            break;
                        }
                        listArchiveType.Add(row.Cells[nameof(EI.Invoice.eArchiveType)].Value.ToString());

                        string content = Singl.archiveControllerGet.getArchiveContentXml(row.Cells[nameof(EI.Invoice.uuid)].Value.ToString(), row.Cells[nameof(EI.Invoice.rowUnique)].Value.ToString());
                        listArchiveContent.Add(content);

                        listArchiverowUnique.Add(row.Cells[nameof(EI.Invoice.rowUnique)].Value.ToString());
                    }

                    if (listArchiveContent.Count > 0)
                    {
                        string responseErrorMessage = Singl.archiveControllerGet.sendEarchive(listArchiveContent.ToArray(), listArchiveType.ToArray(), seriName, Singl.userInformationDalGet.getUserInformation().mail);

                        if (responseErrorMessage != null)
                        {
                            MessageBox.Show(responseErrorMessage,Lang.operationFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            //db de fatura durumunu taslaktan cıkar
                            foreach (var rowUnique in listArchiverowUnique)
                            {
                                Singl.archiveInvoiceDalGet.findArchive(rowUnique).draftFlag = false;

                            }
                            Singl.databaseContextGet.SaveChanges();
                            MessageBox.Show(Lang.succesful);//"Başarılı"
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

                if (listUnvalidArchive.Count >0)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, listUnvalidArchive) + Environment.NewLine +Lang.noGetInvoice);//Seçili arsivler getirilemedi
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





    }
}
