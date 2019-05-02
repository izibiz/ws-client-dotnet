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
            this.menuInvoice = new System.Windows.Forms.MenuStrip();
            this.itemArchiveInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemListArchiveInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDraftArchiveInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemListDraftArchiveInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDraftNewInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.menuInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuInvoice
            // 
            this.menuInvoice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuInvoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuInvoice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuInvoice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemArchiveInvoice,
            this.itemDraftArchiveInvoice});
            this.menuInvoice.Location = new System.Drawing.Point(0, 0);
            this.menuInvoice.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.menuInvoice.Name = "menuInvoice";
            this.menuInvoice.Size = new System.Drawing.Size(173, 502);
            this.menuInvoice.TabIndex = 1;
            this.menuInvoice.Text = "menuStrip1";
            // 
            // itemArchiveInvoice
            // 
            this.itemArchiveInvoice.BackColor = System.Drawing.Color.Teal;
            this.itemArchiveInvoice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemListArchiveInvoice});
            this.itemArchiveInvoice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemArchiveInvoice.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemArchiveInvoice.Name = "itemArchiveInvoice";
            this.itemArchiveInvoice.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemArchiveInvoice.Size = new System.Drawing.Size(166, 29);
            this.itemArchiveInvoice.Text = "e arsiv Faturalar";
            // 
            // itemListArchiveInvoice
            // 
            this.itemListArchiveInvoice.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.itemListArchiveInvoice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.itemListArchiveInvoice.Name = "itemListArchiveInvoice";
            this.itemListArchiveInvoice.Size = new System.Drawing.Size(186, 24);
            this.itemListArchiveInvoice.Text = "E-Fatura Listele";
            this.itemListArchiveInvoice.Click += new System.EventHandler(this.itemListArchiveInvoice_Click);
            // 
            // itemDraftArchiveInvoice
            // 
            this.itemDraftArchiveInvoice.BackColor = System.Drawing.Color.Teal;
            this.itemDraftArchiveInvoice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemListDraftArchiveInvoice,
            this.itemDraftNewInvoice});
            this.itemDraftArchiveInvoice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemDraftArchiveInvoice.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemDraftArchiveInvoice.Name = "itemDraftArchiveInvoice";
            this.itemDraftArchiveInvoice.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemDraftArchiveInvoice.Size = new System.Drawing.Size(166, 29);
            this.itemDraftArchiveInvoice.Text = "Taslak arsiv Faturalar";
            // 
            // itemListDraftArchiveInvoice
            // 
            this.itemListDraftArchiveInvoice.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.itemListDraftArchiveInvoice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.itemListDraftArchiveInvoice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 4);
            this.itemListDraftArchiveInvoice.Name = "itemListDraftArchiveInvoice";
            this.itemListDraftArchiveInvoice.Size = new System.Drawing.Size(219, 24);
            this.itemListDraftArchiveInvoice.Text = "Taslak Fatura Listele";
            // 
            // itemDraftNewInvoice
            // 
            this.itemDraftNewInvoice.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.itemDraftNewInvoice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.itemDraftNewInvoice.Margin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.itemDraftNewInvoice.Name = "itemDraftNewInvoice";
            this.itemDraftNewInvoice.Size = new System.Drawing.Size(219, 24);
            this.itemDraftNewInvoice.Text = "+Yeni Fatura";
            // 
            // tableGrid
            // 
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.Location = new System.Drawing.Point(282, 175);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGrid.Size = new System.Drawing.Size(549, 237);
            this.tableGrid.TabIndex = 19;
            // 
            // FrmArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 502);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.menuInvoice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmArchive";
            this.Text = "FrmArchive";
            this.Load += new System.EventHandler(this.FrmArchive_Load);
            this.menuInvoice.ResumeLayout(false);
            this.menuInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemArchiveInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemListArchiveInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemDraftArchiveInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemListDraftArchiveInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemDraftNewInvoice;
        private System.Windows.Forms.DataGridView tableGrid;
    }
}