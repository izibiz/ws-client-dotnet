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
using izibiz.UI.Controls;

namespace izibiz.UI
{
    public partial class FrmSelfEmployment : Form
    {
        private string gridMenuType;
        private string gridDirection;

        private const int SidebarExpandedWidth = 340;
        private const int SidebarCollapsedWidth = 64;
        private bool _sidebarCollapsed = false;
        private Timer _sidebarAnimTimer;
        private int _sidebarTargetWidth;

        public FrmSelfEmployment()
        {
            InitializeComponent();
            try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
        }

        private void FrmSelfEmployment_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();

            RoundedPathHelper.ApplyRoundedRegion(btnHomePage, 14);
            btnHomePage.BackgroundImage = Properties.Resources.izibizLogoFull;
            btnHomePage.BackgroundImageLayout = ImageLayout.Zoom;

            sourceCardSoap.FetchClicked += BtnTakeSmm_Click;
            sourceCardRest.FetchClicked += BtnRestListele_Click;
            documentActionsCard1.ViewRequested += DocumentActionsCard1_ViewRequested;
            documentActionsCard1.DownloadRequested += DocumentActionsCard1_DownloadRequested;
            documentActionsCard1.CancelRequested += DocumentActionsCard1_CancelRequested;
            documentActionsCard1.AssignNumberRequested += DocumentActionsCard1_AssignNumberRequested;

            tableGrid.CellPainting += tableGrid_CellPainting;
            tableGrid.CellMouseMove += TableGrid_CellMouseMove;
            tableGrid.CellMouseLeave += TableGrid_CellMouseLeave;
            tableGrid.SelectionChanged += TableGrid_SelectionChanged;

            SetupSidebarHoverEffects();
            UpdateEmptyState();

            ArrangeResponsiveLayout();
            this.BeginInvoke(new MethodInvoker(ArrangeResponsiveLayout));
        }

        private void SetupSidebarHoverEffects()
        {
            HoverAnimator.Attach(btnHamburger, BrandColors.SidebarDark, BrandColors.SidebarHover);
            foreach (var navBtn in new[] { btnNavSmm, btnNavDraftSmm, btnNavSmmReports, btnNavNewSmm })
            {
                HoverAnimator.Attach(navBtn, BrandColors.SidebarDark, BrandColors.SidebarHover);
                RoundedPathHelper.ApplyRoundedRegion(navBtn, 10);
            }
        }

        private void BtnHamburger_Click(object sender, EventArgs e)
        {
            _sidebarCollapsed = !_sidebarCollapsed;
            _sidebarTargetWidth = _sidebarCollapsed ? SidebarCollapsedWidth : SidebarExpandedWidth;

            if (_sidebarCollapsed)
            {
                SetSidebarContentVisible(false);
            }

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
            foreach (var navBtn in new[] { btnNavSmm, btnNavDraftSmm, btnNavSmmReports, btnNavNewSmm })
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

        private void UpdateEmptyState()
        {
            bool isEmpty = tableGrid.Rows.Count == 0;
            lblEmptyIcon.Visible = isEmpty;
            lblEmptyText.Visible = false;
            tableGrid.Visible = !isEmpty;
        }

        private void FrmSelfEmployment_Resize(object sender, EventArgs e)
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

            int startX = contentLeft + (contentWidth - pairWidth) / 2;
            sourceCardSoap.Location = new Point(startX, sourceCardSoap.Top);
            sourceCardRest.Location = new Point(startX + cardWidth + cardGap, sourceCardRest.Top);

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
            await LoadRestDataAsync(showSuccessMessage: true);
        }

