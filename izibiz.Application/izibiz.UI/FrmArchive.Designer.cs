namespace izibiz.UI
{
    partial class FrmArchive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmArchive));
            this.menuInvoice = new System.Windows.Forms.MenuStrip();
            this.itemArchiveInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDraftArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGetReportList = new System.Windows.Forms.ToolStripMenuItem();
            this.itemArchiveNewCreated = new System.Windows.Forms.ToolStripMenuItem();
            this.btnArchiveCancel = new System.Windows.Forms.Button();
            this.btnArchiveGetState = new System.Windows.Forms.Button();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.tableArchiveGrid = new System.Windows.Forms.DataGridView();
            this.btnArchiveView = new System.Windows.Forms.Button();
            this.rdViewHtml = new System.Windows.Forms.RadioButton();
            this.rdViewPdf = new System.Windows.Forms.RadioButton();
            this.rdViewXml = new System.Windows.Forms.RadioButton();
            this.btnTakeArchiveInv = new System.Windows.Forms.Button();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.pnlArchive = new System.Windows.Forms.Panel();
            this.btnFilterArchiveReports = new System.Windows.Forms.Button();
            this.btnGetSignedXmlArchive = new System.Windows.Forms.Button();
            this.pnlArchiveReport = new System.Windows.Forms.Panel();
            this.btnGetSingedXml = new System.Windows.Forms.Button();
            this.pnlDraftArchive = new System.Windows.Forms.Panel();
            this.btnDeleteDraftArchive = new System.Windows.Forms.Button();
            this.btnSendDraftArchive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableArchiveGrid)).BeginInit();
            this.pnlArchive.SuspendLayout();
            this.pnlArchiveReport.SuspendLayout();
            this.pnlDraftArchive.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuInvoice
            // 
            this.menuInvoice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuInvoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuInvoice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuInvoice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuInvoice.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemArchiveInvoices,
            this.itemDraftArchive,
            this.itemGetReportList,
            this.itemArchiveNewCreated});
            this.menuInvoice.Location = new System.Drawing.Point(0, 0);
            this.menuInvoice.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.menuInvoice.Name = "menuInvoice";
            this.menuInvoice.Size = new System.Drawing.Size(150, 565);
            this.menuInvoice.TabIndex = 1;
            this.menuInvoice.Text = "menuStrip1";
            // 
            // itemArchiveInvoices
            // 
            this.itemArchiveInvoices.BackColor = System.Drawing.Color.Teal;
            this.itemArchiveInvoices.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.itemArchiveInvoices.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemArchiveInvoices.Margin = new System.Windows.Forms.Padding(2, 120, 2, 2);
            this.itemArchiveInvoices.Name = "itemArchiveInvoices";
            this.itemArchiveInvoices.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemArchiveInvoices.Size = new System.Drawing.Size(139, 29);
            this.itemArchiveInvoices.Text = "Arşiv Faturalar";
            this.itemArchiveInvoices.Click += new System.EventHandler(this.itemArchiveInvoices_Click);
            // 
            // itemDraftArchive
            // 
            this.itemDraftArchive.BackColor = System.Drawing.Color.Teal;
            this.itemDraftArchive.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.itemDraftArchive.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemDraftArchive.Margin = new System.Windows.Forms.Padding(2, 40, 2, 2);
            this.itemDraftArchive.Name = "itemDraftArchive";
            this.itemDraftArchive.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemDraftArchive.Size = new System.Drawing.Size(139, 30);
            this.itemDraftArchive.Text = "Taslak Faturalar";
            this.itemDraftArchive.Click += new System.EventHandler(this.ıtemDraftArchive_Click);
            // 
            // itemGetReportList
            // 
            this.itemGetReportList.BackColor = System.Drawing.Color.Teal;
            this.itemGetReportList.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemGetReportList.Margin = new System.Windows.Forms.Padding(2, 40, 2, 2);
            this.itemGetReportList.Name = "itemGetReportList";
            this.itemGetReportList.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemGetReportList.Size = new System.Drawing.Size(139, 29);
            this.itemGetReportList.Text = "Arsiv Raporları";
            this.itemGetReportList.Click += new System.EventHandler(this.itemGetReportList_Click);
            // 
            // itemArchiveNewCreated
            // 
            this.itemArchiveNewCreated.BackColor = System.Drawing.Color.Teal;
            this.itemArchiveNewCreated.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemArchiveNewCreated.Margin = new System.Windows.Forms.Padding(2, 40, 2, 2);
            this.itemArchiveNewCreated.Name = "itemArchiveNewCreated";
            this.itemArchiveNewCreated.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemArchiveNewCreated.Size = new System.Drawing.Size(139, 29);
            this.itemArchiveNewCreated.Text = "+ Yeni Fatura";
            this.itemArchiveNewCreated.Click += new System.EventHandler(this.itemArchiveNewCreated_Click);
            // 
            // btnArchiveCancel
            // 
            this.btnArchiveCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnArchiveCancel.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnArchiveCancel.FlatAppearance.BorderSize = 2;
            this.btnArchiveCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchiveCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArchiveCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnArchiveCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnArchiveCancel.Image")));
            this.btnArchiveCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnArchiveCancel.Location = new System.Drawing.Point(443, 11);

            this.btnArchiveCancel.Location = new System.Drawing.Point(591, 14);
            this.btnArchiveCancel.Margin = new System.Windows.Forms.Padding(4);

            this.btnArchiveCancel.Name = "btnArchiveCancel";
            this.btnArchiveCancel.Size = new System.Drawing.Size(115, 48);
            this.btnArchiveCancel.TabIndex = 27;
            this.btnArchiveCancel.Text = "iade et";
            this.btnArchiveCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArchiveCancel.UseVisualStyleBackColor = false;
            this.btnArchiveCancel.Click += new System.EventHandler(this.btnArchiveCancel_Click);
            // 
            // btnArchiveGetState
            // 
            this.btnArchiveGetState.BackColor = System.Drawing.Color.CadetBlue;
            this.btnArchiveGetState.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnArchiveGetState.FlatAppearance.BorderSize = 2;
            this.btnArchiveGetState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchiveGetState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArchiveGetState.ForeColor = System.Drawing.SystemColors.ButtonHighlight;

            this.btnArchiveGetState.Location = new System.Drawing.Point(317, 11);

            this.btnArchiveGetState.Location = new System.Drawing.Point(423, 14);
            this.btnArchiveGetState.Margin = new System.Windows.Forms.Padding(4);

            this.btnArchiveGetState.Name = "btnArchiveGetState";
            this.btnArchiveGetState.Size = new System.Drawing.Size(120, 49);
            this.btnArchiveGetState.TabIndex = 28;
            this.btnArchiveGetState.Text = "durum sorgula";
            this.btnArchiveGetState.UseVisualStyleBackColor = false;
            this.btnArchiveGetState.Click += new System.EventHandler(this.btnArchiveGetState_Click);
            // 
            // btnSendMail
            // 
            this.btnSendMail.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendMail.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendMail.FlatAppearance.BorderSize = 2;
            this.btnSendMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendMail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendMail.Location = new System.Drawing.Point(564, 11);
            this.btnSendMail.Location = new System.Drawing.Point(752, 14);
            this.btnSendMail.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(120, 48);
            this.btnSendMail.TabIndex = 30;
            this.btnSendMail.Text = "maıle gonder";
            this.btnSendMail.UseVisualStyleBackColor = false;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // tableArchiveGrid
            // 
            this.tableArchiveGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableArchiveGrid.Location = new System.Drawing.Point(223, 182);
            this.tableArchiveGrid.Location = new System.Drawing.Point(297, 224);
            this.tableArchiveGrid.Margin = new System.Windows.Forms.Padding(4);
            this.tableArchiveGrid.Name = "tableArchiveGrid";
            this.tableArchiveGrid.ReadOnly = true;
            this.tableArchiveGrid.RowHeadersWidth = 51;
            this.tableArchiveGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableArchiveGrid.Size = new System.Drawing.Size(808, 371);
            this.tableArchiveGrid.TabIndex = 36;
            this.tableArchiveGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableArchiveGrid_CellClick);
            this.tableArchiveGrid.SelectionChanged += new System.EventHandler(this.tableArchiveGrid_SelectionChanged);
            // 
            // btnArchiveView
            // 
            this.btnArchiveView.BackColor = System.Drawing.Color.CadetBlue;
            this.btnArchiveView.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnArchiveView.FlatAppearance.BorderSize = 2;
            this.btnArchiveView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchiveView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArchiveView.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnArchiveView.Location = new System.Drawing.Point(12, 14);
            this.btnArchiveView.Location = new System.Drawing.Point(16, 17);
            this.btnArchiveView.Margin = new System.Windows.Forms.Padding(4);
            this.btnArchiveView.Name = "btnArchiveView";
            this.btnArchiveView.Size = new System.Drawing.Size(102, 49);
            this.btnArchiveView.TabIndex = 37;
            this.btnArchiveView.Text = "goruntule";
            this.btnArchiveView.UseVisualStyleBackColor = false;
            this.btnArchiveView.Click += new System.EventHandler(this.btnArchiveView_Click);
            // 
            // rdViewHtml
            // 
            this.rdViewHtml.AutoSize = true;
            this.rdViewHtml.Location = new System.Drawing.Point(120, 11);
            this.rdViewHtml.Location = new System.Drawing.Point(160, 14);
            this.rdViewHtml.Margin = new System.Windows.Forms.Padding(4);
            this.rdViewHtml.Name = "rdViewHtml";
            this.rdViewHtml.Size = new System.Drawing.Size(44, 17);
            this.rdViewHtml.TabIndex = 38;
            this.rdViewHtml.TabStop = true;
            this.rdViewHtml.Text = "html";
            this.rdViewHtml.UseVisualStyleBackColor = true;
            // 
            // rdViewPdf
            // 
            this.rdViewPdf.AutoSize = true;
            this.rdViewPdf.Location = new System.Drawing.Point(120, 30);
            this.rdViewPdf.Location = new System.Drawing.Point(160, 37);
            this.rdViewPdf.Margin = new System.Windows.Forms.Padding(4);
            this.rdViewPdf.Name = "rdViewPdf";
            this.rdViewPdf.Size = new System.Drawing.Size(40, 17);
            this.rdViewPdf.TabIndex = 39;
            this.rdViewPdf.TabStop = true;
            this.rdViewPdf.Text = "pdf";
            this.rdViewPdf.UseVisualStyleBackColor = true;
            // 
            // rdViewXml
            // 
            this.rdViewXml.AutoSize = true;
            this.rdViewXml.Location = new System.Drawing.Point(120, 49);
            this.rdViewXml.Location = new System.Drawing.Point(160, 60);
            this.rdViewXml.Margin = new System.Windows.Forms.Padding(4);
            this.rdViewXml.Name = "rdViewXml";
            this.rdViewXml.Size = new System.Drawing.Size(68, 17);
            this.rdViewXml.TabIndex = 40;
            this.rdViewXml.TabStop = true;
            this.rdViewXml.Text = "imzalı xml";
            this.rdViewXml.UseVisualStyleBackColor = true;
            // 
            // btnTakeArchiveInv
            // 
            this.btnTakeArchiveInv.BackColor = System.Drawing.Color.CadetBlue;
            this.btnTakeArchiveInv.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnTakeArchiveInv.FlatAppearance.BorderSize = 2;
            this.btnTakeArchiveInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeArchiveInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTakeArchiveInv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTakeArchiveInv.Location = new System.Drawing.Point(168, 24);
            this.btnTakeArchiveInv.Location = new System.Drawing.Point(224, 30);
            this.btnTakeArchiveInv.Margin = new System.Windows.Forms.Padding(4);
            this.btnTakeArchiveInv.Name = "btnTakeArchiveInv";
            this.btnTakeArchiveInv.Size = new System.Drawing.Size(120, 49);
            this.btnTakeArchiveInv.TabIndex = 41;
            this.btnTakeArchiveInv.Text = "fatura al";
            this.btnTakeArchiveInv.UseVisualStyleBackColor = false;
            this.btnTakeArchiveInv.Visible = false;
            this.btnTakeArchiveInv.Click += new System.EventHandler(this.btnTakeArchiveInv_Click);
            // 
            // btnHomePage
            // 
            this.btnHomePage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnHomePage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHomePage.BackgroundImage")));
            this.btnHomePage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHomePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHomePage.FlatAppearance.BorderSize = 0;
            this.btnHomePage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnHomePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHomePage.ForeColor = System.Drawing.Color.Snow;
            this.btnHomePage.Location = new System.Drawing.Point(23, 24);
            this.btnHomePage.Location = new System.Drawing.Point(31, 30);
            this.btnHomePage.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(109, 70);
            this.btnHomePage.TabIndex = 42;
            this.btnHomePage.Text = "Ana Sayfa";
            this.btnHomePage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHomePage.UseVisualStyleBackColor = false;
            this.btnHomePage.Click += new System.EventHandler(this.btnHomePage_Click);
            // 
            // pnlArchive
            // 
            this.pnlArchive.Controls.Add(this.btnFilterArchiveReports);
            this.pnlArchive.Controls.Add(this.btnGetSignedXmlArchive);
            this.pnlArchive.Controls.Add(this.btnArchiveView);
            this.pnlArchive.Controls.Add(this.btnSendMail);
            this.pnlArchive.Controls.Add(this.rdViewXml);
            this.pnlArchive.Controls.Add(this.rdViewHtml);
            this.pnlArchive.Controls.Add(this.rdViewPdf);
            this.pnlArchive.Controls.Add(this.btnArchiveGetState);
            this.pnlArchive.Controls.Add(this.btnArchiveCancel);
            this.pnlArchive.Location = new System.Drawing.Point(291, 12);
            this.pnlArchive.Location = new System.Drawing.Point(388, 15);
            this.pnlArchive.Margin = new System.Windows.Forms.Padding(4);
            this.pnlArchive.Name = "pnlArchive";
            this.pnlArchive.Size = new System.Drawing.Size(689, 136);
            this.pnlArchive.TabIndex = 43;
            this.pnlArchive.Visible = false;
            // 
            // btnFilterArchiveReports
            // 
            this.btnFilterArchiveReports.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnFilterArchiveReports.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnFilterArchiveReports.FlatAppearance.BorderSize = 2;
            this.btnFilterArchiveReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterArchiveReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFilterArchiveReports.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFilterArchiveReports.Location = new System.Drawing.Point(12, 82);
            this.btnFilterArchiveReports.Location = new System.Drawing.Point(16, 101);
            this.btnFilterArchiveReports.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilterArchiveReports.Name = "btnFilterArchiveReports";
            this.btnFilterArchiveReports.Size = new System.Drawing.Size(128, 47);
            this.btnFilterArchiveReports.TabIndex = 42;
            this.btnFilterArchiveReports.Text = "Raporlananlar";
            this.btnFilterArchiveReports.UseVisualStyleBackColor = false;
            this.btnFilterArchiveReports.Click += new System.EventHandler(this.btnFilterArchiveReports_Click);
            // 
            // btnGetSignedXmlArchive
            // 
            this.btnGetSignedXmlArchive.BackColor = System.Drawing.Color.CadetBlue;
            this.btnGetSignedXmlArchive.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGetSignedXmlArchive.FlatAppearance.BorderSize = 2;
            this.btnGetSignedXmlArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetSignedXmlArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetSignedXmlArchive.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetSignedXmlArchive.Location = new System.Drawing.Point(194, 11);
            this.btnGetSignedXmlArchive.Location = new System.Drawing.Point(259, 14);
            this.btnGetSignedXmlArchive.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetSignedXmlArchive.Name = "btnGetSignedXmlArchive";
            this.btnGetSignedXmlArchive.Size = new System.Drawing.Size(112, 49);
            this.btnGetSignedXmlArchive.TabIndex = 41;
            this.btnGetSignedXmlArchive.Text = "imzalı Xml Al";
            this.btnGetSignedXmlArchive.UseVisualStyleBackColor = false;
            this.btnGetSignedXmlArchive.Click += new System.EventHandler(this.btnGetSignedXmlArchive_Click);
            // 
            // pnlArchiveReport
            // 
            this.pnlArchiveReport.Controls.Add(this.btnGetSingedXml);
            this.pnlArchiveReport.Location = new System.Drawing.Point(291, 12);
            this.pnlArchiveReport.Location = new System.Drawing.Point(388, 15);
            this.pnlArchiveReport.Margin = new System.Windows.Forms.Padding(4);
            this.pnlArchiveReport.Name = "pnlArchiveReport";
            this.pnlArchiveReport.Size = new System.Drawing.Size(689, 136);
            this.pnlArchiveReport.TabIndex = 45;
            this.pnlArchiveReport.Visible = false;
            // 
            // btnGetSingedXml
            // 
            this.btnGetSingedXml.BackColor = System.Drawing.Color.CadetBlue;
            this.btnGetSingedXml.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGetSingedXml.FlatAppearance.BorderSize = 2;
            this.btnGetSingedXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetSingedXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetSingedXml.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetSingedXml.Location = new System.Drawing.Point(12, 8);
            this.btnGetSingedXml.Location = new System.Drawing.Point(16, 10);
            this.btnGetSingedXml.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetSingedXml.Name = "btnGetSingedXml";
            this.btnGetSingedXml.Size = new System.Drawing.Size(120, 51);
            this.btnGetSingedXml.TabIndex = 45;
            this.btnGetSingedXml.Text = "Imzali Xml Al";
            this.btnGetSingedXml.UseVisualStyleBackColor = false;
            this.btnGetSingedXml.Click += new System.EventHandler(this.btnGetSingedXml_Click);
            // 
            // pnlDraftArchive
            // 
            this.pnlDraftArchive.Controls.Add(this.btnDeleteDraftArchive);
            this.pnlDraftArchive.Controls.Add(this.btnSendDraftArchive);
            this.pnlDraftArchive.Location = new System.Drawing.Point(291, 12);
            this.pnlDraftArchive.Location = new System.Drawing.Point(388, 15);
            this.pnlDraftArchive.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDraftArchive.Name = "pnlDraftArchive";
            this.pnlDraftArchive.Size = new System.Drawing.Size(689, 136);
            this.pnlDraftArchive.TabIndex = 46;
            this.pnlDraftArchive.Visible = false;
            // 
            // btnDeleteDraftArchive
            // 
            this.btnDeleteDraftArchive.BackColor = System.Drawing.Color.Crimson;
            this.btnDeleteDraftArchive.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnDeleteDraftArchive.FlatAppearance.BorderSize = 2;
            this.btnDeleteDraftArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDraftArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDeleteDraftArchive.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteDraftArchive.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteDraftArchive.Image")));
            this.btnDeleteDraftArchive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDraftArchive.Location = new System.Drawing.Point(151, 13);
            this.btnDeleteDraftArchive.Location = new System.Drawing.Point(201, 16);
            this.btnDeleteDraftArchive.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteDraftArchive.Name = "btnDeleteDraftArchive";
            this.btnDeleteDraftArchive.Size = new System.Drawing.Size(117, 47);
            this.btnDeleteDraftArchive.TabIndex = 42;
            this.btnDeleteDraftArchive.Text = "Sil";
            this.btnDeleteDraftArchive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteDraftArchive.UseVisualStyleBackColor = false;
            this.btnDeleteDraftArchive.Click += new System.EventHandler(this.btnCancelDraftArchive_Click);
            // 
            // btnSendDraftArchive
            // 
            this.btnSendDraftArchive.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendDraftArchive.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendDraftArchive.FlatAppearance.BorderSize = 2;
            this.btnSendDraftArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendDraftArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendDraftArchive.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendDraftArchive.Location = new System.Drawing.Point(12, 13);
            this.btnSendDraftArchive.Location = new System.Drawing.Point(16, 16);
            this.btnSendDraftArchive.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendDraftArchive.Name = "btnSendDraftArchive";
            this.btnSendDraftArchive.Size = new System.Drawing.Size(120, 47);
            this.btnSendDraftArchive.TabIndex = 41;
            this.btnSendDraftArchive.Text = "Gönder";
            this.btnSendDraftArchive.UseVisualStyleBackColor = false;
            this.btnSendDraftArchive.Click += new System.EventHandler(this.btnSendDraftArchive_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(371, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "islem yapabılmek ıcın tablodan bir veriye  tıklayınız";
            // 
            // FrmArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 565);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTakeArchiveInv);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.tableArchiveGrid);
            this.Controls.Add(this.menuInvoice);
            this.Controls.Add(this.pnlArchive);
            this.Controls.Add(this.pnlDraftArchive);
            this.Controls.Add(this.pnlArchiveReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmArchive";
            this.Text = "FrmArchive";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmArchive_FormClosed);
            this.Load += new System.EventHandler(this.FrmArchive_Load);
            this.menuInvoice.ResumeLayout(false);
            this.menuInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableArchiveGrid)).EndInit();
            this.pnlArchive.ResumeLayout(false);
            this.pnlArchive.PerformLayout();
            this.pnlArchiveReport.ResumeLayout(false);
            this.pnlDraftArchive.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemArchiveInvoices;
        private System.Windows.Forms.ToolStripMenuItem itemArchiveNewCreated;
        private System.Windows.Forms.Button btnArchiveCancel;
        private System.Windows.Forms.Button btnArchiveGetState;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.DataGridView tableArchiveGrid;
        private System.Windows.Forms.Button btnArchiveView;
        private System.Windows.Forms.RadioButton rdViewHtml;
        private System.Windows.Forms.RadioButton rdViewPdf;
        private System.Windows.Forms.RadioButton rdViewXml;
        private System.Windows.Forms.Button btnTakeArchiveInv;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.Panel pnlArchive;
        private System.Windows.Forms.ToolStripMenuItem itemGetReportList;
        private System.Windows.Forms.Panel pnlArchiveReport;
        private System.Windows.Forms.Button btnGetSingedXml;
        private System.Windows.Forms.ToolStripMenuItem itemDraftArchive;
        private System.Windows.Forms.Panel pnlDraftArchive;
        private System.Windows.Forms.Button btnSendDraftArchive;
        private System.Windows.Forms.Button btnDeleteDraftArchive;
        private System.Windows.Forms.Button btnGetSignedXmlArchive;
        private System.Windows.Forms.Button btnFilterArchiveReports;
        private System.Windows.Forms.Label label1;
    }
}