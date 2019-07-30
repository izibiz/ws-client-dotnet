namespace izibiz.UI
{
    partial class FrmInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvoice));
            this.menuInvoice = new System.Windows.Forms.MenuStrip();
            this.itemIncomingInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSentInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDraftInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNewInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemListGibUserList = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTakeGibUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelIncomingInv = new System.Windows.Forms.Panel();
            this.btnGetRejectedIncomingInv = new System.Windows.Forms.Button();
            this.btnWaitResponseGetInv = new System.Windows.Forms.Button();
            this.btnIncomingInvGetState = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.panelSentInv = new System.Windows.Forms.Panel();
            this.btnGetRejectedSendInv = new System.Windows.Forms.Button();
            this.btnGetSendSignedInvoice = new System.Windows.Forms.Button();
            this.btnFaultyInvoices = new System.Windows.Forms.Button();
            this.btnSentInvAgainSent = new System.Windows.Forms.Button();
            this.btnSentInvGetState = new System.Windows.Forms.Button();
            this.btnTakeInv = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.panelDraftInv = new System.Windows.Forms.Panel();
            this.rdUnzip = new System.Windows.Forms.RadioButton();
            this.rdZip = new System.Windows.Forms.RadioButton();
            this.btnLoadPortal = new System.Windows.Forms.Button();
            this.btnSendDraftInv = new System.Windows.Forms.Button();
            this.timeStartFilter = new System.Windows.Forms.DateTimePicker();
            this.timeFinishFilter = new System.Windows.Forms.DateTimePicker();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnFilterList = new System.Windows.Forms.Button();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.lblInformation = new System.Windows.Forms.Label();
            this.menuInvoice.SuspendLayout();
            this.panelIncomingInv.SuspendLayout();
            this.panelSentInv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.panelDraftInv.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuInvoice
            // 
            this.menuInvoice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuInvoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuInvoice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuInvoice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuInvoice.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemIncomingInvoice,
            this.itemSentInvoice,
            this.itemDraftInvoice,
            this.itemNewInvoice,
            this.itemListGibUserList,
            this.itemTakeGibUsers});
            this.menuInvoice.Location = new System.Drawing.Point(0, 0);
            this.menuInvoice.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.menuInvoice.Name = "menuInvoice";
            this.menuInvoice.Size = new System.Drawing.Size(138, 566);
            this.menuInvoice.TabIndex = 0;
            this.menuInvoice.Text = "menuStrip1";
            // 
            // itemIncomingInvoice
            // 
            this.itemIncomingInvoice.BackColor = System.Drawing.Color.Teal;
            this.itemIncomingInvoice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemIncomingInvoice.Margin = new System.Windows.Forms.Padding(0, 110, 0, 0);
            this.itemIncomingInvoice.Name = "itemIncomingInvoice";
            this.itemIncomingInvoice.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemIncomingInvoice.Size = new System.Drawing.Size(131, 29);
            this.itemIncomingInvoice.Text = "Gelen Faturalar";
            this.itemIncomingInvoice.Click += new System.EventHandler(this.itemIncomingInvoice_Click);
            // 
            // itemSentInvoice
            // 
            this.itemSentInvoice.BackColor = System.Drawing.Color.Teal;
            this.itemSentInvoice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemSentInvoice.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemSentInvoice.Name = "itemSentInvoice";
            this.itemSentInvoice.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemSentInvoice.Size = new System.Drawing.Size(131, 29);
            this.itemSentInvoice.Text = " Giden Faturalar";
            this.itemSentInvoice.Click += new System.EventHandler(this.itemSentInvoice_Click);
            // 
            // itemDraftInvoice
            // 
            this.itemDraftInvoice.BackColor = System.Drawing.Color.Teal;
            this.itemDraftInvoice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemDraftInvoice.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemDraftInvoice.Name = "itemDraftInvoice";
            this.itemDraftInvoice.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemDraftInvoice.Size = new System.Drawing.Size(131, 29);
            this.itemDraftInvoice.Text = "Taslak Faturalar";
            this.itemDraftInvoice.Click += new System.EventHandler(this.itemDraftInvoice_Click_1);
            // 
            // itemNewInvoice
            // 
            this.itemNewInvoice.BackColor = System.Drawing.Color.Teal;
            this.itemNewInvoice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemNewInvoice.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemNewInvoice.Name = "itemNewInvoice";
            this.itemNewInvoice.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemNewInvoice.Size = new System.Drawing.Size(131, 29);
            this.itemNewInvoice.Text = "Yeni Fatura";
            this.itemNewInvoice.Click += new System.EventHandler(this.itemNewInvoice_Click);
            // 
            // itemListGibUserList
            // 
            this.itemListGibUserList.BackColor = System.Drawing.Color.Teal;
            this.itemListGibUserList.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemListGibUserList.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemListGibUserList.Name = "itemListGibUserList";
            this.itemListGibUserList.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemListGibUserList.Size = new System.Drawing.Size(131, 29);
            this.itemListGibUserList.Text = "Gib User Listele";
            this.itemListGibUserList.Click += new System.EventHandler(this.itemListGibUserList_Click);
            // 
            // itemTakeGibUsers
            // 
            this.itemTakeGibUsers.BackColor = System.Drawing.Color.Teal;
            this.itemTakeGibUsers.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemTakeGibUsers.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemTakeGibUsers.Name = "itemTakeGibUsers";
            this.itemTakeGibUsers.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemTakeGibUsers.Size = new System.Drawing.Size(131, 29);
            this.itemTakeGibUsers.Text = "Gib User List Al";
            this.itemTakeGibUsers.Click += new System.EventHandler(this.itemTakeGibUsers_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.Location = new System.Drawing.Point(543, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 25);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "hosgeldınız";
            // 
            // panelIncomingInv
            // 
            this.panelIncomingInv.BackColor = System.Drawing.Color.Transparent;
            this.panelIncomingInv.Controls.Add(this.btnGetRejectedIncomingInv);
            this.panelIncomingInv.Controls.Add(this.btnWaitResponseGetInv);
            this.panelIncomingInv.Controls.Add(this.btnIncomingInvGetState);
            this.panelIncomingInv.Controls.Add(this.btnAccept);
            this.panelIncomingInv.Controls.Add(this.btnReject);
            this.panelIncomingInv.Location = new System.Drawing.Point(316, 36);
            this.panelIncomingInv.Name = "panelIncomingInv";
            this.panelIncomingInv.Size = new System.Drawing.Size(656, 79);
            this.panelIncomingInv.TabIndex = 14;
            this.panelIncomingInv.Visible = false;
            // 
            // btnGetRejectedIncomingInv
            // 
            this.btnGetRejectedIncomingInv.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGetRejectedIncomingInv.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGetRejectedIncomingInv.FlatAppearance.BorderSize = 2;
            this.btnGetRejectedIncomingInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetRejectedIncomingInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetRejectedIncomingInv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetRejectedIncomingInv.Location = new System.Drawing.Point(527, 4);
            this.btnGetRejectedIncomingInv.Name = "btnGetRejectedIncomingInv";
            this.btnGetRejectedIncomingInv.Size = new System.Drawing.Size(120, 50);
            this.btnGetRejectedIncomingInv.TabIndex = 28;
            this.btnGetRejectedIncomingInv.Text = "Reddedilenler";
            this.btnGetRejectedIncomingInv.UseVisualStyleBackColor = false;
            this.btnGetRejectedIncomingInv.Click += new System.EventHandler(this.btnGetRejectedIncomingInv_Click);
            // 
            // btnWaitResponseGetInv
            // 
            this.btnWaitResponseGetInv.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnWaitResponseGetInv.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnWaitResponseGetInv.FlatAppearance.BorderSize = 2;
            this.btnWaitResponseGetInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaitResponseGetInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnWaitResponseGetInv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnWaitResponseGetInv.Location = new System.Drawing.Point(399, 4);
            this.btnWaitResponseGetInv.Name = "btnWaitResponseGetInv";
            this.btnWaitResponseGetInv.Size = new System.Drawing.Size(120, 49);
            this.btnWaitResponseGetInv.TabIndex = 27;
            this.btnWaitResponseGetInv.Text = "Yanıt Bekleyenler";
            this.btnWaitResponseGetInv.UseVisualStyleBackColor = false;
            this.btnWaitResponseGetInv.Click += new System.EventHandler(this.btnWaitResponseGetInv_Click);
            // 
            // btnIncomingInvGetState
            // 
            this.btnIncomingInvGetState.BackColor = System.Drawing.Color.CadetBlue;
            this.btnIncomingInvGetState.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnIncomingInvGetState.FlatAppearance.BorderSize = 2;
            this.btnIncomingInvGetState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncomingInvGetState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIncomingInvGetState.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIncomingInvGetState.Location = new System.Drawing.Point(8, 18);
            this.btnIncomingInvGetState.Name = "btnIncomingInvGetState";
            this.btnIncomingInvGetState.Size = new System.Drawing.Size(125, 35);
            this.btnIncomingInvGetState.TabIndex = 22;
            this.btnIncomingInvGetState.Text = "durum sorgula";
            this.btnIncomingInvGetState.UseVisualStyleBackColor = false;
            this.btnIncomingInvGetState.Click += new System.EventHandler(this.btnIncomingInvGetState_Click_1);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAccept.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnAccept.FlatAppearance.BorderSize = 2;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAccept.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAccept.Location = new System.Drawing.Point(141, 18);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(120, 35);
            this.btnAccept.TabIndex = 19;
            this.btnAccept.Text = "kabul et";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.IndianRed;
            this.btnReject.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnReject.FlatAppearance.BorderSize = 2;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReject.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReject.Location = new System.Drawing.Point(270, 18);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(120, 35);
            this.btnReject.TabIndex = 20;
            this.btnReject.Text = "Reddet";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // panelSentInv
            // 
            this.panelSentInv.BackColor = System.Drawing.Color.Transparent;
            this.panelSentInv.Controls.Add(this.btnGetRejectedSendInv);
            this.panelSentInv.Controls.Add(this.btnGetSendSignedInvoice);
            this.panelSentInv.Controls.Add(this.btnFaultyInvoices);
            this.panelSentInv.Controls.Add(this.btnSentInvAgainSent);
            this.panelSentInv.Controls.Add(this.btnSentInvGetState);
            this.panelSentInv.Location = new System.Drawing.Point(316, 36);
            this.panelSentInv.Name = "panelSentInv";
            this.panelSentInv.Size = new System.Drawing.Size(656, 79);
            this.panelSentInv.TabIndex = 18;
            this.panelSentInv.Visible = false;
            // 
            // btnGetRejectedSendInv
            // 
            this.btnGetRejectedSendInv.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGetRejectedSendInv.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGetRejectedSendInv.FlatAppearance.BorderSize = 2;
            this.btnGetRejectedSendInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetRejectedSendInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetRejectedSendInv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetRejectedSendInv.Location = new System.Drawing.Point(407, 14);
            this.btnGetRejectedSendInv.Name = "btnGetRejectedSendInv";
            this.btnGetRejectedSendInv.Size = new System.Drawing.Size(120, 46);
            this.btnGetRejectedSendInv.TabIndex = 26;
            this.btnGetRejectedSendInv.Text = "Reddedilenler";
            this.btnGetRejectedSendInv.UseVisualStyleBackColor = false;
            this.btnGetRejectedSendInv.Click += new System.EventHandler(this.btnGetRejectedSendInv_Click);
            // 
            // btnGetSendSignedInvoice
            // 
            this.btnGetSendSignedInvoice.BackColor = System.Drawing.Color.CadetBlue;
            this.btnGetSendSignedInvoice.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnGetSendSignedInvoice.FlatAppearance.BorderSize = 2;
            this.btnGetSendSignedInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetSendSignedInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGetSendSignedInvoice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetSendSignedInvoice.Location = new System.Drawing.Point(270, 25);
            this.btnGetSendSignedInvoice.Name = "btnGetSendSignedInvoice";
            this.btnGetSendSignedInvoice.Size = new System.Drawing.Size(131, 35);
            this.btnGetSendSignedInvoice.TabIndex = 25;
            this.btnGetSendSignedInvoice.Text = "Imzalı Xml Al";
            this.btnGetSendSignedInvoice.UseVisualStyleBackColor = false;
            this.btnGetSendSignedInvoice.Click += new System.EventHandler(this.btnGetSendSignedInvoice_Click);
            // 
            // btnFaultyInvoices
            // 
            this.btnFaultyInvoices.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnFaultyInvoices.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnFaultyInvoices.FlatAppearance.BorderSize = 2;
            this.btnFaultyInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFaultyInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFaultyInvoices.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFaultyInvoices.Location = new System.Drawing.Point(541, 14);
            this.btnFaultyInvoices.Name = "btnFaultyInvoices";
            this.btnFaultyInvoices.Size = new System.Drawing.Size(106, 46);
            this.btnFaultyInvoices.TabIndex = 24;
            this.btnFaultyInvoices.Text = "Hatalılar";
            this.btnFaultyInvoices.UseVisualStyleBackColor = false;
            this.btnFaultyInvoices.Click += new System.EventHandler(this.btnFaultyInvoices_Click);
            // 
            // btnSentInvAgainSent
            // 
            this.btnSentInvAgainSent.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSentInvAgainSent.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSentInvAgainSent.FlatAppearance.BorderSize = 2;
            this.btnSentInvAgainSent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSentInvAgainSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSentInvAgainSent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSentInvAgainSent.Location = new System.Drawing.Point(7, 25);
            this.btnSentInvAgainSent.Name = "btnSentInvAgainSent";
            this.btnSentInvAgainSent.Size = new System.Drawing.Size(120, 35);
            this.btnSentInvAgainSent.TabIndex = 23;
            this.btnSentInvAgainSent.Text = "Yeniden gönder";
            this.btnSentInvAgainSent.UseVisualStyleBackColor = false;
            this.btnSentInvAgainSent.Click += new System.EventHandler(this.btnSentInvAgainSent_Click);
            // 
            // btnSentInvGetState
            // 
            this.btnSentInvGetState.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSentInvGetState.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSentInvGetState.FlatAppearance.BorderSize = 2;
            this.btnSentInvGetState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSentInvGetState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSentInvGetState.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSentInvGetState.Location = new System.Drawing.Point(140, 25);
            this.btnSentInvGetState.Name = "btnSentInvGetState";
            this.btnSentInvGetState.Size = new System.Drawing.Size(117, 35);
            this.btnSentInvGetState.TabIndex = 22;
            this.btnSentInvGetState.Text = "Durum sorgula";
            this.btnSentInvGetState.UseVisualStyleBackColor = false;
            this.btnSentInvGetState.Click += new System.EventHandler(this.btnSentInvGetState_Click);
            // 
            // btnTakeInv
            // 
            this.btnTakeInv.BackColor = System.Drawing.Color.CadetBlue;
            this.btnTakeInv.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnTakeInv.FlatAppearance.BorderSize = 2;
            this.btnTakeInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTakeInv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTakeInv.Location = new System.Drawing.Point(190, 61);
            this.btnTakeInv.Name = "btnTakeInv";
            this.btnTakeInv.Size = new System.Drawing.Size(120, 35);
            this.btnTakeInv.TabIndex = 25;
            this.btnTakeInv.Text = "fatura al";
            this.btnTakeInv.UseVisualStyleBackColor = false;
            this.btnTakeInv.Visible = false;
            this.btnTakeInv.Click += new System.EventHandler(this.btnTakeInv_Click);
            // 
            // tableGrid
            // 
            this.tableGrid.BackgroundColor = System.Drawing.Color.MintCream;
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.Location = new System.Drawing.Point(213, 165);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.RowHeadersWidth = 51;
            this.tableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGrid.Size = new System.Drawing.Size(882, 389);
            this.tableGrid.TabIndex = 18;
            this.tableGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableGrid_CellClick);
            // 
            // panelDraftInv
            // 
            this.panelDraftInv.BackColor = System.Drawing.Color.Transparent;
            this.panelDraftInv.Controls.Add(this.rdUnzip);
            this.panelDraftInv.Controls.Add(this.rdZip);
            this.panelDraftInv.Controls.Add(this.btnLoadPortal);
            this.panelDraftInv.Controls.Add(this.btnSendDraftInv);
            this.panelDraftInv.Location = new System.Drawing.Point(316, 36);
            this.panelDraftInv.Name = "panelDraftInv";
            this.panelDraftInv.Size = new System.Drawing.Size(656, 79);
            this.panelDraftInv.TabIndex = 19;
            this.panelDraftInv.Visible = false;
            // 
            // rdUnzip
            // 
            this.rdUnzip.AutoSize = true;
            this.rdUnzip.Location = new System.Drawing.Point(404, 29);
            this.rdUnzip.Name = "rdUnzip";
            this.rdUnzip.Size = new System.Drawing.Size(50, 17);
            this.rdUnzip.TabIndex = 27;
            this.rdUnzip.TabStop = true;
            this.rdUnzip.Text = "zipsiz";
            this.rdUnzip.UseVisualStyleBackColor = true;
            // 
            // rdZip
            // 
            this.rdZip.AutoSize = true;
            this.rdZip.Location = new System.Drawing.Point(313, 29);
            this.rdZip.Name = "rdZip";
            this.rdZip.Size = new System.Drawing.Size(42, 17);
            this.rdZip.TabIndex = 26;
            this.rdZip.TabStop = true;
            this.rdZip.Text = "zipli";
            this.rdZip.UseVisualStyleBackColor = true;
            // 
            // btnLoadPortal
            // 
            this.btnLoadPortal.BackColor = System.Drawing.Color.CadetBlue;
            this.btnLoadPortal.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnLoadPortal.FlatAppearance.BorderSize = 2;
            this.btnLoadPortal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadPortal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoadPortal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoadPortal.Location = new System.Drawing.Point(161, 20);
            this.btnLoadPortal.Name = "btnLoadPortal";
            this.btnLoadPortal.Size = new System.Drawing.Size(120, 35);
            this.btnLoadPortal.TabIndex = 25;
            this.btnLoadPortal.Text = "portala yukle";
            this.btnLoadPortal.UseVisualStyleBackColor = false;
            this.btnLoadPortal.Click += new System.EventHandler(this.btnLoadPortal_Click);
            // 
            // btnSendDraftInv
            // 
            this.btnSendDraftInv.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendDraftInv.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendDraftInv.FlatAppearance.BorderSize = 2;
            this.btnSendDraftInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendDraftInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendDraftInv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendDraftInv.Location = new System.Drawing.Point(20, 20);
            this.btnSendDraftInv.Name = "btnSendDraftInv";
            this.btnSendDraftInv.Size = new System.Drawing.Size(120, 35);
            this.btnSendDraftInv.TabIndex = 24;
            this.btnSendDraftInv.Text = "Gönder";
            this.btnSendDraftInv.UseVisualStyleBackColor = false;
            this.btnSendDraftInv.Click += new System.EventHandler(this.btnSendDraftInv_Click);
            // 
            // timeStartFilter
            // 
            this.timeStartFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeStartFilter.Location = new System.Drawing.Point(25, 11);
            this.timeStartFilter.Name = "timeStartFilter";
            this.timeStartFilter.Size = new System.Drawing.Size(107, 20);
            this.timeStartFilter.TabIndex = 26;
            // 
            // timeFinishFilter
            // 
            this.timeFinishFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeFinishFilter.Location = new System.Drawing.Point(25, 45);
            this.timeFinishFilter.Name = "timeFinishFilter";
            this.timeFinishFilter.Size = new System.Drawing.Size(107, 20);
            this.timeFinishFilter.TabIndex = 27;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnFilterList);
            this.grpFilter.Controls.Add(this.timeStartFilter);
            this.grpFilter.Controls.Add(this.timeFinishFilter);
            this.grpFilter.Location = new System.Drawing.Point(980, 29);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(147, 114);
            this.grpFilter.TabIndex = 29;
            this.grpFilter.TabStop = false;
            this.grpFilter.Visible = false;
            // 
            // btnFilterList
            // 
            this.btnFilterList.BackColor = System.Drawing.Color.Lavender;
            this.btnFilterList.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnFilterList.FlatAppearance.BorderSize = 2;
            this.btnFilterList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterList.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFilterList.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFilterList.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterList.Image")));
            this.btnFilterList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilterList.Location = new System.Drawing.Point(25, 81);
            this.btnFilterList.Name = "btnFilterList";
            this.btnFilterList.Size = new System.Drawing.Size(107, 27);
            this.btnFilterList.TabIndex = 28;
            this.btnFilterList.Text = "Filtrele";
            this.btnFilterList.UseVisualStyleBackColor = false;
            this.btnFilterList.Click += new System.EventHandler(this.btnFilterList_Click);
            // 
            // btnHomePage
            // 
            this.btnHomePage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnHomePage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHomePage.BackgroundImage")));
            this.btnHomePage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHomePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHomePage.FlatAppearance.BorderSize = 0;
            this.btnHomePage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnHomePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHomePage.ForeColor = System.Drawing.Color.Snow;
            this.btnHomePage.Location = new System.Drawing.Point(12, 29);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(115, 70);
            this.btnHomePage.TabIndex = 31;
            this.btnHomePage.Text = "Ana Sayfa";
            this.btnHomePage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHomePage.UseVisualStyleBackColor = false;
            this.btnHomePage.Click += new System.EventHandler(this.btnHomePage_Click);
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(316, 129);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(239, 13);
            this.lblInformation.TabIndex = 32;
            this.lblInformation.Text = "islem yapabılmek ıcın tablodan bir veriye  tıklayınız";
            this.lblInformation.Visible = false;
            // 
            // FrmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1028, 566);
            this.ControlBox = false;
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.btnTakeInv);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.menuInvoice);
            this.Controls.Add(this.panelSentInv);
            this.Controls.Add(this.panelIncomingInv);
            this.Controls.Add(this.panelDraftInv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuInvoice;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInvoice";
            this.Text = "FrmInvoice";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmInvoice_FormClosed);
            this.Load += new System.EventHandler(this.FrmInvoice_Load);
            this.menuInvoice.ResumeLayout(false);
            this.menuInvoice.PerformLayout();
            this.panelIncomingInv.ResumeLayout(false);
            this.panelSentInv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.panelDraftInv.ResumeLayout(false);
            this.panelDraftInv.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemIncomingInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemSentInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemDraftInvoice;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelIncomingInv;
        private System.Windows.Forms.Panel panelSentInv;
        private System.Windows.Forms.DataGridView tableGrid;
        private System.Windows.Forms.Button btnIncomingInvGetState;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnFaultyInvoices;
        private System.Windows.Forms.Button btnSentInvAgainSent;
        private System.Windows.Forms.Button btnSentInvGetState;
        private System.Windows.Forms.Panel panelDraftInv;
        private System.Windows.Forms.Button btnSendDraftInv;
        private System.Windows.Forms.Button btnLoadPortal;
        private System.Windows.Forms.Button btnTakeInv;
        private System.Windows.Forms.DateTimePicker timeStartFilter;
        private System.Windows.Forms.DateTimePicker timeFinishFilter;
        private System.Windows.Forms.Button btnFilterList;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.RadioButton rdUnzip;
        private System.Windows.Forms.RadioButton rdZip;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.Button btnGetSendSignedInvoice;
        private System.Windows.Forms.Button btnGetRejectedIncomingInv;
        private System.Windows.Forms.Button btnWaitResponseGetInv;
        private System.Windows.Forms.Button btnGetRejectedSendInv;
        private System.Windows.Forms.ToolStripMenuItem itemListGibUserList;
        private System.Windows.Forms.ToolStripMenuItem itemNewInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemTakeGibUsers;
        private System.Windows.Forms.Label lblInformation;
    }
}