        private async Task LoadRestDataAsync(bool showSuccessMessage = false)
        {
            try
            {
                // Mevcut seçili olan elemanları ve scroll pozisyonunu hafızaya al
                var selectedIds = new System.Collections.Generic.List<long>();
                foreach (DataGridViewRow row in tableGrid.Rows)
                {
                    if (row.Cells["chkSelect"]?.Value != null && (bool)row.Cells["chkSelect"].Value == true)
                    {
                        if (row.DataBoundItem is izibiz.REST.Concrete.Smm.SmmListItem item)
                        {
                            selectedIds.Add(item.Id);
                        }
                    }
                }
                int firstDisplayedRowIndex = tableGrid.FirstDisplayedScrollingRowIndex;

                string folder = (gridMenuType == EI.SelfEmploymentReceipt.draftSmm.ToString()) ? "draft" : "outbox";
                var filter = new izibiz.REST.Models.Request.ListFilter { Page = 1, PageSize = 50, Folder = folder };
                var result = await Singl.SmmClientGet.ListAsync(filter);

                if (folder == "outbox")
                {
                    // "Giden E-SMM" ekranında taslaklar, numara atananlar olmamalı
                    var draftStatuses = new[] { "Taslak", "Numara Atanıyor", "Numara Atandı" };
                    result.Contents = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(result.Contents, c => !draftStatuses.Contains(c.DocumentStatusLabel)));
                }

                // Listeyi belge numarasına ve ID'ye göre sıralayarak ekrandaki oynamayı (zıplamayı) engelle
                var sortedContents = System.Linq.Enumerable.ToList(System.Linq.Enumerable.OrderByDescending(result.Contents, c => c.Id));

                tableGrid.DataSource = sortedContents;
                EnsureCheckboxColumn();
                FormatGridColumns();
                UpdateEmptyState();

                // Hafızaya alınan seçimleri geri yükle
                bool selectionRestored = false;
                foreach (DataGridViewRow row in tableGrid.Rows)
                {
                    if (row.DataBoundItem is izibiz.REST.Concrete.Smm.SmmListItem item && selectedIds.Contains(item.Id))
                    {
                        row.Cells["chkSelect"].Value = true;
                        selectionRestored = true;
                    }
                }

                // Scroll pozisyonunu geri yükle
                if (firstDisplayedRowIndex >= 0 && firstDisplayedRowIndex < tableGrid.Rows.Count)
                {
                    tableGrid.FirstDisplayedScrollingRowIndex = firstDisplayedRowIndex;
                }

                if (selectionRestored)
                {
                    UpdateActionButtonsState();
                }

                documentActionsCard1.Visible = true;

                // Seri ön eklerini çek
                var series = await Singl.SmmClientGet.GetSeriesAsync();
                if (series != null)
                {
                    documentActionsCard1.SetPrefixes(series.Select(s => s.Prefix).ToArray());
                }

                if (showSuccessMessage)
                {
                    MessageBox.Show($"REST API'den başarıyla {result.Contents.Count} adet E-SMM çekildi!", "REST Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("REST API Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TableGrid_SelectionChanged(object sender, EventArgs e)
        {
            // Logic moved to UpdateActionButtonsState
        }

        private async void DocumentActionsCard1_AssignNumberRequested(object sender, string prefix)
        {
            var selectedRows = GetSelectedRows();
            if (selectedRows.Count == 0) return;
            
            var ids = new List<long>();
            foreach (var row in selectedRows)
            {
                var boundItem = row.DataBoundItem;
                if (boundItem is izibiz.REST.Concrete.Smm.SmmListItem restItem)
                {
                    ids.Add(restItem.Id);
                }
            }

            if (ids.Count > 0)
            {
                documentActionsCard1.Enabled = false;
                try
                {
                    bool success = await Singl.SmmClientGet.AssignNumberAsync(ids, prefix, autoSend: false);
                    if (success)
                    {
                        await LoadRestDataAsync(showSuccessMessage: false);
                        MessageBox.Show("Numara atama işlemi sıraya alındı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Numara atama işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Numara atanırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    documentActionsCard1.Enabled = true;
                }
            }
        }

        private void localizationItemTextWrite()
        {
            if (Settings.Default.language == "English")
            {
                Lang.Culture = new CultureInfo("en-US");
            }
            else
            {
                Lang.Culture = new CultureInfo("");
            }
        }

        private void BtnHomePage_Click(object sender, EventArgs e)
        {
            FrmHome frmHome = new FrmHome();
            this.Hide();
            frmHome.Show();
            this.Dispose();
        }

        private int _htmlBtnHoveredRow = -1;

        private void addViewButtonToDatagridView()
        {
            tableGrid.Columns.Clear();
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconHtml,
                Name = EI.GridBtnClmName.previewHtml.ToString(),
                HeaderText = "",
                Width = 46,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                ToolTipText = "HTML Görüntüle"
            });
        }

        private void gridSmmUpdateList(List<SelfEmploymentReceipts> smmList)
        {
            documentActionsCard1.Visible = false;
            gridDirection = nameof(EI.Direction.IN);
            tableGrid.DataSource = null;
            tableGrid.Columns.Clear();
            UpdateEmptyState();

            if (smmList.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                addViewButtonToDatagridView();
                tableGrid.DataSource = smmList;
                EnsureCheckboxColumn();
                FormatGridColumns();
                UpdateEmptyState();

                lblInformation.Text = Lang.clickRowInvoice;
                lblInformation.Visible = false;
            }
        }

        private void FormatGridColumns()
        {
            foreach (DataGridViewColumn col in tableGrid.Columns)
            {
                if (col.Name != "chkSelect" && col.Name != nameof(EI.GridBtnClmName.previewHtml))
                {
                    col.Visible = false;
                }
                
                if (col.Name != "chkSelect")
                {
                    col.ReadOnly = true;
                }
            }

            bool isRest = tableGrid.Columns.Contains("DocumentNo");
            int displayIdx = 2; 

            void SetupCol(string colName, string headerText)
            {
                if (tableGrid.Columns.Contains(colName))
                {
                    tableGrid.Columns[colName].Visible = true;
                    if (!string.IsNullOrEmpty(headerText)) tableGrid.Columns[colName].HeaderText = headerText;
                    tableGrid.Columns[colName].DisplayIndex = displayIdx++;
                }
            }

            if (tableGrid.Columns.Contains(nameof(EI.GridBtnClmName.previewHtml)))
            {
                tableGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)].DisplayIndex = 1;
            }

            if (isRest)
            {
                SetupCol("DocumentNo", "Belge No");
                SetupCol("ReceiverIdentifier", "VKN/TCKN");
                SetupCol("ReceiverName", "Firma Unvanı");
                SetupCol("IssueDate", "Belge Tarihi");
                SetupCol("SentTime", "Gönderilme Zamanı");
                SetupCol("Amount", "Tutar");
                SetupCol("ProfileId", "Senaryo");
                SetupCol("TypeCode", "Tip");
                SetupCol("DocumentStatusLabel", "Durum");

                if (tableGrid.Columns.Contains("Amount"))
                {
                    tableGrid.Columns["Amount"].DefaultCellStyle.Format = "C2";
                }
            }
            else 
            {
                SetupCol(EI.SelfEmploymentReceipt.uuid.ToString(), Lang.uuid);
                SetupCol(EI.SelfEmploymentReceipt.issueDate.ToString(), Lang.issueDate);
                SetupCol(EI.SelfEmploymentReceipt.customerTitle.ToString(), Lang.customerTitle);
                SetupCol(EI.SelfEmploymentReceipt.profileID.ToString(), Lang.profileid);
                SetupCol(EI.SelfEmploymentReceipt.cDate.ToString(), Lang.cDate);
                SetupCol(EI.SelfEmploymentReceipt.statusDesc.ToString(), Lang.statusDesc);
                SetupCol(EI.SelfEmploymentReceipt.status.ToString(), Lang.status);
            }
        }

        private void BtnTakeSmm_Click(object sender, EventArgs e)
        {
            documentActionsCard1.Visible = false;

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
                string inner = ex.InnerException != null ? ex.InnerException.Message : "";
                if (ex.InnerException?.InnerException != null)
                {
                    inner += "\n" + ex.InnerException.InnerException.Message;
                }
                MessageBox.Show(Lang.dbFault + " " + inner, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null) msg += "\nİç Hata: " + ex.InnerException.Message;
                MessageBox.Show(msg);
            }
        }

