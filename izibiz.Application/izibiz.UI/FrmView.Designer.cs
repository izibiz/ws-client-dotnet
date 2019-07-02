namespace izibiz.UI
{
    partial class FrmView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmView));
            this.viewDoc = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // viewDoc
            // 
            this.viewDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewDoc.Location = new System.Drawing.Point(0, 0);
            this.viewDoc.MinimumSize = new System.Drawing.Size(20, 20);
            this.viewDoc.Name = "viewDoc";
            this.viewDoc.Size = new System.Drawing.Size(1104, 501);
            this.viewDoc.TabIndex = 0;
            // 
            // FrmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1104, 501);
            this.Controls.Add(this.viewDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmView";
            this.Text = "PreviewInvoices";
            this.Load += new System.EventHandler(this.PreviewInvoices_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser viewDoc;
    }
}