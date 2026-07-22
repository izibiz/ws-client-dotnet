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

        private const int SidebarExpandedWidth = 340;
        private const int SidebarCollapsedWidth = 64;
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

            RoundedPathHelper.ApplyRoundedRegion(btnHomePage, 14);
            btnHomePage.BackgroundImage = Properties.Resources.izibizLogoFull;
            btnHomePage.BackgroundImageLayout = ImageLayout.Zoom;

            // Removed custom icon assignment to use the application default

            sourceCardSoap.FetchClicked += BtnTakeCreditNote_Click;
            sourceCardRest.FetchClicked += BtnRestListele_Click;
            documentActionsCard1.ViewRequested += DocumentActionsCard1_ViewRequested;
            documentActionsCard1.DownloadRequested += DocumentActionsCard1_DownloadRequested;
            documentActionsCard1.CancelRequested += DocumentActionsCard1_CancelRequested;

            SetupSidebarHoverEffects();

            // Kullanıcı soldaki menüden seçmedikçe listeleme yapma.
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
                RoundedPathHelper.ApplyRoundedRegion(navBtn, 10);
            }
        }

        /// <summary>
        /// Hamburger butonu: sidebar'ı animasyonlu şekilde daraltır/genişletir.
        /// İçerik (logo, menü yazıları) hiçbir zaman küçültülmez/kısaltılmaz; sadece
        /// panel dar durumdayken gizlenir, tam genişliğe ulaşınca geri gösterilir.
        /// (İçeriği panel hâlâ dar iken göstermek, logonun taşmış gibi görünmesine sebep oluyordu.)
        /// </summary>
        private void BtnHamburger_Click(object sender, EventArgs e)
        {
            _sidebarCollapsed = !_sidebarCollapsed;
            _sidebarTargetWidth = _sidebarCollapsed ? SidebarCollapsedWidth : SidebarExpandedWidth;

            if (_sidebarCollapsed)
            {
                SetSidebarContentVisible(false);
            }

            // Animasyon sırasında grid titremesini önlemek için sütun oto-boyutlandırmayı geçici olarak durdur
            tableGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            if (_sidebarAnimTimer == null)
            {
                _sidebarAnimTimer = new Timer { Interval = 10 };
                _sidebarAnimTimer.Tick += SidebarAnimTimer_Tick;
            }
            _sidebarAnimTimer.Start();
        }

        private void SetSidebarContentVisible(bool visible)
        {
            btnHomePage.Visible = visible;
            foreach (var navBtn in new[] { btnNavMustahsil, btnNavDraft, btnNavReports, btnNavNew })
            {
                navBtn.Visible = visible;
            }
        }

        private void SidebarAnimTimer_Tick(object sender, EventArgs e)
        {
            int diff = _sidebarTargetWidth - pnlSidebar.Width;
            if (Math.Abs(diff) <= 4)
            {
                pnlSidebar.Width = _sidebarTargetWidth;
                _sidebarAnimTimer.Stop();

                if (!_sidebarCollapsed)
                {
                    SetSidebarContentVisible(true);
                }

                // Animasyon bittiğinde sütun boyutlandırmayı eski haline (Fill) getir
                tableGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ArrangeResponsiveLayout();
            }
            else
            {
                pnlSidebar.Width += diff / 3;
                btnHamburger.Location = new Point(pnlSidebar.Width - 60, 24);
                ArrangeResponsiveLayout();
            }
        }

        /// <summary>
        /// Grid'de veri yoksa (henüz çekilmediyse) büyük boş bir beyazlık yerine
        /// ikon + açıklama içeren bir "boş durum" mesajı gösterir.
        /// </summary>
        private void UpdateEmptyState()
        {
            bool isEmpty = tableGrid.Rows.Count == 0;
            lblEmptyIcon.Visible = isEmpty;
            lblEmptyText.Visible = false;
            tableGrid.Visible = !isEmpty;
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
            const int cardWidth = 340;
            const int cardGap = 40;
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
            int emptyCenterY = tableGrid.Top + (tableGrid.Height / 2) - (lblEmptyIcon.Height / 2);
            lblEmptyIcon.Location = new Point(contentLeft, emptyCenterY);
            lblEmptyIcon.Width = contentWidth;
            lblEmptyText.Location = new Point(contentLeft, lblEmptyText.Top);
            lblEmptyText.Width = contentWidth;
        }

        private async void BtnRestListele_Click(object sender, EventArgs e)
        {
            try
            {
                // Taslak ekranındaysak REST'in ayrı "draft" endpoint'ini kullanıyoruz;
                // /outbox endpoint'i taslak/numara atandı durumundaki belgeleri hiç döndürmüyor.
                bool isDraftContext = gridMenuType == EI.CreditNote.draftCreditNote.ToString();

                // API sayfalaması 0'dan başlıyor (page=0 ilk sayfa); Page=1 vermek ikinci sayfayı
                // getirip en güncel kayıtları (ör. Numara Atandı belgelerini) atlıyordu.
                var filter = new izibiz.REST.Models.Request.ListFilter { Page = 0, PageSize = 50 };
                var result = isDraftContext
                    ? await Singl.MustahsilClientGet.ListDraftsAsync(filter)
                    : await Singl.MustahsilClientGet.ListAsync(filter);

                // API'nin döndürdüğü sıra bir belge güncellendiğinde (ör. iptal edilince) değişebiliyor;
                // bu da her yenilemede listenin "oynamasına" ve belge bulmayı zorlaştırmasına sebep oluyordu.
                // Belge No'ya göre sabit sıralayınca konumlar yenilemeler arasında tutarlı kalıyor.
                var sortedContents = result.Contents.OrderBy(c => c.DocumentNo).ToList();

                tableGrid.DataSource = sortedContents;
                EnsureCheckboxColumn();
                FormatGridColumns();
                UpdateEmptyState();

                documentActionsCard1.Visible = result.Contents.Count > 0;

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
                EnsureCheckboxColumn();
                FormatGridColumns();
                UpdateEmptyState();
            }
        }

        private void FormatGridColumns()
        {
            // First, hide all columns to avoid clutter
            foreach (DataGridViewColumn col in tableGrid.Columns)
            {
                if (col.Name != "chkSelect" && col.Name != nameof(EI.GridBtnClmName.previewHtml))
                {
                    col.Visible = false;
                }
            }

            // We need to determine if we are in SOAP or REST mode by checking if a specific column exists.
            bool isRest = tableGrid.Columns.Contains("DocumentNo");

            // We set the DisplayIndex and HeaderText for the desired columns to match the web portal.
            int displayIdx = 2; // chkSelect is 0, previewHtml is 1

            void SetupCol(string colName, string headerText)
            {
                if (tableGrid.Columns.Contains(colName))
                {
                    tableGrid.Columns[colName].Visible = true;
                    tableGrid.Columns[colName].HeaderText = headerText;
                    tableGrid.Columns[colName].DisplayIndex = displayIdx++;
                }
            }

            if (isRest)
            {
                SetupCol("DocumentNo", "Belge No");
                SetupCol("ReceiverIdentifier", "VKN/TCKN");
                SetupCol("ReceiverName", "Firma Unvanı");
                SetupCol("IssueDate", "Belge Tarihi");
                SetupCol("Amount", "Tutar");
                SetupCol("ProfileId", "Senaryo");
                SetupCol("TypeCode", "Tip");
                SetupCol("DocumentStatusLabel", "Durum");

                // Belge No sütunu Fill modunda çok daralıp "..." ile kesiliyordu;
                // benzer önekli belge numaralarını ayırt edebilmek için asgari genişlik veriyoruz.
                if (tableGrid.Columns.Contains("DocumentNo"))
                {
                    tableGrid.Columns["DocumentNo"].MinimumWidth = 180;
                }
            }
            else // SOAP
            {
                SetupCol("CreditNoteID", "Belge No");
                SetupCol("customerIdentifier", "VKN/TCKN");
                SetupCol("customerTitle", "Firma Unvanı");
                SetupCol("issueDate", "Belge Tarihi");
                SetupCol("cDate", "Gönderilme Zamanı");
                SetupCol("profileID", "Senaryo");
                SetupCol("statusDesc", "Durum");

                if (tableGrid.Columns.Contains("CreditNoteID"))
                {
                    tableGrid.Columns["CreditNoteID"].MinimumWidth = 180;
                }
            }
        }




        private void BtnTakeCreditNote_Click(object sender, EventArgs e)
        {
            documentActionsCard1.Visible = false;
            bool isDraftContext = gridMenuType == EI.CreditNote.draftCreditNote.ToString();

            try
            {

                string errorMessage = Singl.creditNoteControllerGet.getCreditNoteListOnServiceAndSaveDb();

                if (errorMessage == null)
                {
                    gridCreditNoteUpdateList(Singl.creditNotesDalGet.getCreditNoteWithDraft(isDraftContext));

                    if (tableGrid.Rows.Count > 0)
                    {
                        documentActionsCard1.Visible = true;
                    }
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

            // Menüden E-Müstahsil'e geçişte otomatik listeleme yapılmaz;
            // liste ancak "SOAP ile Çek" veya "REST ile Çek" ile çekilir.
            tableGrid.DataSource = null;
            tableGrid.Columns.Clear();
            UpdateEmptyState();
        }

        private void ItemGetDraftCreditNote_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.CreditNote.draftCreditNote.ToString();

            sourceCardSoap.FetchButtonVisible = true;
            sourceCardRest.FetchButtonVisible = true;
            documentActionsCard1.Visible = false;

            // Menüden Taslak'a geçişte otomatik listeleme yapılmaz;
            // liste ancak "SOAP ile Çek" veya "REST ile Çek" ile çekilir.
            tableGrid.DataSource = null;
            tableGrid.Columns.Clear();
            UpdateEmptyState();
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
                documentActionsCard1.Visible = (gridMenuType == EI.CreditNote.CreditNotes.ToString()
                    || gridMenuType == EI.CreditNote.draftCreditNote.ToString());

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
                        var xmlResult = await Singl.MustahsilClientGet.DownloadAsync(new System.Collections.Generic.List<string> { restItem.Id.ToString() }, "ubl");
                        byte[] xmlBytes = System.Linq.Enumerable.FirstOrDefault(xmlResult.Values);
                        string strContent = System.Text.Encoding.UTF8.GetString(xmlBytes);
                        FrmView previewInvoices = new FrmView(strContent, nameof(EI.CreditNote.CreditNotes), isHtml: false);
                        previewInvoices.ShowDialog();
                    }
                    else
                    {
                        // PDF önizleme: geçici klasöre yazılır, kalıcı bir indirme sayılmaz.
                        var pdfResult = await Singl.MustahsilClientGet.DownloadAsync(new System.Collections.Generic.List<string> { restItem.Id.ToString() }, "pdf");
                        byte[] pdfBytes = System.Linq.Enumerable.FirstOrDefault(pdfResult.Values);
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

        private void EnsureCheckboxColumn()
        {
            if (!tableGrid.Columns.Contains("chkSelect"))
            {
                var chkCol = new DataGridViewCheckBoxColumn
                {
                    Name = "chkSelect",
                    HeaderText = "",
                    Width = 40,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    ReadOnly = false
                };
                tableGrid.Columns.Insert(0, chkCol);
            }
            
            foreach (DataGridViewColumn col in tableGrid.Columns)
            {
                if (col.Name != "chkSelect" && col.Name != nameof(EI.GridBtnClmName.previewHtml))
                {
                    col.ReadOnly = true;
                }
            }
        }

        private void tableGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tableGrid.IsCurrentCellDirty && tableGrid.CurrentCell.OwningColumn.Name == "chkSelect")
            {
                tableGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tableGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && tableGrid.Columns[e.ColumnIndex].Name == "chkSelect")
            {
                UpdateActionButtonsState();
            }
        }

        private void UpdateActionButtonsState()
        {
            int checkedCount = 0;
            foreach (DataGridViewRow row in tableGrid.Rows)
            {
                if (row.Cells["chkSelect"].Value != null && Convert.ToBoolean(row.Cells["chkSelect"].Value))
                {
                    checkedCount++;
                }
            }

            if (checkedCount > 1)
            {
                documentActionsCard1.ViewButtonEnabled = false;
                documentActionsCard1.CancelButtonEnabled = false;
            }
            else
            {
                documentActionsCard1.ViewButtonEnabled = true;
                documentActionsCard1.CancelButtonEnabled = true;
            }
        }

        /// <summary>
        /// İndir: seçili formatı (pdf/html/xml) kalıcı olarak diske kaydeder ve açar.
        /// </summary>
        private async void DocumentActionsCard1_DownloadRequested(object sender, DocumentActionEventArgs e)
        {
            try
            {
                var checkedRows = new System.Collections.Generic.List<DataGridViewRow>();
                foreach (DataGridViewRow row in tableGrid.Rows)
                {
                    if (row.Cells["chkSelect"].Value != null && Convert.ToBoolean(row.Cells["chkSelect"].Value))
                    {
                        checkedRows.Add(row);
                    }
                }

                if (checkedRows.Count == 0)
                {
                    if (tableGrid.SelectedRows.Count > 0)
                    {
                        checkedRows.Add(tableGrid.SelectedRows[0]);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen indirmek için en az bir belge seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var idsToDownload = new System.Collections.Generic.List<string>();
                string singlePathToOpen = null;

                foreach (var row in checkedRows)
                {
                    if (row.DataBoundItem is izibiz.REST.Concrete.Mustahsil.MustahsilListItem restItem)
                    {
                        idsToDownload.Add(restItem.Id.ToString());
                    }
                }

                if (idsToDownload.Count > 0)
                {
                    string apiFormat = e.Format == "xml" ? "ubl" : e.Format;
                    var result = await Singl.MustahsilClientGet.DownloadAsync(idsToDownload, apiFormat);

                    foreach (var kvp in result)
                    {
                        string safeFileName = System.IO.Path.GetFileName(kvp.Key);
                        string path = System.IO.Path.Combine(FolderControl.CreditNoteFolderPath, safeFileName);
                        FolderControl.writeFileOnDiskWithByte(kvp.Value, path);
                        if (idsToDownload.Count == 1)
                        {
                            singlePathToOpen = path;
                        }
                    }

                    if (idsToDownload.Count == 1)
                    {
                        if (!string.IsNullOrEmpty(singlePathToOpen))
                        {
                            System.Diagnostics.Process.Start(singlePathToOpen);
                        }
                        MessageBox.Show($"Belge indirildi.", "İndirme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(FolderControl.CreditNoteFolderPath);
                        MessageBox.Show($"{idsToDownload.Count} adet belge başarıyla indirildi.\nKlasör: {FolderControl.CreditNoteFolderPath}", "Toplu İndirme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }

                // REST kaynaklı satır yoksa SOAP verisi olabilir; SOAP tarafında da indirme destekleniyor.
                CONTENT_TYPE soapDocType = e.Format == "xml" ? CONTENT_TYPE.XML : e.Format == "html" ? CONTENT_TYPE.HTML : CONTENT_TYPE.PDF;
                int soapSavedCount = 0;

                foreach (var row in checkedRows)
                {
                    if (row.DataBoundItem is CreditNotes soapItem)
                    {
                        byte[] content = Singl.creditNoteControllerGet.getCreditNoteWithType(soapItem.uuid, soapDocType);
                        if (content != null)
                        {
                            string path = FolderControl.CreditNoteFolderPath + soapItem.uuid + "." + soapDocType;
                            FolderControl.writeFileOnDiskWithByte(content, path);
                            singlePathToOpen = path;
                            soapSavedCount++;
                        }
                    }
                }

                if (soapSavedCount == 0)
                {
                    MessageBox.Show("İndirme özelliği şu an sadece REST verileri için kullanılabilir.");
                }
                else if (soapSavedCount == 1)
                {
                    System.Diagnostics.Process.Start(singlePathToOpen);
                    MessageBox.Show("Belge indirildi.", "İndirme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Diagnostics.Process.Start(FolderControl.CreditNoteFolderPath);
                    MessageBox.Show($"{soapSavedCount} adet belge başarıyla indirildi.\nKlasör: {FolderControl.CreditNoteFolderPath}", "Toplu İndirme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İndirme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sil: Taslak'ta belgeyi tamamen siler (henüz GİB'e gönderilmedi), Giden'de ise
        /// belgeyi "İptal Raporlandı" durumuna geçirir (soft-cancel, listede kalır).
        /// Zaten iptal edilmiş bir belge tekrar iptal edilemez; geri alınamaz olduğu için önce onay istenir.
        /// </summary>
        private async void DocumentActionsCard1_CancelRequested(object sender, EventArgs e)
        {
            if (tableGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen tablodan bir belge seçin.");
                return;
            }

            var boundItem = tableGrid.SelectedRows[0].DataBoundItem;
            if (!(boundItem is izibiz.REST.Concrete.Mustahsil.MustahsilListItem restItem))
            {
                MessageBox.Show("Silme özelliği şu an sadece REST verileri için kullanılabilir.");
                return;
            }

            string status = restItem.DocumentStatusLabel;
            if (status == "İptal Raporlandı" || status == "İptal Edildi")
            {
                MessageBox.Show("Bu belge zaten iptal edilmiş, tekrar iptal edilemez.", "İşlem Yapılamaz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isDraftContext = gridMenuType == EI.CreditNote.draftCreditNote.ToString();

            string confirmMessage = isDraftContext
                ? $"'{restItem.Uuid}' numaralı taslağı silmek istediğinize emin misiniz? Bu işlem geri alınamaz."
                : $"'{restItem.Uuid}' numaralı belgeyi iptal etmek istediğinize emin misiniz? Belge \"İptal Raporlandı\" durumuna geçecek. Bu işlem geri alınamaz.";

            var confirm = MessageBox.Show(
                confirmMessage,
                "Belgeyi Sil",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Taslak: henüz GİB'e gönderilmediği için gerçekten silinir (deleteDocument: true).
                // Giden: soft-cancel, "İptal Raporlandı" durumuna geçer, listede kalır.
                await Singl.MustahsilClientGet.CancelAsync(restItem.Uuid, deleteDocument: isDraftContext);
                MessageBox.Show(
                    isDraftContext ? "Taslak başarıyla silindi." : "Belge başarıyla iptal edildi.",
                    "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnRestListele_Click(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
