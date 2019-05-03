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
            this.itemArchiveInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.itemListArchiveReport = new System.Windows.Forms.ToolStripMenuItem();
            this.itemArchiveNewCreated = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tableArchiveGrid = new System.Windows.Forms.DataGridView();
            this.btnArchiveView = new System.Windows.Forms.Button();
            this.rdViewHtml = new System.Windows.Forms.RadioButton();
            this.rdViewPdf = new System.Windows.Forms.RadioButton();
            this.rdViewXml = new System.Windows.Forms.RadioButton();
            this.btnTakeArchiveInv = new System.Windows.Forms.Button();
            this.menuInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableArchiveGrid)).BeginInit();
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
            this.itemArchiveInvoices.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
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
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CadetBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(366, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 35);
            this.button1.TabIndex = 27;
            this.button1.Text = "iade Et";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.CadetBlue;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(219, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 49);
            this.button2.TabIndex = 28;
            this.button2.Text = "durum sorgula";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.CadetBlue;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(386, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 49);
            this.button3.TabIndex = 29;
            this.button3.Text = "rapor detay sorgula";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.CadetBlue;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(586, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 35);
            this.button4.TabIndex = 30;
            this.button4.Text = "maıle gonder";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.CadetBlue;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.button5.FlatAppearance.BorderSize = 2;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(513, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(193, 35);
            this.button5.TabIndex = 31;
            this.button5.Text = "donemlık arsıv raporu";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            // 
            // tableArchiveGrid
            // 
            this.tableArchiveGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableArchiveGrid.Location = new System.Drawing.Point(206, 224);
            this.tableArchiveGrid.Name = "tableArchiveGrid";
            this.tableArchiveGrid.ReadOnly = true;
            this.tableArchiveGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableArchiveGrid.Size = new System.Drawing.Size(550, 211);
            this.tableArchiveGrid.TabIndex = 36;
            // 
            // btnArchiveView
            // 
            this.btnArchiveView.BackColor = System.Drawing.Color.CadetBlue;
            this.btnArchiveView.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnArchiveView.FlatAppearance.BorderSize = 2;
            this.btnArchiveView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchiveView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArchiveView.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnArchiveView.Location = new System.Drawing.Point(747, 114);
            this.btnArchiveView.Name = "btnArchiveView";
            this.btnArchiveView.Size = new System.Drawing.Size(120, 35);
            this.btnArchiveView.TabIndex = 37;
            this.btnArchiveView.Text = "goruntule";
            this.btnArchiveView.UseVisualStyleBackColor = false;
            this.btnArchiveView.Visible = false;
            this.btnArchiveView.Click += new System.EventHandler(this.btnArchiveView_Click);
            // 
            // rdViewHtml
            // 
            this.rdViewHtml.AutoSize = true;
            this.rdViewHtml.Location = new System.Drawing.Point(783, 168);
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
            this.rdViewPdf.Location = new System.Drawing.Point(783, 191);
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
            this.rdViewXml.Location = new System.Drawing.Point(783, 214);
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
            this.btnTakeArchiveInv.Location = new System.Drawing.Point(219, 105);
            this.btnTakeArchiveInv.Name = "btnTakeArchiveInv";
            this.btnTakeArchiveInv.Size = new System.Drawing.Size(120, 35);
            this.btnTakeArchiveInv.TabIndex = 41;
            this.btnTakeArchiveInv.Text = "fatura al";
            this.btnTakeArchiveInv.UseVisualStyleBackColor = false;
            this.btnTakeArchiveInv.Visible = false;
            this.btnTakeArchiveInv.Click += new System.EventHandler(this.btnTakeArchiveInv_Click);
            // 
            // FrmArchive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 476);
            this.Controls.Add(this.btnTakeArchiveInv);
            this.Controls.Add(this.rdViewXml);
            this.Controls.Add(this.rdViewPdf);
            this.Controls.Add(this.rdViewHtml);
            this.Controls.Add(this.btnArchiveView);
            this.Controls.Add(this.tableArchiveGrid);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuInvoice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmArchive";
            this.Text = "FrmArchive";
            this.Load += new System.EventHandler(this.FrmArchive_Load);
            this.menuInvoice.ResumeLayout(false);
            this.menuInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableArchiveGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemArchiveInvoices;
        private System.Windows.Forms.ToolStripMenuItem itemArchiveNewCreated;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView tableArchiveGrid;
        private System.Windows.Forms.Button btnArchiveView;
        private System.Windows.Forms.RadioButton rdViewHtml;
        private System.Windows.Forms.RadioButton rdViewPdf;
        private System.Windows.Forms.RadioButton rdViewXml;
        private System.Windows.Forms.ToolStripMenuItem itemListArchiveReport;
        private System.Windows.Forms.Button btnTakeArchiveInv;
    }
}