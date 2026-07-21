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
using izibiz.MODEL.Entities;
using izibiz.COMMON.FileControl;

namespace izibiz.UI
{
    public partial class FrmSelfEmployment : Form
    {

        private string gridMenuType;
        private string gridDirection;
        

        public FrmSelfEmployment()
        {
            InitializeComponent();
            try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
        }


        private Button btnRestListele;

        private void FrmSelfEmployment_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();

            // REST test butonu SOAP butonuyla uyumlu şekilde ekleniyor
            btnRestListele = new Button();
            btnRestListele.Text = "REST ile SMM Çek";
            btnRestListele.Size = btnTakeSmm.Size;
            btnRestListele.Location = new Point(btnTakeSmm.Location.X, btnTakeSmm.Location.Y + btnTakeSmm.Height + 10);
            btnRestListele.BackColor = btnTakeSmm.BackColor;
            btnRestListele.ForeColor = btnTakeSmm.ForeColor;
            btnRestListele.FlatStyle = btnTakeSmm.FlatStyle;
            btnRestListele.Font = btnTakeSmm.Font;
            btnRestListele.FlatAppearance.BorderColor = btnTakeSmm.FlatAppearance.BorderColor;
            btnRestListele.FlatAppearance.BorderSize = btnTakeSmm.FlatAppearance.BorderSize;
            btnRestListele.Click += BtnRestListele_Click;
            btnRestListele.Visible = false; // E-Smm menüsüne tıklanana kadar gizli
            this.Controls.Add(btnRestListele);
            btnRestListele.BringToFront();
        }