        private async void ItemGetSmm_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.SelfEmploymentReceipt.SelfEmploymentReceipts.ToString();
            sourceCardSoap.FetchButtonVisible = true;
            sourceCardRest.FetchButtonVisible = true;
            documentActionsCard1.Visible = false;

            try
            {
                var list = await Task.Run(() => Singl.smmDalGet.getSmmWithDraft(false));
                gridSmmUpdateList(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private async void ItemGetDraftSmm_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.SelfEmploymentReceipt.draftSmm.ToString();
            gridDirection = nameof(EI.Direction.DRAFT);
            sourceCardSoap.FetchButtonVisible = false;
            documentActionsCard1.Visible = false;

            try
            {
                var list = await Task.Run(() => Singl.smmDalGet.getSmmWithDraft(true));
                gridSmmUpdateList(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ItemGetSmmReports_Click(object sender, EventArgs e)
        {
            gridMenuType = EI.SmmReports.SmmReports.ToString();
            sourceCardSoap.FetchButtonVisible = true;
            documentActionsCard1.Visible = false;
            MessageBox.Show("SMM Raporları yapım aşamasında");
        }

        private void EnsureCheckboxColumn()
        {
            if (tableGrid.Columns.Contains("chkSelect")) return;
            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
            chkCol.Name = "chkSelect";
            chkCol.HeaderText = "";
            chkCol.Width = 35;
            chkCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            chkCol.ReadOnly = false;
            chkCol.TrueValue = true;
            chkCol.FalseValue = false;
            tableGrid.Columns.Insert(0, chkCol);
        }

        private void tableGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tableGrid.IsCurrentCellDirty && tableGrid.CurrentCell is DataGridViewCheckBoxCell)
            {
                tableGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tableGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == tableGrid.Columns["chkSelect"]?.Index)
            {
                UpdateActionButtonsState();
            }
        }

        private void UpdateActionButtonsState()
        {
            var selectedRows = GetSelectedRows();
            int selectedCount = selectedRows.Count;
            if (selectedCount == 0)
            {
                documentActionsCard1.Visible = false;
                documentActionsCard1.ViewButtonEnabled = false;
                documentActionsCard1.DownloadButtonEnabled = false;
                documentActionsCard1.CancelButtonEnabled = false;
            }
            else
            {
                documentActionsCard1.Visible = true;
                bool allDrafts = true;

                foreach (var row in selectedRows)
                {
                    string statusStr = "";
                    if (row.DataBoundItem is izibiz.REST.Concrete.Smm.SmmListItem restItem)
                    {
                        statusStr = restItem.DocumentStatusLabel;
                    }
                    else if (row.Cells[nameof(EI.SelfEmploymentReceipt.statusDesc)] != null)
                    {
                        statusStr = row.Cells[nameof(EI.SelfEmploymentReceipt.statusDesc)].Value?.ToString();
                    }

                    if (statusStr != null && !(statusStr.Equals("Taslak", StringComparison.OrdinalIgnoreCase) || statusStr.Equals("Draft", StringComparison.OrdinalIgnoreCase)))
                    {
                        allDrafts = false;
                        break;
                    }
                }

                if (allDrafts)
                {
                    documentActionsCard1.CardMode = DocumentCardMode.AssignNumber;
                }
                else
                {
                    documentActionsCard1.CardMode = DocumentCardMode.ViewDownload;
                    documentActionsCard1.ViewButtonEnabled = selectedCount == 1;
                    documentActionsCard1.DownloadButtonEnabled = true;
                    documentActionsCard1.CancelButtonEnabled = selectedCount == 1;
                }
            }
        }

        private List<DataGridViewRow> GetSelectedRows()
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in tableGrid.Rows)
            {
                var cell = row.Cells["chkSelect"];
                if (cell != null && cell.Value != null && (bool)cell.Value == true)
                {
                    list.Add(row);
                }
            }
            return list;
        }

