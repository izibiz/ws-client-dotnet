namespace izibiz.UI
{
    partial class FrmReconcilation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReconcilation));
            this.btnGetStatusReconcilation = new System.Windows.Forms.Button();
            this.btnSendReconzilation = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.itemNewReconcilation = new System.Windows.Forms.ToolStripMenuItem();
            this.itemBaBsReconsilations = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTakeDespatch = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.menuInvoice = new System.Windows.Forms.MenuStrip();
            this.itemCurrentReconcilations = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDraftDespatch = new System.Windows.Forms.Panel();
            this.btnSendMailReconcilation = new System.Windows.Forms.Button();
            this.btnHomePage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.menuInvoice.SuspendLayout();
            this.pnlDraftDespatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetStatusReconcilation
            // 
            this.btnGetStatusReconcilation.BackColor = System.Drawing.Color.CadetBlue;
            this.btnGetStatusReconcilation.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGetStatusReconcilation.FlatAppearance.BorderSize = 2;
            this.btnGetStatusReconcilation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetStatusReconcilation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetStatusReconcilation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetStatusReconcilation.Location = new System.Drawing.Point(24, 27);
            this.btnGetStatusReconcilation.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetStatusReconcilation.Name = "btnGetStatusReconcilation";
            this.btnGetStatusReconcilation.Size = new System.Drawing.Size(156, 43);
            this.btnGetStatusReconcilation.TabIndex = 28;
            this.btnGetStatusReconcilation.Text = "Durum sorgula";
            this.btnGetStatusReconcilation.UseVisualStyleBackColor = false;
            // 
            // btnSendReconzilation
            // 
            this.btnSendReconzilation.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendReconzilation.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendReconzilation.FlatAppearance.BorderSize = 2;
            this.btnSendReconzilation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendReconzilation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendReconzilation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendReconzilation.Location = new System.Drawing.Point(207, 27);
            this.btnSendReconzilation.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendReconzilation.Name = "btnSendReconzilation";
            this.btnSendReconzilation.Size = new System.Drawing.Size(156, 43);
            this.btnSendReconzilation.TabIndex = 25;
            this.btnSendReconzilation.Text = "Gönder";
            this.btnSendReconzilation.UseVisualStyleBackColor = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblText.Location = new System.Drawing.Point(674, 11);
            this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(145, 29);
            this.lblText.TabIndex = 50;
            this.lblText.Text = "Hosgeldınız";
            // 
            // itemNewReconcilation
            // 
            this.itemNewReconcilation.BackColor = System.Drawing.Color.Teal;
            this.itemNewReconcilation.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemNewReconcilation.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemNewReconcilation.Name = "itemNewReconcilation";
            this.itemNewReconcilation.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemNewReconcilation.Size = new System.Drawing.Size(179, 34);
            this.itemNewReconcilation.Text = "Yeni Mutabakat";
            this.itemNewReconcilation.Click += new System.EventHandler(this.İtemNewReconcilation_Click);
            // 
            // itemBaBsReconsilations
            // 
            this.itemBaBsReconsilations.BackColor = System.Drawing.Color.Teal;
            this.itemBaBsReconsilations.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemBaBsReconsilations.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemBaBsReconsilations.Name = "itemBaBsReconsilations";
            this.itemBaBsReconsilations.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemBaBsReconsilations.Size = new System.Drawing.Size(179, 34);
            this.itemBaBsReconsilations.Text = "BA/BS Mutabakat";
            // 
            // btnTakeDespatch
            // 
            this.btnTakeDespatch.BackColor = System.Drawing.Color.CadetBlue;
            this.btnTakeDespatch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnTakeDespatch.FlatAppearance.BorderSize = 2;
            this.btnTakeDespatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeDespatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTakeDespatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTakeDespatch.Location = new System.Drawing.Point(196, 85);
            this.btnTakeDespatch.Margin = new System.Windows.Forms.Padding(4);
            this.btnTakeDespatch.Name = "btnTakeDespatch";
            this.btnTakeDespatch.Size = new System.Drawing.Size(160, 43);
            this.btnTakeDespatch.TabIndex = 45;
            this.btnTakeDespatch.Text = "Mutabakat al";
            this.btnTakeDespatch.UseVisualStyleBackColor = false;
            this.btnTakeDespatch.Visible = false;
            // 
            // tableGrid
            // 
            this.tableGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.GridColor = System.Drawing.SystemColors.Control;
            this.tableGrid.Location = new System.Drawing.Point(251, 218);
            this.tableGrid.Margin = new System.Windows.Forms.Padding(4);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.RowHeadersWidth = 51;
            this.tableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGrid.Size = new System.Drawing.Size(995, 449);
            this.tableGrid.TabIndex = 44;
            // 
            // menuInvoice
            // 
            this.menuInvoice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuInvoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuInvoice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuInvoice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuInvoice.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCurrentReconcilations,
            this.itemBaBsReconsilations,
            this.itemNewReconcilation});
            this.menuInvoice.Location = new System.Drawing.Point(0, 0);
            this.menuInvoice.Margin = new System.Windows.Forms.Padding(0, 0, 27, 0);
            this.menuInvoice.Name = "menuInvoice";
            this.menuInvoice.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuInvoice.Size = new System.Drawing.Size(188, 762);
            this.menuInvoice.TabIndex = 43;
            this.menuInvoice.Text = "menuStrip1";
            // 
            // itemCurrentReconcilations
            // 
            this.itemCurrentReconcilations.BackColor = System.Drawing.Color.Teal;
            this.itemCurrentReconcilations.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemCurrentReconcilations.Margin = new System.Windows.Forms.Padding(0, 140, 0, 0);
            this.itemCurrentReconcilations.Name = "itemCurrentReconcilations";
            this.itemCurrentReconcilations.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemCurrentReconcilations.Size = new System.Drawing.Size(179, 34);
            this.itemCurrentReconcilations.Text = "Cari Mutabakat";
            // 
            // pnlDraftDespatch
            // 
            this.pnlDraftDespatch.Controls.Add(this.btnGetStatusReconcilation);
            this.pnlDraftDespatch.Controls.Add(this.btnSendMailReconcilation);
            this.pnlDraftDespatch.Controls.Add(this.btnSendReconzilation);
            this.pnlDraftDespatch.Location = new System.Drawing.Point(364, 76);
            this.pnlDraftDespatch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDraftDespatch.Name = "pnlDraftDespatch";
            this.pnlDraftDespatch.Size = new System.Drawing.Size(861, 104);
            this.pnlDraftDespatch.TabIndex = 51;
            this.pnlDraftDespatch.Visible = false;
            // 
            // btnSendMailReconcilation
            // 
            this.btnSendMailReconcilation.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendMailReconcilation.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendMailReconcilation.FlatAppearance.BorderSize = 2;
            this.btnSendMailReconcilation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMailReconcilation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendMailReconcilation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendMailReconcilation.Location = new System.Drawing.Point(389, 27);
            this.btnSendMailReconcilation.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMailReconcilation.Name = "btnSendMailReconcilation";
            this.btnSendMailReconcilation.Size = new System.Drawing.Size(156, 43);
            this.btnSendMailReconcilation.TabIndex = 27;
            this.btnSendMailReconcilation.Text = "Mail Gönder";
            this.btnSendMailReconcilation.UseVisualStyleBackColor = false;
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
            this.btnHomePage.Location = new System.Drawing.Point(13, 25);
            this.btnHomePage.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(153, 86);
            this.btnHomePage.TabIndex = 47;
            this.btnHomePage.Text = "Ana Sayfa";
            this.btnHomePage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHomePage.UseVisualStyleBackColor = false;
            // 
            // FrmReconcilation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 762);
            this.ControlBox = false;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnTakeDespatch);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.pnlDraftDespatch);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.menuInvoice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReconcilation";
            this.Text = "FrmReconcilation";
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.menuInvoice.ResumeLayout(false);
            this.menuInvoice.PerformLayout();
            this.pnlDraftDespatch.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGetStatusReconcilation;
        private System.Windows.Forms.Button btnSendReconzilation;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.ToolStripMenuItem itemNewReconcilation;
        private System.Windows.Forms.ToolStripMenuItem itemBaBsReconsilations;
        private System.Windows.Forms.Button btnTakeDespatch;
        private System.Windows.Forms.DataGridView tableGrid;
        private System.Windows.Forms.MenuStrip menuInvoice;
        private System.Windows.Forms.Panel pnlDraftDespatch;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.ToolStripMenuItem itemCurrentReconcilations;
        private System.Windows.Forms.Button btnSendMailReconcilation;
    }
}