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
            this.itemListArchiveReport = new System.Windows.Forms.ToolStripMenuItem();
            this.itemArchiveNewCreated = new System.Windows.Forms.ToolStripMenuItem();
            this.btnArchiveCancel = new System.Windows.Forms.Button();
            this.btnArchiveGetState = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tableArchiveGrid = new System.Windows.Forms.DataGridView();
            this.btnArchiveView = new System.Windows.Forms.Button();
            this.rdViewHtml = new System.Windows.Forms.RadioButton();
            this.rdViewPdf = new System.Windows.Forms.RadioButton();
            this.rdViewXml = new System.Windows.Forms.RadioButton();
            this.btnTakeArchiveInv = new System.Windows.Forms.Button();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.pnlArchive = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.menuInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableArchiveGrid)).BeginInit();
            this.pnlArchive.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuInvoice
            // 
            this.menuInvoice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuInvoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuInvoice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuInvoice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemArchiveInvoices,
            this.itemArchiveNewCreated});
            this.menuInvoice.Location = new System.Drawing.Point(0, 0);
            this.menuInvoice.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.menuInvoice.Name = "menuInvoice";
            this.menuInvoice.Size = new System.Drawing.Size(138, 476);
            this.menuInvoice.TabIndex = 1;
            this.menuInvoice.Text = "menuStrip1";
            // 
            // itemArchiveInvoices
            // 
            this.itemArchiveInvoices.BackColor = System.Drawing.Color.Teal;
            this.itemArchiveInvoices.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemListArchiveReport});
            this.itemArchiveInvoices.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemArchiveInvoices.Margin = new System.Windows.Forms.Padding(0, 120, 0, 0);
            this.itemArchiveInvoices.Name = "itemArchiveInvoices";
            this.itemArchiveInvoices.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemArchiveInvoices.Size = new System.Drawing.Size(131, 29);
            this.itemArchiveInvoices.Text = "e arsiv Faturalar";
            // 
            // itemListArchiveReport
            // 
            this.itemListArchiveReport.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.itemListArchiveReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.itemListArchiveReport.Name = "itemListArchiveReport";
            this.itemListArchiveReport.Size = new System.Drawing.Size(215, 24);
            this.itemListArchiveReport.Text = "E-Arsiv rapor lıstele";
            this.itemListArchiveReport.Click += new System.EventHandler(this.itemListArchiveInvoice_Click);
            // 
            // itemArchiveNewCreated
            // 
            this.itemArchiveNewCreated.BackColor = System.Drawing.Color.Teal;
            this.itemArchiveNewCreated.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemArchiveNewCreated.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemArchiveNewCreated.Name = "itemArchiveNewCreated";
            this.itemArchiveNewCreated.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemArchiveNewCreated.Size = new System.Drawing.Size(131, 29);
            this.itemArchiveNewCreated.Text = "+ Yeni Fatura";
            this.itemArchiveNewCreated.Click += new System.EventHandler(this.itemArchiveNewCreated_Click);
            // 
            // btnArchiveCancel
            // 
            this.btnArchiveCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnArchiveCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnArchiveCancel.FlatAppearance.BorderSize = 2;
            this.btnArchiveCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchiveCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArchiveCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnArchiveCancel.Location = new System.Drawing.Point(340, 11);
            this.btnArchiveCancel.Name = "btnArchiveCancel";
            this.btnArchiveCancel.Size = new System.Drawing.Size(120, 48);
            this.btnArchiveCancel.TabIndex = 27;
            this.btnArchiveCancel.Text = "iade göster";
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
            this.btnArchiveGetState.Location = new System.Drawing.Point(200, 10);
            this.btnArchiveGetState.Name = "btnArchiveGetState";
            this.btnArchiveGetState.Size = new System.Drawing.Size(120, 49);
            this.btnArchiveGetState.TabIndex = 28;
            this.btnArchiveGetState.Text = "durum sorgula";
            this.btnArchiveGetState.UseVisualStyleBackColor = false;
            this.btnArchiveGetState.Click += new System.EventHandler(this.btnArchiveGetState_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.CadetBlue;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(220, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 49);
            this.button3.TabIndex = 29;
            this.button3.Text = "rapor detay sorgula";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnSendMail
            // 
            this.btnSendMail.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendMail.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendMail.FlatAppearance.BorderSize = 2;
            this.btnSendMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendMail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendMail.Location = new System.Drawing.Point(481, 11);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(120, 48);
            this.btnSendMail.TabIndex = 30;
            this.btnSendMail.Text = "maıle gonder";
            this.btnSendMail.UseVisualStyleBackColor = false;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.CadetBlue;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button5.FlatAppearance.BorderSize = 2;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(6, 83);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(193, 47);
            this.button5.TabIndex = 31;
            this.button5.Text = "donemlık arsıv raporu";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // tableArchiveGrid
            // 
            this.tableArchiveGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableArchiveGrid.Location = new System.Drawing.Point(161, 184);
            this.tableArchiveGrid.Name = "tableArchiveGrid";
            this.tableArchiveGrid.ReadOnly = true;
            this.tableArchiveGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableArchiveGrid.Size = new System.Drawing.Size(733, 280);
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
            this.btnArchiveView.Location = new System.Drawing.Point(8, 10);
            this.btnArchiveView.Name = "btnArchiveView";
            this.btnArchiveView.Size = new System.Drawing.Size(120, 49);
            this.btnArchiveView.TabIndex = 37;
            this.btnArchiveView.Text = "goruntule";
            this.btnArchiveView.UseVisualStyleBackColor = false;
            this.btnArchiveView.Click += new System.EventHandler(this.btnArchiveView_Click);
            // 
            // rdViewHtml
            // 
            this.rdViewHtml.AutoSize = true;
            this.rdViewHtml.Location = new System.Drawing.Point(133, 5);
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
            this.rdViewPdf.Location = new System.Drawing.Point(133, 26);
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
            this.rdViewXml.Location = new System.Drawing.Point(130, 46);
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
            this.btnTakeArchiveInv.Location = new System.Drawing.Point(173, 26);
            this.btnTakeArchiveInv.Name = "btnTakeArchiveInv";
            this.btnTakeArchiveInv.Size = new System.Drawing.Size(120, 49);
            this.btnTakeArchiveInv.TabIndex = 41;
            this.btnTakeArchiveInv.Text = "fatura al";
            this.btnTakeArchiveInv.UseVisualStyleBackColor = false;
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
            this.btnHomePage.Location = new System.Drawing.Point(16, 24);
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
            this.pnlArchive.Controls.Add(this.button1);
            this.pnlArchive.Controls.Add(this.btnArchiveView);
            this.pnlArchive.Controls.Add(this.rdViewXml);
            this.pnlArchive.Controls.Add(this.rdViewHtml);
            this.pnlArchive.Controls.Add(this.rdViewPdf);
            this.pnlArchive.Controls.Add(this.button5);
            this.pnlArchive.Controls.Add(this.btnArchiveGetState);
            this.pnlArchive.Controls.Add(this.button3);
            this.pnlArchive.Controls.Add(this.btnSendMail);
            this.pnlArchive.Controls.Add(this.btnArchiveCancel);
            this.pnlArchive.Location = new System.Drawing.Point(299, 16);
            this.pnlArchive.Name = "pnlArchive";
            this.pnlArchive.Size = new System.Drawing.Size(621, 138);
            this.pnlArchive.TabIndex = 43;
            this.pnlArchive.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CadetBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(359, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 48);
            this.button1.TabIndex = 41;
            this.button1.Text = "sms gonder";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FrmArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 476);
            this.Controls.Add(this.btnTakeArchiveInv);
            this.Controls.Add(this.pnlArchive);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.tableArchiveGrid);
            this.Controls.Add(this.menuInvoice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmArchive";
            this.Text = "FrmArchive";
            this.Load += new System.EventHandler(this.FrmArchive_Load);
            this.menuInvoice.ResumeLayout(false);
            this.menuInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableArchiveGrid)).EndInit();
            this.pnlArchive.ResumeLayout(false);
            this.pnlArchive.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemArchiveInvoices;
        private System.Windows.Forms.ToolStripMenuItem itemArchiveNewCreated;
        private System.Windows.Forms.Button btnArchiveCancel;
        private System.Windows.Forms.Button btnArchiveGetState;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView tableArchiveGrid;
        private System.Windows.Forms.Button btnArchiveView;
        private System.Windows.Forms.RadioButton rdViewHtml;
        private System.Windows.Forms.RadioButton rdViewPdf;
        private System.Windows.Forms.RadioButton rdViewXml;
        private System.Windows.Forms.ToolStripMenuItem itemListArchiveReport;
        private System.Windows.Forms.Button btnTakeArchiveInv;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.Panel pnlArchive;
        private System.Windows.Forms.Button button1;
    }
}