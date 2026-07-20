namespace izibiz.UI.Controls
{
    partial class DocumentActionsCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.rdPdf = new System.Windows.Forms.RadioButton();
            this.rdHtml = new System.Windows.Forms.RadioButton();
            this.rdXml = new System.Windows.Forms.RadioButton();
            this.btnView = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Belge Görüntüleme / İndirme";
            //
            // lblDesc
            //
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDesc.Location = new System.Drawing.Point(21, 55);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(320, 19);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "Seçili belgeyi görüntüleyin veya indirin";
            //
            // rdPdf
            //
            this.rdPdf.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdPdf.BackColor = System.Drawing.Color.FromArgb(24, 110, 97);
            this.rdPdf.FlatAppearance.BorderSize = 0;
            this.rdPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdPdf.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdPdf.ForeColor = System.Drawing.Color.White;
            this.rdPdf.Location = new System.Drawing.Point(20, 95);
            this.rdPdf.Name = "rdPdf";
            this.rdPdf.Size = new System.Drawing.Size(90, 45);
            this.rdPdf.TabIndex = 2;
            this.rdPdf.TabStop = true;
            this.rdPdf.Text = "PDF";
            this.rdPdf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdPdf.UseVisualStyleBackColor = false;
            this.rdPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdPdf.Checked = true;
            //
            // rdHtml
            //
            this.rdHtml.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdHtml.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.rdHtml.FlatAppearance.BorderSize = 0;
            this.rdHtml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdHtml.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdHtml.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.rdHtml.Location = new System.Drawing.Point(120, 95);
            this.rdHtml.Name = "rdHtml";
            this.rdHtml.Size = new System.Drawing.Size(90, 45);
            this.rdHtml.TabIndex = 3;
            this.rdHtml.TabStop = true;
            this.rdHtml.Text = "HTML";
            this.rdHtml.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdHtml.UseVisualStyleBackColor = false;
            this.rdHtml.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // rdXml
            //
            this.rdXml.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdXml.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.rdXml.FlatAppearance.BorderSize = 0;
            this.rdXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdXml.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdXml.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.rdXml.Location = new System.Drawing.Point(220, 95);
            this.rdXml.Name = "rdXml";
            this.rdXml.Size = new System.Drawing.Size(90, 45);
            this.rdXml.TabIndex = 4;
            this.rdXml.TabStop = true;
            this.rdXml.Text = "XML";
            this.rdXml.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdXml.UseVisualStyleBackColor = false;
            this.rdXml.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnView
            //
            this.btnView.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(335, 95);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(150, 45);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "Görüntüle";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnDownload
            //
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(95, 130, 35);
            this.btnDownload.FlatAppearance.BorderSize = 0;
            this.btnDownload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(118, 160, 45);
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(500, 95);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(150, 45);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "İndir";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // lblNote
            //
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNote.Location = new System.Drawing.Point(20, 155);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(300, 19);
            this.lblNote.TabIndex = 7;
            this.lblNote.Text = "Not: XML formatı sadece indirilebilir, önizleme desteklenmez.";
            //
            // DocumentActionsCard
            //
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.rdXml);
            this.Controls.Add(this.rdHtml);
            this.Controls.Add(this.rdPdf);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblTitle);
            this.Name = "DocumentActionsCard";
            this.Size = new System.Drawing.Size(1262, 200);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DocumentActionsCard_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.RadioButton rdPdf;
        private System.Windows.Forms.RadioButton rdHtml;
        private System.Windows.Forms.RadioButton rdXml;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label lblNote;
    }
}
