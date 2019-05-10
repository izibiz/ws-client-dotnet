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


        private bool isArchive;



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

            itemArchiveInvoices.Text = Lang.eArchiveInvoices;
            btnFilterArchivesReport.Text = Lang.eArchiveReportList;
            itemArchiveNewCreated.Text = Lang.newInvoice;
            #endregion

        }






        private void gridArchiveChangeColoumnHeaderText()
        {
            tableArchiveGrid.Columns[EI.Invoice.ID.ToString()].HeaderText = Lang.id;

            tableArchiveGrid.Columns[EI.Invoice.uuid.ToString()].HeaderText = Lang.uuid;
            
            tableArchiveGrid.Columns[EI.Invoice.draftFlagDesc.ToString()].HeaderText = Lang.isDraftFlag;

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
                foreach (ArchiveInvoices arc in archiveList)
                {
                    if (arc.draftFlag.Equals(true))
                    {
                        arc.draftFlagDesc = Lang.yes;
                    }
                    else if (arc.draftFlag.Equals(false))
                    {
                        arc.draftFlagDesc = Lang.no;
                    }
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




        private void itemListArchiveInvoice_Click(object sender, EventArgs e)
        {

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
                if (isArchive)
                {
                    //servisten yenı faturaları cek db ye kaydet ve datagridde göster
                    gridArchiveUpdateList(Singl.archiveControllerGet.getArchiveListOnService());
                }
                else
                {
                    gridReportUpdateList(Singl.archiveControllerGet.getReportListOnService());
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
                if (isArchive)
                {
                    pnlArchive.Visible = true;
                    pnlArchiveReport.Visible = false;
                }
                else
                {
                    pnlArchive.Visible = false;
                    pnlArchiveReport.Visible = true;
                }
                #endregion

                try
                {
                    if (!isArchive) //rapor ıse
                    {
                        if (e.ColumnIndex == tableArchiveGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)].Index)
                        {
                            //diskte imzalı content var mı

                            //yoksa imzalı contentı getır
                            string content = Singl.archiveControllerGet.getArchiveReportXmlOnDisc(tableArchiveGrid.Rows[e.RowIndex].Cells[nameof(EI.ArchiveReports.reportNo)].Value.ToString());
                            if (content != null) //servisten veya dıskten getırlebılmısse
                            {
                                FrmView previewInvoices = new FrmView(content, nameof(EI.Invoice.ArchiveInvoices));
                                previewInvoices.ShowDialog();
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
                List<string> validRowUniqueList = new List<string>();

                //cancelcontentlıst dekı cancel contentlerı foreachle gecerken olusturuyoruz
                for (int cnt = 0; cnt < tableArchiveGrid.SelectedRows.Count; cnt++)
                {
                    //daha onceden cancel edılmemıs ıse
                    if (tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.stateNote)].Value == null || tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.stateNote)].Value.ToString() != nameof(EI.StateNote.CANCEL))
                    {
                        //validse cancel contentlerı olustur 
                        Singl.archiveControllerGet.addContentCancelArcOnCancelContentArr(tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString(), tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.ID)].Value.ToString());

                        //validse RowUnique yı kaydet
                        validRowUniqueList.Add(tableArchiveGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.rowUnique)].Value.ToString());
                    }
                }


                //valid fatura varsa
                if (validRowUniqueList.Count != 0)
                {
                    if (Singl.archiveControllerGet.cancelEarchive()) //return code 0 ise ,true ıse
                    {
                        string succList = "";
                        //valid olanları db de status note cancel yap
                        foreach (string rowUnique in validRowUniqueList)
                        {
                            Singl.archiveInvoiceDalGet.findArchive(rowUnique).stateNote = EI.StateNote.CANCEL.ToString();

                            List<string> idList = new List<string>();
                            idList.Add(rowUnique.Split('/').First());

                            succList = string.Join(Environment.NewLine, idList);
                        }
                        Singl.archiveInvoiceDalGet.dbSaveChanges();

                        MessageBox.Show(succList + Environment.NewLine + "secılı arsıv iptal edildi");
                    }
                    else
                    {
                        MessageBox.Show("islem basarısız");
                    }
                }
                else
                {
                    MessageBox.Show("daha onceden ıptal edılmıs bır fatura tekrar ıptal edılemez");
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
            try
            {
                List<string> listUuid = new List<string>();

                foreach (DataGridViewRow row in tableArchiveGrid.SelectedRows)
                {
                    listUuid.Add(row.Cells[nameof(EI.Invoice.uuid)].Value.ToString());
                }

                EARCHIVE_INVOICE[] archiveArr = Singl.archiveControllerGet.getArchiveStatus(listUuid.ToArray());
                if (archiveArr != null)
                {
                    //basarılı sekılde guncellenen faturaların uuıdlerını gostermek ıcın bunu temızlıyoruz
                    listUuid.Clear();

                    foreach (EARCHIVE_INVOICE arc in archiveArr)
                    {
                        if (arc.HEADER.STATUS != "200")
                        {
                            Singl.archiveInvoiceDalGet.updateArchiveStatus(arc);
                            listUuid.Add(arc.HEADER.INVOICE_ID);
                        }
                    }
                    Singl.archiveInvoiceDalGet.dbSaveChanges();
                    string message = string.Join(Environment.NewLine, listUuid) + Environment.NewLine + "secılı arsıv durumları guncellendi"; //nolu faturalar guncellendi           
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

                    for (int cnt = 0; cnt < frmSelectMail.mailArr.Length; cnt++)
                    {
                        if (Singl.archiveControllerGet.sendArchiveMail(uuidArr[cnt], frmSelectMail.mailArr[cnt])) //return 0
                        {
                            idSuccesedSendMail.Add(uuidArr[cnt]);
                        }
                    }
                    if (idSuccesedSendMail.Count > 0)
                    {
                        MessageBox.Show(string.Join(Environment.NewLine, idSuccesedSendMail) + Environment.NewLine + "secılı faturalar basarıyla maıl gonderıldı");
                    }
                    else
                    {
                        MessageBox.Show("basarısız");
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
            isArchive = true;
            btnTakeArchiveInv.Visible = true;
            pnlArchive.Visible = false;
            pnlArchiveReport.Visible = false;
            try
            {
                //db dekı raporlanmıs arsıv faturaları getır
                gridArchiveUpdateList(Singl.archiveInvoiceDalGet.getArchiveList());
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

        private void btnFilterArchivesReport_Click(object sender, EventArgs e)
        {
            pnlArchive.Visible = false;
            try
            {
                //db dekı raporlanmıs arsıv faturaları getır
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
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void itemGetReportList_Click(object sender, EventArgs e)
        {
            isArchive = false;
            btnTakeArchiveInv.Visible = true;
            pnlArchive.Visible = false;
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

        private void addViewReportButtonToDatagridView()
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
                addViewReportButtonToDatagridView();
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

                    string signedXmlContent = Singl.archiveControllerGet.getArchiveReportXmlOnDisc(reportNo);
                    if (signedXmlContent != null)
                    {
                        //contentı dıske yazdır
                        FolderControl.writeFileOnDiskWithString(signedXmlContent, FolderControl.inboxFolderArchiveReport + reportNo + "." + nameof(EI.DocumentType.XML));
                        listReportNoSucc.Add(row.Cells[nameof(EI.ArchiveReports.reportNo)].Value.ToString());
                    }
                }

                if (listReportNoSucc.Count > 0)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, listReportNoSucc) + Environment.NewLine + "secılı arsıv raporları basarıyla kaydedıldı");
                }
                else
                {
                    MessageBox.Show("islem basarısız");
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
