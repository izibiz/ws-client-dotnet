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
using izibiz.SERVICES.serviceSmm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace izibiz.UI
{
    public partial class FrmSelfEmployment : Form
    {

        private string gridMenuType;




        public FrmSelfEmployment()
        {
            InitializeComponent();
        }


        private void FrmSelfEmployment_Load(object sender, EventArgs e)
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



        //private void gridArchiveUpdateList(List<ArchiveInvoices> archiveList)
        //{
        //    pnlSmm.Visible = false;
        //    pnlSmmReports.Visible = false;
        //    pnlDraftSmm.Visible = false;

        //    tableGrid.DataSource = null;
        //    tableGrid.Columns.Clear();

        //    if (archiveList.Count == 0)
        //    {
        //        MessageBox.Show(Lang.noShowInvoice);
        //    }
        //    else
        //    {

        //        foreach (ArchiveInvoices arc in archiveList)
        //        {
        //            if (arc.reportFlag)
        //            {
        //                arc.reportFlagDesc = Lang.yes;
        //            }
        //            else
        //            {
        //                arc.reportFlagDesc = Lang.no;
        //            }
        //        }

        //        tableGrid.DataSource = archiveList;
        //        gridArchiveChangeColoumnHeaderText();

        //        tableArchiveGrid.Columns[nameof(EI.Invoice.reportFlag)].Visible = false;
        //        tableArchiveGrid.Columns[nameof(EI.Invoice.draftFlag)].Visible = false;
        //        tableArchiveGrid.Columns[nameof(EI.Invoice.stateNote)].Visible = false;
        //        tableArchiveGrid.Columns[nameof(EI.Invoice.folderPath)].Visible = false;

        //        if (gridMenuType == EI.Invoice.DraftArchive.ToString()) //taslak ıse
        //        {
        //            tableGrid.Columns[nameof(EI.Invoice.reportFlagDesc)].Visible = false;
        //        }
        //    }
        //}





        private void BtnTakeSmm_Click(object sender, EventArgs e)
        {
            pnlSmm.Visible = false;
            pnlDraftSmm.Visible = false;
            pnlSmmReports.Visible = false;

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




        private void ItemGetSmm_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.SelfEmploymentReceipt.SelfEmploymentReceipts.ToString();

            btnTakeSmm.Visible = true;
            pnlSmm.Visible = false;
            pnlDraftSmm.Visible = false;
            pnlSmmReports.Visible = false;

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

        private void ItemGetDraftSmm_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.SelfEmploymentReceipt.draftSmm.ToString();

            btnTakeSmm.Visible = true;
            pnlSmm.Visible = false;
            pnlDraftSmm.Visible = false;
            pnlSmmReports.Visible = false;

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

        private void ItemGetSmmReports_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.SmmReports.SmmReports.ToString();

            btnTakeSmm.Visible = true;
            pnlSmm.Visible = false;
            pnlDraftSmm.Visible = false;
            pnlSmmReports.Visible = false;

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
                if (gridMenuType == EI.SelfEmploymentReceipt.SelfEmploymentReceipts.ToString())//smm
                {
                    pnlSmm.Visible = true;
                    pnlSmmReports.Visible = false;
                    pnlDraftSmm.Visible = false;

                }
                else if (gridMenuType == EI.SmmReports.SmmReports.ToString()) //smm report
                {
                    pnlSmm.Visible = false;
                    pnlSmmReports.Visible = true;
                    pnlDraftSmm.Visible = false;
                }
                else //taslak smm
                {
                    pnlSmm.Visible = false;
                    pnlSmmReports.Visible = false;
                    pnlDraftSmm.Visible = true;
                }
                #endregion

                try
                {

                    if (e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)].Index)
                    {

                        // imzalı contentı getır
                        if (gridMenuType.Equals(nameof(EI.SmmReports.SmmReports))) //smm raporlarında  ıse
                        {


                            ////burayı ekle
                            ///





                        }
                        else  //smm  veya taslak smmde ıse
                        {
                            string content = Singl.smmControllerGet.getSmmContentXml(tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.uuid)].Value.ToString());

                            if (content != null) //servisten veya dıskten getırlebılmısse
                            {
                                FrmView previewInvoices = new FrmView(content, nameof(EI.SelfEmploymentReceipt.SelfEmploymentReceipts)); //taslak fatura olsa turu arsıvdır
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
    }
}
