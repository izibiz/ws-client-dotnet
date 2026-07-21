namespace izibiz.UI
{
    partial class FrmCreditNote
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.btnHamburger = new System.Windows.Forms.Button();
            this.btnNavMustahsil = new System.Windows.Forms.Button();
            this.btnNavDraft = new System.Windows.Forms.Button();
            this.btnNavReports = new System.Windows.Forms.Button();
            this.btnNavNew = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.sourceCardSoap = new izibiz.UI.Controls.SourceCard();
            this.sourceCardRest = new izibiz.UI.Controls.SourceCard();
            this.documentActionsCard1 = new izibiz.UI.Controls.DocumentActionsCard();
            this.lblInformation = new System.Windows.Forms.Label();
            this.lblEmptyIcon = new System.Windows.Forms.Label();
            this.lblEmptyText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlSidebar
            //
            this.pnlSidebar.BackColor = izibiz.UI.Controls.BrandColors.SidebarDark;
            this.pnlSidebar.Controls.Add(this.btnNavNew);
            this.pnlSidebar.Controls.Add(this.btnNavReports);
            this.pnlSidebar.Controls.Add(this.btnNavDraft);
            this.pnlSidebar.Controls.Add(this.btnNavMustahsil);
            this.pnlSidebar.Controls.Add(this.btnHamburger);
            this.pnlSidebar.Controls.Add(this.btnHomePage);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(340, 932);
            this.pnlSidebar.TabIndex = 54;
            //
            // btnHamburger
            //
            this.btnHamburger.BackColor = izibiz.UI.Controls.BrandColors.SidebarDark;
            this.btnHamburger.FlatAppearance.BorderSize = 0;
            this.btnHamburger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHamburger.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnHamburger.ForeColor = System.Drawing.Color.White;
            this.btnHamburger.Location = new System.Drawing.Point(280, 24);
            this.btnHamburger.Name = "btnHamburger";
            this.btnHamburger.Size = new System.Drawing.Size(44, 44);
            this.btnHamburger.TabIndex = 58;
            this.btnHamburger.Text = "☰";
            this.btnHamburger.UseVisualStyleBackColor = false;
            this.btnHamburger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHamburger.Click += new System.EventHandler(this.BtnHamburger_Click);
            //
            // btnHomePage
            //
            this.btnHomePage.BackColor = izibiz.UI.Controls.BrandColors.SidebarDark;
            this.btnHomePage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHomePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHomePage.FlatAppearance.BorderSize = 0;
            this.btnHomePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomePage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnHomePage.ForeColor = System.Drawing.Color.Snow;
            this.btnHomePage.Location = new System.Drawing.Point(16, 20);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Padding = new System.Windows.Forms.Padding(6);
            this.btnHomePage.Size = new System.Drawing.Size(308, 90);
            this.btnHomePage.TabIndex = 57;
            this.btnHomePage.Text = "";
            this.btnHomePage.UseVisualStyleBackColor = false;
            this.btnHomePage.Click += new System.EventHandler(this.BtnHomePage_Click);
            //
            // btnNavMustahsil
            //
            this.btnNavMustahsil.BackColor = izibiz.UI.Controls.BrandColors.SidebarDark;
            this.btnNavMustahsil.FlatAppearance.BorderSize = 0;
            this.btnNavMustahsil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavMustahsil.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnNavMustahsil.ForeColor = System.Drawing.Color.White;
            this.btnNavMustahsil.Location = new System.Drawing.Point(16, 144);
            this.btnNavMustahsil.Name = "btnNavMustahsil";
            this.btnNavMustahsil.Size = new System.Drawing.Size(308, 56);
            this.btnNavMustahsil.TabIndex = 59;
            this.btnNavMustahsil.Text = "\uD83D\uDCC4   E-Müstahsil";
            this.btnNavMustahsil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavMustahsil.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavMustahsil.UseVisualStyleBackColor = false;
            this.btnNavMustahsil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavMustahsil.Click += new System.EventHandler(this.ItemGetCreditNote_Click);
            //
            // btnNavDraft
            //
            this.btnNavDraft.BackColor = izibiz.UI.Controls.BrandColors.SidebarDark;
            this.btnNavDraft.FlatAppearance.BorderSize = 0;
            this.btnNavDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDraft.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnNavDraft.ForeColor = System.Drawing.Color.White;
            this.btnNavDraft.Location = new System.Drawing.Point(16, 228);
            this.btnNavDraft.Name = "btnNavDraft";
            this.btnNavDraft.Size = new System.Drawing.Size(308, 56);
            this.btnNavDraft.TabIndex = 60;
            this.btnNavDraft.Text = "\uD83D\uDCDD   Taslak";
            this.btnNavDraft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDraft.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavDraft.UseVisualStyleBackColor = false;
            this.btnNavDraft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDraft.Click += new System.EventHandler(this.ItemGetDraftCreditNote_Click);
            //
            // btnNavReports
            //
            this.btnNavReports.BackColor = izibiz.UI.Controls.BrandColors.SidebarDark;
            this.btnNavReports.FlatAppearance.BorderSize = 0;
            this.btnNavReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavReports.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnNavReports.ForeColor = System.Drawing.Color.White;
            this.btnNavReports.Location = new System.Drawing.Point(16, 312);
            this.btnNavReports.Name = "btnNavReports";
            this.btnNavReports.Size = new System.Drawing.Size(308, 56);
            this.btnNavReports.TabIndex = 61;
            this.btnNavReports.Text = "\uD83D\uDCCA   Rapor E-Müstahsil";
            this.btnNavReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavReports.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavReports.UseVisualStyleBackColor = false;
            this.btnNavReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavReports.Click += new System.EventHandler(this.ItemGetCreditNote_Click);
            //
            // btnNavNew
            //
            this.btnNavNew.BackColor = izibiz.UI.Controls.BrandColors.SidebarDark;
            this.btnNavNew.FlatAppearance.BorderSize = 0;
            this.btnNavNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavNew.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnNavNew.ForeColor = System.Drawing.Color.White;
            this.btnNavNew.Location = new System.Drawing.Point(16, 416);
            this.btnNavNew.Name = "btnNavNew";
            this.btnNavNew.Size = new System.Drawing.Size(308, 56);
            this.btnNavNew.TabIndex = 62;
            this.btnNavNew.Text = "➕   Yeni E-Müstahsil";
            this.btnNavNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavNew.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnNavNew.UseVisualStyleBackColor = false;
            this.btnNavNew.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // tableGrid
            //
            this.tableGrid.BackgroundColor = System.Drawing.Color.White;
            this.tableGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.EnableHeadersVisualStyles = false;
            this.tableGrid.GridColor = izibiz.UI.Controls.BrandColors.CardBorder;
            this.tableGrid.Location = new System.Drawing.Point(291, 600);
            this.tableGrid.Margin = new System.Windows.Forms.Padding(6);
            this.tableGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = false;
            this.tableGrid.RowHeadersVisible = false;
            this.tableGrid.RowHeadersWidth = 28;
            this.tableGrid.RowTemplate.Height = 42;
            this.tableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGrid.Size = new System.Drawing.Size(1262, 300);
            this.tableGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableGrid.TabIndex = 55;
            this.tableGrid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.tableGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tableGrid.ColumnHeadersDefaultCellStyle.BackColor = izibiz.UI.Controls.BrandColors.SidebarDark;
            this.tableGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.tableGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tableGrid.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tableGrid.ColumnHeadersHeight = 46;
            this.tableGrid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tableGrid.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 0, 6, 0);
            this.tableGrid.DefaultCellStyle.SelectionBackColor = izibiz.UI.Controls.BrandColors.Teal;
            this.tableGrid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.tableGrid.RowsDefaultCellStyle.SelectionBackColor = izibiz.UI.Controls.BrandColors.Teal;
            this.tableGrid.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.tableGrid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableGrid_CellClick);
            this.tableGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableGrid_CellContentClick);
            this.tableGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.tableGrid_CurrentCellDirtyStateChanged);
            this.tableGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableGrid_CellValueChanged);
            //
            // sourceCardSoap
            //
            this.sourceCardSoap.AccentColor = izibiz.UI.Controls.BrandColors.Purple;
            this.sourceCardSoap.ButtonText = "SOAP ile Çek";
            this.sourceCardSoap.DescriptionText = "Mevcut SOAP servisi";
            this.sourceCardSoap.FetchButtonVisible = false;
            this.sourceCardSoap.IconGlyph = "⚙";
            this.sourceCardSoap.IconTintColor = izibiz.UI.Controls.BrandColors.PurpleLight;
            this.sourceCardSoap.Location = new System.Drawing.Point(627, 40);
            this.sourceCardSoap.Name = "sourceCardSoap";
            this.sourceCardSoap.Size = new System.Drawing.Size(340, 230);
            this.sourceCardSoap.TabIndex = 66;
            this.sourceCardSoap.TitleText = "SOAP";
            //
            // sourceCardRest
            //
            this.sourceCardRest.AccentColor = izibiz.UI.Controls.BrandColors.Teal;
            this.sourceCardRest.ButtonText = "REST ile Çek";
            this.sourceCardRest.DescriptionText = "REST API üzerinden";
            this.sourceCardRest.FetchButtonVisible = false;
            this.sourceCardRest.IconGlyph = "☁";
            this.sourceCardRest.IconTintColor = izibiz.UI.Controls.BrandColors.TealLight;
            this.sourceCardRest.Location = new System.Drawing.Point(937, 40);
            this.sourceCardRest.Name = "sourceCardRest";
            this.sourceCardRest.Size = new System.Drawing.Size(340, 230);
            this.sourceCardRest.TabIndex = 67;
            this.sourceCardRest.TitleText = "REST";
            //
            // documentActionsCard1
            //
            this.documentActionsCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.documentActionsCard1.DescriptionText = "Seçili belgeyi görüntüleyin veya indirin";
            this.documentActionsCard1.Location = new System.Drawing.Point(291, 295);
            this.documentActionsCard1.Name = "documentActionsCard1";
            this.documentActionsCard1.Size = new System.Drawing.Size(1262, 265);
            this.documentActionsCard1.TabIndex = 68;
            this.documentActionsCard1.TitleText = "Belge Görüntüleme / İndirme";
            this.documentActionsCard1.Visible = false;
            //
            // lblInformation
            //
            this.lblInformation.AutoSize = true;
            this.lblInformation.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblInformation.ForeColor = izibiz.UI.Controls.BrandColors.TextMuted;
            this.lblInformation.Location = new System.Drawing.Point(294, 570);
            this.lblInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(352, 20);
            this.lblInformation.TabIndex = 65;
            this.lblInformation.Text = "islem yapabılmek ıcın tablodan bir veriye  tıklayınız";
            this.lblInformation.Visible = false;
            //
            // lblEmptyIcon
            //
            this.lblEmptyIcon.Font = new System.Drawing.Font("Segoe UI", 42F);
            this.lblEmptyIcon.ForeColor = izibiz.UI.Controls.BrandColors.TealLight;
            this.lblEmptyIcon.Location = new System.Drawing.Point(291, 660);
            this.lblEmptyIcon.Name = "lblEmptyIcon";
            this.lblEmptyIcon.Size = new System.Drawing.Size(1262, 80);
            this.lblEmptyIcon.TabIndex = 69;
            this.lblEmptyIcon.Text = "📄";
            this.lblEmptyIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblEmptyText
            //
            this.lblEmptyText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblEmptyText.ForeColor = izibiz.UI.Controls.BrandColors.TextMuted;
            this.lblEmptyText.Location = new System.Drawing.Point(291, 745);
            this.lblEmptyText.Name = "lblEmptyText";
            this.lblEmptyText.Size = new System.Drawing.Size(1262, 30);
            this.lblEmptyText.TabIndex = 70;
            this.lblEmptyText.Text = "Henüz belge yok — yukarıdan SOAP ya da REST ile çekin";
            this.lblEmptyText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // FrmCreditNote
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = izibiz.UI.Controls.BrandColors.PageBackground;
            this.ClientSize = new System.Drawing.Size(1730, 932);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ControlBox = true;
            this.Controls.Add(this.lblEmptyText);
            this.Controls.Add(this.lblEmptyIcon);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.documentActionsCard1);
            this.Controls.Add(this.sourceCardRest);
            this.Controls.Add(this.sourceCardSoap);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.pnlSidebar);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "FrmCreditNote";
            this.Text = "FrmCreditNote";
            this.Load += new System.EventHandler(this.FrmCreditNote_Load);
            this.Resize += new System.EventHandler(this.FrmCreditNote_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.Button btnHamburger;
        private System.Windows.Forms.Button btnNavMustahsil;
        private System.Windows.Forms.Button btnNavDraft;
        private System.Windows.Forms.Button btnNavReports;
        private System.Windows.Forms.Button btnNavNew;
        private System.Windows.Forms.DataGridView tableGrid;
        private izibiz.UI.Controls.SourceCard sourceCardSoap;
        private izibiz.UI.Controls.SourceCard sourceCardRest;
        private izibiz.UI.Controls.DocumentActionsCard documentActionsCard1;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Label lblEmptyIcon;
        private System.Windows.Forms.Label lblEmptyText;
    }
}
