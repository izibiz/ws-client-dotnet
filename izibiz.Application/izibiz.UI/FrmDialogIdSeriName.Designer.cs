namespace izibiz.UI
{
    partial class FrmDialogSelectCombo
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
            this.cmbSeriNames = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbSeriNames
            // 
            this.cmbSeriNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeriNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSeriNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbSeriNames.FormattingEnabled = true;
            this.cmbSeriNames.Location = new System.Drawing.Point(44, 83);
            this.cmbSeriNames.Name = "cmbSeriNames";
            this.cmbSeriNames.Size = new System.Drawing.Size(227, 26);
            this.cmbSeriNames.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(260, 147);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(91, 29);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "button1";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblInformation.Location = new System.Drawing.Point(41, 46);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(46, 17);
            this.lblInformation.TabIndex = 2;
            this.lblInformation.Text = "label1";
            // 
            // FrmDialogIdSeriName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 188);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbSeriNames);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDialogIdSeriName";
            this.Text = "FrmDialogLoadSendInv";
            this.Load += new System.EventHandler(this.FrmDialogIdSeriName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSeriNames;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblInformation;
    }
}