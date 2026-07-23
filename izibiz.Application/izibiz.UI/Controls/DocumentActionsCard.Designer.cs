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
            this.lblViewHeader = new System.Windows.Forms.Label();
            this.pnlViewFormats = new System.Windows.Forms.Panel();
            this.rdViewPdf = new System.Windows.Forms.RadioButton();
            this.rdViewHtml = new System.Windows.Forms.RadioButton();
            this.btnView = new System.Windows.Forms.Button();
            this.lblDownloadHeader = new System.Windows.Forms.Label();
            this.pnlDownloadFormats = new System.Windows.Forms.Panel();
            this.rdDownloadPdf = new System.Windows.Forms.RadioButton();
            this.rdDownloadHtml = new System.Windows.Forms.RadioButton();
            this.rdDownloadXml = new System.Windows.Forms.RadioButton();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lblCancelHeader = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.pnlViewFormats.SuspendLayout();
            this.pnlDownloadFormats.SuspendLayout();
            this.pnlAssignNumber = new System.Windows.Forms.Panel();
            this.cmbPrefix = new System.Windows.Forms.ComboBox();
            this.btnAssignNumber = new System.Windows.Forms.Button();
            this.pnlAssignNumber.SuspendLayout();
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
            this.lblTitle.Visible = false;
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
            this.lblDesc.Visible = false;
            //
            // lblViewHeader
            //
            this.lblViewHeader.AutoSize = true;
            this.lblViewHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblViewHeader.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblViewHeader.Location = new System.Drawing.Point(20, 92);
            this.lblViewHeader.Name = "lblViewHeader";
            this.lblViewHeader.Size = new System.Drawing.Size(90, 25);
            this.lblViewHeader.TabIndex = 2;
            this.lblViewHeader.Text = "Görüntüle";
            this.lblViewHeader.Visible = false;
            //
            // pnlViewFormats
            //
            this.pnlViewFormats.BackColor = System.Drawing.Color.White;
            this.pnlViewFormats.Controls.Add(this.rdViewPdf);
            this.pnlViewFormats.Controls.Add(this.rdViewHtml);
            this.pnlViewFormats.Location = new System.Drawing.Point(20, 122);
            this.pnlViewFormats.Name = "pnlViewFormats";
            this.pnlViewFormats.Size = new System.Drawing.Size(210, 45);
            this.pnlViewFormats.TabIndex = 3;
            this.pnlViewFormats.Visible = false;
            //
            // rdViewPdf
            //
            this.rdViewPdf.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdViewPdf.BackColor = System.Drawing.Color.FromArgb(24, 110, 97);
            this.rdViewPdf.FlatAppearance.BorderSize = 0;
            this.rdViewPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdViewPdf.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdViewPdf.ForeColor = System.Drawing.Color.White;
            this.rdViewPdf.Location = new System.Drawing.Point(0, 0);
            this.rdViewPdf.Name = "rdViewPdf";
            this.rdViewPdf.Size = new System.Drawing.Size(95, 45);
            this.rdViewPdf.TabIndex = 0;
            this.rdViewPdf.TabStop = true;
            this.rdViewPdf.Text = "PDF";
            this.rdViewPdf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdViewPdf.UseVisualStyleBackColor = false;
            this.rdViewPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdViewPdf.Checked = true;
            //
            // rdViewHtml
            //
            this.rdViewHtml.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdViewHtml.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.rdViewHtml.FlatAppearance.BorderSize = 0;
            this.rdViewHtml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdViewHtml.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdViewHtml.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.rdViewHtml.Location = new System.Drawing.Point(105, 0);
            this.rdViewHtml.Name = "rdViewHtml";
            this.rdViewHtml.Size = new System.Drawing.Size(95, 45);
            this.rdViewHtml.TabIndex = 1;
            this.rdViewHtml.TabStop = true;
            this.rdViewHtml.Text = "HTML";
            this.rdViewHtml.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdViewHtml.UseVisualStyleBackColor = false;
            this.rdViewHtml.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnView
            //
            this.btnView.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(20, 177);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(210, 45);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "Görüntüle";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Visible = false;
            //
            // lblDownloadHeader
            //
            this.lblDownloadHeader.AutoSize = true;
            this.lblDownloadHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDownloadHeader.ForeColor = System.Drawing.Color.FromArgb(95, 130, 35);
            this.lblDownloadHeader.Location = new System.Drawing.Point(650, 92);
            this.lblDownloadHeader.Name = "lblDownloadHeader";
            this.lblDownloadHeader.Size = new System.Drawing.Size(60, 25);
            this.lblDownloadHeader.TabIndex = 5;
            this.lblDownloadHeader.Text = "İndir";
            this.lblDownloadHeader.Visible = false;
            //
            // pnlDownloadFormats
            //
            this.pnlDownloadFormats.BackColor = System.Drawing.Color.White;
            this.pnlDownloadFormats.Controls.Add(this.rdDownloadPdf);
            this.pnlDownloadFormats.Controls.Add(this.rdDownloadHtml);
            this.pnlDownloadFormats.Controls.Add(this.rdDownloadXml);
            this.pnlDownloadFormats.Location = new System.Drawing.Point(650, 122);
            this.pnlDownloadFormats.Name = "pnlDownloadFormats";
            this.pnlDownloadFormats.Size = new System.Drawing.Size(315, 45);
            this.pnlDownloadFormats.TabIndex = 6;
            this.pnlDownloadFormats.Visible = false;
            //
            // rdDownloadPdf
            //
            this.rdDownloadPdf.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdDownloadPdf.BackColor = System.Drawing.Color.FromArgb(24, 110, 97);
            this.rdDownloadPdf.FlatAppearance.BorderSize = 0;
            this.rdDownloadPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdDownloadPdf.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdDownloadPdf.ForeColor = System.Drawing.Color.White;
            this.rdDownloadPdf.Location = new System.Drawing.Point(0, 0);
            this.rdDownloadPdf.Name = "rdDownloadPdf";
            this.rdDownloadPdf.Size = new System.Drawing.Size(95, 45);
            this.rdDownloadPdf.TabIndex = 0;
            this.rdDownloadPdf.TabStop = true;
            this.rdDownloadPdf.Text = "PDF";
            this.rdDownloadPdf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdDownloadPdf.UseVisualStyleBackColor = false;
            this.rdDownloadPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdDownloadPdf.Checked = true;
            //
            // rdDownloadHtml
            //
            this.rdDownloadHtml.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdDownloadHtml.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.rdDownloadHtml.FlatAppearance.BorderSize = 0;
            this.rdDownloadHtml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdDownloadHtml.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdDownloadHtml.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.rdDownloadHtml.Location = new System.Drawing.Point(105, 0);
            this.rdDownloadHtml.Name = "rdDownloadHtml";
            this.rdDownloadHtml.Size = new System.Drawing.Size(95, 45);
            this.rdDownloadHtml.TabIndex = 1;
            this.rdDownloadHtml.TabStop = true;
            this.rdDownloadHtml.Text = "HTML";
            this.rdDownloadHtml.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdDownloadHtml.UseVisualStyleBackColor = false;
            this.rdDownloadHtml.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // rdDownloadXml
            //
            this.rdDownloadXml.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdDownloadXml.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.rdDownloadXml.FlatAppearance.BorderSize = 0;
            this.rdDownloadXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdDownloadXml.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdDownloadXml.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.rdDownloadXml.Location = new System.Drawing.Point(210, 0);
            this.rdDownloadXml.Name = "rdDownloadXml";
            this.rdDownloadXml.Size = new System.Drawing.Size(95, 45);
            this.rdDownloadXml.TabIndex = 2;
            this.rdDownloadXml.TabStop = true;
            this.rdDownloadXml.Text = "XML";
            this.rdDownloadXml.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdDownloadXml.UseVisualStyleBackColor = false;
            this.rdDownloadXml.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnDownload
            //
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(95, 130, 35);
            this.btnDownload.FlatAppearance.BorderSize = 0;
            this.btnDownload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(118, 160, 45);
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(0, 0);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(95, 40);
            this.btnDownload.TabIndex = 7;
            this.btnDownload.Text = "İndir ˅";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // lblCancelHeader
            //
            this.lblCancelHeader.AutoSize = true;
            this.lblCancelHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCancelHeader.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.lblCancelHeader.Location = new System.Drawing.Point(1000, 92);
            this.lblCancelHeader.Name = "lblCancelHeader";
            this.lblCancelHeader.Size = new System.Drawing.Size(40, 25);
            this.lblCancelHeader.TabIndex = 9;
            this.lblCancelHeader.Text = "Sil";
            this.lblCancelHeader.Visible = false;
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(105, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "İptal Raporla";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // lblNote
            //
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNote.Location = new System.Drawing.Point(20, 235);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(300, 19);
            this.lblNote.TabIndex = 8;
            this.lblNote.Text = "Not: Görüntüleme geçicidir, indirme belgeyi klasörünüze kalıcı olarak kaydeder.";
            this.lblNote.Visible = false;
            //
            // pnlAssignNumber
            //
            this.pnlAssignNumber.Controls.Add(this.cmbPrefix);
            this.pnlAssignNumber.Controls.Add(this.btnAssignNumber);
            this.pnlAssignNumber.Location = new System.Drawing.Point(0, 0);
            this.pnlAssignNumber.Name = "pnlAssignNumber";
            this.pnlAssignNumber.Size = new System.Drawing.Size(250, 45);
            this.pnlAssignNumber.TabIndex = 10;
            this.pnlAssignNumber.Visible = false;
            //
            // cmbPrefix
            //
            this.cmbPrefix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrefix.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPrefix.FormattingEnabled = true;
            this.cmbPrefix.Location = new System.Drawing.Point(0, 8);
            this.cmbPrefix.Name = "cmbPrefix";
            this.cmbPrefix.Size = new System.Drawing.Size(100, 31);
            this.cmbPrefix.TabIndex = 0;
            //
            // btnAssignNumber
            //
            this.btnAssignNumber.BackColor = System.Drawing.Color.FromArgb(95, 130, 35);
            this.btnAssignNumber.FlatAppearance.BorderSize = 0;
            this.btnAssignNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAssignNumber.ForeColor = System.Drawing.Color.White;
            this.btnAssignNumber.Location = new System.Drawing.Point(110, 5);
            this.btnAssignNumber.Name = "btnAssignNumber";
            this.btnAssignNumber.Size = new System.Drawing.Size(130, 35);
            this.btnAssignNumber.TabIndex = 1;
            this.btnAssignNumber.Text = "Numara Ata";
            this.btnAssignNumber.UseVisualStyleBackColor = false;
            this.btnAssignNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // DocumentActionsCard
            //
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlAssignNumber);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCancelHeader);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.pnlDownloadFormats);
            this.Controls.Add(this.lblDownloadHeader);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.pnlViewFormats);
            this.Controls.Add(this.lblViewHeader);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblTitle);
            this.Name = "DocumentActionsCard";
            this.Size = new System.Drawing.Size(250, 45);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DocumentActionsCard_Paint);
            this.pnlViewFormats.ResumeLayout(false);
            this.pnlDownloadFormats.ResumeLayout(false);
            this.pnlAssignNumber.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblViewHeader;
        private System.Windows.Forms.Panel pnlViewFormats;
        private System.Windows.Forms.RadioButton rdViewPdf;
        private System.Windows.Forms.RadioButton rdViewHtml;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblDownloadHeader;
        private System.Windows.Forms.Panel pnlDownloadFormats;
        private System.Windows.Forms.RadioButton rdDownloadPdf;
        private System.Windows.Forms.RadioButton rdDownloadHtml;
        private System.Windows.Forms.RadioButton rdDownloadXml;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label lblCancelHeader;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlAssignNumber;
        private System.Windows.Forms.ComboBox cmbPrefix;
        private System.Windows.Forms.Button btnAssignNumber;
    }
}
