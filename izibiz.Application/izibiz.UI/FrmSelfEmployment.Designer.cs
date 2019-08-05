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
            this.label1 = new System.Windows.Forms.Label();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.itemNewSmm = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGetSmmReports = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGetDraftSmm = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGetSmm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTakeSmm = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.pnlDraftSmm = new System.Windows.Forms.Panel();
            this.btnSendSmm = new System.Windows.Forms.Button();
            this.btnLoadDraftSmm = new System.Windows.Forms.Button();
            this.pnlSmm = new System.Windows.Forms.Panel();
            this.pnlSmmReports = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.menu.SuspendLayout();
            this.pnlDraftSmm.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(255, 418);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 20);
            this.label1.TabIndex = 61;
            this.label1.Text = "islem yapabılmek ıcın tablodan bir veriye  tıklayınız";
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
            this.itemNewSmm.Size = new System.Drawing.Size(153, 34);
            this.itemNewSmm.Text = "+ Yeni Smm";
            // 
            // itemGetSmmReports
            // 
            this.itemGetSmmReports.BackColor = System.Drawing.Color.Teal;
            this.itemGetSmmReports.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemGetSmmReports.Margin = new System.Windows.Forms.Padding(2, 40, 2, 2);
            this.itemGetSmmReports.Name = "itemGetSmmReports";
            this.itemGetSmmReports.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemGetSmmReports.Size = new System.Drawing.Size(153, 34);
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
            this.itemGetDraftSmm.Size = new System.Drawing.Size(153, 37);
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
            this.itemGetSmm.Size = new System.Drawing.Size(153, 34);
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
            this.menu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(166, 746);
            this.menu.TabIndex = 54;
            this.menu.Text = "menuStrip1";
            // 
            // pnlDraftSmm
            // 
            this.pnlDraftSmm.Controls.Add(this.btnSendSmm);
            this.pnlDraftSmm.Controls.Add(this.btnLoadDraftSmm);
            this.pnlDraftSmm.Location = new System.Drawing.Point(429, 34);
            this.pnlDraftSmm.Name = "pnlDraftSmm";
            this.pnlDraftSmm.Size = new System.Drawing.Size(765, 106);
            this.pnlDraftSmm.TabIndex = 62;
            this.pnlDraftSmm.Visible = false;
            // 
            // btnSendSmm
            // 
            this.btnSendSmm.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendSmm.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendSmm.FlatAppearance.BorderSize = 2;
            this.btnSendSmm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSmm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendSmm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendSmm.Location = new System.Drawing.Point(208, 28);
            this.btnSendSmm.Margin = new System.Windows.Forms.Padding(5);
            this.btnSendSmm.Name = "btnSendSmm";
            this.btnSendSmm.Size = new System.Drawing.Size(160, 58);
            this.btnSendSmm.TabIndex = 45;
            this.btnSendSmm.Text = "Gönder";
            this.btnSendSmm.UseVisualStyleBackColor = false;
            // 
            // btnLoadDraftSmm
            // 
            this.btnLoadDraftSmm.BackColor = System.Drawing.Color.CadetBlue;
            this.btnLoadDraftSmm.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnLoadDraftSmm.FlatAppearance.BorderSize = 2;
            this.btnLoadDraftSmm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDraftSmm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoadDraftSmm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoadDraftSmm.Location = new System.Drawing.Point(18, 29);
            this.btnLoadDraftSmm.Margin = new System.Windows.Forms.Padding(5);
            this.btnLoadDraftSmm.Name = "btnLoadDraftSmm";
            this.btnLoadDraftSmm.Size = new System.Drawing.Size(160, 58);
            this.btnLoadDraftSmm.TabIndex = 44;
            this.btnLoadDraftSmm.Text = "Portala Yukle";
            this.btnLoadDraftSmm.UseVisualStyleBackColor = false;
            // 
            // pnlSmm
            // 
            this.pnlSmm.Location = new System.Drawing.Point(429, 155);
            this.pnlSmm.Name = "pnlSmm";
            this.pnlSmm.Size = new System.Drawing.Size(765, 115);
            this.pnlSmm.TabIndex = 63;
            this.pnlSmm.Visible = false;
            // 
            // pnlSmmReports
            // 
            this.pnlSmmReports.Location = new System.Drawing.Point(429, 285);
            this.pnlSmmReports.Name = "pnlSmmReports";
            this.pnlSmmReports.Size = new System.Drawing.Size(765, 104);
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
            this.Controls.Add(this.label1);
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
            this.pnlDraftSmm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.ToolStripMenuItem itemNewSmm;
        private System.Windows.Forms.ToolStripMenuItem itemGetSmmReports;
        private System.Windows.Forms.ToolStripMenuItem itemGetDraftSmm;
        private System.Windows.Forms.ToolStripMenuItem itemGetSmm;
        private System.Windows.Forms.Button btnTakeSmm;
        private System.Windows.Forms.DataGridView tableGrid;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.Panel pnlDraftSmm;
        private System.Windows.Forms.Button btnSendSmm;
        private System.Windows.Forms.Button btnLoadDraftSmm;
        private System.Windows.Forms.Panel pnlSmm;
        private System.Windows.Forms.Panel pnlSmmReports;
    }
}