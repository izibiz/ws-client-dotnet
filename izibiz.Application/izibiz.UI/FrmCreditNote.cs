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
using izibiz.UI.Controls;

namespace izibiz.UI
{
    public partial class FrmCreditNote : Form
    {

        private string gridMenuType;
        private string gridDirection;

        private const int SidebarExpandedWidth = 256;
        private const int SidebarCollapsedWidth = 88;
        private bool _sidebarCollapsed = false;
        private Timer _sidebarAnimTimer;
        private int _sidebarTargetWidth;




        public FrmCreditNote()
        {
            InitializeComponent();
            try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
        }


        private void FrmCreditNote_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();

            RoundedPathHelper.ApplyRoundedRegion(btnHomePage, 38);
            btnHomePage.BackgroundImage = Properties.Resources.izibizLogo;
            btnHomePage.BackgroundImageLayout = ImageLayout.Zoom;

            // Removed custom icon assignment to use the application default

            sourceCardSoap.FetchClicked += BtnTakeCreditNote_Click;
            sourceCardRest.FetchClicked += BtnRestListele_Click;
            documentActionsCard1.ViewRequested += DocumentActionsCard1_ViewRequested;
            documentActionsCard1.DownloadRequested += DocumentActionsCard1_DownloadRequested;

            SetupSidebarHoverEffects();
            UpdateEmptyState();

            ArrangeResponsiveLayout();
            // Maximized durumuna geçiş Load anında henüz tamamlanmamış olabiliyor;
            // gerçek pencere boyutu netleştikten sonra bir kez daha hesapla.
            this.BeginInvoke(new MethodInvoker(ArrangeResponsiveLayout));
        }

        private void SetupSidebarHoverEffects()
        {
            HoverAnimator.Attach(btnHamburger, BrandColors.SidebarDark, BrandColors.SidebarHover);
            foreach (var navBtn in new[] { btnNavMustahsil, btnNavDraft, btnNavReports, btnNavNew })
            {
                HoverAnimator.Attach(navBtn, BrandColors.SidebarDark, BrandColors.SidebarHover);
            }
        }

        /// <summary>
        /// Hamburger butonu: sidebar'ı animasyonlu şekilde daraltır/genişletir.
        /// Öğe sayısı arttıkça (yeni menü eklendikçe) daraltılmış hâl yer kazandırır.
        /// </summary>
        private void BtnHamburger_Click(object sender, EventArgs e)
        {
            _sidebarCollapsed = !_sidebarCollapsed;
            _sidebarTargetWidth = _sidebarCollapsed ? SidebarCollapsedWidth : SidebarExpandedWidth;

            foreach (var navBtn in new[] { btnNavMustahsil, btnNavDraft, btnNavReports, btnNavNew })
            {
                if (_sidebarCollapsed)
                {
                    navBtn.Text = navBtn.Text.Substring(0, 1);
                    navBtn.TextAlign = ContentAlignment.MiddleCenter;
                    navBtn.Padding = new Padding(0);
                    navBtn.Width = SidebarCollapsedWidth - 32;
                }
                else
                {
                    navBtn.Text = (string)navBtn.Tag;
                    navBtn.TextAlign = ContentAlignment.MiddleLeft;
                    navBtn.Padding = new Padding(20, 0, 0, 0);
                    navBtn.Width = SidebarExpandedWidth - 32;
                }
            }

            if (_sidebarAnimTimer == null)
            {
                _sidebarAnimTimer = new Timer { Interval = 10 };
                _sidebarAnimTimer.Tick += SidebarAnimTimer_Tick;
            }
            _sidebarAnimTimer.Start();
        }

        private void SidebarAnimTimer_Tick(object sender, EventArgs e)
        {
            int diff = _sidebarTargetWidth - pnlSidebar.Width;
            if (Math.Abs(diff) <= 4)
            {
                pnlSidebar.Width = _sidebarTargetWidth;
                _sidebarAnimTimer.Stop();
            }
            else
            {
                pnlSidebar.Width += diff / 3;
            }

            btnHamburger.Location = new Point(pnlSidebar.Width - 60, 24);
            ArrangeResponsiveLayout();
        }

        /// <summary>
        /// Grid'de veri yoksa (henüz çekilmediyse) büyük boş bir beyazlık yerine
        /// ikon + açıklama içeren bir "boş durum" mesajı gösterir.
        /// </summary>
        private void UpdateEmptyState()
        {
            bool isEmpty = tableGrid.Rows.Count == 0;
            lblEmptyIcon.Visible = isEmpty;
            lblEmptyText.Visible = isEmpty;
        }

        /// <summary>
        /// Pencere yeniden boyutlandırıldığında SOAP/REST kartlarını yatayda yeniden ortalar,
        /// grid ve Görüntüleme kartını pencerenin sağ kenarına kadar (küçük bir boşluk bırakarak) genişletir.
        /// </summary>
        private void FrmCreditNote_Resize(object sender, EventArgs e)
        {
            ArrangeResponsiveLayout();
            this.Invalidate();
        }

