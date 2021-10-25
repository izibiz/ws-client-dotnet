namespace izibiz.UI
{
    partial class FrmSelfEmployment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelfEmployment));
            this.IblInformation = new System.Windows.Forms.Label();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.itemNewSmm = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGetSmmReports = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGetDraftSmm = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGetSmm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTakeSmm = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.pnlDraftSmm = new System.Windows.Forms.Panel();
            this.pnlSmm = new System.Windows.Forms.Panel();
            this.btnFilterArchiveReports = new System.Windows.Forms.Button();
            this.btnGetSignedXmlArchive = new System.Windows.Forms.Button();
            this.btnCreditNoteView = new System.Windows.Forms.Button();
            this.rdViewXml = new System.Windows.Forms.RadioButton();
            this.rdViewHtml = new System.Windows.Forms.RadioButton();
            this.rdViewPdf = new System.Windows.Forms.RadioButton();
            this.btnArchiveGetState = new System.Windows.Forms.Button();
            this.btnArchiveCancel = new System.Windows.Forms.Button();
            this.pnlSmmReports = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.menu.SuspendLayout();
            this.pnlSmm.SuspendLayout();
            this.SuspendLayout();
            // 
            // IblInformation
            // 
            this.IblInformation.AutoSize = true;
            this.IblInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IblInformation.Location = new System.Drawing.Point(255, 418);
            this.IblInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IblInformation.Name = "IblInformation";
            this.IblInformation.Size = new System.Drawing.Size(383, 20);
            this.IblInformation.TabIndex = 61;
            this.IblInformation.Text = "islem yapabılmek ıcın tablodan bir veriye  tıklayınız";
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
            this.btnHomePage.Location = new System.Drawing.Point(14, 34);
            this.btnHomePage.Margin = new System.Windows.Forms.Padding(5);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(145, 86);
            this.btnHomePage.TabIndex = 57;
            this.btnHomePage.Text = "Ana Sayfa";
            this.btnHomePage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHomePage.UseVisualStyleBackColor = false;
            this.btnHomePage.Click += new System.EventHandler(this.BtnHomePage_Click);
            // 
            // itemNewSmm
            // 
            this.itemNewSmm.BackColor = System.Drawing.Color.Teal;
            this.itemNewSmm.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemNewSmm.Margin = new System.Windows.Forms.Padding(2, 40, 2, 2);
            this.itemNewSmm.Name = "itemNewSmm";
            this.itemNewSmm.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemNewSmm.Size = new System.Drawing.Size(154, 34);
            this.itemNewSmm.Text = "+ Yeni Smm";
            // 
            // itemGetSmmReports
            // 
            this.itemGetSmmReports.BackColor = System.Drawing.Color.Teal;
            this.itemGetSmmReports.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemGetSmmReports.Margin = new System.Windows.Forms.Padding(2, 40, 2, 2);
            this.itemGetSmmReports.Name = "itemGetSmmReports";
            this.itemGetSmmReports.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemGetSmmReports.Size = new System.Drawing.Size(154, 34);
            this.itemGetSmmReports.Text = "Smm Raporları";
            this.itemGetSmmReports.Click += new System.EventHandler(this.ItemGetSmmReports_Click);
            // 
            // itemGetDraftSmm
            // 
            this.itemGetDraftSmm.BackColor = System.Drawing.Color.Teal;
            this.itemGetDraftSmm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.itemGetDraftSmm.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemGetDraftSmm.Margin = new System.Windows.Forms.Padding(2, 40, 2, 2);
            this.itemGetDraftSmm.Name = "itemGetDraftSmm";
            this.itemGetDraftSmm.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemGetDraftSmm.Size = new System.Drawing.Size(154, 37);
            this.itemGetDraftSmm.Text = "Taslak Smm";
            this.itemGetDraftSmm.Click += new System.EventHandler(this.ItemGetDraftSmm_Click);
            // 
            // itemGetSmm
            // 
            this.itemGetSmm.BackColor = System.Drawing.Color.Teal;
            this.itemGetSmm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.itemGetSmm.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemGetSmm.Margin = new System.Windows.Forms.Padding(2, 140, 2, 2);
            this.itemGetSmm.Name = "itemGetSmm";
            this.itemGetSmm.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemGetSmm.Size = new System.Drawing.Size(154, 34);
            this.itemGetSmm.Text = "E-Smm";
            this.itemGetSmm.Click += new System.EventHandler(this.ItemGetSmm_Click);
            // 
            // btnTakeSmm
            // 
            this.btnTakeSmm.BackColor = System.Drawing.Color.CadetBlue;
            this.btnTakeSmm.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnTakeSmm.FlatAppearance.BorderSize = 2;
            this.btnTakeSmm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeSmm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTakeSmm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTakeSmm.Location = new System.Drawing.Point(261, 60);
            this.btnTakeSmm.Margin = new System.Windows.Forms.Padding(5);
            this.btnTakeSmm.Name = "btnTakeSmm";
            this.btnTakeSmm.Size = new System.Drawing.Size(160, 60);
            this.btnTakeSmm.TabIndex = 56;
            this.btnTakeSmm.Text = "smm al";
            this.btnTakeSmm.UseVisualStyleBackColor = false;
            this.btnTakeSmm.Visible = false;
            this.btnTakeSmm.Click += new System.EventHandler(this.BtnTakeSmm_Click);
            // 
            // tableGrid
            // 
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.Location = new System.Drawing.Point(259, 443);
            this.tableGrid.Margin = new System.Windows.Forms.Padding(5);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.RowHeadersWidth = 51;
            this.tableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGrid.Size = new System.Drawing.Size(1077, 280);
            this.tableGrid.TabIndex = 55;
            this.tableGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableGrid_CellClick);
            this.tableGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableGrid_CellContentClick);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemGetSmm,
            this.itemGetDraftSmm,
            this.itemGetSmmReports,
            this.itemNewSmm});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Margin = new System.Windows.Forms.Padding(0, 0, 27, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(165, 746);
            this.menu.TabIndex = 54;
            this.menu.Text = "menuStrip1";
            // 
            // pnlDraftSmm
            // 
            this.pnlDraftSmm.Location = new System.Drawing.Point(429, 34);
            this.pnlDraftSmm.Name = "pnlDraftSmm";
            this.pnlDraftSmm.Size = new System.Drawing.Size(921, 106);
            this.pnlDraftSmm.TabIndex = 62;
            this.pnlDraftSmm.Visible = false;
            this.pnlDraftSmm.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDraftSmm_Paint);
            // 
            // pnlSmm
            // 
            this.pnlSmm.Controls.Add(this.btnFilterArchiveReports);
            this.pnlSmm.Controls.Add(this.btnGetSignedXmlArchive);
            this.pnlSmm.Controls.Add(this.btnCreditNoteView);
            this.pnlSmm.Controls.Add(this.rdViewXml);
            this.pnlSmm.Controls.Add(this.rdViewHtml);
            this.pnlSmm.Controls.Add(this.rdViewPdf);
            this.pnlSmm.Controls.Add(this.btnArchiveGetState);
            this.pnlSmm.Controls.Add(this.btnArchiveCancel);
            this.pnlSmm.Location = new System.Drawing.Point(429, 146);
            this.pnlSmm.Name = "pnlSmm";
            this.pnlSmm.Size = new System.Drawing.Size(921, 115);
            this.pnlSmm.TabIndex = 63;
            this.pnlSmm.Visible = false;
            // 
            // btnFilterArchiveReports
            // 
            this.btnFilterArchiveReports.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnFilterArchiveReports.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnFilterArchiveReports.FlatAppearance.BorderSize = 2;
            this.btnFilterArchiveReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterArchiveReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFilterArchiveReports.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFilterArchiveReports.Location = new System.Drawing.Point(744, 30);
            this.btnFilterArchiveReports.Margin = new System.Windows.Forms.Padding(5);
            this.btnFilterArchiveReports.Name = "btnFilterArchiveReports";
            this.btnFilterArchiveReports.Size = new System.Drawing.Size(171, 58);
            this.btnFilterArchiveReports.TabIndex = 58;
            this.btnFilterArchiveReports.Text = "Raporlananlar";
            this.btnFilterArchiveReports.UseVisualStyleBackColor = false;
            // 
            // btnGetSignedXmlArchive
            // 
            this.btnGetSignedXmlArchive.BackColor = System.Drawing.Color.CadetBlue;
            this.btnGetSignedXmlArchive.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGetSignedXmlArchive.FlatAppearance.BorderSize = 2;
            this.btnGetSignedXmlArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetSignedXmlArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetSignedXmlArchive.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetSignedXmlArchive.Location = new System.Drawing.Point(210, 30);
            this.btnGetSignedXmlArchive.Margin = new System.Windows.Forms.Padding(5);
            this.btnGetSignedXmlArchive.Name = "btnGetSignedXmlArchive";
            this.btnGetSignedXmlArchive.Size = new System.Drawing.Size(149, 60);
            this.btnGetSignedXmlArchive.TabIndex = 57;
            this.btnGetSignedXmlArchive.Text = "imzalı Xml Al";
            this.btnGetSignedXmlArchive.UseVisualStyleBackColor = false;
            // 
            // btnCreditNoteView
            // 
            this.btnCreditNoteView.BackColor = System.Drawing.Color.CadetBlue;
            this.btnCreditNoteView.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnCreditNoteView.FlatAppearance.BorderSize = 2;
            this.btnCreditNoteView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreditNoteView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCreditNoteView.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreditNoteView.Location = new System.Drawing.Point(5, 29);
            this.btnCreditNoteView.Margin = new System.Windows.Forms.Padding(5);
            this.btnCreditNoteView.Name = "btnCreditNoteView";
            this.btnCreditNoteView.Size = new System.Drawing.Size(136, 60);
            this.btnCreditNoteView.TabIndex = 53;
            this.btnCreditNoteView.Text = "goruntule";
            this.btnCreditNoteView.UseVisualStyleBackColor = false;
            this.btnCreditNoteView.Click += new System.EventHandler(this.btnCreditNoteView_Click);
            // 
            // rdViewXml
            // 
            this.rdViewXml.AutoSize = true;
            this.rdViewXml.Location = new System.Drawing.Point(151, 82);
            this.rdViewXml.Margin = new System.Windows.Forms.Padding(5);
            this.rdViewXml.Name = "rdViewXml";
            this.rdViewXml.Size = new System.Drawing.Size(49, 21);
            this.rdViewXml.TabIndex = 56;
            this.rdViewXml.TabStop = true;
            this.rdViewXml.Text = "xml";
            this.rdViewXml.UseVisualStyleBackColor = true;
            // 
            // rdViewHtml
            // 
            this.rdViewHtml.AutoSize = true;
            this.rdViewHtml.Location = new System.Drawing.Point(151, 24);
            this.rdViewHtml.Margin = new System.Windows.Forms.Padding(5);
            this.rdViewHtml.Name = "rdViewHtml";
            this.rdViewHtml.Size = new System.Drawing.Size(55, 21);
            this.rdViewHtml.TabIndex = 54;
            this.rdViewHtml.TabStop = true;
            this.rdViewHtml.Text = "html";
            this.rdViewHtml.UseVisualStyleBackColor = true;
            // 
            // rdViewPdf
            // 
            this.rdViewPdf.AutoSize = true;
            this.rdViewPdf.Location = new System.Drawing.Point(151, 51);
            this.rdViewPdf.Margin = new System.Windows.Forms.Padding(5);
            this.rdViewPdf.Name = "rdViewPdf";
            this.rdViewPdf.Size = new System.Drawing.Size(49, 21);
            this.rdViewPdf.TabIndex = 55;
            this.rdViewPdf.TabStop = true;
            this.rdViewPdf.Text = "pdf";
            this.rdViewPdf.UseVisualStyleBackColor = true;
            // 
            // btnArchiveGetState
            // 
            this.btnArchiveGetState.BackColor = System.Drawing.Color.CadetBlue;
            this.btnArchiveGetState.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnArchiveGetState.FlatAppearance.BorderSize = 2;
            this.btnArchiveGetState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchiveGetState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArchiveGetState.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnArchiveGetState.Location = new System.Drawing.Point(386, 30);
            this.btnArchiveGetState.Margin = new System.Windows.Forms.Padding(5);
            this.btnArchiveGetState.Name = "btnArchiveGetState";
            this.btnArchiveGetState.Size = new System.Drawing.Size(160, 60);
            this.btnArchiveGetState.TabIndex = 52;
            this.btnArchiveGetState.Text = "durum sorgula";
            this.btnArchiveGetState.UseVisualStyleBackColor = false;
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
            this.btnArchiveCancel.Location = new System.Drawing.Point(566, 31);
            this.btnArchiveCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnArchiveCancel.Name = "btnArchiveCancel";
            this.btnArchiveCancel.Size = new System.Drawing.Size(153, 59);
            this.btnArchiveCancel.TabIndex = 51;
            this.btnArchiveCancel.Text = "iade et";
            this.btnArchiveCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArchiveCancel.UseVisualStyleBackColor = false;
            // 
            // pnlSmmReports
            // 
            this.pnlSmmReports.Location = new System.Drawing.Point(429, 285);
            this.pnlSmmReports.Name = "pnlSmmReports";
            this.pnlSmmReports.Size = new System.Drawing.Size(921, 104);
            this.pnlSmmReports.TabIndex = 64;
            this.pnlSmmReports.Visible = false;
            // 
            // FrmSelfEmployment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 746);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSmmReports);
            this.Controls.Add(this.pnlSmm);
            this.Controls.Add(this.pnlDraftSmm);
            this.Controls.Add(this.IblInformation);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.btnTakeSmm);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.menu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelfEmployment";
            this.Text = "FrmSelfEmployment";
            this.Load += new System.EventHandler(this.FrmSelfEmployment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlSmm.ResumeLayout(false);
            this.pnlSmm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IblInformation;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.ToolStripMenuItem itemNewSmm;
        private System.Windows.Forms.ToolStripMenuItem itemGetSmmReports;
        private System.Windows.Forms.ToolStripMenuItem itemGetDraftSmm;
        private System.Windows.Forms.ToolStripMenuItem itemGetSmm;
        private System.Windows.Forms.Button btnTakeSmm;
        private System.Windows.Forms.DataGridView tableGrid;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.Panel pnlDraftSmm;
        private System.Windows.Forms.Panel pnlSmm;
        private System.Windows.Forms.Panel pnlSmmReports;
        private System.Windows.Forms.Button btnFilterArchiveReports;
        private System.Windows.Forms.Button btnGetSignedXmlArchive;
        private System.Windows.Forms.Button btnCreditNoteView;
        private System.Windows.Forms.RadioButton rdViewXml;
        private System.Windows.Forms.RadioButton rdViewHtml;
        private System.Windows.Forms.RadioButton rdViewPdf;
        private System.Windows.Forms.Button btnArchiveGetState;
        private System.Windows.Forms.Button btnArchiveCancel;
    }
}