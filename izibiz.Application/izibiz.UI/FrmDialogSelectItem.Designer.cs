namespace izibiz.UI
{
    partial class FrmDialogSelectItem
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
            this.linkLblAddSeriName = new System.Windows.Forms.LinkLabel();
            this.btnAddSeriName = new System.Windows.Forms.Button();
            this.grpAddSeriName = new System.Windows.Forms.GroupBox();
            this.msdAddSeriName = new System.Windows.Forms.MaskedTextBox();
            this.grpAddSeriName.SuspendLayout();
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
            this.btnOk.Location = new System.Drawing.Point(180, 147);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(91, 29);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "tamam";
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
            // linkLblAddSeriName
            // 
            this.linkLblAddSeriName.AutoSize = true;
            this.linkLblAddSeriName.Location = new System.Drawing.Point(277, 9);
            this.linkLblAddSeriName.Name = "linkLblAddSeriName";
            this.linkLblAddSeriName.Size = new System.Drawing.Size(77, 13);
            this.linkLblAddSeriName.TabIndex = 3;
            this.linkLblAddSeriName.TabStop = true;
            this.linkLblAddSeriName.Text = "seri Name ekle";
            this.linkLblAddSeriName.Visible = false;
            this.linkLblAddSeriName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblAddSeriName_LinkClicked);
            // 
            // btnAddSeriName
            // 
            this.btnAddSeriName.Location = new System.Drawing.Point(53, 88);
            this.btnAddSeriName.Name = "btnAddSeriName";
            this.btnAddSeriName.Size = new System.Drawing.Size(75, 23);
            this.btnAddSeriName.TabIndex = 5;
            this.btnAddSeriName.Text = "ekle";
            this.btnAddSeriName.UseVisualStyleBackColor = true;
            this.btnAddSeriName.Click += new System.EventHandler(this.btnAddSeriName_Click);
            // 
            // grpAddSeriName
            // 
            this.grpAddSeriName.Controls.Add(this.msdAddSeriName);
            this.grpAddSeriName.Controls.Add(this.btnAddSeriName);
            this.grpAddSeriName.Location = new System.Drawing.Point(328, 46);
            this.grpAddSeriName.Name = "grpAddSeriName";
            this.grpAddSeriName.Size = new System.Drawing.Size(200, 117);
            this.grpAddSeriName.TabIndex = 6;
            this.grpAddSeriName.TabStop = false;
            this.grpAddSeriName.Text = "Seri Name ekleme";
            this.grpAddSeriName.Visible = false;
            // 
            // msdAddSeriName
            // 
            this.msdAddSeriName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msdAddSeriName.Location = new System.Drawing.Point(53, 37);
            this.msdAddSeriName.Mask = "AAA";
            this.msdAddSeriName.Name = "msdAddSeriName";
            this.msdAddSeriName.Size = new System.Drawing.Size(64, 26);
            this.msdAddSeriName.TabIndex = 6;
            // 
            // FrmDialogSelectItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 188);
            this.Controls.Add(this.grpAddSeriName);
            this.Controls.Add(this.linkLblAddSeriName);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbSeriNames);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDialogSelectItem";
            this.Text = "FrmDialogLoadSendInv";
            this.Load += new System.EventHandler(this.FrmDialogIdSeriName_Load);
            this.grpAddSeriName.ResumeLayout(false);
            this.grpAddSeriName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSeriNames;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.LinkLabel linkLblAddSeriName;
        private System.Windows.Forms.Button btnAddSeriName;
        private System.Windows.Forms.GroupBox grpAddSeriName;
        private System.Windows.Forms.MaskedTextBox msdAddSeriName;
    }
}