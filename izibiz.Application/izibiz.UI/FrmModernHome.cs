using System;
using System.Drawing;
using System.Windows.Forms;

namespace izibiz.UI
{
    public class FrmModernHome : Form
    {
        private FlowLayoutPanel flowPanel;

        public FrmModernHome()
        {
            InitializeComponents();
            try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
        }

        private void InitializeComponents()
        {
            this.BackColor = UITheme.BackgroundColor;
            
            flowPanel = new FlowLayoutPanel();
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.Padding = new Padding(40);
            flowPanel.AutoScroll = true;
            this.Controls.Add(flowPanel);

            // Adding Module Cards
            flowPanel.Controls.Add(CreateModuleCard("E-Fatura", "#3B82F6", "\uD83D\uDCC4", OpenInvoice));
            flowPanel.Controls.Add(CreateModuleCard("E-Arşiv", "#10B981", "\uD83D\uDCC1", OpenArchive));
            flowPanel.Controls.Add(CreateModuleCard("E-Serbest Meslek", "#F59E0B", "\uD83D\uDCDC", OpenSmm));
            flowPanel.Controls.Add(CreateModuleCard("E-İrsaliye", "#EF4444", "\uD83D\uDE9A", OpenIrsaliye));
            flowPanel.Controls.Add(CreateModuleCard("E-Müstahsil", "#8B5CF6", "\uD83D\uDCD4", OpenMustahsil));
        }

        private Panel CreateModuleCard(string title, string colorHex, string iconText, EventHandler clickEvent)
        {
            Panel card = new Panel();
            card.Size = new Size(220, 220);
            card.Margin = new Padding(20);
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;
            
            // Subtle border effect using Paint (optional)
            card.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle, ColorTranslator.FromHtml("#E2E8F0"), ButtonBorderStyle.Solid);
            };

            // Icon
            Label lblIcon = new Label();
            lblIcon.Text = iconText;
            lblIcon.Font = new Font("Segoe UI Emoji", 48F, FontStyle.Regular);
            lblIcon.ForeColor = ColorTranslator.FromHtml(colorHex);
            lblIcon.AutoSize = false;
            lblIcon.Dock = DockStyle.Top;
            lblIcon.Height = 120;
            lblIcon.TextAlign = ContentAlignment.BottomCenter;
            lblIcon.Cursor = Cursors.Hand;
            card.Controls.Add(lblIcon);

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = UITheme.TitleFont;
            lblTitle.ForeColor = UITheme.TextColor;
            lblTitle.AutoSize = false;
            lblTitle.Dock = DockStyle.Bottom;
            lblTitle.Height = 100;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Cursor = Cursors.Hand;
            card.Controls.Add(lblTitle);

            // Hover and Click wiring
            Action<Control> wireEvents = null;
            wireEvents = (c) => {
                c.Click += clickEvent;
                c.MouseEnter += (s, e) => { 
                    card.BackColor = ColorTranslator.FromHtml("#F8FAFC"); 
                    card.Margin = new Padding(20, 15, 20, 25); 
                };
                c.MouseLeave += (s, e) => { 
                    card.BackColor = Color.White; 
                    card.Margin = new Padding(20); 
                };
                foreach (Control child in c.Controls) wireEvents(child);
            };
            wireEvents(card);

            return card;
        }

        private FrmModernShell GetShell()
        {
            return Application.OpenForms["FrmModernShell"] as FrmModernShell;
        }

        private void OpenInvoice(object sender, EventArgs e) => GetShell()?.OpenInvoice();
        private void OpenArchive(object sender, EventArgs e) => GetShell()?.OpenArchive();
        private void OpenSmm(object sender, EventArgs e) => GetShell()?.OpenSmm();
        private void OpenIrsaliye(object sender, EventArgs e) => GetShell()?.OpenIrsaliye();
        private void OpenMustahsil(object sender, EventArgs e) => GetShell()?.OpenMustahsil();
    }
}
