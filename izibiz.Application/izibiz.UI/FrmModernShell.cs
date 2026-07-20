using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using izibiz.COMMON.Language;

namespace izibiz.UI
{
    public class FrmModernShell : Form
    {
        private Panel pnlSidebar;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Label lblTitle;
        private Button btnClose;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FrmModernShell()
        {
            InitializeComponents();
            try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
            LoadDefaultView();
        }

        private void InitializeComponents()
        {
            this.Size = new Size(1200, 800);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = UITheme.BackgroundColor;

            // Header Panel
            pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 40;
            pnlHeader.BackColor = UITheme.PanelColor;
            pnlHeader.MouseDown += PnlHeader_MouseDown;
            this.Controls.Add(pnlHeader);

            lblTitle = new Label();
            lblTitle.Text = "E-Dönüşüm Portalı";
            lblTitle.Font = UITheme.TitleFont;
            lblTitle.ForeColor = UITheme.TextColor;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 7);
            lblTitle.MouseDown += PnlHeader_MouseDown;
            pnlHeader.Controls.Add(lblTitle);

            // Window Controls (Right to Left due to DockStyle.Right)
            btnClose = new Button();
            btnClose.Text = "X";
            btnClose.Dock = DockStyle.Right;
            btnClose.Width = 45;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = UITheme.TextColor;
            btnClose.Font = UITheme.BoldFont;
            btnClose.Cursor = Cursors.Hand;
            btnClose.MouseEnter += (s, e) => { btnClose.BackColor = Color.IndianRed; btnClose.ForeColor = Color.White; };
            btnClose.MouseLeave += (s, e) => { btnClose.BackColor = Color.Transparent; btnClose.ForeColor = UITheme.TextColor; };
            btnClose.Click += (s, e) => Application.Exit();
            pnlHeader.Controls.Add(btnClose);

            Button btnMaximize = new Button();
            btnMaximize.Text = "🗖"; // Maximize symbol
            btnMaximize.Dock = DockStyle.Right;
            btnMaximize.Width = 45;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.BackColor = Color.Transparent;
            btnMaximize.ForeColor = UITheme.TextColor;
            btnMaximize.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btnMaximize.Cursor = Cursors.Hand;
            btnMaximize.MouseEnter += (s, e) => { btnMaximize.BackColor = ColorTranslator.FromHtml("#E2E8F0"); };
            btnMaximize.MouseLeave += (s, e) => { btnMaximize.BackColor = Color.Transparent; };
            btnMaximize.Click += (s, e) => { 
                this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized; 
            };
            pnlHeader.Controls.Add(btnMaximize);

            Button btnMinimize = new Button();
            btnMinimize.Text = "🗕"; // Minimize symbol
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.Width = 45;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.ForeColor = UITheme.TextColor;
            btnMinimize.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.MouseEnter += (s, e) => { btnMinimize.BackColor = ColorTranslator.FromHtml("#E2E8F0"); };
            btnMinimize.MouseLeave += (s, e) => { btnMinimize.BackColor = Color.Transparent; };
            btnMinimize.Click += (s, e) => { this.WindowState = FormWindowState.Minimized; };
            pnlHeader.Controls.Add(btnMinimize);

            // Sidebar Panel
            pnlSidebar = new Panel();
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 220;
            pnlSidebar.BackColor = UITheme.SidebarColor;
            this.Controls.Add(pnlSidebar);

            // App Logo / Title in Sidebar
            Label lblLogo = new Label();
            lblLogo.Text = "IZIBIZ";
            lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Height = 80;
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            pnlSidebar.Controls.Add(lblLogo);

            // Content Panel
            pnlContent = new Panel();
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = UITheme.BackgroundColor;
            this.Controls.Add(pnlContent);
            pnlContent.BringToFront();

            // Menu Buttons (Added from bottom to top due to DockStyle.Top)
            AddMenuButton("E-Müstahsil", OpenMustahsil);
            AddMenuButton("E-İrsaliye", OpenIrsaliye);
            AddMenuButton("E-Smm", OpenSmm);
            AddMenuButton("E-Arşiv", OpenArchive);
            AddMenuButton("E-Fatura", OpenInvoice);
            AddMenuButton("Ana Sayfa", LoadDefaultView);
        }

        private void AddMenuButton(string text, EventHandler clickEvent)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Dock = DockStyle.Top;
            btn.Height = 50;
            UITheme.ApplySidebarButton(btn);
            btn.Click += clickEvent;
            pnlSidebar.Controls.Add(btn);
            btn.BringToFront(); // To keep order correct
        }

        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LoadFormInContent(Form frm)
        {
            pnlContent.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        public void LoadDefaultView(object sender = null, EventArgs e = null)
        {
            lblTitle.Text = "Ana Sayfa";
            LoadFormInContent(new FrmModernHome());
        }

        public void OpenInvoice(object sender = null, EventArgs e = null)
        {
            lblTitle.Text = "E-Fatura";
            LoadFormInContent(new FrmInvoice());
        }

        public void OpenArchive(object sender = null, EventArgs e = null)
        {
            lblTitle.Text = "E-Arşiv";
            LoadFormInContent(new FrmArchive());
        }

        public void OpenSmm(object sender = null, EventArgs e = null)
        {
            lblTitle.Text = "E-Serbest Meslek Makbuzu";
            LoadFormInContent(new FrmModernSmm());
        }

        public void OpenIrsaliye(object sender = null, EventArgs e = null)
        {
            lblTitle.Text = "E-İrsaliye";
            LoadFormInContent(new FrmDespatch());
        }

        public void OpenMustahsil(object sender = null, EventArgs e = null)
        {
            lblTitle.Text = "E-Müstahsil";
            LoadFormInContent(new FrmCreditNote());
        }
    }
}
