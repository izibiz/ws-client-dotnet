namespace izibiz.UI.Controls
{
    partial class SourceCard
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
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.btnFetch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(65, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Başlık";
            //
            // lblIcon
            //
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblIcon.ForeColor = System.Drawing.Color.FromArgb(191, 219, 254);
            this.lblIcon.Location = new System.Drawing.Point(210, 10);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(56, 56);
            this.lblIcon.TabIndex = 1;
            this.lblIcon.Text = "⚙";
            this.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblDesc
            //
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDesc.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDesc.Location = new System.Drawing.Point(21, 55);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(180, 19);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Açıklama";
            //
            // btnFetch
            //
            this.btnFetch.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnFetch.FlatAppearance.BorderSize = 0;
            this.btnFetch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnFetch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFetch.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnFetch.ForeColor = System.Drawing.Color.White;
            this.btnFetch.Location = new System.Drawing.Point(20, 100);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(240, 68);
            this.btnFetch.TabIndex = 3;
            this.btnFetch.Text = "Çek";
            this.btnFetch.UseVisualStyleBackColor = false;
            this.btnFetch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFetch.Visible = false;
            //
            // SourceCard
            //
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblIcon);
            this.Controls.Add(this.lblTitle);
            this.Name = "SourceCard";
            this.Size = new System.Drawing.Size(280, 190);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SourceCard_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button btnFetch;
    }
}
