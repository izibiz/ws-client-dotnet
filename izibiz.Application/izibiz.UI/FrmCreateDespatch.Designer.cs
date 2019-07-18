namespace izibiz.UI
{
    partial class FrmCreateDespatch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCreateDespatch = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.grpReceiver = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.lblProvince = new System.Windows.Forms.Label();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.txtCustSurname = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.msdVknTc = new System.Windows.Forms.MaskedTextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblVknTckn = new System.Windows.Forms.Label();
            this.grpDespatchInformation = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbScenario = new System.Windows.Forms.ComboBox();
            this.lblMoneyType = new System.Windows.Forms.Label();
            this.cmbMoneyType = new System.Windows.Forms.ComboBox();
            this.cmbConsignmentTime = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimeConsignmentDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDespatchTime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeDespatchDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpOrderInformation = new System.Windows.Forms.GroupBox();
            this.dateTimeOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.grpCarrierInformation = new System.Windows.Forms.GroupBox();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.msdCarrierTcVkn = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCarrierTitle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grpRowInformation = new System.Windows.Forms.GroupBox();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.gridPrice = new System.Windows.Forms.DataGridView();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpChauffeurInformation = new System.Windows.Forms.GroupBox();
            this.msdDriverTc = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDriverName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.grpReceiver.SuspendLayout();
            this.grpDespatchInformation.SuspendLayout();
            this.grpOrderInformation.SuspendLayout();
            this.grpCarrierInformation.SuspendLayout();
            this.grpRowInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrice)).BeginInit();
            this.grpChauffeurInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateDespatch
            // 
            this.btnCreateDespatch.Location = new System.Drawing.Point(1003, 777);
            this.btnCreateDespatch.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateDespatch.Name = "btnCreateDespatch";
            this.btnCreateDespatch.Size = new System.Drawing.Size(157, 57);
            this.btnCreateDespatch.TabIndex = 0;
            this.btnCreateDespatch.Text = "olustur";
            this.btnCreateDespatch.UseVisualStyleBackColor = true;
            this.btnCreateDespatch.Click += new System.EventHandler(this.btnCreateDespatch_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(815, 777);
            this.btnClean.Margin = new System.Windows.Forms.Padding(4);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(152, 57);
            this.btnClean.TabIndex = 1;
            this.btnClean.Text = "temizle";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // grpReceiver
            // 
            this.grpReceiver.Controls.Add(this.label8);
            this.grpReceiver.Controls.Add(this.txtPartyName);
            this.grpReceiver.Controls.Add(this.lblDistrict);
            this.grpReceiver.Controls.Add(this.lblProvince);
            this.grpReceiver.Controls.Add(this.txtDistrict);
            this.grpReceiver.Controls.Add(this.txtCity);
            this.grpReceiver.Controls.Add(this.lblSurname);
            this.grpReceiver.Controls.Add(this.txtCustSurname);
            this.grpReceiver.Controls.Add(this.lblName);
            this.grpReceiver.Controls.Add(this.txtCustName);
            this.grpReceiver.Controls.Add(this.txtMail);
            this.grpReceiver.Controls.Add(this.msdVknTc);
            this.grpReceiver.Controls.Add(this.lblMail);
            this.grpReceiver.Controls.Add(this.lblVknTckn);
            this.grpReceiver.Location = new System.Drawing.Point(16, 39);
            this.grpReceiver.Margin = new System.Windows.Forms.Padding(4);
            this.grpReceiver.Name = "grpReceiver";
            this.grpReceiver.Padding = new System.Windows.Forms.Padding(4);
            this.grpReceiver.Size = new System.Drawing.Size(869, 174);
            this.grpReceiver.TabIndex = 6;
            this.grpReceiver.TabStop = false;
            this.grpReceiver.Text = "Alıcı";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(580, 42);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "Kurum Adı";
            // 
            // txtPartyName
            // 
            this.txtPartyName.Location = new System.Drawing.Point(671, 38);
            this.txtPartyName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(144, 22);
            this.txtPartyName.TabIndex = 25;
            this.txtPartyName.Text = "İzibiz";
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(315, 133);
            this.lblDistrict.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(29, 17);
            this.lblDistrict.TabIndex = 23;
            this.lblDistrict.Text = "İlçe";
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(315, 89);
            this.lblProvince.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(14, 17);
            this.lblProvince.TabIndex = 24;
            this.lblProvince.Text = "İl";
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(397, 124);
            this.txtDistrict.Margin = new System.Windows.Forms.Padding(4);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(144, 22);
            this.txtDistrict.TabIndex = 21;
            this.txtDistrict.Text = "Kadıkoy";
            // 
            // txtCity
            // 
            this.txtCity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtCity.Location = new System.Drawing.Point(397, 80);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(144, 22);
            this.txtCity.TabIndex = 22;
            this.txtCity.Text = "İstanbul";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(32, 133);
            this.lblSurname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(48, 17);
            this.lblSurname.TabIndex = 20;
            this.lblSurname.Text = "Soyad";
            // 
            // txtCustSurname
            // 
            this.txtCustSurname.Location = new System.Drawing.Point(128, 129);
            this.txtCustSurname.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustSurname.Name = "txtCustSurname";
            this.txtCustSurname.Size = new System.Drawing.Size(144, 22);
            this.txtCustSurname.TabIndex = 19;
            this.txtCustSurname.Text = "Demir";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(32, 87);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 17);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Ad ";
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(128, 84);
            this.txtCustName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(144, 22);
            this.txtCustName.TabIndex = 16;
            this.txtCustName.Text = "Ahmet";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(397, 38);
            this.txtMail.Margin = new System.Windows.Forms.Padding(4);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(144, 22);
            this.txtMail.TabIndex = 14;
            this.txtMail.Text = "example@gmail.com";
            // 
            // msdVknTc
            // 
            this.msdVknTc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msdVknTc.Location = new System.Drawing.Point(128, 38);
            this.msdVknTc.Margin = new System.Windows.Forms.Padding(4);
            this.msdVknTc.Mask = "00000000000";
            this.msdVknTc.Name = "msdVknTc";
            this.msdVknTc.Size = new System.Drawing.Size(144, 23);
            this.msdVknTc.TabIndex = 5;
            this.msdVknTc.Text = "4840847211";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(315, 42);
            this.lblMail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(58, 17);
            this.lblMail.TabIndex = 3;
            this.lblMail.Text = "E-Posta";
            // 
            // lblVknTckn
            // 
            this.lblVknTckn.AutoSize = true;
            this.lblVknTckn.Location = new System.Drawing.Point(32, 42);
            this.lblVknTckn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVknTckn.Name = "lblVknTckn";
            this.lblVknTckn.Size = new System.Drawing.Size(77, 17);
            this.lblVknTckn.TabIndex = 3;
            this.lblVknTckn.Text = "VKN/TCKN";
            // 
            // grpDespatchInformation
            // 
            this.grpDespatchInformation.Controls.Add(this.cmbType);
            this.grpDespatchInformation.Controls.Add(this.cmbScenario);
            this.grpDespatchInformation.Controls.Add(this.lblMoneyType);
            this.grpDespatchInformation.Controls.Add(this.cmbMoneyType);
            this.grpDespatchInformation.Controls.Add(this.cmbConsignmentTime);
            this.grpDespatchInformation.Controls.Add(this.label6);
            this.grpDespatchInformation.Controls.Add(this.dateTimeConsignmentDate);
            this.grpDespatchInformation.Controls.Add(this.label7);
            this.grpDespatchInformation.Controls.Add(this.cmbDespatchTime);
            this.grpDespatchInformation.Controls.Add(this.label5);
            this.grpDespatchInformation.Controls.Add(this.dateTimeDespatchDate);
            this.grpDespatchInformation.Controls.Add(this.label1);
            this.grpDespatchInformation.Controls.Add(this.label2);
            this.grpDespatchInformation.Controls.Add(this.label4);
            this.grpDespatchInformation.Location = new System.Drawing.Point(16, 256);
            this.grpDespatchInformation.Margin = new System.Windows.Forms.Padding(4);
            this.grpDespatchInformation.Name = "grpDespatchInformation";
            this.grpDespatchInformation.Padding = new System.Windows.Forms.Padding(4);
            this.grpDespatchInformation.Size = new System.Drawing.Size(485, 373);
            this.grpDespatchInformation.TabIndex = 7;
            this.grpDespatchInformation.TabStop = false;
            this.grpDespatchInformation.Text = "İrsaliye Bilgileri";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(129, 87);
            this.cmbType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(160, 24);
            this.cmbType.TabIndex = 32;
            // 
            // cmbScenario
            // 
            this.cmbScenario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScenario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbScenario.FormattingEnabled = true;
            this.cmbScenario.Location = new System.Drawing.Point(129, 42);
            this.cmbScenario.Margin = new System.Windows.Forms.Padding(4);
            this.cmbScenario.Name = "cmbScenario";
            this.cmbScenario.Size = new System.Drawing.Size(160, 24);
            this.cmbScenario.TabIndex = 31;
            // 
            // lblMoneyType
            // 
            this.lblMoneyType.AutoSize = true;
            this.lblMoneyType.Location = new System.Drawing.Point(28, 329);
            this.lblMoneyType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoneyType.Name = "lblMoneyType";
            this.lblMoneyType.Size = new System.Drawing.Size(76, 17);
            this.lblMoneyType.TabIndex = 30;
            this.lblMoneyType.Text = "Para Birimi";
            // 
            // cmbMoneyType
            // 
            this.cmbMoneyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneyType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMoneyType.FormattingEnabled = true;
            this.cmbMoneyType.Location = new System.Drawing.Point(127, 325);
            this.cmbMoneyType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMoneyType.Name = "cmbMoneyType";
            this.cmbMoneyType.Size = new System.Drawing.Size(144, 24);
            this.cmbMoneyType.TabIndex = 29;
            // 
            // cmbConsignmentTime
            // 
            this.cmbConsignmentTime.BackColor = System.Drawing.SystemColors.Window;
            this.cmbConsignmentTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConsignmentTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbConsignmentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbConsignmentTime.FormattingEnabled = true;
            this.cmbConsignmentTime.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00"});
            this.cmbConsignmentTime.Location = new System.Drawing.Point(128, 279);
            this.cmbConsignmentTime.Margin = new System.Windows.Forms.Padding(4);
            this.cmbConsignmentTime.Name = "cmbConsignmentTime";
            this.cmbConsignmentTime.Size = new System.Drawing.Size(144, 28);
            this.cmbConsignmentTime.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 279);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Sevk Saat";
            // 
            // dateTimeConsignmentDate
            // 
            this.dateTimeConsignmentDate.Location = new System.Drawing.Point(128, 226);
            this.dateTimeConsignmentDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeConsignmentDate.Name = "dateTimeConsignmentDate";
            this.dateTimeConsignmentDate.Size = new System.Drawing.Size(143, 22);
            this.dateTimeConsignmentDate.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 233);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Sevk Tarih";
            // 
            // cmbDespatchTime
            // 
            this.cmbDespatchTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDespatchTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDespatchTime.FormattingEnabled = true;
            this.cmbDespatchTime.Items.AddRange(new object[] {
            "00:00",
            "01:00"});
            this.cmbDespatchTime.Location = new System.Drawing.Point(129, 186);
            this.cmbDespatchTime.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDespatchTime.Name = "cmbDespatchTime";
            this.cmbDespatchTime.Size = new System.Drawing.Size(143, 24);
            this.cmbDespatchTime.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 186);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "İrsaliye Saat";
            // 
            // dateTimeDespatchDate
            // 
            this.dateTimeDespatchDate.Location = new System.Drawing.Point(129, 133);
            this.dateTimeDespatchDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeDespatchDate.Name = "dateTimeDespatchDate";
            this.dateTimeDespatchDate.Size = new System.Drawing.Size(143, 22);
            this.dateTimeDespatchDate.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "İrsaliye Tarih";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tip";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Senaryo";
            // 
            // grpOrderInformation
            // 
            this.grpOrderInformation.Controls.Add(this.dateTimeOrderDate);
            this.grpOrderInformation.Controls.Add(this.label14);
            this.grpOrderInformation.Controls.Add(this.txtOrderId);
            this.grpOrderInformation.Controls.Add(this.label13);
            this.grpOrderInformation.Location = new System.Drawing.Point(541, 256);
            this.grpOrderInformation.Margin = new System.Windows.Forms.Padding(4);
            this.grpOrderInformation.Name = "grpOrderInformation";
            this.grpOrderInformation.Padding = new System.Windows.Forms.Padding(4);
            this.grpOrderInformation.Size = new System.Drawing.Size(603, 103);
            this.grpOrderInformation.TabIndex = 8;
            this.grpOrderInformation.TabStop = false;
            this.grpOrderInformation.Text = "Siparis Bilgileri";
            // 
            // dateTimeOrderDate
            // 
            this.dateTimeOrderDate.Location = new System.Drawing.Point(440, 34);
            this.dateTimeOrderDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeOrderDate.Name = "dateTimeOrderDate";
            this.dateTimeOrderDate.Size = new System.Drawing.Size(143, 22);
            this.dateTimeOrderDate.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(339, 42);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 17);
            this.label14.TabIndex = 31;
            this.label14.Text = "Sipariş Tarih";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(163, 38);
            this.txtOrderId.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(144, 22);
            this.txtOrderId.TabIndex = 21;
            this.txtOrderId.Text = "Ahmet";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 42);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 17);
            this.label13.TabIndex = 3;
            this.label13.Text = "Sipariş Numarası";
            // 
            // grpCarrierInformation
            // 
            this.grpCarrierInformation.Controls.Add(this.txtPlate);
            this.grpCarrierInformation.Controls.Add(this.label11);
            this.grpCarrierInformation.Controls.Add(this.msdCarrierTcVkn);
            this.grpCarrierInformation.Controls.Add(this.label9);
            this.grpCarrierInformation.Controls.Add(this.txtCarrierTitle);
            this.grpCarrierInformation.Controls.Add(this.label10);
            this.grpCarrierInformation.Location = new System.Drawing.Point(541, 506);
            this.grpCarrierInformation.Margin = new System.Windows.Forms.Padding(4);
            this.grpCarrierInformation.Name = "grpCarrierInformation";
            this.grpCarrierInformation.Padding = new System.Windows.Forms.Padding(4);
            this.grpCarrierInformation.Size = new System.Drawing.Size(603, 123);
            this.grpCarrierInformation.TabIndex = 10;
            this.grpCarrierInformation.TabStop = false;
            this.grpCarrierInformation.Text = "Taşıyıcı  Bilgileri";
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(163, 87);
            this.txtPlate.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(144, 22);
            this.txtPlate.TabIndex = 34;
            this.txtPlate.Text = "34 tr 123";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 91);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 17);
            this.label11.TabIndex = 33;
            this.label11.Text = "Plaka";
            // 
            // msdCarrierTcVkn
            // 
            this.msdCarrierTcVkn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msdCarrierTcVkn.Location = new System.Drawing.Point(417, 38);
            this.msdCarrierTcVkn.Margin = new System.Windows.Forms.Padding(4);
            this.msdCarrierTcVkn.Mask = "00000000000";
            this.msdCarrierTcVkn.Name = "msdCarrierTcVkn";
            this.msdCarrierTcVkn.Size = new System.Drawing.Size(144, 23);
            this.msdCarrierTcVkn.TabIndex = 32;
            this.msdCarrierTcVkn.Text = "11111111110";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(325, 42);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "VKN/TCKN";
            // 
            // txtCarrierTitle
            // 
            this.txtCarrierTitle.Location = new System.Drawing.Point(163, 38);
            this.txtCarrierTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtCarrierTitle.Name = "txtCarrierTitle";
            this.txtCarrierTitle.Size = new System.Drawing.Size(144, 22);
            this.txtCarrierTitle.TabIndex = 21;
            this.txtCarrierTitle.Text = "Ahmet";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 42);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "Taşıyıcı Ünvan";
            // 
            // grpRowInformation
            // 
            this.grpRowInformation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpRowInformation.CausesValidation = false;
            this.grpRowInformation.Controls.Add(this.btnRemoveRow);
            this.grpRowInformation.Controls.Add(this.gridPrice);
            this.grpRowInformation.Controls.Add(this.btnAddRow);
            this.grpRowInformation.Location = new System.Drawing.Point(16, 647);
            this.grpRowInformation.Margin = new System.Windows.Forms.Padding(4);
            this.grpRowInformation.Name = "grpRowInformation";
            this.grpRowInformation.Padding = new System.Windows.Forms.Padding(4);
            this.grpRowInformation.Size = new System.Drawing.Size(777, 186);
            this.grpRowInformation.TabIndex = 11;
            this.grpRowInformation.TabStop = false;
            this.grpRowInformation.Text = "Satır Bilgileri";
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(617, 70);
            this.btnRemoveRow.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(121, 28);
            this.btnRemoveRow.TabIndex = 6;
            this.btnRemoveRow.Text = "Satır Kaldır";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // gridPrice
            // 
            this.gridPrice.AllowUserToAddRows = false;
            this.gridPrice.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            this.gridPrice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPrice.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPrice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPrice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productName,
            this.quantity,
            this.unit,
            this.unitPrice});
            this.gridPrice.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridPrice.Location = new System.Drawing.Point(20, 26);
            this.gridPrice.Margin = new System.Windows.Forms.Padding(4);
            this.gridPrice.MultiSelect = false;
            this.gridPrice.Name = "gridPrice";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPrice.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridPrice.RowHeadersVisible = false;
            this.gridPrice.RowHeadersWidth = 51;
            this.gridPrice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            this.gridPrice.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.gridPrice.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gridPrice.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridPrice.Size = new System.Drawing.Size(591, 122);
            this.gridPrice.TabIndex = 5;
            // 
            // productName
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.productName.DefaultCellStyle = dataGridViewCellStyle3;
            this.productName.HeaderText = "ad";
            this.productName.MinimumWidth = 6;
            this.productName.Name = "productName";
            this.productName.Width = 125;
            // 
            // quantity
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.quantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.quantity.HeaderText = "miktar";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.Width = 125;
            // 
            // unit
            // 
            this.unit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unit.HeaderText = "Birim";
            this.unit.MinimumWidth = 6;
            this.unit.Name = "unit";
            this.unit.Width = 125;
            // 
            // unitPrice
            // 
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.unitPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.unitPrice.HeaderText = "birim fiyat";
            this.unitPrice.MinimumWidth = 6;
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.unitPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.unitPrice.Width = 125;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(617, 34);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(121, 28);
            this.btnAddRow.TabIndex = 3;
            this.btnAddRow.Text = "Satır Ekle";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(980, 673);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(144, 22);
            this.txtTotalAmount.TabIndex = 23;
            this.txtTotalAmount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(849, 677);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Toplam Tutar";
            // 
            // grpChauffeurInformation
            // 
            this.grpChauffeurInformation.Controls.Add(this.msdDriverTc);
            this.grpChauffeurInformation.Controls.Add(this.label16);
            this.grpChauffeurInformation.Controls.Add(this.txtDriverName);
            this.grpChauffeurInformation.Controls.Add(this.label15);
            this.grpChauffeurInformation.Location = new System.Drawing.Point(541, 389);
            this.grpChauffeurInformation.Margin = new System.Windows.Forms.Padding(4);
            this.grpChauffeurInformation.Name = "grpChauffeurInformation";
            this.grpChauffeurInformation.Padding = new System.Windows.Forms.Padding(4);
            this.grpChauffeurInformation.Size = new System.Drawing.Size(603, 103);
            this.grpChauffeurInformation.TabIndex = 24;
            this.grpChauffeurInformation.TabStop = false;
            this.grpChauffeurInformation.Text = "Şoför Bilgileri";
            // 
            // msdDriverTc
            // 
            this.msdDriverTc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msdDriverTc.Location = new System.Drawing.Point(403, 38);
            this.msdDriverTc.Margin = new System.Windows.Forms.Padding(4);
            this.msdDriverTc.Mask = "00000000000";
            this.msdDriverTc.Name = "msdDriverTc";
            this.msdDriverTc.Size = new System.Drawing.Size(144, 23);
            this.msdDriverTc.TabIndex = 34;
            this.msdDriverTc.Text = "11111111110";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(347, 42);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 17);
            this.label16.TabIndex = 33;
            this.label16.Text = "TC";
            // 
            // txtDriverName
            // 
            this.txtDriverName.Location = new System.Drawing.Point(163, 38);
            this.txtDriverName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Size = new System.Drawing.Size(144, 22);
            this.txtDriverName.TabIndex = 21;
            this.txtDriverName.Text = "Ahmet veli";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 42);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 17);
            this.label15.TabIndex = 3;
            this.label15.Text = "Adı Soyadı";
            // 
            // FrmCreateDespatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 891);
            this.Controls.Add(this.grpChauffeurInformation);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpRowInformation);
            this.Controls.Add(this.grpCarrierInformation);
            this.Controls.Add(this.grpOrderInformation);
            this.Controls.Add(this.grpDespatchInformation);
            this.Controls.Add(this.grpReceiver);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnCreateDespatch);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateDespatch";
            this.Text = "FrmCreateDespatch";
            this.Load += new System.EventHandler(this.FrmCreateDespatch_Load);
            this.grpReceiver.ResumeLayout(false);
            this.grpReceiver.PerformLayout();
            this.grpDespatchInformation.ResumeLayout(false);
            this.grpDespatchInformation.PerformLayout();
            this.grpOrderInformation.ResumeLayout(false);
            this.grpOrderInformation.PerformLayout();
            this.grpCarrierInformation.ResumeLayout(false);
            this.grpCarrierInformation.PerformLayout();
            this.grpRowInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPrice)).EndInit();
            this.grpChauffeurInformation.ResumeLayout(false);
            this.grpChauffeurInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateDespatch;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.GroupBox grpReceiver;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox txtCustSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.MaskedTextBox msdVknTc;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblVknTckn;
        private System.Windows.Forms.GroupBox grpDespatchInformation;
        private System.Windows.Forms.ComboBox cmbConsignmentTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimeConsignmentDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDespatchTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimeDespatchDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMoneyType;
        private System.Windows.Forms.ComboBox cmbMoneyType;
        private System.Windows.Forms.GroupBox grpOrderInformation;
        private System.Windows.Forms.DateTimePicker dateTimeOrderDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grpCarrierInformation;
        private System.Windows.Forms.MaskedTextBox msdCarrierTcVkn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCarrierTitle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grpRowInformation;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.DataGridView gridPrice;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbScenario;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpChauffeurInformation;
        private System.Windows.Forms.MaskedTextBox msdDriverTc;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDriverName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
    }
}