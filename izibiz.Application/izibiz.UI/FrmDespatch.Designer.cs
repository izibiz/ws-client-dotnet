namespace izibiz.UI
{
    partial class FrmDespatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDespatch));
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnFilterList = new System.Windows.Forms.Button();
            this.timeStartFilter = new System.Windows.Forms.DateTimePicker();
            this.timeFinishFilter = new System.Windows.Forms.DateTimePicker();
            this.btnTakeDespatch = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.menuInvoice = new System.Windows.Forms.MenuStrip();
            this.itemInDespatch = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOutDespatch = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDraftDespatch = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNewDespatch = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGetListGibUserList = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTakeGibUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlIncomingDespatch = new System.Windows.Forms.Panel();
            this.btnInDespatchGetXml = new System.Windows.Forms.Button();
            this.btnInDespatchGetStatus = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlSendDespatch = new System.Windows.Forms.Panel();
            this.btnOutDespatchGetXml = new System.Windows.Forms.Button();
            this.btnOutDespatchGetStatus = new System.Windows.Forms.Button();
            this.pnlDraftDespatch = new System.Windows.Forms.Panel();
            this.btnDraftDespatchGetStatus = new System.Windows.Forms.Button();
            this.btnLoadDespatch = new System.Windows.Forms.Button();
            this.btnSendDespatch = new System.Windows.Forms.Button();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.lblRowClickInfo = new System.Windows.Forms.Label();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.menuInvoice.SuspendLayout();
            this.pnlIncomingDespatch.SuspendLayout();
            this.pnlSendDespatch.SuspendLayout();
            this.pnlDraftDespatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnFilterList);
            this.grpFilter.Controls.Add(this.timeStartFilter);
            this.grpFilter.Controls.Add(this.timeFinishFilter);
            this.grpFilter.Location = new System.Drawing.Point(1033, 29);
            this.grpFilter.Margin = new System.Windows.Forms.Padding(4);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(4);
            this.grpFilter.Size = new System.Drawing.Size(147, 147);
            this.grpFilter.TabIndex = 39;
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
            this.btnFilterList.Location = new System.Drawing.Point(33, 100);
            this.btnFilterList.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilterList.Name = "btnFilterList";
            this.btnFilterList.Size = new System.Drawing.Size(107, 27);
            this.btnFilterList.TabIndex = 28;
            this.btnFilterList.Text = "Filtrele";
            this.btnFilterList.UseVisualStyleBackColor = false;
            this.btnFilterList.Click += new System.EventHandler(this.btnFilterList_Click);
            // 
            // timeStartFilter
            // 
            this.timeStartFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeStartFilter.Location = new System.Drawing.Point(33, 14);
            this.timeStartFilter.Margin = new System.Windows.Forms.Padding(4);
            this.timeStartFilter.Name = "timeStartFilter";
            this.timeStartFilter.Size = new System.Drawing.Size(107, 20);
            this.timeStartFilter.TabIndex = 26;
            // 
            // timeFinishFilter
            // 
            this.timeFinishFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timeFinishFilter.Location = new System.Drawing.Point(33, 55);
            this.timeFinishFilter.Margin = new System.Windows.Forms.Padding(4);
            this.timeFinishFilter.Name = "timeFinishFilter";
            this.timeFinishFilter.Size = new System.Drawing.Size(107, 20);
            this.timeFinishFilter.TabIndex = 27;
            // 
            // btnTakeDespatch
            // 
            this.btnTakeDespatch.BackColor = System.Drawing.Color.CadetBlue;
            this.btnTakeDespatch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnTakeDespatch.FlatAppearance.BorderSize = 2;
            this.btnTakeDespatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeDespatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTakeDespatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTakeDespatch.Location = new System.Drawing.Point(206, 76);
            this.btnTakeDespatch.Margin = new System.Windows.Forms.Padding(4);
            this.btnTakeDespatch.Name = "btnTakeDespatch";
            this.btnTakeDespatch.Size = new System.Drawing.Size(120, 35);
            this.btnTakeDespatch.TabIndex = 38;
            this.btnTakeDespatch.Text = "İrsaliye al";
            this.btnTakeDespatch.UseVisualStyleBackColor = false;
            this.btnTakeDespatch.Visible = false;
            this.btnTakeDespatch.Click += new System.EventHandler(this.btnTakeDespatch_Click);
            // 
            // tableGrid
            // 
            this.tableGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.GridColor = System.Drawing.SystemColors.Control;
            this.tableGrid.Location = new System.Drawing.Point(208, 233);
            this.tableGrid.Margin = new System.Windows.Forms.Padding(4);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.RowHeadersWidth = 51;
            this.tableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGrid.Size = new System.Drawing.Size(1009, 502);
            this.tableGrid.TabIndex = 35;
            this.tableGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableGrid_CellClick);
            // 
            // menuInvoice
            // 
            this.menuInvoice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuInvoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuInvoice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuInvoice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuInvoice.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemInDespatch,
            this.itemOutDespatch,
            this.itemDraftDespatch,
            this.itemNewDespatch,
            this.itemGetListGibUserList,
            this.itemTakeGibUsers});
            this.menuInvoice.Location = new System.Drawing.Point(0, 0);
            this.menuInvoice.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.menuInvoice.Name = "menuInvoice";
            this.menuInvoice.Size = new System.Drawing.Size(135, 748);
            this.menuInvoice.TabIndex = 32;
            this.menuInvoice.Text = "menuStrip1";
            // 
            // itemInDespatch
            // 
            this.itemInDespatch.BackColor = System.Drawing.Color.Teal;
            this.itemInDespatch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemInDespatch.Margin = new System.Windows.Forms.Padding(0, 140, 0, 0);
            this.itemInDespatch.Name = "itemInDespatch";
            this.itemInDespatch.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemInDespatch.Size = new System.Drawing.Size(128, 29);
            this.itemInDespatch.Text = "Gelen İrsaliye";
            this.itemInDespatch.Click += new System.EventHandler(this.itemInDespatch_Click);
            // 
            // itemOutDespatch
            // 
            this.itemOutDespatch.BackColor = System.Drawing.Color.Teal;
            this.itemOutDespatch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemOutDespatch.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemOutDespatch.Name = "itemOutDespatch";
            this.itemOutDespatch.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemOutDespatch.Size = new System.Drawing.Size(128, 29);
            this.itemOutDespatch.Text = " Giden İrsaliye";
            this.itemOutDespatch.Click += new System.EventHandler(this.itemOutDespatch_Click);
            // 
            // itemDraftDespatch
            // 
            this.itemDraftDespatch.BackColor = System.Drawing.Color.Teal;
            this.itemDraftDespatch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemDraftDespatch.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemDraftDespatch.Name = "itemDraftDespatch";
            this.itemDraftDespatch.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemDraftDespatch.Size = new System.Drawing.Size(128, 29);
            this.itemDraftDespatch.Text = "Taslak İrsaliye";
            this.itemDraftDespatch.Click += new System.EventHandler(this.itemDraftDespatch_Click);
            // 
            // itemNewDespatch
            // 
            this.itemNewDespatch.BackColor = System.Drawing.Color.Teal;
            this.itemNewDespatch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemNewDespatch.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemNewDespatch.Name = "itemNewDespatch";
            this.itemNewDespatch.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemNewDespatch.Size = new System.Drawing.Size(128, 29);
            this.itemNewDespatch.Text = "Yeni İrsaliye";
            this.itemNewDespatch.Click += new System.EventHandler(this.itemNewDespatch_Click);
            // 
            // itemGetListGibUserList
            // 
            this.itemGetListGibUserList.BackColor = System.Drawing.Color.Teal;
            this.itemGetListGibUserList.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemGetListGibUserList.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemGetListGibUserList.Name = "itemGetListGibUserList";
            this.itemGetListGibUserList.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemGetListGibUserList.Size = new System.Drawing.Size(128, 29);
            this.itemGetListGibUserList.Text = "Gib User Listele";
            this.itemGetListGibUserList.Click += new System.EventHandler(this.itemGetListGibUserList_Click);
            // 
            // itemTakeGibUsers
            // 
            this.itemTakeGibUsers.BackColor = System.Drawing.Color.Teal;
            this.itemTakeGibUsers.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemTakeGibUsers.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemTakeGibUsers.Name = "itemTakeGibUsers";
            this.itemTakeGibUsers.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemTakeGibUsers.Size = new System.Drawing.Size(128, 29);
            this.itemTakeGibUsers.Text = "Gib User List Al";
            this.itemTakeGibUsers.Click += new System.EventHandler(this.itemTakeGibUsers_Click);
            // 
            // pnlIncomingDespatch
            // 
            this.pnlIncomingDespatch.Controls.Add(this.btnInDespatchGetXml);
            this.pnlIncomingDespatch.Controls.Add(this.btnInDespatchGetStatus);
            this.pnlIncomingDespatch.Location = new System.Drawing.Point(332, 76);
            this.pnlIncomingDespatch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlIncomingDespatch.Name = "pnlIncomingDespatch";
            this.pnlIncomingDespatch.Size = new System.Drawing.Size(661, 100);
            this.pnlIncomingDespatch.TabIndex = 41;
            this.pnlIncomingDespatch.Visible = false;
            // 
            // btnInDespatchGetXml
            // 
            this.btnInDespatchGetXml.BackColor = System.Drawing.Color.CadetBlue;
            this.btnInDespatchGetXml.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnInDespatchGetXml.FlatAppearance.BorderSize = 2;
            this.btnInDespatchGetXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInDespatchGetXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnInDespatchGetXml.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInDespatchGetXml.Location = new System.Drawing.Point(207, 25);
            this.btnInDespatchGetXml.Margin = new System.Windows.Forms.Padding(4);
            this.btnInDespatchGetXml.Name = "btnInDespatchGetXml";
            this.btnInDespatchGetXml.Size = new System.Drawing.Size(117, 35);
            this.btnInDespatchGetXml.TabIndex = 30;
            this.btnInDespatchGetXml.Text = "Xml İndir";
            this.btnInDespatchGetXml.UseVisualStyleBackColor = false;
            this.btnInDespatchGetXml.Click += new System.EventHandler(this.btnInDespatchGetXml_Click);
            // 
            // btnInDespatchGetStatus
            // 
            this.btnInDespatchGetStatus.BackColor = System.Drawing.Color.CadetBlue;
            this.btnInDespatchGetStatus.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnInDespatchGetStatus.FlatAppearance.BorderSize = 2;
            this.btnInDespatchGetStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInDespatchGetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnInDespatchGetStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInDespatchGetStatus.Location = new System.Drawing.Point(24, 25);
            this.btnInDespatchGetStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnInDespatchGetStatus.Name = "btnInDespatchGetStatus";
            this.btnInDespatchGetStatus.Size = new System.Drawing.Size(117, 35);
            this.btnInDespatchGetStatus.TabIndex = 23;
            this.btnInDespatchGetStatus.Text = "Durum sorgula";
            this.btnInDespatchGetStatus.UseVisualStyleBackColor = false;
            this.btnInDespatchGetStatus.Click += new System.EventHandler(this.btnInDespatchGetStatus_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblText.Location = new System.Drawing.Point(569, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(113, 25);
            this.lblText.TabIndex = 42;
            this.lblText.Text = "Hosgeldınız";
            // 
            // pnlSendDespatch
            // 
            this.pnlSendDespatch.Controls.Add(this.btnOutDespatchGetXml);
            this.pnlSendDespatch.Controls.Add(this.btnOutDespatchGetStatus);
            this.pnlSendDespatch.Location = new System.Drawing.Point(332, 76);
            this.pnlSendDespatch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSendDespatch.Name = "pnlSendDespatch";
            this.pnlSendDespatch.Size = new System.Drawing.Size(661, 74);
            this.pnlSendDespatch.TabIndex = 42;
            this.pnlSendDespatch.Visible = false;
            // 
            // btnOutDespatchGetXml
            // 
            this.btnOutDespatchGetXml.BackColor = System.Drawing.Color.CadetBlue;
            this.btnOutDespatchGetXml.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnOutDespatchGetXml.FlatAppearance.BorderSize = 2;
            this.btnOutDespatchGetXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutDespatchGetXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOutDespatchGetXml.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOutDespatchGetXml.Location = new System.Drawing.Point(207, 21);
            this.btnOutDespatchGetXml.Margin = new System.Windows.Forms.Padding(4);
            this.btnOutDespatchGetXml.Name = "btnOutDespatchGetXml";
            this.btnOutDespatchGetXml.Size = new System.Drawing.Size(117, 35);
            this.btnOutDespatchGetXml.TabIndex = 30;
            this.btnOutDespatchGetXml.Text = "Xml İndir";
            this.btnOutDespatchGetXml.UseVisualStyleBackColor = false;
            this.btnOutDespatchGetXml.Click += new System.EventHandler(this.btnOutDespatchGetXml_Click);
            // 
            // btnOutDespatchGetStatus
            // 
            this.btnOutDespatchGetStatus.BackColor = System.Drawing.Color.CadetBlue;
            this.btnOutDespatchGetStatus.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnOutDespatchGetStatus.FlatAppearance.BorderSize = 2;
            this.btnOutDespatchGetStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutDespatchGetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOutDespatchGetStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOutDespatchGetStatus.Location = new System.Drawing.Point(24, 21);
            this.btnOutDespatchGetStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnOutDespatchGetStatus.Name = "btnOutDespatchGetStatus";
            this.btnOutDespatchGetStatus.Size = new System.Drawing.Size(117, 35);
            this.btnOutDespatchGetStatus.TabIndex = 24;
            this.btnOutDespatchGetStatus.Text = "Durum sorgula";
            this.btnOutDespatchGetStatus.UseVisualStyleBackColor = false;
            this.btnOutDespatchGetStatus.Click += new System.EventHandler(this.btnOutDespatchGetStatus_Click);
            // 
            // pnlDraftDespatch
            // 
            this.pnlDraftDespatch.Controls.Add(this.btnDraftDespatchGetStatus);
            this.pnlDraftDespatch.Controls.Add(this.btnLoadDespatch);
            this.pnlDraftDespatch.Controls.Add(this.btnSendDespatch);
            this.pnlDraftDespatch.Location = new System.Drawing.Point(332, 76);
            this.pnlDraftDespatch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDraftDespatch.Name = "pnlDraftDespatch";
            this.pnlDraftDespatch.Size = new System.Drawing.Size(661, 119);
            this.pnlDraftDespatch.TabIndex = 42;
            this.pnlDraftDespatch.Visible = false;
            // 
            // btnDraftDespatchGetStatus
            // 
            this.btnDraftDespatchGetStatus.BackColor = System.Drawing.Color.CadetBlue;
            this.btnDraftDespatchGetStatus.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnDraftDespatchGetStatus.FlatAppearance.BorderSize = 2;
            this.btnDraftDespatchGetStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDraftDespatchGetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDraftDespatchGetStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDraftDespatchGetStatus.Location = new System.Drawing.Point(24, 27);
            this.btnDraftDespatchGetStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnDraftDespatchGetStatus.Name = "btnDraftDespatchGetStatus";
            this.btnDraftDespatchGetStatus.Size = new System.Drawing.Size(117, 35);
            this.btnDraftDespatchGetStatus.TabIndex = 28;
            this.btnDraftDespatchGetStatus.Text = "Durum sorgula";
            this.btnDraftDespatchGetStatus.UseVisualStyleBackColor = false;
            this.btnDraftDespatchGetStatus.Click += new System.EventHandler(this.btnDraftDespatchGetStatus_Click);
            // 
            // btnLoadDespatch
            // 
            this.btnLoadDespatch.BackColor = System.Drawing.Color.CadetBlue;
            this.btnLoadDespatch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnLoadDespatch.FlatAppearance.BorderSize = 2;
            this.btnLoadDespatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDespatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoadDespatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLoadDespatch.Location = new System.Drawing.Point(389, 27);
            this.btnLoadDespatch.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadDespatch.Name = "btnLoadDespatch";
            this.btnLoadDespatch.Size = new System.Drawing.Size(117, 35);
            this.btnLoadDespatch.TabIndex = 27;
            this.btnLoadDespatch.Text = "Portala Yükle";
            this.btnLoadDespatch.UseVisualStyleBackColor = false;
            this.btnLoadDespatch.Click += new System.EventHandler(this.btnLoadDespatch_Click);
            // 
            // btnSendDespatch
            // 
            this.btnSendDespatch.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendDespatch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendDespatch.FlatAppearance.BorderSize = 2;
            this.btnSendDespatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendDespatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendDespatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendDespatch.Location = new System.Drawing.Point(207, 27);
            this.btnSendDespatch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendDespatch.Name = "btnSendDespatch";
            this.btnSendDespatch.Size = new System.Drawing.Size(117, 35);
            this.btnSendDespatch.TabIndex = 25;
            this.btnSendDespatch.Text = "Gönder";
            this.btnSendDespatch.UseVisualStyleBackColor = false;
            this.btnSendDespatch.Click += new System.EventHandler(this.btnSendDespatch_Click);
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
            this.btnHomePage.Location = new System.Drawing.Point(12, 27);
            this.btnHomePage.Margin = new System.Windows.Forms.Padding(4);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(104, 86);
            this.btnHomePage.TabIndex = 40;
            this.btnHomePage.Text = "Ana Sayfa";
            this.btnHomePage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHomePage.UseVisualStyleBackColor = false;
            this.btnHomePage.Click += new System.EventHandler(this.BtnHomePage_Click);
            // 
            // lblRowClickInfo
            // 
            this.lblRowClickInfo.AutoSize = true;
            this.lblRowClickInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRowClickInfo.Location = new System.Drawing.Point(329, 208);
            this.lblRowClickInfo.Name = "lblRowClickInfo";
            this.lblRowClickInfo.Size = new System.Drawing.Size(322, 17);
            this.lblRowClickInfo.TabIndex = 53;
            this.lblRowClickInfo.Text = "islem yapabılmek ıcın tablodan bir veriye  tıklayınız";
            // 
            // FrmDespatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 748);
            this.ControlBox = false;
            this.Controls.Add(this.lblRowClickInfo);
            this.Controls.Add(this.pnlSendDespatch);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.pnlIncomingDespatch);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.btnTakeDespatch);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.menuInvoice);
            this.Controls.Add(this.pnlDraftDespatch);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDespatch";
            this.Text = "FrmDespatch";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDespatch_FormClosed);
            this.Load += new System.EventHandler(this.FrmDespatch_Load);
            this.grpFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.menuInvoice.ResumeLayout(false);
            this.menuInvoice.PerformLayout();
            this.pnlIncomingDespatch.ResumeLayout(false);
            this.pnlSendDespatch.ResumeLayout(false);
            this.pnlDraftDespatch.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFilterList;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.DateTimePicker timeStartFilter;
        private System.Windows.Forms.DateTimePicker timeFinishFilter;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.Button btnTakeDespatch;
        private System.Windows.Forms.DataGridView tableGrid;
        private System.Windows.Forms.MenuStrip menuInvoice;
        private System.Windows.Forms.ToolStripMenuItem itemInDespatch;
        private System.Windows.Forms.ToolStripMenuItem itemOutDespatch;
        private System.Windows.Forms.ToolStripMenuItem itemDraftDespatch;
        private System.Windows.Forms.ToolStripMenuItem itemNewDespatch;
        private System.Windows.Forms.Panel pnlIncomingDespatch;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Panel pnlSendDespatch;
        private System.Windows.Forms.Panel pnlDraftDespatch;
        private System.Windows.Forms.Button btnInDespatchGetStatus;
        private System.Windows.Forms.Button btnOutDespatchGetStatus;
        private System.Windows.Forms.Button btnSendDespatch;
        private System.Windows.Forms.ToolStripMenuItem itemTakeGibUsers;
        private System.Windows.Forms.ToolStripMenuItem itemGetListGibUserList;
        private System.Windows.Forms.Button btnLoadDespatch;
        private System.Windows.Forms.Button btnDraftDespatchGetStatus;
        private System.Windows.Forms.Button btnInDespatchGetXml;
        private System.Windows.Forms.Button btnOutDespatchGetXml;
        private System.Windows.Forms.Label lblRowClickInfo;

    }
}