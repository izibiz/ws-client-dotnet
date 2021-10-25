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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreditNote));
            this.label1 = new System.Windows.Forms.Label();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.itemNewCreditNote = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGetCreditNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGetDraftCreditNote = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGetCreditNote = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTakeCreditNote = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.pnlDraftCreditNote = new System.Windows.Forms.Panel();
            this.pnlCreditNote = new System.Windows.Forms.Panel();
            this.btnCreditNoteView = new System.Windows.Forms.Button();
            this.rdViewXml = new System.Windows.Forms.RadioButton();
            this.rdViewHtml = new System.Windows.Forms.RadioButton();
            this.rdViewPdf = new System.Windows.Forms.RadioButton();
            this.pnlCreditNoteReports = new System.Windows.Forms.Panel();
            this.lblInformation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.menu.SuspendLayout();
            this.pnlDraftCreditNote.SuspendLayout();
            this.pnlCreditNote.SuspendLayout();
            this.pnlCreditNoteReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(287, 522);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 61;
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
            this.btnHomePage.Location = new System.Drawing.Point(16, 42);
            this.btnHomePage.Margin = new System.Windows.Forms.Padding(6);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(163, 108);
            this.btnHomePage.TabIndex = 57;
            this.btnHomePage.Text = "Ana Sayfa";
            this.btnHomePage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHomePage.UseVisualStyleBackColor = false;
            this.btnHomePage.Click += new System.EventHandler(this.BtnHomePage_Click);
            // 
            // itemNewCreditNote
            // 
            this.itemNewCreditNote.BackColor = System.Drawing.Color.Teal;
            this.itemNewCreditNote.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemNewCreditNote.Margin = new System.Windows.Forms.Padding(2, 40, 2, 2);
            this.itemNewCreditNote.Name = "itemNewCreditNote";
            this.itemNewCreditNote.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemNewCreditNote.Size = new System.Drawing.Size(245, 39);
            this.itemNewCreditNote.Text = "+ Yeni E-Müstahsil";
            // 
            // itemGetCreditNotes
            // 
            this.itemGetCreditNotes.BackColor = System.Drawing.Color.Teal;
            this.itemGetCreditNotes.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemGetCreditNotes.Margin = new System.Windows.Forms.Padding(2, 40, 2, 2);
            this.itemGetCreditNotes.Name = "itemGetCreditNotes";
            this.itemGetCreditNotes.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemGetCreditNotes.Size = new System.Drawing.Size(245, 39);
            this.itemGetCreditNotes.Text = "E-Müstahsil Raporları";
            this.itemGetCreditNotes.Click += new System.EventHandler(this.ItemGetCreditNote_Click);
            // 
            // itemGetDraftCreditNote
            // 
            this.itemGetDraftCreditNote.BackColor = System.Drawing.Color.Teal;
            this.itemGetDraftCreditNote.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.itemGetDraftCreditNote.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemGetDraftCreditNote.Margin = new System.Windows.Forms.Padding(2, 40, 2, 2);
            this.itemGetDraftCreditNote.Name = "itemGetDraftCreditNote";
            this.itemGetDraftCreditNote.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemGetDraftCreditNote.Size = new System.Drawing.Size(245, 41);
            this.itemGetDraftCreditNote.Text = "Taslak E-Müstahsil";
            this.itemGetDraftCreditNote.Click += new System.EventHandler(this.ItemGetDraftCreditNote_Click);
            // 
            // itemGetCreditNote
            // 
            this.itemGetCreditNote.BackColor = System.Drawing.Color.Teal;
            this.itemGetCreditNote.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.itemGetCreditNote.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemGetCreditNote.Margin = new System.Windows.Forms.Padding(2, 140, 2, 2);
            this.itemGetCreditNote.Name = "itemGetCreditNote";
            this.itemGetCreditNote.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemGetCreditNote.Size = new System.Drawing.Size(245, 40);
            this.itemGetCreditNote.Text = "E-Müstahsil";
            this.itemGetCreditNote.Click += new System.EventHandler(this.ItemGetCreditNote_Click);
            // 
            // btnTakeCreditNote
            // 
            this.btnTakeCreditNote.BackColor = System.Drawing.Color.CadetBlue;
            this.btnTakeCreditNote.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnTakeCreditNote.FlatAppearance.BorderSize = 2;
            this.btnTakeCreditNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeCreditNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTakeCreditNote.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTakeCreditNote.Location = new System.Drawing.Point(294, 75);
            this.btnTakeCreditNote.Margin = new System.Windows.Forms.Padding(6);
            this.btnTakeCreditNote.Name = "btnTakeCreditNote";
            this.btnTakeCreditNote.Size = new System.Drawing.Size(180, 75);
            this.btnTakeCreditNote.TabIndex = 56;
            this.btnTakeCreditNote.Text = "E-Müstahsil al";
            this.btnTakeCreditNote.UseVisualStyleBackColor = false;
            this.btnTakeCreditNote.Visible = false;
            this.btnTakeCreditNote.Click += new System.EventHandler(this.BtnTakeCreditNote_Click);
            // 
            // tableGrid
            // 
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.Location = new System.Drawing.Point(291, 554);
            this.tableGrid.Margin = new System.Windows.Forms.Padding(6);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.RowHeadersWidth = 51;
            this.tableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGrid.Size = new System.Drawing.Size(1262, 350);
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
            this.itemGetCreditNote,
            this.itemGetDraftCreditNote,
            this.itemGetCreditNotes,
            this.itemNewCreditNote});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Margin = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(256, 932);
            this.menu.TabIndex = 54;
            this.menu.Text = "menuStrip1";
            // 
            // pnlDraftCreditNote
            // 
            this.pnlDraftCreditNote.Controls.Add(this.pnlCreditNoteReports);
            this.pnlDraftCreditNote.Location = new System.Drawing.Point(519, 52);
            this.pnlDraftCreditNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDraftCreditNote.Name = "pnlDraftCreditNote";
            this.pnlDraftCreditNote.Size = new System.Drawing.Size(1071, 132);
            this.pnlDraftCreditNote.TabIndex = 62;
            this.pnlDraftCreditNote.Visible = false;
            // 
            // pnlCreditNote
            // 
            this.pnlCreditNote.Controls.Add(this.btnCreditNoteView);
            this.pnlCreditNote.Controls.Add(this.rdViewXml);
            this.pnlCreditNote.Controls.Add(this.rdViewHtml);
            this.pnlCreditNote.Controls.Add(this.rdViewPdf);
            this.pnlCreditNote.Location = new System.Drawing.Point(4, 0);
            this.pnlCreditNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlCreditNote.Name = "pnlCreditNote";
            this.pnlCreditNote.Size = new System.Drawing.Size(1071, 136);
            this.pnlCreditNote.TabIndex = 63;
            this.pnlCreditNote.Visible = false;
            this.pnlCreditNote.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCreditNote_Paint);
            // 
            // btnCreditNoteView
            // 
            this.btnCreditNoteView.BackColor = System.Drawing.Color.CadetBlue;
            this.btnCreditNoteView.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnCreditNoteView.FlatAppearance.BorderSize = 2;
            this.btnCreditNoteView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreditNoteView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCreditNoteView.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreditNoteView.Location = new System.Drawing.Point(10, 22);
            this.btnCreditNoteView.Margin = new System.Windows.Forms.Padding(6);
            this.btnCreditNoteView.Name = "btnCreditNoteView";
            this.btnCreditNoteView.Size = new System.Drawing.Size(153, 75);
            this.btnCreditNoteView.TabIndex = 45;
            this.btnCreditNoteView.Text = "Görüntüle";
            this.btnCreditNoteView.UseVisualStyleBackColor = false;
            this.btnCreditNoteView.Click += new System.EventHandler(this.btnArchiveView_Click);
            // 
            // rdViewXml
            // 
            this.rdViewXml.AutoSize = true;
            this.rdViewXml.Location = new System.Drawing.Point(174, 88);
            this.rdViewXml.Margin = new System.Windows.Forms.Padding(6);
            this.rdViewXml.Name = "rdViewXml";
            this.rdViewXml.Size = new System.Drawing.Size(57, 24);
            this.rdViewXml.TabIndex = 48;
            this.rdViewXml.TabStop = true;
            this.rdViewXml.Text = "xml";
            this.rdViewXml.UseVisualStyleBackColor = true;
            // 
            // rdViewHtml
            // 
            this.rdViewHtml.AutoSize = true;
            this.rdViewHtml.Location = new System.Drawing.Point(174, 15);
            this.rdViewHtml.Margin = new System.Windows.Forms.Padding(6);
            this.rdViewHtml.Name = "rdViewHtml";
            this.rdViewHtml.Size = new System.Drawing.Size(64, 24);
            this.rdViewHtml.TabIndex = 46;
            this.rdViewHtml.TabStop = true;
            this.rdViewHtml.Text = "html";
            this.rdViewHtml.UseVisualStyleBackColor = true;
            // 
            // rdViewPdf
            // 
            this.rdViewPdf.AutoSize = true;
            this.rdViewPdf.Location = new System.Drawing.Point(174, 49);
            this.rdViewPdf.Margin = new System.Windows.Forms.Padding(6);
            this.rdViewPdf.Name = "rdViewPdf";
            this.rdViewPdf.Size = new System.Drawing.Size(57, 24);
            this.rdViewPdf.TabIndex = 47;
            this.rdViewPdf.TabStop = true;
            this.rdViewPdf.Text = "pdf";
            this.rdViewPdf.UseVisualStyleBackColor = true;
            // 
            // pnlCreditNoteReports
            // 
            this.pnlCreditNoteReports.Controls.Add(this.pnlCreditNote);
            this.pnlCreditNoteReports.Location = new System.Drawing.Point(4, 4);
            this.pnlCreditNoteReports.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlCreditNoteReports.Name = "pnlCreditNoteReports";
            this.pnlCreditNoteReports.Size = new System.Drawing.Size(1071, 141);
            this.pnlCreditNoteReports.TabIndex = 64;
            this.pnlCreditNoteReports.Visible = false;
            this.pnlCreditNoteReports.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCreditNotes_Paint);
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(307, 511);
            this.lblInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(352, 20);
            this.lblInformation.TabIndex = 65;
            this.lblInformation.Text = "islem yapabılmek ıcın tablodan bir veriye  tıklayınız";
            this.lblInformation.Visible = false;
            // 
            // FrmCreditNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1730, 932);
            this.ControlBox = false;
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.pnlDraftCreditNote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.btnTakeCreditNote);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.menu);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreditNote";
            this.Text = "FrmCreditNote";
            this.Load += new System.EventHandler(this.FrmCreditNote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pnlDraftCreditNote.ResumeLayout(false);
            this.pnlCreditNote.ResumeLayout(false);
            this.pnlCreditNote.PerformLayout();
            this.pnlCreditNoteReports.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.ToolStripMenuItem itemNewCreditNote;
        private System.Windows.Forms.ToolStripMenuItem itemGetCreditNotes;
        private System.Windows.Forms.ToolStripMenuItem itemGetDraftCreditNote;
        private System.Windows.Forms.ToolStripMenuItem itemGetCreditNote;
        private System.Windows.Forms.Button btnTakeCreditNote;
        private System.Windows.Forms.DataGridView tableGrid;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.Panel pnlDraftCreditNote;
        private System.Windows.Forms.Panel pnlCreditNote;
        private System.Windows.Forms.Panel pnlCreditNoteReports;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Button btnCreditNoteView;
        private System.Windows.Forms.RadioButton rdViewXml;
        private System.Windows.Forms.RadioButton rdViewHtml;
        private System.Windows.Forms.RadioButton rdViewPdf;
    }
}