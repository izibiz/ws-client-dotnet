namespace izibiz.UI
{
    partial class FrmCreateReconcilation
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
            this.lblScenario = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbReconcilationSenario = new System.Windows.Forms.ComboBox();
            this.txtReceiverTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBsAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBaAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlBaBsDocPiece = new System.Windows.Forms.Panel();
            this.nmBsDocPiece = new System.Windows.Forms.NumericUpDown();
            this.nmBaDocPiece = new System.Windows.Forms.NumericUpDown();
            this.pnlCurrentPiece = new System.Windows.Forms.Panel();
            this.dateReconcilation = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCurrentAmount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.msdReceiverVkn = new System.Windows.Forms.MaskedTextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pnlPartner = new System.Windows.Forms.Panel();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.pnlBaBsDocPiece.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmBsDocPiece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmBaDocPiece)).BeginInit();
            this.pnlCurrentPiece.SuspendLayout();
            this.pnlPartner.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblScenario
            // 
            this.lblScenario.AutoSize = true;
            this.lblScenario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblScenario.Location = new System.Drawing.Point(167, 89);
            this.lblScenario.Name = "lblScenario";
            this.lblScenario.Size = new System.Drawing.Size(70, 20);
            this.lblScenario.TabIndex = 0;
            this.lblScenario.Text = "Senaryo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alıcı Unvan";
            // 
            // cmbReconcilationSenario
            // 
            this.cmbReconcilationSenario.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbReconcilationSenario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReconcilationSenario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReconcilationSenario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbReconcilationSenario.FormattingEnabled = true;
            this.cmbReconcilationSenario.Items.AddRange(new object[] {
            "BA/BS Mutabakat",
            "Cari Mutabakat"});
            this.cmbReconcilationSenario.Location = new System.Drawing.Point(267, 86);
            this.cmbReconcilationSenario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbReconcilationSenario.Name = "cmbReconcilationSenario";
            this.cmbReconcilationSenario.Size = new System.Drawing.Size(279, 28);
            this.cmbReconcilationSenario.TabIndex = 2;
            this.cmbReconcilationSenario.SelectedValueChanged += new System.EventHandler(this.CmbReconcilationSenario_SelectedValueChanged);
            // 
            // txtReceiverTitle
            // 
            this.txtReceiverTitle.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiverTitle.Location = new System.Drawing.Point(169, 21);
            this.txtReceiverTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReceiverTitle.Name = "txtReceiverTitle";
            this.txtReceiverTitle.Size = new System.Drawing.Size(196, 30);
            this.txtReceiverTitle.TabIndex = 3;
            this.txtReceiverTitle.Text = "unvan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "BA döküman Adedi";
            // 
            // txtPeriod
            // 
            this.txtPeriod.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriod.Location = new System.Drawing.Point(213, 129);
            this.txtPeriod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(196, 30);
            this.txtPeriod.TabIndex = 9;
            this.txtPeriod.Text = "201908";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dönem";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bs döküman Adedi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 23);
            this.label8.TabIndex = 12;
            this.label8.Text = "E posta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 23);
            this.label9.TabIndex = 10;
            this.label9.Text = "Alıcı Vkn/Tckn";
            // 
            // txtBsAmount
            // 
            this.txtBsAmount.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBsAmount.Location = new System.Drawing.Point(213, 239);
            this.txtBsAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBsAmount.Name = "txtBsAmount";
            this.txtBsAmount.Size = new System.Drawing.Size(196, 30);
            this.txtBsAmount.TabIndex = 25;
            this.txtBsAmount.Text = "22";
            this.txtBsAmount.Leave += new System.EventHandler(this.TxtBsAmount_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 23);
            this.label10.TabIndex = 24;
            this.label10.Text = "BS Döküman tutarı";
            // 
            // txtBaAmount
            // 
            this.txtBaAmount.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaAmount.Location = new System.Drawing.Point(213, 181);
            this.txtBaAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBaAmount.Name = "txtBaAmount";
            this.txtBaAmount.Size = new System.Drawing.Size(196, 30);
            this.txtBaAmount.TabIndex = 23;
            this.txtBaAmount.Text = "21";
            this.txtBaAmount.Leave += new System.EventHandler(this.TxtBaAmount_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 23);
            this.label11.TabIndex = 22;
            this.label11.Text = "BA Döküman tutarı";
            // 
            // pnlBaBsDocPiece
            // 
            this.pnlBaBsDocPiece.Controls.Add(this.nmBsDocPiece);
            this.pnlBaBsDocPiece.Controls.Add(this.nmBaDocPiece);
            this.pnlBaBsDocPiece.Controls.Add(this.label3);
            this.pnlBaBsDocPiece.Controls.Add(this.txtBsAmount);
            this.pnlBaBsDocPiece.Controls.Add(this.label10);
            this.pnlBaBsDocPiece.Controls.Add(this.label5);
            this.pnlBaBsDocPiece.Controls.Add(this.txtBaAmount);
            this.pnlBaBsDocPiece.Controls.Add(this.txtPeriod);
            this.pnlBaBsDocPiece.Controls.Add(this.label11);
            this.pnlBaBsDocPiece.Controls.Add(this.label4);
            this.pnlBaBsDocPiece.Location = new System.Drawing.Point(103, 205);
            this.pnlBaBsDocPiece.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBaBsDocPiece.Name = "pnlBaBsDocPiece";
            this.pnlBaBsDocPiece.Size = new System.Drawing.Size(443, 303);
            this.pnlBaBsDocPiece.TabIndex = 26;
            this.pnlBaBsDocPiece.Visible = false;
            // 
            // nmBsDocPiece
            // 
            this.nmBsDocPiece.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nmBsDocPiece.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nmBsDocPiece.Location = new System.Drawing.Point(213, 80);
            this.nmBsDocPiece.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmBsDocPiece.Name = "nmBsDocPiece";
            this.nmBsDocPiece.Size = new System.Drawing.Size(196, 27);
            this.nmBsDocPiece.TabIndex = 28;
            this.nmBsDocPiece.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nmBaDocPiece
            // 
            this.nmBaDocPiece.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nmBaDocPiece.Location = new System.Drawing.Point(213, 27);
            this.nmBaDocPiece.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmBaDocPiece.Name = "nmBaDocPiece";
            this.nmBaDocPiece.Size = new System.Drawing.Size(196, 27);
            this.nmBaDocPiece.TabIndex = 27;
            this.nmBaDocPiece.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlCurrentPiece
            // 
            this.pnlCurrentPiece.Controls.Add(this.dateReconcilation);
            this.pnlCurrentPiece.Controls.Add(this.label15);
            this.pnlCurrentPiece.Controls.Add(this.cmbAccountType);
            this.pnlCurrentPiece.Controls.Add(this.label12);
            this.pnlCurrentPiece.Controls.Add(this.txtCurrentAmount);
            this.pnlCurrentPiece.Controls.Add(this.label14);
            this.pnlCurrentPiece.Location = new System.Drawing.Point(103, 205);
            this.pnlCurrentPiece.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCurrentPiece.Name = "pnlCurrentPiece";
            this.pnlCurrentPiece.Size = new System.Drawing.Size(409, 303);
            this.pnlCurrentPiece.TabIndex = 27;
            this.pnlCurrentPiece.Visible = false;
            // 
            // dateReconcilation
            // 
            this.dateReconcilation.CustomFormat = "dd.MM.yyyy";
            this.dateReconcilation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateReconcilation.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateReconcilation.Location = new System.Drawing.Point(181, 146);
            this.dateReconcilation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateReconcilation.MaxDate = new System.DateTime(2019, 7, 26, 0, 0, 0, 0);
            this.dateReconcilation.Name = "dateReconcilation";
            this.dateReconcilation.Size = new System.Drawing.Size(160, 27);
            this.dateReconcilation.TabIndex = 25;
            this.dateReconcilation.Value = new System.DateTime(2019, 7, 26, 0, 0, 0, 0);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(148, 23);
            this.label15.TabIndex = 24;
            this.label15.Text = "Mutabakat Tarih";
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAccountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.Items.AddRange(new object[] {
            "Alacaklı",
            "Borclu"});
            this.cmbAccountType.Location = new System.Drawing.Point(181, 81);
            this.cmbAccountType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Size = new System.Drawing.Size(160, 28);
            this.cmbAccountType.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 23);
            this.label12.TabIndex = 20;
            this.label12.Text = "Hesap Tipi";
            // 
            // txtCurrentAmount
            // 
            this.txtCurrentAmount.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentAmount.Location = new System.Drawing.Point(181, 25);
            this.txtCurrentAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCurrentAmount.Name = "txtCurrentAmount";
            this.txtCurrentAmount.Size = new System.Drawing.Size(160, 30);
            this.txtCurrentAmount.TabIndex = 19;
            this.txtCurrentAmount.Text = "12";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 23);
            this.label14.TabIndex = 18;
            this.label14.Text = "Cari Bakiye";
            // 
            // msdReceiverVkn
            // 
            this.msdReceiverVkn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msdReceiverVkn.Location = new System.Drawing.Point(169, 80);
            this.msdReceiverVkn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.msdReceiverVkn.Mask = "99999999999";
            this.msdReceiverVkn.Name = "msdReceiverVkn";
            this.msdReceiverVkn.Size = new System.Drawing.Size(196, 27);
            this.msdReceiverVkn.TabIndex = 28;
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCreate.Location = new System.Drawing.Point(828, 514);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(160, 65);
            this.btnCreate.TabIndex = 30;
            this.btnCreate.Text = "Olustur";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // pnlPartner
            // 
            this.pnlPartner.Controls.Add(this.txtMail);
            this.pnlPartner.Controls.Add(this.label2);
            this.pnlPartner.Controls.Add(this.txtReceiverTitle);
            this.pnlPartner.Controls.Add(this.msdReceiverVkn);
            this.pnlPartner.Controls.Add(this.label9);
            this.pnlPartner.Controls.Add(this.label8);
            this.pnlPartner.Location = new System.Drawing.Point(609, 214);
            this.pnlPartner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPartner.Name = "pnlPartner";
            this.pnlPartner.Size = new System.Drawing.Size(379, 236);
            this.pnlPartner.TabIndex = 31;
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.Location = new System.Drawing.Point(169, 130);
            this.txtMail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(196, 30);
            this.txtMail.TabIndex = 29;
            this.txtMail.Text = "gamze@gmail.com";
            // 
            // FrmCreateReconcilation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 604);
            this.Controls.Add(this.pnlPartner);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pnlBaBsDocPiece);
            this.Controls.Add(this.cmbReconcilationSenario);
            this.Controls.Add(this.lblScenario);
            this.Controls.Add(this.pnlCurrentPiece);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateReconcilation";
            this.Text = "FrmNewReconcilation";
            this.Load += new System.EventHandler(this.FrmCreateReconcilation_Load);
            this.pnlBaBsDocPiece.ResumeLayout(false);
            this.pnlBaBsDocPiece.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmBsDocPiece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmBaDocPiece)).EndInit();
            this.pnlCurrentPiece.ResumeLayout(false);
            this.pnlCurrentPiece.PerformLayout();
            this.pnlPartner.ResumeLayout(false);
            this.pnlPartner.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScenario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbReconcilationSenario;
        private System.Windows.Forms.TextBox txtReceiverTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBsAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBaAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlBaBsDocPiece;
        private System.Windows.Forms.NumericUpDown nmBsDocPiece;
        private System.Windows.Forms.NumericUpDown nmBaDocPiece;
        private System.Windows.Forms.Panel pnlCurrentPiece;
        private System.Windows.Forms.DateTimePicker dateReconcilation;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCurrentAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox msdReceiverVkn;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel pnlPartner;
        private System.Windows.Forms.TextBox txtMail;
    }
}