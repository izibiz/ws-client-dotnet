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
            this.btnFilterList = new System.Windows.Forms.Button();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.timeStartFilter = new System.Windows.Forms.DateTimePicker();
            this.timeFinishFilter = new System.Windows.Forms.DateTimePicker();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.btnTakeDespatch = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.menuInvoice = new System.Windows.Forms.MenuStrip();
            this.itemIncomingDespatch = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSentDespatch = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDraftDespatch = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNewDespatch = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTakeGibUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.itemListGibUserList = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlIncomingDespatch = new System.Windows.Forms.Panel();
            this.btnAnswerDespatch = new System.Windows.Forms.Button();
            this.btnIncomingDespatchGetStatus = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.pnlSendDespatch = new System.Windows.Forms.Panel();
            this.btnSendDespatchGetStatus = new System.Windows.Forms.Button();
            this.pnlDraftDespatch = new System.Windows.Forms.Panel();
            this.btnDraftDespatchGetStatus = new System.Windows.Forms.Button();
            this.btnLoadDespatch = new System.Windows.Forms.Button();
            this.btnCancelDespatch = new System.Windows.Forms.Button();
            this.btnSendDespatch = new System.Windows.Forms.Button();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.menuInvoice.SuspendLayout();
            this.pnlIncomingDespatch.SuspendLayout();
            this.pnlSendDespatch.SuspendLayout();
            this.pnlDraftDespatch.SuspendLayout();
            this.SuspendLayout();
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
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnFilterList);
            this.grpFilter.Controls.Add(this.timeStartFilter);
            this.grpFilter.Controls.Add(this.timeFinishFilter);
            this.grpFilter.Location = new System.Drawing.Point(1033, 29);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(147, 114);
            this.grpFilter.TabIndex = 39;
            this.grpFilter.TabStop = false;
            this.grpFilter.Visible = false;
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
            this.btnHomePage.Location = new System.Drawing.Point(9, 22);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(115, 70);
            this.btnHomePage.TabIndex = 40;
            this.btnHomePage.Text = "Ana Sayfa";
            this.btnHomePage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHomePage.UseVisualStyleBackColor = false;
            // 
            // btnTakeDespatch
            // 
            this.btnTakeDespatch.BackColor = System.Drawing.Color.CadetBlue;
            this.btnTakeDespatch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnTakeDespatch.FlatAppearance.BorderSize = 2;
            this.btnTakeDespatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeDespatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTakeDespatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTakeDespatch.Location = new System.Drawing.Point(211, 62);
            this.btnTakeDespatch.Name = "btnTakeDespatch";
            this.btnTakeDespatch.Size = new System.Drawing.Size(120, 35);
            this.btnTakeDespatch.TabIndex = 38;
            this.btnTakeDespatch.Text = "fatura al";
            this.btnTakeDespatch.UseVisualStyleBackColor = false;
            this.btnTakeDespatch.Visible = false;
            this.btnTakeDespatch.Click += new System.EventHandler(this.btnTakeDespatch_Click);
            // 
            // tableGrid
            // 
            this.tableGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.GridColor = System.Drawing.SystemColors.Control;
            this.tableGrid.Location = new System.Drawing.Point(243, 302);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGrid.Size = new System.Drawing.Size(905, 294);
            this.tableGrid.TabIndex = 35;
            this.tableGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableGrid_CellClick);
            // 
            // menuInvoice
            // 
            this.menuInvoice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuInvoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuInvoice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuInvoice.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuInvoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemIncomingDespatch,
            this.itemSentDespatch,
            this.itemDraftDespatch,
            this.itemNewDespatch,
            this.itemTakeGibUsers,
            this.itemListGibUserList});
            this.menuInvoice.Location = new System.Drawing.Point(0, 0);
            this.menuInvoice.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.menuInvoice.Name = "menuInvoice";
            this.menuInvoice.Size = new System.Drawing.Size(135, 608);
            this.menuInvoice.TabIndex = 32;
            this.menuInvoice.Text = "menuStrip1";
            // 
            // itemIncomingDespatch
            // 
            this.itemIncomingDespatch.BackColor = System.Drawing.Color.Teal;
            this.itemIncomingDespatch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemIncomingDespatch.Margin = new System.Windows.Forms.Padding(0, 110, 0, 0);
            this.itemIncomingDespatch.Name = "itemIncomingDespatch";
            this.itemIncomingDespatch.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemIncomingDespatch.Size = new System.Drawing.Size(128, 29);
            this.itemIncomingDespatch.Text = "Gelen İrsaliye";
            this.itemIncomingDespatch.Click += new System.EventHandler(this.itemIncomingInvoice_Click);
            // 
            // itemSentDespatch
            // 
            this.itemSentDespatch.BackColor = System.Drawing.Color.Teal;
            this.itemSentDespatch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemSentDespatch.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemSentDespatch.Name = "itemSentDespatch";
            this.itemSentDespatch.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemSentDespatch.Size = new System.Drawing.Size(128, 29);
            this.itemSentDespatch.Text = " Giden İrsaliye";
            this.itemSentDespatch.Click += new System.EventHandler(this.itemSentInvoice_Click);
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
            this.itemDraftDespatch.Click += new System.EventHandler(this.itemDraftInvoice_Click);
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
            // 
            // itemTakeGibUsers
            // 
            this.itemTakeGibUsers.BackColor = System.Drawing.Color.Teal;
            this.itemTakeGibUsers.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemTakeGibUsers.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemTakeGibUsers.Name = "itemTakeGibUsers";
            this.itemTakeGibUsers.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemTakeGibUsers.ShowShortcutKeys = false;
            this.itemTakeGibUsers.Size = new System.Drawing.Size(128, 29);
            this.itemTakeGibUsers.Text = "Gib User List Al";
            this.itemTakeGibUsers.Click += new System.EventHandler(this.itemTakeGibUsers_Click);
            // 
            // itemListGibUserList
            // 
            this.itemListGibUserList.BackColor = System.Drawing.Color.Teal;
            this.itemListGibUserList.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.itemListGibUserList.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.itemListGibUserList.Name = "itemListGibUserList";
            this.itemListGibUserList.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.itemListGibUserList.Size = new System.Drawing.Size(128, 29);
            this.itemListGibUserList.Text = "Gib User Listele";
            this.itemListGibUserList.Click += new System.EventHandler(this.itemListGibUserList_Click);
            // 
            // pnlIncomingDespatch
            // 
            this.pnlIncomingDespatch.Controls.Add(this.btnAnswerDespatch);
            this.pnlIncomingDespatch.Controls.Add(this.btnIncomingDespatchGetStatus);
            this.pnlIncomingDespatch.Location = new System.Drawing.Point(337, 62);
            this.pnlIncomingDespatch.Name = "pnlIncomingDespatch";
            this.pnlIncomingDespatch.Size = new System.Drawing.Size(646, 71);
            this.pnlIncomingDespatch.TabIndex = 41;
            this.pnlIncomingDespatch.Visible = false;
            // 
            // btnAnswerDespatch
            // 
            this.btnAnswerDespatch.BackColor = System.Drawing.Color.CadetBlue;
            this.btnAnswerDespatch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnAnswerDespatch.FlatAppearance.BorderSize = 2;
            this.btnAnswerDespatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswerDespatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAnswerDespatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAnswerDespatch.Location = new System.Drawing.Point(155, 20);
            this.btnAnswerDespatch.Name = "btnAnswerDespatch";
            this.btnAnswerDespatch.Size = new System.Drawing.Size(117, 35);
            this.btnAnswerDespatch.TabIndex = 24;
            this.btnAnswerDespatch.Text = "Yanıt Ver";
            this.btnAnswerDespatch.UseVisualStyleBackColor = false;
            // 
            // btnIncomingDespatchGetStatus
            // 
            this.btnIncomingDespatchGetStatus.BackColor = System.Drawing.Color.CadetBlue;
            this.btnIncomingDespatchGetStatus.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnIncomingDespatchGetStatus.FlatAppearance.BorderSize = 2;
            this.btnIncomingDespatchGetStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncomingDespatchGetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIncomingDespatchGetStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIncomingDespatchGetStatus.Location = new System.Drawing.Point(18, 20);
            this.btnIncomingDespatchGetStatus.Name = "btnIncomingDespatchGetStatus";
            this.btnIncomingDespatchGetStatus.Size = new System.Drawing.Size(117, 35);
            this.btnIncomingDespatchGetStatus.TabIndex = 23;
            this.btnIncomingDespatchGetStatus.Text = "Durum sorgula";
            this.btnIncomingDespatchGetStatus.UseVisualStyleBackColor = false;
            this.btnIncomingDespatchGetStatus.Click += new System.EventHandler(this.btnIncomingDespatchGetStatus_Click);
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
            this.pnlSendDespatch.Controls.Add(this.btnSendDespatchGetStatus);
            this.pnlSendDespatch.Location = new System.Drawing.Point(337, 146);
            this.pnlSendDespatch.Name = "pnlSendDespatch";
            this.pnlSendDespatch.Size = new System.Drawing.Size(646, 70);
            this.pnlSendDespatch.TabIndex = 42;
            this.pnlSendDespatch.Visible = false;
            // 
            // btnSendDespatchGetStatus
            // 
            this.btnSendDespatchGetStatus.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendDespatchGetStatus.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendDespatchGetStatus.FlatAppearance.BorderSize = 2;
            this.btnSendDespatchGetStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendDespatchGetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendDespatchGetStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendDespatchGetStatus.Location = new System.Drawing.Point(18, 17);
            this.btnSendDespatchGetStatus.Name = "btnSendDespatchGetStatus";
            this.btnSendDespatchGetStatus.Size = new System.Drawing.Size(117, 35);
            this.btnSendDespatchGetStatus.TabIndex = 24;
            this.btnSendDespatchGetStatus.Text = "Durum sorgula";
            this.btnSendDespatchGetStatus.UseVisualStyleBackColor = false;
            this.btnSendDespatchGetStatus.Click += new System.EventHandler(this.btnSendDespatchGetStatus_Click);
            // 
            // pnlDraftDespatch
            // 
            this.pnlDraftDespatch.Controls.Add(this.btnDraftDespatchGetStatus);
            this.pnlDraftDespatch.Controls.Add(this.btnLoadDespatch);
            this.pnlDraftDespatch.Controls.Add(this.btnCancelDespatch);
            this.pnlDraftDespatch.Controls.Add(this.btnSendDespatch);
            this.pnlDraftDespatch.Location = new System.Drawing.Point(337, 222);
            this.pnlDraftDespatch.Name = "pnlDraftDespatch";
            this.pnlDraftDespatch.Size = new System.Drawing.Size(646, 74);
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
            this.btnDraftDespatchGetStatus.Location = new System.Drawing.Point(18, 22);
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
            this.btnLoadDespatch.Location = new System.Drawing.Point(292, 22);
            this.btnLoadDespatch.Name = "btnLoadDespatch";
            this.btnLoadDespatch.Size = new System.Drawing.Size(117, 35);
            this.btnLoadDespatch.TabIndex = 27;
            this.btnLoadDespatch.Text = "Portala Yükle";
            this.btnLoadDespatch.UseVisualStyleBackColor = false;
            this.btnLoadDespatch.Click += new System.EventHandler(this.btnLoadDespatch_Click);
            // 
            // btnCancelDespatch
            // 
            this.btnCancelDespatch.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelDespatch.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCancelDespatch.FlatAppearance.BorderSize = 2;
            this.btnCancelDespatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelDespatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCancelDespatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelDespatch.Location = new System.Drawing.Point(429, 22);
            this.btnCancelDespatch.Name = "btnCancelDespatch";
            this.btnCancelDespatch.Size = new System.Drawing.Size(117, 35);
            this.btnCancelDespatch.TabIndex = 26;
            this.btnCancelDespatch.Text = "İptal Et";
            this.btnCancelDespatch.UseVisualStyleBackColor = false;
            // 
            // btnSendDespatch
            // 
            this.btnSendDespatch.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSendDespatch.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSendDespatch.FlatAppearance.BorderSize = 2;
            this.btnSendDespatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendDespatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSendDespatch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendDespatch.Location = new System.Drawing.Point(155, 22);
            this.btnSendDespatch.Name = "btnSendDespatch";
            this.btnSendDespatch.Size = new System.Drawing.Size(117, 35);
            this.btnSendDespatch.TabIndex = 25;
            this.btnSendDespatch.Text = "Gönder";
            this.btnSendDespatch.UseVisualStyleBackColor = false;
            // 
            // FrmDespatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 608);
            this.Controls.Add(this.pnlSendDespatch);
            this.Controls.Add(this.pnlDraftDespatch);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.pnlIncomingDespatch);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.btnTakeDespatch);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.menuInvoice);
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
        private System.Windows.Forms.ToolStripMenuItem itemIncomingDespatch;
        private System.Windows.Forms.ToolStripMenuItem itemSentDespatch;
        private System.Windows.Forms.ToolStripMenuItem itemDraftDespatch;
        private System.Windows.Forms.ToolStripMenuItem itemNewDespatch;
        private System.Windows.Forms.Panel pnlIncomingDespatch;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Panel pnlSendDespatch;
        private System.Windows.Forms.Panel pnlDraftDespatch;
        private System.Windows.Forms.Button btnIncomingDespatchGetStatus;
        private System.Windows.Forms.Button btnSendDespatchGetStatus;
        private System.Windows.Forms.Button btnAnswerDespatch;
        private System.Windows.Forms.Button btnCancelDespatch;
        private System.Windows.Forms.Button btnSendDespatch;
        private System.Windows.Forms.ToolStripMenuItem itemTakeGibUsers;
        private System.Windows.Forms.ToolStripMenuItem itemListGibUserList;
        private System.Windows.Forms.Button btnLoadDespatch;
        private System.Windows.Forms.Button btnDraftDespatchGetStatus;
    }
}