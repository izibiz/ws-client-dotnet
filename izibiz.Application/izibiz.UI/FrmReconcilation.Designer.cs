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
            this.btnSendReconcilation = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.itemNewReconcilation = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEMReconsilations = new System.Windows.Forms.ToolStripMenuItem();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.menuInvoice = new System.Windows.Forms.MenuStrip();
            this.itemCMReconcilations = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlReconcilationButton = new System.Windows.Forms.Panel();
            this.btnSendMailReconcilation = new System.Windows.Forms.Button();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.lblInf = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.menuInvoice.SuspendLayout();
            this.pnlReconcilationButton.SuspendLayout();
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
            this.btnGetStatusReconcilation.Location = new System.Drawing.Point(308, 24);
            this.btnGetStatusReconcilation.Name = "btnGetStatusReconcilation";
            this.btnGetStatusReconcilation.Size = new System.Drawing.Size(117, 35);
            this.btnGetStatusReconcilation.TabIndex = 28;
            this.btnGetStatusReconcilation.Text = "Durum sorgula";
            this.btnGetStatusReconcilation.UseVisualStyleBackColor = false;
            this.btnGetStatusReconcilation.Click += new System.EventHandler(this.BtnGetStatusReconcilation_Click);
            // 
            // btnSendReconcilation
            // 
            this.btnSendReconcilation.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendReconcilation.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendReconcilation.FlatAppearance.BorderSize = 2;
            this.btnSendReconcilation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendReconcilation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendReconcilation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendReconcilation.Location = new System.Drawing.Point(20, 24);
            this.btnSendReconcilation.Name = "btnSendReconcilation";
            this.btnSendReconcilation.Size = new System.Drawing.Size(117, 35);
            this.btnSendReconcilation.TabIndex = 25;
            this.btnSendReconcilation.Text = "Gönder";
            this.btnSendReconcilation.UseVisualStyleBackColor = false;
            this.btnSendReconcilation.Click += new System.EventHandler(this.BtnSendReconcilation_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcome.Location = new System.Drawing.Point(506, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(113, 25);
            this.lblWelcome.TabIndex = 50;
            this.lblWelcome.Text = "Hosgeldınız";
            // 
            // itemNewReconcilation
            // 
            this.itemNewReconcilation.BackColor = System.Drawing.Color.Teal;
            this.itemNewReconcilation.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemNewReconcilation.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemNewReconcilation.Name = "itemNewReconcilation";
            this.itemNewReconcilation.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemNewReconcilation.Size = new System.Drawing.Size(145, 29);
            this.itemNewReconcilation.Text = "Yeni Mutabakat";
            this.itemNewReconcilation.Click += new System.EventHandler(this.İtemNewReconcilation_Click);
            // 
            // itemEMReconsilations
            // 
            this.itemEMReconsilations.BackColor = System.Drawing.Color.Teal;
            this.itemEMReconsilations.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemEMReconsilations.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemEMReconsilations.Name = "itemEMReconsilations";
            this.itemEMReconsilations.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemEMReconsilations.Size = new System.Drawing.Size(145, 29);
            this.itemEMReconsilations.Text = "BA/BS Mutabakat";
            this.itemEMReconsilations.Click += new System.EventHandler(this.İtemBaBsReconsilations_Click);
            // 
            // tableGrid
            // 
            this.tableGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.GridColor = System.Drawing.SystemColors.Control;
            this.tableGrid.Location = new System.Drawing.Point(188, 177);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.RowHeadersWidth = 51;
            this.tableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGrid.Size = new System.Drawing.Size(746, 365);
            this.tableGrid.TabIndex = 44;
            this.tableGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableGrid_CellContentClick);
            // 
            // menuInvoice
            // 
            this.menuInvoice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuInvoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuInvoice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuInvoice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuInvoice.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCMReconcilations,
            this.itemEMReconsilations,
            this.itemNewReconcilation});
            this.menuInvoice.Location = new System.Drawing.Point(0, 0);
            this.menuInvoice.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.menuInvoice.Name = "menuInvoice";
            this.menuInvoice.Size = new System.Drawing.Size(152, 609);
            this.menuInvoice.TabIndex = 43;
            this.menuInvoice.Text = "menuStrip1";
            // 
            // itemCMReconcilations
            // 
            this.itemCMReconcilations.BackColor = System.Drawing.Color.Teal;
            this.itemCMReconcilations.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemCMReconcilations.Margin = new System.Windows.Forms.Padding(0, 140, 0, 0);
            this.itemCMReconcilations.Name = "itemCMReconcilations";
            this.itemCMReconcilations.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemCMReconcilations.Size = new System.Drawing.Size(145, 29);
            this.itemCMReconcilations.Text = "Cari Mutabakat";
            this.itemCMReconcilations.Click += new System.EventHandler(this.İtemCurrentReconcilations_Click);
            // 
            // pnlReconcilationButton
            // 
            this.pnlReconcilationButton.Controls.Add(this.btnGetStatusReconcilation);
            this.pnlReconcilationButton.Controls.Add(this.btnSendMailReconcilation);
            this.pnlReconcilationButton.Controls.Add(this.btnSendReconcilation);
            this.pnlReconcilationButton.Enabled = false;
            this.pnlReconcilationButton.Location = new System.Drawing.Point(273, 62);
            this.pnlReconcilationButton.Name = "pnlReconcilationButton";
            this.pnlReconcilationButton.Size = new System.Drawing.Size(646, 84);
            this.pnlReconcilationButton.TabIndex = 51;
            // 
            // btnSendMailReconcilation
            // 
            this.btnSendMailReconcilation.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendMailReconcilation.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendMailReconcilation.FlatAppearance.BorderSize = 2;
            this.btnSendMailReconcilation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMailReconcilation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendMailReconcilation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendMailReconcilation.Location = new System.Drawing.Point(156, 24);
            this.btnSendMailReconcilation.Name = "btnSendMailReconcilation";
            this.btnSendMailReconcilation.Size = new System.Drawing.Size(117, 35);
            this.btnSendMailReconcilation.TabIndex = 27;
            this.btnSendMailReconcilation.Text = "Mail Gönder";
            this.btnSendMailReconcilation.UseVisualStyleBackColor = false;
            this.btnSendMailReconcilation.Click += new System.EventHandler(this.btnSendMailReconcilation_Click);
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
            this.btnHomePage.Location = new System.Drawing.Point(10, 20);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(115, 70);
            this.btnHomePage.TabIndex = 47;
            this.btnHomePage.Text = "Ana Sayfa";
            this.btnHomePage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHomePage.UseVisualStyleBackColor = false;
            // 
            // lblInf
            // 
            this.lblInf.AutoSize = true;
            this.lblInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblInf.Location = new System.Drawing.Point(273, 153);
            this.lblInf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInf.Name = "lblInf";
            this.lblInf.Size = new System.Drawing.Size(322, 17);
            this.lblInf.TabIndex = 52;
            this.lblInf.Text = "islem yapabılmek ıcın tablodan bir veriye  tıklayınız";
            // 
            // FrmReconcilation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 609);
            this.ControlBox = false;
            this.Controls.Add(this.lblInf);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.pnlReconcilationButton);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.menuInvoice);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReconcilation";
            this.Text = "FrmReconcilation";
            this.Load += new System.EventHandler(this.FrmReconcilation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.menuInvoice.ResumeLayout(false);
            this.menuInvoice.PerformLayout();
            this.pnlReconcilationButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGetStatusReconcilation;
        private System.Windows.Forms.Button btnSendReconcilation;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ToolStripMenuItem itemNewReconcilation;
        private System.Windows.Forms.ToolStripMenuItem itemEMReconsilations;
        private System.Windows.Forms.DataGridView tableGrid;
        private System.Windows.Forms.MenuStrip menuInvoice;
        private System.Windows.Forms.Panel pnlReconcilationButton;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.ToolStripMenuItem itemCMReconcilations;
        private System.Windows.Forms.Button btnSendMailReconcilation;
        private System.Windows.Forms.Label lblInf;
    }
}