        private async void BtnRestListele_Click(object sender, EventArgs e)
        {
            try
            {
                var filter = new izibiz.REST.Models.Request.ListFilter
                {
                    Page = 1,
                    PageSize = 50
                };

                // REST API'ye istek at
                var result = await Singl.SmmClientGet.ListAsync(filter);

                // Grid'e bağlama
                tableGrid.DataSource = result.Contents;
                
                MessageBox.Show($"REST API'den başarıyla {result.Contents.Count} adet E-SMM çekildi!", "REST Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("REST API Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            this.Hide();
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



        private void gridSmmUpdateList(List<SelfEmploymentReceipts> smmList)
        {
            pnlSmm.Visible = false;
            pnlSmm.Visible = false;
            pnlDraftSmm.Visible = false;
            gridDirection = nameof(EI.Direction.IN);
            tableGrid.DataSource = null;
            tableGrid.Columns.Clear();

            if (smmList.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {

                addViewButtonToDatagridView();
                tableGrid.DataSource = smmList;
                dataGridChangeColumnHeaderText();

                //gridde taslak faturaları lısletemıyorsak
                
                tableGrid.Columns[nameof(EI.SelfEmploymentReceipt.isDraft)].Visible = false;
                tableGrid.Columns[nameof(EI.SelfEmploymentReceipt.statusCode)].Visible = false;
                tableGrid.Columns[nameof(EI.SelfEmploymentReceipt.status)].Visible = false;
                tableGrid.Columns[nameof(EI.SelfEmploymentReceipt.emailStatusCode)].Visible = false;
                tableGrid.Columns[nameof(EI.SelfEmploymentReceipt.folderPath)].Visible = false;


                IblInformation.Text = Lang.clickRowInvoice;
                IblInformation.Visible = true;

            }
        }

        private void dataGridChangeColumnHeaderText()
        {

            tableGrid.Columns[EI.SelfEmploymentReceipt.status.ToString()].HeaderText = Lang.status;


            tableGrid.Columns[EI.SelfEmploymentReceipt.uuid.ToString()].HeaderText = Lang.uuid;

            tableGrid.Columns[EI.SelfEmploymentReceipt.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableGrid.Columns[EI.SelfEmploymentReceipt.profileID.ToString()].HeaderText = Lang.profileid;

            tableGrid.Columns[EI.SelfEmploymentReceipt.cDate.ToString()].HeaderText = Lang.cDate;

            tableGrid.Columns[EI.SelfEmploymentReceipt.customerTitle.ToString()].HeaderText = Lang.customerTitle;

            tableGrid.Columns[EI.SelfEmploymentReceipt.statusDesc.ToString()].HeaderText = Lang.statusDesc;
        }





        private void BtnTakeSmm_Click(object sender, EventArgs e)
        {
            pnlSmm.Visible = false;
            pnlDraftSmm.Visible = false;
            pnlSmmReports.Visible = false;

            try
            {

                string errorMessage = Singl.smmControllerGet.getSmmListOnServiceAndSaveDb();

                if (errorMessage == null)
                {
                    gridSmmUpdateList(Singl.smmDalGet.getSmmWithDraft(false));
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




        private void ItemGetSmm_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.SelfEmploymentReceipt.SelfEmploymentReceipts.ToString();

            btnTakeSmm.Visible = true;
            if (btnRestListele != null) btnRestListele.Visible = true;
            pnlSmm.Visible = false;
            pnlDraftSmm.Visible = false;
            pnlSmmReports.Visible = false;

            try
            {
                gridSmmUpdateList(Singl.smmDalGet.getSmmWithDraft(false));


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

            btnTakeSmm.Visible = false;
            pnlSmm.Visible = false;
            pnlDraftSmm.Visible = false;
            pnlSmmReports.Visible = false;

            try
            {

                gridSmmUpdateList(Singl.smmDalGet.getSmmWithDraft(true));

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

        private async void TableGrid_CellClick(object sender, DataGridViewCellEventArgs e)
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
                    btnTakeSmm.Visible = false;
                    if (btnRestListele != null) btnRestListele.Visible = false;
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
                            var boundItem = tableGrid.Rows[e.RowIndex].DataBoundItem;
                            if (boundItem is izibiz.REST.Concrete.Smm.SmmListItem restItem)
                            {
                                // Turuncu buton = Ekranda GİB formatlı orijinal önizleme için UBL'i (XML) çekip XSLT'ye sokuyoruz
                                var xmlResult = await Singl.SmmClientGet.DownloadAsync(new System.Collections.Generic.List<string> { restItem.Id.ToString() }, "ubl");
                                byte[] xmlBytes = System.Linq.Enumerable.FirstOrDefault(xmlResult.Values);
                                string content = System.Text.Encoding.UTF8.GetString(xmlBytes);
                                FrmView previewInvoices = new FrmView(content, nameof(EI.SelfEmploymentReceipt.SelfEmploymentReceipts), isHtml: false); 
                                previewInvoices.ShowDialog();
                            }
                            else
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

        private void pnlDraftSmm_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnCreditNoteView_Click(object sender, EventArgs e)
        {

            try
            {
                var boundItem = tableGrid.SelectedRows[0].DataBoundItem;
                if (boundItem is izibiz.REST.Concrete.Smm.SmmListItem restItem)
                {
                    string format = "pdf";
                    if (rdViewHtml.Checked) format = "html";
                    else if (rdViewXml.Checked) format = "xml";

                    if (format == "html")
                    {
                        // HTML seçiliyse = Ekranda GİB formatlı orijinal önizleme için UBL'i (XML) çekip XSLT'ye sokuyoruz
                        var xmlResult = await Singl.SmmClientGet.DownloadAsync(new System.Collections.Generic.List<string> { restItem.Id.ToString() }, "ubl");
                        byte[] xmlBytes = System.Linq.Enumerable.FirstOrDefault(xmlResult.Values);
                        string strContent = System.Text.Encoding.UTF8.GetString(xmlBytes);
                        FrmView previewInvoices = new FrmView(strContent, nameof(EI.SelfEmploymentReceipt.SelfEmploymentReceipts), isHtml: false);
                        previewInvoices.ShowDialog();
                    }
                    else
                    {
                        // PDF veya UBL seçiliyse = diske kaydet = POST /download
                        var downloadResult = await Singl.SmmClientGet.DownloadAsync(new System.Collections.Generic.List<string> { restItem.Id.ToString() }, format);
                        byte[] downloadBytes = System.Linq.Enumerable.FirstOrDefault(downloadResult.Values);
                        string ext = format == "xml" ? ".xml" : ".pdf";
                        string path = FolderControl.smmFolderPath + restItem.Uuid + ext;
                        FolderControl.writeFileOnDiskWithByte(downloadBytes, path);
                        System.Diagnostics.Process.Start(path);
                    }
                    return; // REST işlemi bitti, SOAP koduna geçme
                }

                string uuid = tableGrid.SelectedRows[0].Cells[nameof(EI.SelfEmploymentReceipt.uuid)].Value.ToString();
                CONTENT_TYPE docType = CONTENT_TYPE.XML;

                if (rdViewHtml.Checked) //html
                {
                    string xmlContent = Singl.smmControllerGet.getSmmContentXml(uuid);
                    if (xmlContent != null)
                    {
                        FrmView previewInvoices = new FrmView(xmlContent, nameof(EI.SelfEmploymentReceipt.SelfEmploymentReceipts));
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
                    byte[] content = Singl.smmControllerGet.getSmmWithType(uuid, docType);
                    if (content != null)
                    {
                        string path = FolderControl.smmFolderPath + uuid + "." + docType;
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

        private void tableGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
