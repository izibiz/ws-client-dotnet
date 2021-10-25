using izibiz.COMMON;
using izibiz.COMMON.Language;
using izibiz.CONTROLLER.Singleton;
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
using izibiz.MODEL.Entities;
using izibiz.SERVICES.serviceCreditNote;
using izibiz.COMMON.FileControl;

namespace izibiz.UI
{
    public partial class FrmCreditNote : Form
    {

        private string gridMenuType;
        private string gridDirection;




        public FrmCreditNote()
        {
            InitializeComponent();
        }


        private void FrmCreditNote_Load(object sender, EventArgs e)
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

            #endregion

        }




        private void BtnHomePage_Click(object sender, EventArgs e)
        {
            FrmHome frmHome = new FrmHome();
            frmHome.Show();
            this.Dispose();
        }



        private void addViewButtonToDatagridView()
        {
            tableGrid.Columns.Clear();
            //html goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconHtml,
                Name = EI.GridBtnClmName.previewHtml.ToString(),
                HeaderText = Lang.preview,
            });
        }



        private void gridCreditNoteUpdateList(List<CreditNotes> CreditNoteList)
        {
            pnlCreditNote.Visible = false;
            pnlCreditNoteReports.Visible = false;
            pnlDraftCreditNote.Visible = false;
            gridDirection = nameof(EI.Direction.IN);
            tableGrid.DataSource = null;
            tableGrid.Columns.Clear();

            if (CreditNoteList.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                foreach (CreditNotes inv in CreditNoteList)
                {
                    
                    if (inv.isDraft != null)
                    {
                        if (inv.isDraft.Equals(nameof(EI.ActiveOrPasive.Y)))
                        {
                            inv.draftDesc = Lang.yes;
                        }
                        else if (inv.isDraft.Equals(nameof(EI.ActiveOrPasive.N)))
                        {
                            inv.draftDesc = Lang.no;
                        }
                    }
                }

                addViewButtonToDatagridView();
                tableGrid.DataSource = CreditNoteList;
                dataGridChangeColumnHeaderText();

                //gridde taslak faturaları lısletemıyorsak
                if (!gridDirection.Equals(nameof(EI.Direction.DRAFT)))
                {
                    tableGrid.Columns[nameof(EI.CreditNote.draftDesc)].Visible = false;
                }
                tableGrid.Columns[nameof(EI.CreditNote.isDraft)].Visible = false;
                tableGrid.Columns[nameof(EI.CreditNote.statusCode)].Visible = false;
                tableGrid.Columns[nameof(EI.CreditNote.status)].Visible = false;
                tableGrid.Columns[nameof(EI.CreditNote.emailStatusCode)].Visible = false;
                tableGrid.Columns[nameof(EI.CreditNote.folderPath)].Visible = false;


                lblInformation.Text = Lang.clickRowInvoice;
                lblInformation.Visible = true;

            }
        }

        private void dataGridChangeColumnHeaderText()
        {

            tableGrid.Columns[EI.CreditNote.status.ToString()].HeaderText = Lang.status;


            tableGrid.Columns[EI.CreditNote.uuid.ToString()].HeaderText = Lang.uuid;

            tableGrid.Columns[EI.CreditNote.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableGrid.Columns[EI.CreditNote.profileId.ToString()].HeaderText = Lang.profileid;

            tableGrid.Columns[EI.CreditNote.cDate.ToString()].HeaderText = Lang.cDate;

            tableGrid.Columns[EI.CreditNote.draftDesc.ToString()].HeaderText = Lang.fromPortal;

            tableGrid.Columns[EI.CreditNote.customerTitle.ToString()].HeaderText = Lang.customerTitle;

            tableGrid.Columns[EI.CreditNote.CreditNoteID.ToString()].HeaderText = Lang.creditNoteID;

            tableGrid.Columns[EI.CreditNote.customerIdentifier.ToString()].HeaderText = Lang.vknTckn;

            tableGrid.Columns[EI.CreditNote.statusDesc.ToString()].HeaderText = Lang.statusDesc;

        }




        private void BtnTakeCreditNote_Click(object sender, EventArgs e)
        {
            pnlCreditNote.Visible = false;
            pnlDraftCreditNote.Visible = false;
            pnlCreditNoteReports.Visible = false;

            try
            {

                string errorMessage = Singl.creditNoteControllerGet.getCreditNoteListOnServiceAndSaveDb();

                if (errorMessage == null)
                {
                    gridCreditNoteUpdateList(Singl.creditNotesDalGet.getCreditNoteWithDraft(false));
                }
                else
                {
                    MessageBox.Show(errorMessage);
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




        private void ItemGetCreditNote_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.CreditNote.CreditNotes.ToString();

            btnTakeCreditNote.Visible = true;
            pnlCreditNote.Visible = false;
            pnlDraftCreditNote.Visible = false;
            pnlCreditNoteReports.Visible = false;

            try
            {
                gridCreditNoteUpdateList(Singl.creditNotesDalGet.getCreditNoteWithDraft(false));


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

        private void ItemGetDraftCreditNote_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.CreditNote.draftCreditNote.ToString();
            gridDirection = nameof(EI.Direction.DRAFT);
            btnTakeCreditNote.Visible = false;
            pnlCreditNote.Visible = false;
            pnlDraftCreditNote.Visible = false;
            pnlCreditNoteReports.Visible = false;

            try
            {

                gridCreditNoteUpdateList(Singl.creditNotesDalGet.getCreditNoteWithDraft(true));

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

        private void ItemGetCreditNoteReports_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.CreditNote.CreditNotes.ToString();

            btnTakeCreditNote.Visible = true;
            pnlCreditNote.Visible = false;
            pnlDraftCreditNote.Visible = false;
            pnlCreditNoteReports.Visible = false;

            try
            {
                //db dekı raporlanmıs arsıv faturaları getır



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

        private void TableGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                #region panelVisiblity
                if (gridMenuType == EI.CreditNote.CreditNotes.ToString())//CreditNote
                {
                    pnlCreditNote.Visible = true;
                    pnlCreditNoteReports.Visible = false;
                    pnlDraftCreditNote.Visible = false;

                }
                else if (gridMenuType == EI.CreditNote.CreditNotes.ToString()) //CreditNotes
                {
                    pnlCreditNote.Visible = false;
                    pnlCreditNoteReports.Visible = true;
                    pnlDraftCreditNote.Visible = false;
                }
                else //taslak CreditNote
                {
                    pnlCreditNote.Visible = false;
                    pnlCreditNoteReports.Visible = false;
                    pnlDraftCreditNote.Visible = true;
                }
                #endregion

                try
                {

                    if (e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)].Index)
                    {

                        // imzalı contentı getır
                        if (gridMenuType.Equals(nameof(EI.CreditNote.creditNoteReports))) //CreditNote raporlarında  ıse
                        {


                            ////burayı ekle
                            ///





                        }
                        else  //CreditNote  veya taslak CreditNotede ıse
                        {
                            string content = Singl.creditNoteControllerGet.getCreditNotesContentXml(tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.uuid)].Value.ToString());

                            if (content != null) //servisten veya dıskten getırlebılmısse
                            {
                                FrmView previewInvoices = new FrmView(content, nameof(EI.CreditNote.CreditNotes)); //taslak fatura olsa turu arsıvdır
                                previewInvoices.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show(Lang.cantGetContent);//content dıskten sılınmıs ve servısten getırılemedı
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
      


        private void tableGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlCreditNotes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlCreditNote_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnArchiveView_Click(object sender, EventArgs e)
        {
            
                try
                {
                    string uuid = tableGrid.SelectedRows[0].Cells[nameof(EI.CreditNote.uuid)].Value.ToString();
                    CONTENT_TYPE docType = CONTENT_TYPE.XML;

                    if (rdViewHtml.Checked) //html
                    {
                        string xmlContent = Singl.creditNoteControllerGet.getCreditNotesContentXml(uuid);
                        if (xmlContent != null)
                        {
                            FrmView previewInvoices = new FrmView(xmlContent, nameof(EI.CreditNote.CreditNotes));
                            previewInvoices.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show(Lang.cantGetContent);//content dıskten sılınmıs ve servısten getırılemedı
                        }
                    }
                    else  //html degılse
                    {
                        if (rdViewXml.Checked) // xml ise
                        {
                            docType = CONTENT_TYPE.XML; 
                        }
                        else //hicbirini secmezse pdf  görüntülenecektır
                        {
                            docType = CONTENT_TYPE.PDF;
                        }
                        /////////////
                        byte[] content = Singl.creditNoteControllerGet.getCreditNoteWithType(uuid, docType);
                        if (content != null)
                        {
                            string path = FolderControl.CreditNoteFolderPath + uuid + "." + docType;
                            FolderControl.writeFileOnDiskWithByte(content, path);
                            System.Diagnostics.Process.Start(path);
                        }
                        else
                        {
                            MessageBox.Show(Lang.cantGetContent);//content dıskten sılınmıs ve servısten getırılemedı
                        }
                    }
                }
                catch (FaultException<SERVICES.serviceCreditNote.REQUEST_ERRORType> ex)  //archive req error
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
