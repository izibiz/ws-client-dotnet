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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpTotal = new System.Windows.Forms.GroupBox();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.lblTotalAmountWithTax = new System.Windows.Forms.Label();
            this.lblCalculatedTaxAmount = new System.Windows.Forms.Label();
            this.lblServiceAmount = new System.Windows.Forms.Label();
            this.txtPayableAmount = new System.Windows.Forms.TextBox();
            this.txtTotalAmountWithTax = new System.Windows.Forms.TextBox();
            this.txtTaxAmount = new System.Windows.Forms.TextBox();
            this.txtServiceAmount = new System.Windows.Forms.TextBox();
            this.grpRowInformation = new System.Windows.Forms.GroupBox();
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
            this.cmbInvType = new System.Windows.Forms.ComboBox();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.lblInvoiceChapiter = new System.Windows.Forms.Label();
            this.lblMoneyType = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblScenario = new System.Windows.Forms.Label();
            this.cmbMoneyType = new System.Windows.Forms.ComboBox();
            this.cmbScenario = new System.Windows.Forms.ComboBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.grpReceiver = new System.Windows.Forms.GroupBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.txtCustSurname = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.msdVknTc = new System.Windows.Forms.MaskedTextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.lblProvince = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblVknTckn = new System.Windows.Forms.Label();
            this.msdPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblArchiveSendingType = new System.Windows.Forms.Label();
            this.cmbArchiveSendingType = new System.Windows.Forms.ComboBox();
            this.cmbArchiveType = new System.Windows.Forms.ComboBox();
            this.lblArchiveType = new System.Windows.Forms.Label();
            this.pnlArchiveInformation = new System.Windows.Forms.Panel();
            this.pnlArchive = new System.Windows.Forms.Panel();
            this.chkSendMail = new System.Windows.Forms.CheckBox();
            this.grpSendingType = new System.Windows.Forms.GroupBox();
            this.datepicDespatchDate = new System.Windows.Forms.DateTimePicker();
            this.msdDeliveryVkn = new System.Windows.Forms.MaskedTextBox();
            this.rdTuzel = new System.Windows.Forms.RadioButton();
            this.rdReal = new System.Windows.Forms.RadioButton();
            this.lblSendingDate = new System.Windows.Forms.Label();
            this.lblCarrierTitle = new System.Windows.Forms.Label();
            this.lblCarrierVknTckn = new System.Windows.Forms.Label();
            this.lblCarrier = new System.Windows.Forms.Label();
            this.txtCarrierTitle = new System.Windows.Forms.TextBox();
            this.grpPaymentInformation = new System.Windows.Forms.GroupBox();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.datepicPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.lblInternetSalesInformation = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblMiddleman = new System.Windows.Forms.Label();
            this.lblPaymentType = new System.Windows.Forms.Label();
            this.txtMediator = new System.Windows.Forms.TextBox();
            this.grpTotal.SuspendLayout();
            this.grpRowInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrice)).BeginInit();
            this.grpInvInformation.SuspendLayout();
            this.grpReceiver.SuspendLayout();
            this.pnlArchiveInformation.SuspendLayout();
            this.pnlArchive.SuspendLayout();
            this.grpSendingType.SuspendLayout();
            this.grpPaymentInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(309, 519);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(176, 39);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Temizle";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpTotal
            // 
            this.grpTotal.Controls.Add(this.lblPaidAmount);
            this.grpTotal.Controls.Add(this.lblTotalAmountWithTax);
            this.grpTotal.Controls.Add(this.lblCalculatedTaxAmount);
            this.grpTotal.Controls.Add(this.lblServiceAmount);
            this.grpTotal.Controls.Add(this.txtPayableAmount);
            this.grpTotal.Controls.Add(this.txtTotalAmountWithTax);
            this.grpTotal.Controls.Add(this.txtTaxAmount);
            this.grpTotal.Controls.Add(this.txtServiceAmount);
            this.grpTotal.Location = new System.Drawing.Point(871, 326);
            this.grpTotal.Name = "grpTotal";
            this.grpTotal.Size = new System.Drawing.Size(327, 180);
            this.grpTotal.TabIndex = 8;
            this.grpTotal.TabStop = false;
            this.grpTotal.Text = "Toplam";
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Location = new System.Drawing.Point(29, 138);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(85, 13);
            this.lblPaidAmount.TabIndex = 3;
            this.lblPaidAmount.Text = "Ödenecek Tutar";
            // 
            // lblTotalAmountWithTax
            // 
            this.lblTotalAmountWithTax.AutoSize = true;
            this.lblTotalAmountWithTax.Location = new System.Drawing.Point(29, 99);
            this.lblTotalAmountWithTax.Name = "lblTotalAmountWithTax";
            this.lblTotalAmountWithTax.Size = new System.Drawing.Size(135, 13);
            this.lblTotalAmountWithTax.TabIndex = 3;
            this.lblTotalAmountWithTax.Text = "Vergiler Dahil Toplam Tutar";
            // 
            // lblCalculatedTaxAmount
            // 
            this.lblCalculatedTaxAmount.AutoSize = true;
            this.lblCalculatedTaxAmount.Location = new System.Drawing.Point(29, 62);
            this.lblCalculatedTaxAmount.Name = "lblCalculatedTaxAmount";
            this.lblCalculatedTaxAmount.Size = new System.Drawing.Size(89, 13);
            this.lblCalculatedTaxAmount.TabIndex = 3;
            this.lblCalculatedTaxAmount.Text = "Hesaplanan KDV";
            // 
            // lblServiceAmount
            // 
            this.lblServiceAmount.AutoSize = true;
            this.lblServiceAmount.Location = new System.Drawing.Point(29, 22);
            this.lblServiceAmount.Name = "lblServiceAmount";
            this.lblServiceAmount.Size = new System.Drawing.Size(129, 13);
            this.lblServiceAmount.TabIndex = 3;
            this.lblServiceAmount.Text = "Mal/Hizmet Toplam Tutarı";
            // 
            // txtPayableAmount
            // 
            this.txtPayableAmount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPayableAmount.Enabled = false;
            this.txtPayableAmount.Location = new System.Drawing.Point(189, 135);
            this.txtPayableAmount.Name = "txtPayableAmount";
            this.txtPayableAmount.ReadOnly = true;
            this.txtPayableAmount.Size = new System.Drawing.Size(100, 20);
            this.txtPayableAmount.TabIndex = 1;
            // 
            // txtTotalAmountWithTax
            // 
            this.txtTotalAmountWithTax.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTotalAmountWithTax.Enabled = false;
            this.txtTotalAmountWithTax.Location = new System.Drawing.Point(189, 96);
            this.txtTotalAmountWithTax.Name = "txtTotalAmountWithTax";
            this.txtTotalAmountWithTax.ReadOnly = true;
            this.txtTotalAmountWithTax.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAmountWithTax.TabIndex = 1;
            // 
            // txtTaxAmount
            // 
            this.txtTaxAmount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTaxAmount.Enabled = false;
            this.txtTaxAmount.Location = new System.Drawing.Point(188, 59);
            this.txtTaxAmount.Name = "txtTaxAmount";
            this.txtTaxAmount.ReadOnly = true;
            this.txtTaxAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTaxAmount.TabIndex = 1;
            // 
            // txtServiceAmount
            // 
            this.txtServiceAmount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtServiceAmount.Enabled = false;
            this.txtServiceAmount.Location = new System.Drawing.Point(188, 19);
            this.txtServiceAmount.Name = "txtServiceAmount";
            this.txtServiceAmount.ReadOnly = true;
            this.txtServiceAmount.Size = new System.Drawing.Size(100, 20);
            this.txtServiceAmount.TabIndex = 1;
            // 
            // grpRowInformation
            // 
            this.grpRowInformation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpRowInformation.CausesValidation = false;
            this.grpRowInformation.Controls.Add(this.btnRemoveRow);
            this.grpRowInformation.Controls.Add(this.gridPrice);
            this.grpRowInformation.Controls.Add(this.btnAddRow);
            this.grpRowInformation.Location = new System.Drawing.Point(12, 326);
            this.grpRowInformation.Name = "grpRowInformation";
            this.grpRowInformation.Size = new System.Drawing.Size(853, 180);
            this.grpRowInformation.TabIndex = 7;
            this.grpRowInformation.TabStop = false;
            this.grpRowInformation.Text = "Satır Bilgileri";
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(751, 50);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(91, 23);
            this.btnRemoveRow.TabIndex = 6;
            this.btnRemoveRow.Text = "Satır Kaldır";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // gridPrice
            // 
            this.gridPrice.AllowUserToAddRows = false;
            this.gridPrice.AllowUserToOrderColumns = true;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Gray;
            this.gridPrice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle23;
            this.gridPrice.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gridPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPrice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPrice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle24;
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
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPrice.DefaultCellStyle = dataGridViewCellStyle31;
            this.gridPrice.Location = new System.Drawing.Point(15, 21);
            this.gridPrice.MultiSelect = false;
            this.gridPrice.Name = "gridPrice";
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPrice.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.gridPrice.RowHeadersVisible = false;
            this.gridPrice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.White;
            this.gridPrice.RowsDefaultCellStyle = dataGridViewCellStyle33;
            this.gridPrice.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gridPrice.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridPrice.Size = new System.Drawing.Size(712, 132);
            this.gridPrice.TabIndex = 5;
            this.gridPrice.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridPrice_CellValidating);
            // 
            // productName
            // 
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            this.productName.DefaultCellStyle = dataGridViewCellStyle25;
            this.productName.HeaderText = "ad";
            this.productName.Name = "productName";
            // 
            // quantity
            // 
            dataGridViewCellStyle26.Format = "N0";
            dataGridViewCellStyle26.NullValue = null;
            this.quantity.DefaultCellStyle = dataGridViewCellStyle26;
            this.quantity.HeaderText = "miktar";
            this.quantity.Name = "quantity";
            // 
            // unit
            // 
            this.unit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unit.HeaderText = "birim";
            this.unit.Name = "unit";
            // 
            // unitPrice
            // 
            dataGridViewCellStyle27.Format = "C2";
            dataGridViewCellStyle27.NullValue = null;
            this.unitPrice.DefaultCellStyle = dataGridViewCellStyle27;
            this.unitPrice.HeaderText = "birim fiyat";
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.unitPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // taxPercent
            // 
            dataGridViewCellStyle28.Format = "N2";
            dataGridViewCellStyle28.NullValue = null;
            this.taxPercent.DefaultCellStyle = dataGridViewCellStyle28;
            this.taxPercent.HeaderText = "kdv oranı";
            this.taxPercent.Name = "taxPercent";
            // 
            // taxAmount
            // 
            dataGridViewCellStyle29.Format = "N2";
            dataGridViewCellStyle29.NullValue = null;
            this.taxAmount.DefaultCellStyle = dataGridViewCellStyle29;
            this.taxAmount.HeaderText = "kdv tutarı";
            this.taxAmount.Name = "taxAmount";
            this.taxAmount.ReadOnly = true;
            // 
            // total
            // 
            dataGridViewCellStyle30.Format = "N2";
            dataGridViewCellStyle30.NullValue = null;
            this.total.DefaultCellStyle = dataGridViewCellStyle30;
            this.total.HeaderText = "toplam";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(751, 21);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(91, 23);
            this.btnAddRow.TabIndex = 3;
            this.btnAddRow.Text = "Satır Ekle";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // grpInvInformation
            // 
            this.grpInvInformation.Controls.Add(this.cmbInvType);
            this.grpInvInformation.Controls.Add(this.txtPartyName);
            this.grpInvInformation.Controls.Add(this.lblInvoiceChapiter);
            this.grpInvInformation.Controls.Add(this.lblMoneyType);
            this.grpInvInformation.Controls.Add(this.lblType);
            this.grpInvInformation.Controls.Add(this.lblDate);
            this.grpInvInformation.Controls.Add(this.lblScenario);
            this.grpInvInformation.Controls.Add(this.cmbMoneyType);
            this.grpInvInformation.Controls.Add(this.cmbScenario);
            this.grpInvInformation.Controls.Add(this.dateTime);
            this.grpInvInformation.Location = new System.Drawing.Point(15, 161);
            this.grpInvInformation.Name = "grpInvInformation";
            this.grpInvInformation.Size = new System.Drawing.Size(416, 159);
            this.grpInvInformation.TabIndex = 6;
            this.grpInvInformation.TabStop = false;
            this.grpInvInformation.Text = "Fatura Bilgileri";
            // 
            // cmbInvType
            // 
            this.cmbInvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbInvType.FormattingEnabled = true;
            this.cmbInvType.Location = new System.Drawing.Point(294, 25);
            this.cmbInvType.Name = "cmbInvType";
            this.cmbInvType.Size = new System.Drawing.Size(109, 21);
            this.cmbInvType.TabIndex = 7;
            // 
            // txtPartyName
            // 
            this.txtPartyName.Location = new System.Drawing.Point(96, 102);
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(109, 20);
            this.txtPartyName.TabIndex = 6;
            this.txtPartyName.Text = "Fatura Gonderme";
            // 
            // lblInvoiceChapiter
            // 
            this.lblInvoiceChapiter.AutoSize = true;
            this.lblInvoiceChapiter.Location = new System.Drawing.Point(17, 105);
            this.lblInvoiceChapiter.Name = "lblInvoiceChapiter";
            this.lblInvoiceChapiter.Size = new System.Drawing.Size(68, 13);
            this.lblInvoiceChapiter.TabIndex = 5;
            this.lblInvoiceChapiter.Text = "Fatura Başlık";
            // 
            // lblMoneyType
            // 
            this.lblMoneyType.AutoSize = true;
            this.lblMoneyType.Location = new System.Drawing.Point(232, 67);
            this.lblMoneyType.Name = "lblMoneyType";
            this.lblMoneyType.Size = new System.Drawing.Size(56, 13);
            this.lblMoneyType.TabIndex = 3;
            this.lblMoneyType.Text = "Para Birimi";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(232, 28);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(22, 13);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Tip";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(24, 68);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(31, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Tarih";
            // 
            // lblScenario
            // 
            this.lblScenario.AutoSize = true;
            this.lblScenario.Location = new System.Drawing.Point(24, 28);
            this.lblScenario.Name = "lblScenario";
            this.lblScenario.Size = new System.Drawing.Size(46, 13);
            this.lblScenario.TabIndex = 3;
            this.lblScenario.Text = "Senaryo";
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
            this.grpReceiver.Controls.Add(this.lblSurname);
            this.grpReceiver.Controls.Add(this.txtCustSurname);
            this.grpReceiver.Controls.Add(this.lblName);
            this.grpReceiver.Controls.Add(this.txtCustName);
            this.grpReceiver.Controls.Add(this.txtMail);
            this.grpReceiver.Controls.Add(this.msdVknTc);
            this.grpReceiver.Controls.Add(this.lblMail);
            this.grpReceiver.Controls.Add(this.lblPhone);
            this.grpReceiver.Controls.Add(this.lblDistrict);
            this.grpReceiver.Controls.Add(this.lblProvince);
            this.grpReceiver.Controls.Add(this.lblTitle);
            this.grpReceiver.Controls.Add(this.lblVknTckn);
            this.grpReceiver.Controls.Add(this.msdPhone);
            this.grpReceiver.Controls.Add(this.txtDistrict);
            this.grpReceiver.Controls.Add(this.txtCity);
            this.grpReceiver.Controls.Add(this.txtTitle);
            this.grpReceiver.Location = new System.Drawing.Point(15, 14);
            this.grpReceiver.Name = "grpReceiver";
            this.grpReceiver.Size = new System.Drawing.Size(1176, 141);
            this.grpReceiver.TabIndex = 5;
            this.grpReceiver.TabStop = false;
            this.grpReceiver.Text = "Alıcı";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(24, 108);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(37, 13);
            this.lblSurname.TabIndex = 20;
            this.lblSurname.Text = "Soyad";
            // 
            // txtCustSurname
            // 
            this.txtCustSurname.Location = new System.Drawing.Point(96, 105);
            this.txtCustSurname.Name = "txtCustSurname";
            this.txtCustSurname.Size = new System.Drawing.Size(109, 20);
            this.txtCustSurname.TabIndex = 19;
            this.txtCustSurname.Text = "Demir";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(24, 71);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(23, 13);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Ad ";
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(96, 68);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(109, 20);
            this.txtCustName.TabIndex = 16;
            this.txtCustName.Text = "Ahmet";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(489, 64);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(109, 20);
            this.txtMail.TabIndex = 14;
            this.txtMail.Text = "example@gmail.com";
            // 
            // msdVknTc
            // 
            this.msdVknTc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msdVknTc.Location = new System.Drawing.Point(96, 31);
            this.msdVknTc.Mask = "00000000000";
            this.msdVknTc.Name = "msdVknTc";
            this.msdVknTc.Size = new System.Drawing.Size(109, 20);
            this.msdVknTc.TabIndex = 5;
            this.msdVknTc.Text = "11111111110";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(427, 67);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(44, 13);
            this.lblMail.TabIndex = 3;
            this.lblMail.Text = "E-Posta";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(427, 31);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(43, 13);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "Telefon";
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.Location = new System.Drawing.Point(232, 71);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(24, 13);
            this.lblDistrict.TabIndex = 3;
            this.lblDistrict.Text = "İlçe";
            // 
            // lblProvince
            // 
            this.lblProvince.AutoSize = true;
            this.lblProvince.Location = new System.Drawing.Point(232, 35);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(12, 13);
            this.lblProvince.TabIndex = 3;
            this.lblProvince.Text = "İl";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(228, 104);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(41, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Ünvanı";
            // 
            // lblVknTckn
            // 
            this.lblVknTckn.AutoSize = true;
            this.lblVknTckn.Location = new System.Drawing.Point(24, 34);
            this.lblVknTckn.Name = "lblVknTckn";
            this.lblVknTckn.Size = new System.Drawing.Size(63, 13);
            this.lblVknTckn.TabIndex = 3;
            this.lblVknTckn.Text = "VKN/TCKN";
            // 
            // msdPhone
            // 
            this.msdPhone.Location = new System.Drawing.Point(489, 28);
            this.msdPhone.Mask = "(999) 000-0000";
            this.msdPhone.Name = "msdPhone";
            this.msdPhone.Size = new System.Drawing.Size(109, 20);
            this.msdPhone.TabIndex = 1;
            this.msdPhone.Text = "1111111111";
            this.msdPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(294, 64);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(109, 20);
            this.txtDistrict.TabIndex = 0;
            this.txtDistrict.Text = "Kadıkoy";
            // 
            // txtCity
            // 
            this.txtCity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtCity.Location = new System.Drawing.Point(294, 28);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(109, 20);
            this.txtCity.TabIndex = 0;
            this.txtCity.Text = "İstanbul";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(294, 101);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(109, 20);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "Tüccar";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(529, 519);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(132, 39);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Olustur";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblArchiveSendingType
            // 
            this.lblArchiveSendingType.AutoSize = true;
            this.lblArchiveSendingType.Location = new System.Drawing.Point(1, 20);
            this.lblArchiveSendingType.Name = "lblArchiveSendingType";
            this.lblArchiveSendingType.Size = new System.Drawing.Size(104, 13);
            this.lblArchiveSendingType.TabIndex = 8;
            this.lblArchiveSendingType.Text = "Arşiv Gönderim Şekli";
            // 
            // cmbArchiveSendingType
            // 
            this.cmbArchiveSendingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArchiveSendingType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbArchiveSendingType.FormattingEnabled = true;
            this.cmbArchiveSendingType.Location = new System.Drawing.Point(109, 17);
            this.cmbArchiveSendingType.Name = "cmbArchiveSendingType";
            this.cmbArchiveSendingType.Size = new System.Drawing.Size(109, 21);
            this.cmbArchiveSendingType.TabIndex = 9;
            // 
            // cmbArchiveType
            // 
            this.cmbArchiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArchiveType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbArchiveType.FormattingEnabled = true;
            this.cmbArchiveType.Location = new System.Drawing.Point(109, 56);
            this.cmbArchiveType.Name = "cmbArchiveType";
            this.cmbArchiveType.Size = new System.Drawing.Size(109, 21);
            this.cmbArchiveType.TabIndex = 11;
            this.cmbArchiveType.SelectedValueChanged += new System.EventHandler(this.cmbArchiveType_SelectedValueChanged);
            // 
            // lblArchiveType
            // 
            this.lblArchiveType.AutoSize = true;
            this.lblArchiveType.Location = new System.Drawing.Point(10, 64);
            this.lblArchiveType.Name = "lblArchiveType";
            this.lblArchiveType.Size = new System.Drawing.Size(50, 13);
            this.lblArchiveType.TabIndex = 10;
            this.lblArchiveType.Text = "Arşiv Tipi";
            // 
            // pnlArchiveInformation
            // 
            this.pnlArchiveInformation.Controls.Add(this.pnlArchive);
            this.pnlArchiveInformation.Controls.Add(this.chkSendMail);
            this.pnlArchiveInformation.Controls.Add(this.grpSendingType);
            this.pnlArchiveInformation.Controls.Add(this.grpPaymentInformation);
            this.pnlArchiveInformation.Location = new System.Drawing.Point(437, 174);
            this.pnlArchiveInformation.Name = "pnlArchiveInformation";
            this.pnlArchiveInformation.Size = new System.Drawing.Size(761, 146);
            this.pnlArchiveInformation.TabIndex = 12;
            this.pnlArchiveInformation.Visible = false;
            // 
            // pnlArchive
            // 
            this.pnlArchive.Controls.Add(this.cmbArchiveType);
            this.pnlArchive.Controls.Add(this.cmbArchiveSendingType);
            this.pnlArchive.Controls.Add(this.lblArchiveType);
            this.pnlArchive.Controls.Add(this.lblArchiveSendingType);
            this.pnlArchive.Location = new System.Drawing.Point(3, 15);
            this.pnlArchive.Name = "pnlArchive";
            this.pnlArchive.Size = new System.Drawing.Size(221, 97);
            this.pnlArchive.TabIndex = 15;
            // 
            // chkSendMail
            // 
            this.chkSendMail.AutoSize = true;
            this.chkSendMail.Location = new System.Drawing.Point(10, 118);
            this.chkSendMail.Name = "chkSendMail";
            this.chkSendMail.Size = new System.Drawing.Size(83, 17);
            this.chkSendMail.TabIndex = 14;
            this.chkSendMail.Text = "Mail Gönder";
            this.chkSendMail.UseVisualStyleBackColor = true;
            // 
            // grpSendingType
            // 
            this.grpSendingType.Controls.Add(this.datepicDespatchDate);
            this.grpSendingType.Controls.Add(this.msdDeliveryVkn);
            this.grpSendingType.Controls.Add(this.rdTuzel);
            this.grpSendingType.Controls.Add(this.rdReal);
            this.grpSendingType.Controls.Add(this.lblSendingDate);
            this.grpSendingType.Controls.Add(this.lblCarrierTitle);
            this.grpSendingType.Controls.Add(this.lblCarrierVknTckn);
            this.grpSendingType.Controls.Add(this.lblCarrier);
            this.grpSendingType.Controls.Add(this.txtCarrierTitle);
            this.grpSendingType.Location = new System.Drawing.Point(498, 3);
            this.grpSendingType.Name = "grpSendingType";
            this.grpSendingType.Size = new System.Drawing.Size(256, 138);
            this.grpSendingType.TabIndex = 13;
            this.grpSendingType.TabStop = false;
            this.grpSendingType.Text = "Gönerim Sekli";
            this.grpSendingType.Visible = false;
            // 
            // datepicDespatchDate
            // 
            this.datepicDespatchDate.Location = new System.Drawing.Point(116, 107);
            this.datepicDespatchDate.Name = "datepicDespatchDate";
            this.datepicDespatchDate.Size = new System.Drawing.Size(109, 20);
            this.datepicDespatchDate.TabIndex = 31;
            // 
            // msdDeliveryVkn
            // 
            this.msdDeliveryVkn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msdDeliveryVkn.Location = new System.Drawing.Point(116, 43);
            this.msdDeliveryVkn.Mask = "0000000000";
            this.msdDeliveryVkn.Name = "msdDeliveryVkn";
            this.msdDeliveryVkn.Size = new System.Drawing.Size(109, 20);
            this.msdDeliveryVkn.TabIndex = 30;
            this.msdDeliveryVkn.Text = "4840847211";
            // 
            // rdTuzel
            // 
            this.rdTuzel.AutoSize = true;
            this.rdTuzel.Location = new System.Drawing.Point(192, 20);
            this.rdTuzel.Name = "rdTuzel";
            this.rdTuzel.Size = new System.Drawing.Size(51, 17);
            this.rdTuzel.TabIndex = 29;
            this.rdTuzel.TabStop = true;
            this.rdTuzel.Text = "Tüzel";
            this.rdTuzel.UseVisualStyleBackColor = true;
            // 
            // rdReal
            // 
            this.rdReal.AutoSize = true;
            this.rdReal.Location = new System.Drawing.Point(117, 20);
            this.rdReal.Name = "rdReal";
            this.rdReal.Size = new System.Drawing.Size(60, 17);
            this.rdReal.TabIndex = 28;
            this.rdReal.TabStop = true;
            this.rdReal.Text = "Gercek";
            this.rdReal.UseVisualStyleBackColor = true;
            // 
            // lblSendingDate
            // 
            this.lblSendingDate.AutoSize = true;
            this.lblSendingDate.Location = new System.Drawing.Point(12, 113);
            this.lblSendingDate.Name = "lblSendingDate";
            this.lblSendingDate.Size = new System.Drawing.Size(33, 13);
            this.lblSendingDate.TabIndex = 27;
            this.lblSendingDate.Text = "Tarihi";
            // 
            // lblCarrierTitle
            // 
            this.lblCarrierTitle.AutoSize = true;
            this.lblCarrierTitle.Location = new System.Drawing.Point(12, 79);
            this.lblCarrierTitle.Name = "lblCarrierTitle";
            this.lblCarrierTitle.Size = new System.Drawing.Size(79, 13);
            this.lblCarrierTitle.TabIndex = 23;
            this.lblCarrierTitle.Text = "Tasıyan Unvan";
            // 
            // lblCarrierVknTckn
            // 
            this.lblCarrierVknTckn.AutoSize = true;
            this.lblCarrierVknTckn.Location = new System.Drawing.Point(12, 48);
            this.lblCarrierVknTckn.Name = "lblCarrierVknTckn";
            this.lblCarrierVknTckn.Size = new System.Drawing.Size(96, 13);
            this.lblCarrierVknTckn.TabIndex = 24;
            this.lblCarrierVknTckn.Text = "Tasıyan Vkn/Tckn";
            // 
            // lblCarrier
            // 
            this.lblCarrier.AutoSize = true;
            this.lblCarrier.Location = new System.Drawing.Point(12, 21);
            this.lblCarrier.Name = "lblCarrier";
            this.lblCarrier.Size = new System.Drawing.Size(44, 13);
            this.lblCarrier.TabIndex = 25;
            this.lblCarrier.Text = "Tasıyan";
            // 
            // txtCarrierTitle
            // 
            this.txtCarrierTitle.Location = new System.Drawing.Point(116, 77);
            this.txtCarrierTitle.Name = "txtCarrierTitle";
            this.txtCarrierTitle.Size = new System.Drawing.Size(109, 20);
            this.txtCarrierTitle.TabIndex = 20;
            this.txtCarrierTitle.Text = "1";
            // 
            // grpPaymentInformation
            // 
            this.grpPaymentInformation.Controls.Add(this.cmbPaymentType);
            this.grpPaymentInformation.Controls.Add(this.datepicPaymentDate);
            this.grpPaymentInformation.Controls.Add(this.lblInternetSalesInformation);
            this.grpPaymentInformation.Controls.Add(this.textBox4);
            this.grpPaymentInformation.Controls.Add(this.lblPaymentDate);
            this.grpPaymentInformation.Controls.Add(this.lblMiddleman);
            this.grpPaymentInformation.Controls.Add(this.lblPaymentType);
            this.grpPaymentInformation.Controls.Add(this.txtMediator);
            this.grpPaymentInformation.Location = new System.Drawing.Point(230, 3);
            this.grpPaymentInformation.Name = "grpPaymentInformation";
            this.grpPaymentInformation.Size = new System.Drawing.Size(262, 138);
            this.grpPaymentInformation.TabIndex = 12;
            this.grpPaymentInformation.TabStop = false;
            this.grpPaymentInformation.Text = "Ödeme Bilgisi";
            this.grpPaymentInformation.Visible = false;
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Location = new System.Drawing.Point(126, 16);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(109, 21);
            this.cmbPaymentType.TabIndex = 21;
            // 
            // datepicPaymentDate
            // 
            this.datepicPaymentDate.Location = new System.Drawing.Point(126, 74);
            this.datepicPaymentDate.Name = "datepicPaymentDate";
            this.datepicPaymentDate.Size = new System.Drawing.Size(109, 20);
            this.datepicPaymentDate.TabIndex = 20;
            // 
            // lblInternetSalesInformation
            // 
            this.lblInternetSalesInformation.AutoSize = true;
            this.lblInternetSalesInformation.Location = new System.Drawing.Point(15, 113);
            this.lblInternetSalesInformation.Name = "lblInternetSalesInformation";
            this.lblInternetSalesInformation.Size = new System.Drawing.Size(97, 13);
            this.lblInternetSalesInformation.TabIndex = 19;
            this.lblInternetSalesInformation.Text = "internet Satıs Bilgisi";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(126, 110);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(109, 20);
            this.textBox4.TabIndex = 18;
            this.textBox4.Text = "1";
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Location = new System.Drawing.Point(15, 79);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(33, 13);
            this.lblPaymentDate.TabIndex = 15;
            this.lblPaymentDate.Text = "Tarihi";
            // 
            // lblMiddleman
            // 
            this.lblMiddleman.AutoSize = true;
            this.lblMiddleman.Location = new System.Drawing.Point(15, 48);
            this.lblMiddleman.Name = "lblMiddleman";
            this.lblMiddleman.Size = new System.Drawing.Size(31, 13);
            this.lblMiddleman.TabIndex = 16;
            this.lblMiddleman.Text = "Aracı";
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.AutoSize = true;
            this.lblPaymentType.Location = new System.Drawing.Point(15, 21);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(30, 13);
            this.lblPaymentType.TabIndex = 17;
            this.lblPaymentType.Text = "Sekli";
            // 
            // txtMediator
            // 
            this.txtMediator.Location = new System.Drawing.Point(126, 45);
            this.txtMediator.Name = "txtMediator";
            this.txtMediator.Size = new System.Drawing.Size(109, 20);
            this.txtMediator.TabIndex = 13;
            this.txtMediator.Text = "1";
            // 
            // FrmCreateInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 577);
            this.Controls.Add(this.pnlArchiveInformation);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpTotal);
            this.Controls.Add(this.grpRowInformation);
            this.Controls.Add(this.grpInvInformation);
            this.Controls.Add(this.grpReceiver);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateInvoice";
            this.Load += new System.EventHandler(this.FrmCreateInvoice_Load);
            this.grpTotal.ResumeLayout(false);
            this.grpTotal.PerformLayout();
            this.grpRowInformation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPrice)).EndInit();
            this.grpInvInformation.ResumeLayout(false);
            this.grpInvInformation.PerformLayout();
            this.grpReceiver.ResumeLayout(false);
            this.grpReceiver.PerformLayout();
            this.pnlArchiveInformation.ResumeLayout(false);
            this.pnlArchiveInformation.PerformLayout();
            this.pnlArchive.ResumeLayout(false);
            this.pnlArchive.PerformLayout();
            this.grpSendingType.ResumeLayout(false);
            this.grpSendingType.PerformLayout();
            this.grpPaymentInformation.ResumeLayout(false);
            this.grpPaymentInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpTotal;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.Label lblTotalAmountWithTax;
        private System.Windows.Forms.Label lblCalculatedTaxAmount;
        private System.Windows.Forms.Label lblServiceAmount;
        private System.Windows.Forms.TextBox txtPayableAmount;
        private System.Windows.Forms.TextBox txtTotalAmountWithTax;
        private System.Windows.Forms.TextBox txtTaxAmount;
        private System.Windows.Forms.TextBox txtServiceAmount;
        private System.Windows.Forms.GroupBox grpRowInformation;
        private System.Windows.Forms.Label lblMoneyType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblScenario;
        private System.Windows.Forms.ComboBox cmbMoneyType;
        private System.Windows.Forms.ComboBox cmbScenario;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.GroupBox grpReceiver;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDistrict;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVknTckn;
        private System.Windows.Forms.MaskedTextBox msdPhone;
        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.MaskedTextBox msdVknTc;
        private System.Windows.Forms.GroupBox grpInvInformation;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.Label lblInvoiceChapiter;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView gridPrice;
        private System.Windows.Forms.ComboBox cmbInvType;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.ComboBox cmbArchiveSendingType;
        private System.Windows.Forms.Label lblArchiveSendingType;
        private System.Windows.Forms.Panel pnlArchiveInformation;
        private System.Windows.Forms.ComboBox cmbArchiveType;
        private System.Windows.Forms.Label lblArchiveType;
        private System.Windows.Forms.GroupBox grpSendingType;
        private System.Windows.Forms.GroupBox grpPaymentInformation;
        private System.Windows.Forms.Label lblInternetSalesInformation;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblMiddleman;
        private System.Windows.Forms.Label lblPaymentType;
        private System.Windows.Forms.TextBox txtMediator;
        private System.Windows.Forms.RadioButton rdTuzel;
        private System.Windows.Forms.RadioButton rdReal;
        private System.Windows.Forms.Label lblSendingDate;
        private System.Windows.Forms.Label lblCarrierTitle;
        private System.Windows.Forms.Label lblCarrierVknTckn;
        private System.Windows.Forms.Label lblCarrier;
        private System.Windows.Forms.TextBox txtCarrierTitle;
        private System.Windows.Forms.DateTimePicker datepicPaymentDate;
        private System.Windows.Forms.DateTimePicker datepicDespatchDate;
        private System.Windows.Forms.MaskedTextBox msdDeliveryVkn;
        private System.Windows.Forms.CheckBox chkSendMail;
        private System.Windows.Forms.Panel pnlArchive;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox txtCustSurname;
    }
}