        private void TableGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)]?.Index)
                {
                    PreviewRowAsync(tableGrid.Rows[e.RowIndex]);
                    return;
                }

                if (e.ColumnIndex != tableGrid.Columns["chkSelect"]?.Index)
                {
                    var chkCell = tableGrid.Rows[e.RowIndex].Cells["chkSelect"];
                    if (chkCell != null)
                    {
                        bool isChecked = chkCell.Value != null && (bool)chkCell.Value;
                        chkCell.Value = !isChecked;
                        tableGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }
                }
            }
        }

        private void tableGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tableGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = tableGrid.Columns[e.ColumnIndex].Name;

                if (colName == nameof(EI.GridBtnClmName.previewHtml))
                {
                    e.PaintBackground(e.CellBounds, true);

                    Rectangle btnRect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 8, e.CellBounds.Width - 16, e.CellBounds.Height - 16);
                    bool isHovered = (_htmlBtnHoveredRow == e.RowIndex);
                    
                    Color btnColor = isHovered ? System.Drawing.Color.FromArgb(226, 232, 240) : System.Drawing.Color.FromArgb(248, 250, 252);
                    Color borderColor = isHovered ? System.Drawing.Color.FromArgb(148, 163, 184) : System.Drawing.Color.FromArgb(203, 213, 225);

                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int r = 6;
                        path.AddArc(btnRect.X, btnRect.Y, r, r, 180, 90);
                        path.AddArc(btnRect.Right - r, btnRect.Y, r, r, 270, 90);
                        path.AddArc(btnRect.Right - r, btnRect.Bottom - r, r, r, 0, 90);
                        path.AddArc(btnRect.X, btnRect.Bottom - r, r, r, 90, 90);
                        path.CloseFigure();

                        using (var brush = new System.Drawing.SolidBrush(btnColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }
                        using (var pen = new System.Drawing.Pen(borderColor, 1))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    }

                    System.Drawing.Image icon = Properties.Resources.iconHtml;
                    int iconWidth = 18;
                    int iconHeight = 18;
                    int iconX = btnRect.X + (btnRect.Width - iconWidth) / 2;
                    int iconY = btnRect.Y + (btnRect.Height - iconHeight) / 2;
                    e.Graphics.DrawImage(icon, iconX, iconY, iconWidth, iconHeight);

                    e.Handled = true;
                }
                else if (colName == "DocumentStatusLabel" || colName == "DocumentStatus" || colName == nameof(EI.SelfEmploymentReceipt.statusDesc) || colName == nameof(EI.SelfEmploymentReceipt.status))
                {
                    e.PaintBackground(e.CellBounds, true);

                    object val = e.Value;
                    string statusText = val != null ? val.ToString() : "";

                    if (!string.IsNullOrEmpty(statusText))
                    {
                        SizeF textSize = e.Graphics.MeasureString(statusText, new Font("Segoe UI Semibold", 8.5F));
                        int paddingX = 12;
                        int paddingY = 6;
                        int badgeWidth = (int)textSize.Width + paddingX * 2;
                        int badgeHeight = (int)textSize.Height + paddingY * 2;

                        int badgeX = e.CellBounds.X + (e.CellBounds.Width - badgeWidth) / 2;
                        int badgeY = e.CellBounds.Y + (e.CellBounds.Height - badgeHeight) / 2;
                        Rectangle badgeRect = new Rectangle(badgeX, badgeY, badgeWidth, badgeHeight);

                        Color badgeColor = Color.FromArgb(59, 130, 246); // Default Blue
                        Color textColor = Color.White;

                        // Retrieve the specific item if it's REST to check for a custom color
                        var boundItem = tableGrid.Rows[e.RowIndex].DataBoundItem;
                        bool apiColorApplied = false;
                        if (boundItem is izibiz.REST.Concrete.Smm.SmmListItem restItem && restItem.DocumentStatus != null)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(restItem.DocumentStatus.BackgroundColor))
                                {
                                    badgeColor = ColorTranslator.FromHtml(restItem.DocumentStatus.BackgroundColor);
                                    apiColorApplied = true;
                                }
                                else if (!string.IsNullOrEmpty(restItem.DocumentStatus.Color)) // API bazen sadece color dönüyor
                                {
                                    badgeColor = ColorTranslator.FromHtml(restItem.DocumentStatus.Color);
                                    apiColorApplied = true;
                                }

                                if (!string.IsNullOrEmpty(restItem.DocumentStatus.Color) && !string.IsNullOrEmpty(restItem.DocumentStatus.BackgroundColor))
                                {
                                    textColor = ColorTranslator.FromHtml(restItem.DocumentStatus.Color);
                                }
                            }
                            catch { /* fallback to default if parsing fails */ }
                        }

                        if (!apiColorApplied)
                        {
                            string lowerStatus = statusText.ToLower(); // Türkçe karakter sorununu aşmak için ToLower() kullanıyoruz
                            if (lowerStatus.Contains("hata") || lowerStatus.Contains("i̇ptal") || lowerStatus.Contains("iptal"))
                                badgeColor = Color.FromArgb(239, 68, 68); // Red
                            else if (lowerStatus.Contains("başarı") || lowerStatus.Contains("onay") || lowerStatus.Contains("işlendi"))
                                badgeColor = Color.FromArgb(34, 197, 94); // Green
                            else if (lowerStatus.Contains("taslak"))
                                badgeColor = Color.FromArgb(100, 116, 139); // Slate Gray
                            else if (lowerStatus.Contains("atanıyor"))
                                badgeColor = Color.FromArgb(234, 179, 8); // Amber/Yellow
                        }

                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                        {
                            int r = 10;
                            path.AddArc(badgeRect.X, badgeRect.Y, r, r, 180, 90);
                            path.AddArc(badgeRect.Right - r, badgeRect.Y, r, r, 270, 90);
                            path.AddArc(badgeRect.Right - r, badgeRect.Bottom - r, r, r, 0, 90);
                            path.AddArc(badgeRect.X, badgeRect.Bottom - r, r, r, 90, 90);
                            path.CloseFigure();

                            using (var brush = new SolidBrush(badgeColor))
                            {
                                e.Graphics.FillPath(brush, path);
                            }
                        }

                        using (var brush = new SolidBrush(textColor))
                        {
                            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                            e.Graphics.DrawString(statusText, new Font("Segoe UI Semibold", 8.5F), brush, badgeRect, sf);
                        }
                    }

                    e.Handled = true;
                }
            }
        }

        private void TableGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && tableGrid.Columns[e.ColumnIndex].Name == nameof(EI.GridBtnClmName.previewHtml))
            {
                if (_htmlBtnHoveredRow != e.RowIndex)
                {
                    int oldRow = _htmlBtnHoveredRow;
                    _htmlBtnHoveredRow = e.RowIndex;
                    if (oldRow >= 0) tableGrid.InvalidateCell(e.ColumnIndex, oldRow);
                    if (_htmlBtnHoveredRow >= 0) tableGrid.InvalidateCell(e.ColumnIndex, _htmlBtnHoveredRow);
                }
                tableGrid.Cursor = Cursors.Hand;
            }
            else
            {
                if (_htmlBtnHoveredRow != -1)
                {
                    int oldRow = _htmlBtnHoveredRow;
                    _htmlBtnHoveredRow = -1;
                    tableGrid.InvalidateCell(tableGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)].Index, oldRow);
                    tableGrid.Cursor = Cursors.Default;
                }
            }
        }

        private void TableGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && tableGrid.Columns[e.ColumnIndex].Name == nameof(EI.GridBtnClmName.previewHtml))
            {
                int oldRow = _htmlBtnHoveredRow;
                _htmlBtnHoveredRow = -1;
                if (oldRow >= 0) tableGrid.InvalidateCell(e.ColumnIndex, oldRow);
                tableGrid.Cursor = Cursors.Default;
            }
        }

        private async void DocumentActionsCard1_DownloadRequested(object sender, EventArgs e)
        {
            var selectedRows = GetSelectedRows();
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen indireceğiniz belgeleri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var restIdList = new List<string>();
                var soapUuidList = new List<string>();

                foreach (var row in selectedRows)
                {
                    var boundItem = row.DataBoundItem;
                    if (boundItem is izibiz.REST.Concrete.Smm.SmmListItem restItem)
                    {
                        restIdList.Add(restItem.Id.ToString());
                    }
                    else
                    {
                        soapUuidList.Add(row.Cells[nameof(EI.SelfEmploymentReceipt.uuid)].Value.ToString());
                    }
                }

                if (restIdList.Count > 0)
                {
                    string format = documentActionsCard1.SelectedDownloadFormat;
                    if (format == "xml") format = "ubl"; // REST uses ubl instead of xml

                    var downloadResult = await Singl.SmmClientGet.DownloadAsync(restIdList, format);
                    if (downloadResult != null && downloadResult.Count > 0)
                    {
                        string extractPath = FolderControl.smmFolderPath + "BulkDownload_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        System.IO.Directory.CreateDirectory(extractPath);
                        
                        foreach (var kvp in downloadResult)
                        {
                            string filePath = System.IO.Path.Combine(extractPath, kvp.Key);
                            FolderControl.writeFileOnDiskWithByte(kvp.Value, filePath);
                        }
                        System.Diagnostics.Process.Start("explorer.exe", extractPath);
                    }
                }

                if (soapUuidList.Count > 0)
                {
                    foreach (var uuid in soapUuidList)
                    {
                        CONTENT_TYPE docType = CONTENT_TYPE.PDF;
                        if (documentActionsCard1.SelectedDownloadFormat == "html") docType = CONTENT_TYPE.HTML;
                        else if (documentActionsCard1.SelectedDownloadFormat == "xml") docType = CONTENT_TYPE.XML;

                        byte[] content = Singl.smmControllerGet.getSmmWithType(uuid, docType);
                        if (content != null)
                        {
                            string path = FolderControl.smmFolderPath + uuid + "." + docType.ToString().ToLower();
                            FolderControl.writeFileOnDiskWithByte(content, path);
                            System.Diagnostics.Process.Start(path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void DocumentActionsCard1_ViewRequested(object sender, EventArgs e)
        {
            var selectedRows = GetSelectedRows();
            if (selectedRows.Count != 1)
            {
                MessageBox.Show("Lütfen görüntülemek için sadece 1 adet belge seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PreviewRowAsync(selectedRows[0]);
        }

        private async void PreviewRowAsync(DataGridViewRow row)
        {
            try
            {
                var boundItem = row.DataBoundItem;
                if (boundItem is izibiz.REST.Concrete.Smm.SmmListItem restItem)
                {
                    var xmlResult = await Singl.SmmClientGet.DownloadAsync(new List<string> { restItem.Id.ToString() }, "ubl");
                    if (xmlResult != null && xmlResult.Values.Count > 0)
                    {
                        byte[] xmlBytes = xmlResult.Values.First();
                        string strContent = System.Text.Encoding.UTF8.GetString(xmlBytes);
                        FrmView previewInvoices = new FrmView(strContent, nameof(EI.SelfEmploymentReceipt.SelfEmploymentReceipts), isHtml: false);
                        previewInvoices.ShowDialog();
                    }
                    return;
                }

                string uuid = row.Cells[nameof(EI.SelfEmploymentReceipt.uuid)].Value.ToString();
                string xmlContent = Singl.smmControllerGet.getSmmContentXml(uuid);
                if (xmlContent != null)
                {
                    FrmView previewInvoices = new FrmView(xmlContent, nameof(EI.SelfEmploymentReceipt.SelfEmploymentReceipts));
                    previewInvoices.ShowDialog();
                }
                else
                {
                        MessageBox.Show(Lang.cantGetContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private async void DocumentActionsCard1_CancelRequested(object sender, EventArgs e)
        {
            var selectedRows = GetSelectedRows();
            if (selectedRows.Count == 0) return;

            // Çoklu silme desteklenmiyor, sadece ilk seçili öğe üzerinden işlem yapalım (Müstahsil ile aynı mantık)
            var boundItem = selectedRows[0].DataBoundItem;
            if (!(boundItem is izibiz.REST.Concrete.Smm.SmmListItem restItem))
            {
                // SOAP için iptal işlemleri 
                var result = MessageBox.Show("Seçili belgeleri iptal etmek istediğinize emin misiniz?", "İptal Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
                
                int soapSuccess = 0;
                int soapFail = 0;
                string soapError = "";

                foreach (DataGridViewRow row in selectedRows)
                {
                    string uuid = row.Cells[nameof(EI.SelfEmploymentReceipt.uuid)].Value.ToString();
                    string err = Singl.smmControllerGet.cancelSmm(uuid);
                    if (string.IsNullOrEmpty(err)) soapSuccess++;
                    else { soapFail++; soapError = err; }
                }

                if (soapFail > 0) MessageBox.Show($"Başarılı: {soapSuccess}\nHatalı: {soapFail}\nSon Hata: {soapError}", "İşlem Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else MessageBox.Show($"{soapSuccess} belge başarıyla iptal edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = restItem.DocumentStatusLabel;
            if (status == "İptal Raporlandı" || status == "İptal Edildi" || status == "İptal")
            {
                MessageBox.Show("Bu belge zaten iptal edilmiş, tekrar iptal edilemez.", "İşlem Yapılamaz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isDraftContext = gridMenuType == EI.SelfEmploymentReceipt.draftSmm.ToString();

            string confirmMessage = isDraftContext
                ? $"'{restItem.Uuid}' numaralı taslağı silmek istediğinize emin misiniz? Bu işlem geri alınamaz."
                : $"'{restItem.Uuid}' numaralı belgeyi iptal etmek istediğinize emin misiniz? Belge \"İptal\" durumuna geçecek. Bu işlem geri alınamaz.";

            var confirm = MessageBox.Show(confirmMessage, "Belgeyi Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                // Taslak: deleteDocument = true ile tamamen silinir.
                // Giden: deleteDocument = false ile "İptal" statüsüne alınır.
                await Singl.SmmClientGet.CancelAsync(restItem.Uuid, deleteDocument: isDraftContext);
                
                MessageBox.Show(
                    isDraftContext ? "Taslak başarıyla silindi." : "Belge başarıyla iptal edildi.",
                    "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                // Tabloyu yenile
                await LoadRestDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
