namespace izibiz.UI
{
    partial class FrmWriteMail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridSendMail = new System.Windows.Forms.DataGridView();
            this.clmArchiveID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSendMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridSendMail)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSendMail
            // 
            this.gridSendMail.AllowUserToAddRows = false;
            this.gridSendMail.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridSendMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSendMail.ColumnHeadersHeight = 30;
            this.gridSendMail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSendMail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmArchiveID,
            this.clmSendMail});
            this.gridSendMail.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.gridSendMail.Location = new System.Drawing.Point(21, 45);
            this.gridSendMail.MultiSelect = false;
            this.gridSendMail.Name = "gridSendMail";
            this.gridSendMail.RowHeadersVisible = false;
            this.gridSendMail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridSendMail.Size = new System.Drawing.Size(481, 115);
            this.gridSendMail.TabIndex = 0;
            // 
            // clmArchiveID
            // 
            this.clmArchiveID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmArchiveID.FillWeight = 88.83249F;
            this.clmArchiveID.HeaderText = "archive ID";
            this.clmArchiveID.Name = "clmArchiveID";
            this.clmArchiveID.ReadOnly = true;
            // 
            // clmSendMail
            // 
            this.clmSendMail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.NullValue = "mail@mail.com";
            this.clmSendMail.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmSendMail.FillWeight = 86.16751F;
            this.clmSendMail.HeaderText = "Mail Adress";
            this.clmSendMail.Name = "clmSendMail";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(415, 183);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 36);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Tamam";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(27, 19);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(35, 13);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "label1";
            // 
            // FrmSelectMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 242);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gridSendMail);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectMail";
            this.Text = "FrmSelectMail";
            this.Load += new System.EventHandler(this.FrmSelectMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSendMail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSendMail;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmArchiveID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSendMail;
        private System.Windows.Forms.Label lblText;
    }
}