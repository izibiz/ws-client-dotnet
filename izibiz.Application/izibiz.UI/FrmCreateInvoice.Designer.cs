namespace izibiz.UI
{
    partial class FrmCreateInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpboxTotal = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPayableAmount = new System.Windows.Forms.TextBox();
            this.txtTotalAmountWithTax = new System.Windows.Forms.TextBox();
            this.txtTaxAmount = new System.Windows.Forms.TextBox();
            this.txtServiceAmount = new System.Windows.Forms.TextBox();
            this.grpboxRow = new System.Windows.Forms.GroupBox();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.gridPrice = new System.Windows.Forms.DataGridView();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.grpInvInformation = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbMoneyType = new System.Windows.Forms.ComboBox();
            this.cmbScenario = new System.Windows.Forms.ComboBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.grpReceiver = new System.Windows.Forms.GroupBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtBuldingNo = new System.Windows.Forms.TextBox();
            this.txtBuldingName = new System.Windows.Forms.TextBox();
            this.txtVision = new System.Windows.Forms.TextBox();
            this.msdVknTc = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.msdPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtTaxScheme = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnCreateUbl = new System.Windows.Forms.Button();
            this.grpboxTotal.SuspendLayout();
            this.grpboxRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrice)).BeginInit();
            this.grpInvInformation.SuspendLayout();
            this.grpReceiver.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(346, 618);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(153, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpboxTotal
            // 
            this.grpboxTotal.Controls.Add(this.txtNote);
            this.grpboxTotal.Controls.Add(this.label19);
            this.grpboxTotal.Controls.Add(this.label18);
            this.grpboxTotal.Controls.Add(this.label17);
            this.grpboxTotal.Controls.Add(this.label16);
            this.grpboxTotal.Controls.Add(this.label15);
            this.grpboxTotal.Controls.Add(this.txtPayableAmount);
            this.grpboxTotal.Controls.Add(this.txtTotalAmountWithTax);
            this.grpboxTotal.Controls.Add(this.txtTaxAmount);
            this.grpboxTotal.Controls.Add(this.txtServiceAmount);
            this.grpboxTotal.Location = new System.Drawing.Point(9, 406);
            this.grpboxTotal.Name = "grpboxTotal";
            this.grpboxTotal.Size = new System.Drawing.Size(1176, 198);
            this.grpboxTotal.TabIndex = 8;
            this.grpboxTotal.TabStop = false;
            this.grpboxTotal.Text = "Toplam ve Not Bilgileri";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(65, 47);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(251, 93);
            this.txtNote.TabIndex = 4;
            this.txtNote.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(588, 168);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Ödenecek Tutar";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(588, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(135, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "Vergiler Dahil Toplam Tutar";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(588, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Hesaplanan KDV";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(588, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(129, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Mal/Hizmet Toplam Tutarı";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Not";
            // 
            // txtPayableAmount
            // 
            this.txtPayableAmount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPayableAmount.Location = new System.Drawing.Point(748, 165);
            this.txtPayableAmount.Name = "txtPayableAmount";
            this.txtPayableAmount.ReadOnly = true;
            this.txtPayableAmount.Size = new System.Drawing.Size(100, 20);
            this.txtPayableAmount.TabIndex = 1;
            // 
            // txtTotalAmountWithTax
            // 
            this.txtTotalAmountWithTax.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTotalAmountWithTax.Location = new System.Drawing.Point(748, 126);
            this.txtTotalAmountWithTax.Name = "txtTotalAmountWithTax";
            this.txtTotalAmountWithTax.ReadOnly = true;
            this.txtTotalAmountWithTax.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAmountWithTax.TabIndex = 1;
            // 
            // txtTaxAmount
            // 
            this.txtTaxAmount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTaxAmount.Location = new System.Drawing.Point(747, 89);
            this.txtTaxAmount.Name = "txtTaxAmount";
            this.txtTaxAmount.ReadOnly = true;
            this.txtTaxAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTaxAmount.TabIndex = 1;
            // 
            // txtServiceAmount
            // 
            this.txtServiceAmount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtServiceAmount.Location = new System.Drawing.Point(747, 49);
            this.txtServiceAmount.Name = "txtServiceAmount";
            this.txtServiceAmount.ReadOnly = true;
            this.txtServiceAmount.Size = new System.Drawing.Size(100, 20);
            this.txtServiceAmount.TabIndex = 1;
            // 
            // grpboxRow
            // 
            this.grpboxRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpboxRow.CausesValidation = false;
            this.grpboxRow.Controls.Add(this.btnRemoveRow);
            this.grpboxRow.Controls.Add(this.gridPrice);
            this.grpboxRow.Controls.Add(this.btnAddRow);
            this.grpboxRow.Location = new System.Drawing.Point(14, 277);
            this.grpboxRow.Name = "grpboxRow";
            this.grpboxRow.Size = new System.Drawing.Size(1176, 121);
            this.grpboxRow.TabIndex = 7;
            this.grpboxRow.TabStop = false;
            this.grpboxRow.Text = "Satır Bilgileri";
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(751, 66);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(91, 23);
            this.btnRemoveRow.TabIndex = 6;
            this.btnRemoveRow.Text = "Remove Row";
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
            this.unitPrice,
            this.taxPercent,
            this.taxAmount,
            this.total});
            this.gridPrice.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPrice.DefaultCellStyle = dataGridViewCellStyle9;
            this.gridPrice.Location = new System.Drawing.Point(6, 19);
            this.gridPrice.MultiSelect = false;
            this.gridPrice.Name = "gridPrice";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPrice.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gridPrice.RowHeadersVisible = false;
            this.gridPrice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridPrice.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.gridPrice.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gridPrice.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPrice.Size = new System.Drawing.Size(712, 96);
            this.gridPrice.TabIndex = 5;
            this.gridPrice.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridPrice_CellValidating);
            // 
            // productName
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.productName.DefaultCellStyle = dataGridViewCellStyle3;
            this.productName.HeaderText = "ad";
            this.productName.Name = "productName";
            // 
            // quantity
            // 
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.quantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.quantity.HeaderText = "miktar";
            this.quantity.Name = "quantity";
            // 
            // unit
            // 
            this.unit.HeaderText = "birim";
            this.unit.Name = "unit";
            // 
            // unitPrice
            // 
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.unitPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.unitPrice.HeaderText = "birim fiyat";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.unitPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // taxPercent
            // 
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.taxPercent.DefaultCellStyle = dataGridViewCellStyle6;
            this.taxPercent.HeaderText = "kdv oranı";
            this.taxPercent.Name = "taxPercent";
            // 
            // taxAmount
            // 
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.taxAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.taxAmount.HeaderText = "kdv tutarı";
            this.taxAmount.Name = "taxAmount";
            this.taxAmount.ReadOnly = true;
            // 
            // total
            // 
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.total.DefaultCellStyle = dataGridViewCellStyle8;
            this.total.HeaderText = "toplam";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(751, 37);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(91, 23);
            this.btnAddRow.TabIndex = 3;
            this.btnAddRow.Text = "Add row";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // grpInvInformation
            // 
            this.grpInvInformation.Controls.Add(this.cmbType);
            this.grpInvInformation.Controls.Add(this.txtPartyName);
            this.grpInvInformation.Controls.Add(this.label1);
            this.grpInvInformation.Controls.Add(this.label13);
            this.grpInvInformation.Controls.Add(this.label14);
            this.grpInvInformation.Controls.Add(this.label12);
            this.grpInvInformation.Controls.Add(this.label11);
            this.grpInvInformation.Controls.Add(this.cmbMoneyType);
            this.grpInvInformation.Controls.Add(this.cmbScenario);
            this.grpInvInformation.Controls.Add(this.dateTime);
            this.grpInvInformation.Location = new System.Drawing.Point(15, 161);
            this.grpInvInformation.Name = "grpInvInformation";
            this.grpInvInformation.Size = new System.Drawing.Size(1176, 105);
            this.grpInvInformation.TabIndex = 6;
            this.grpInvInformation.TabStop = false;
            this.grpInvInformation.Text = "Fatura Bilgileri";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(294, 25);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(109, 21);
            this.cmbType.TabIndex = 7;
            // 
            // txtPartyName
            // 
            this.txtPartyName.Location = new System.Drawing.Point(518, 25);
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(109, 20);
            this.txtPartyName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fatura Başlık";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(232, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Para Birimi";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(232, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Tip";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Tarih";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Senaryo";
            // 
            // cmbMoneyType
            // 
            this.cmbMoneyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneyType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMoneyType.FormattingEnabled = true;
            this.cmbMoneyType.Location = new System.Drawing.Point(294, 60);
            this.cmbMoneyType.Name = "cmbMoneyType";
            this.cmbMoneyType.Size = new System.Drawing.Size(109, 21);
            this.cmbMoneyType.TabIndex = 1;
            // 
            // cmbScenario
            // 
            this.cmbScenario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScenario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbScenario.FormattingEnabled = true;
            this.cmbScenario.Location = new System.Drawing.Point(96, 25);
            this.cmbScenario.Name = "cmbScenario";
            this.cmbScenario.Size = new System.Drawing.Size(109, 21);
            this.cmbScenario.TabIndex = 1;
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(96, 61);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(109, 20);
            this.dateTime.TabIndex = 0;
            // 
            // grpReceiver
            // 
            this.grpReceiver.Controls.Add(this.txtMail);
            this.grpReceiver.Controls.Add(this.label22);
            this.grpReceiver.Controls.Add(this.txtStreet);
            this.grpReceiver.Controls.Add(this.label10);
            this.grpReceiver.Controls.Add(this.label20);
            this.grpReceiver.Controls.Add(this.label21);
            this.grpReceiver.Controls.Add(this.txtBuldingNo);
            this.grpReceiver.Controls.Add(this.txtBuldingName);
            this.grpReceiver.Controls.Add(this.txtVision);
            this.grpReceiver.Controls.Add(this.msdVknTc);
            this.grpReceiver.Controls.Add(this.label9);
            this.grpReceiver.Controls.Add(this.label8);
            this.grpReceiver.Controls.Add(this.label7);
            this.grpReceiver.Controls.Add(this.label6);
            this.grpReceiver.Controls.Add(this.label5);
            this.grpReceiver.Controls.Add(this.label4);
            this.grpReceiver.Controls.Add(this.label3);
            this.grpReceiver.Controls.Add(this.label2);
            this.grpReceiver.Controls.Add(this.msdPhone);
            this.grpReceiver.Controls.Add(this.txtCountry);
            this.grpReceiver.Controls.Add(this.txtDistrict);
            this.grpReceiver.Controls.Add(this.txtCity);
            this.grpReceiver.Controls.Add(this.txtTaxScheme);
            this.grpReceiver.Controls.Add(this.txtTitle);
            this.grpReceiver.Location = new System.Drawing.Point(15, 14);
            this.grpReceiver.Name = "grpReceiver";
            this.grpReceiver.Size = new System.Drawing.Size(1176, 141);
            this.grpReceiver.TabIndex = 5;
            this.grpReceiver.TabStop = false;
            this.grpReceiver.Text = "Alıcı";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(716, 101);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(109, 20);
            this.txtMail.TabIndex = 14;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(654, 35);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(36, 13);
            this.label22.TabIndex = 13;
            this.label22.Text = "sokak";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(716, 28);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(109, 20);
            this.txtStreet.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(426, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "bina no";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(426, 71);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "bina adı";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(426, 35);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 11;
            this.label21.Text = "mahalle";
            // 
            // txtBuldingNo
            // 
            this.txtBuldingNo.Location = new System.Drawing.Point(488, 101);
            this.txtBuldingNo.Name = "txtBuldingNo";
            this.txtBuldingNo.Size = new System.Drawing.Size(109, 20);
            this.txtBuldingNo.TabIndex = 6;
            // 
            // txtBuldingName
            // 
            this.txtBuldingName.Location = new System.Drawing.Point(488, 64);
            this.txtBuldingName.Name = "txtBuldingName";
            this.txtBuldingName.Size = new System.Drawing.Size(109, 20);
            this.txtBuldingName.TabIndex = 7;
            // 
            // txtVision
            // 
            this.txtVision.Location = new System.Drawing.Point(488, 28);
            this.txtVision.Name = "txtVision";
            this.txtVision.Size = new System.Drawing.Size(109, 20);
            this.txtVision.TabIndex = 8;
            // 
            // msdVknTc
            // 
            this.msdVknTc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msdVknTc.Location = new System.Drawing.Point(96, 31);
            this.msdVknTc.Mask = "00000000000";
            this.msdVknTc.Name = "msdVknTc";
            this.msdVknTc.Size = new System.Drawing.Size(109, 20);
            this.msdVknTc.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(654, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "E-Posta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(654, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Telefon";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Ülke";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "İlçe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "İl";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vergi Dairesi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ünvanı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "VKN/TCKN";
            // 
            // msdPhone
            // 
            this.msdPhone.Location = new System.Drawing.Point(716, 65);
            this.msdPhone.Mask = "(999) 000-0000";
            this.msdPhone.Name = "msdPhone";
            this.msdPhone.Size = new System.Drawing.Size(109, 20);
            this.msdPhone.TabIndex = 1;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(294, 101);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(109, 20);
            this.txtCountry.TabIndex = 0;
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(294, 64);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(109, 20);
            this.txtDistrict.TabIndex = 0;
            // 
            // txtCity
            // 
            this.txtCity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtCity.Location = new System.Drawing.Point(294, 28);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(109, 20);
            this.txtCity.TabIndex = 0;
            // 
            // txtTaxScheme
            // 
            this.txtTaxScheme.Location = new System.Drawing.Point(96, 101);
            this.txtTaxScheme.Name = "txtTaxScheme";
            this.txtTaxScheme.Size = new System.Drawing.Size(109, 20);
            this.txtTaxScheme.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(96, 64);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(109, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // btnCreateUbl
            // 
            this.btnCreateUbl.Location = new System.Drawing.Point(537, 618);
            this.btnCreateUbl.Name = "btnCreateUbl";
            this.btnCreateUbl.Size = new System.Drawing.Size(75, 23);
            this.btnCreateUbl.TabIndex = 10;
            this.btnCreateUbl.Text = "Olustur";
            this.btnCreateUbl.UseVisualStyleBackColor = true;
            this.btnCreateUbl.Click += new System.EventHandler(this.btnCreateUbl_Click);
            // 
            // FrmCreateInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 644);
            this.Controls.Add(this.btnCreateUbl);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpboxTotal);
            this.Controls.Add(this.grpboxRow);
            this.Controls.Add(this.grpInvInformation);
            this.Controls.Add(this.grpReceiver);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateInvoice";
            this.Load += new System.EventHandler(this.FrmCreateInvoice_Load);
            this.grpboxTotal.ResumeLayout(false);
            this.grpboxTotal.PerformLayout();
            this.grpboxRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPrice)).EndInit();
            this.grpInvInformation.ResumeLayout(false);
            this.grpInvInformation.PerformLayout();
            this.grpReceiver.ResumeLayout(false);
            this.grpReceiver.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpboxTotal;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPayableAmount;
        private System.Windows.Forms.TextBox txtTotalAmountWithTax;
        private System.Windows.Forms.TextBox txtTaxAmount;
        private System.Windows.Forms.TextBox txtServiceAmount;
        private System.Windows.Forms.GroupBox grpboxRow;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbMoneyType;
        private System.Windows.Forms.ComboBox cmbScenario;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.GroupBox grpReceiver;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox msdPhone;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtTaxScheme;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.MaskedTextBox msdVknTc;
        private System.Windows.Forms.GroupBox grpInvInformation;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtBuldingNo;
        private System.Windows.Forms.TextBox txtBuldingName;
        private System.Windows.Forms.TextBox txtVision;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnCreateUbl;
        private System.Windows.Forms.DataGridView gridPrice;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
    }
}