        private void ArrangeResponsiveLayout()
        {
            int contentLeft = pnlSidebar.Width + 35;
            const int rightMargin = 30;
            const int cardWidth = 280;
            const int cardGap = 30;
            const int pairWidth = cardWidth * 2 + cardGap;

            int contentWidth = this.ClientSize.Width - contentLeft - rightMargin;
            if (contentWidth < pairWidth)
            {
                contentWidth = pairWidth;
            }

            // SOAP/REST kartlarını yatayda ortala.
            int startX = contentLeft + (contentWidth - pairWidth) / 2;
            sourceCardSoap.Location = new Point(startX, sourceCardSoap.Top);
            sourceCardRest.Location = new Point(startX + cardWidth + cardGap, sourceCardRest.Top);

            // Görüntüleme kartı ve grid'i pencerenin sağına kadar (küçük bir boşluk bırakarak) uzat.
            documentActionsCard1.Location = new Point(contentLeft, documentActionsCard1.Top);
            documentActionsCard1.Width = contentWidth;
            tableGrid.Location = new Point(contentLeft, tableGrid.Top);
            tableGrid.Width = contentWidth;
            lblInformation.Location = new Point(contentLeft + 3, lblInformation.Top);
            lblEmptyIcon.Location = new Point(contentLeft, lblEmptyIcon.Top);
            lblEmptyIcon.Width = contentWidth;
            lblEmptyText.Location = new Point(contentLeft, lblEmptyText.Top);
            lblEmptyText.Width = contentWidth;
        }

        private async void BtnRestListele_Click(object sender, EventArgs e)
        {
            try
            {
                var filter = new izibiz.REST.Models.Request.ListFilter { Page = 1, PageSize = 50 };
                var result = await Singl.MustahsilClientGet.ListAsync(filter);

                tableGrid.DataSource = result.Contents;
                UpdateEmptyState();

                gridMenuType = EI.CreditNote.CreditNotes.ToString();
                documentActionsCard1.Visible = true;

                MessageBox.Show($"REST API'den başarıyla {result.Contents.Count} adet E-Müstahsil çekildi!", "REST Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            documentActionsCard1.Visible = false;
            gridDirection = nameof(EI.Direction.IN);
            tableGrid.DataSource = null;
            tableGrid.Columns.Clear();
            UpdateEmptyState();

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
                UpdateEmptyState();
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
            documentActionsCard1.Visible = false;

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

            sourceCardSoap.FetchButtonVisible = true;
            sourceCardRest.FetchButtonVisible = true;
            documentActionsCard1.Visible = false;

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
            sourceCardSoap.FetchButtonVisible = false;
            documentActionsCard1.Visible = false;

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

            sourceCardSoap.FetchButtonVisible = true;
            documentActionsCard1.Visible = false;

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
                documentActionsCard1.Visible = (gridMenuType == EI.CreditNote.CreditNotes.ToString());

                try
                {

                    if (tableGrid.Columns.Contains(nameof(EI.GridBtnClmName.previewHtml))
                        && e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)].Index)
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

        /// <summary>
        /// Görüntüle: seçili formatı (pdf/html) kalıcı dosya bırakmadan önizler. XML görüntülenemez, sadece indirilebilir.
        /// </summary>
        private async void DocumentActionsCard1_ViewRequested(object sender, DocumentActionEventArgs e)
        {
            try
            {
                var boundItem = tableGrid.SelectedRows[0].DataBoundItem;
                if (boundItem is izibiz.REST.Concrete.Mustahsil.MustahsilListItem restItem)
                {
                    if (e.Format == "xml")
                    {
                        MessageBox.Show("XML formatı sadece indirilebilir, önizleme desteklenmiyor. Lütfen \"İndir\" butonunu kullanın.");
                        return;
                    }

                    if (e.Format == "html")
                    {
                        // Ekranda önizleme: hiçbir şey diske yazılmıyor.
                        byte[] xmlBytes = await Singl.MustahsilClientGet.DownloadAsync(restItem.Id.ToString(), "ubl");
                        string strContent = System.Text.Encoding.UTF8.GetString(xmlBytes);
                        FrmView previewInvoices = new FrmView(strContent, nameof(EI.CreditNote.CreditNotes), isHtml: false);
                        previewInvoices.ShowDialog();
                    }
                    else
                    {
                        // PDF önizleme: geçici klasöre yazılır, kalıcı bir indirme sayılmaz.
                        byte[] pdfBytes = await Singl.MustahsilClientGet.DownloadAsync(restItem.Id.ToString(), "pdf");
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), restItem.Uuid + ".pdf");
                        FolderControl.writeFileOnDiskWithByte(pdfBytes, tempPath);
                        System.Diagnostics.Process.Start(tempPath);
                    }
                    return;
                }

                string uuid = tableGrid.SelectedRows[0].Cells[nameof(EI.CreditNote.uuid)].Value.ToString();
                CONTENT_TYPE docType = CONTENT_TYPE.XML;

                if (e.Format == "html")
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
                else
                {
                    docType = e.Format == "xml" ? CONTENT_TYPE.XML : CONTENT_TYPE.PDF;

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

        /// <summary>
        /// İndir: seçili formatı (pdf/html/xml) kalıcı olarak diske kaydeder ve açar.
        /// </summary>
        private async void DocumentActionsCard1_DownloadRequested(object sender, DocumentActionEventArgs e)
        {
            try
            {
                var boundItem = tableGrid.SelectedRows[0].DataBoundItem;
                if (boundItem is izibiz.REST.Concrete.Mustahsil.MustahsilListItem restItem)
                {
                    // API'de "xml" diye ayrı bir indirme formatı yok, XML içerik "ubl" formatı üzerinden geliyor.
                    // Kullanıcıya hâlâ "xml" gösteriyoruz, dosyayı da .xml uzantısıyla kaydediyoruz.
                    string apiFormat = e.Format == "xml" ? "ubl" : e.Format;

                    byte[] downloadBytes = await Singl.MustahsilClientGet.DownloadAsync(restItem.Id.ToString(), apiFormat);
                    string path = FolderControl.CreditNoteFolderPath + restItem.Uuid + "." + e.Format;
                    FolderControl.writeFileOnDiskWithByte(downloadBytes, path);
                    System.Diagnostics.Process.Start(path);

                    MessageBox.Show($"Belge indirildi: {path}", "İndirme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İndirme özelliği şu an sadece REST verileri için kullanılabilir.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İndirme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
