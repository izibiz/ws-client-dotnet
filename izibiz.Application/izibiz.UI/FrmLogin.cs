using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using izibiz.CONTROLLER.Singleton;
using izibiz.SERVICES.serviceAuth;
using izibiz.COMMON.Language;
using System.Net.Security;
using System.Net;
using izibiz.COMMON;
using izibiz.UI.Controls;

namespace izibiz.UI
{

    public partial class FrmLogin : Form
    {

        public static string usurname;
        public static string password;
       //int saniye = 0;

        //   private static RemoteCertificateValidationCallback cert;


        public FrmLogin()
        {
            //   ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            //  cert = ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);


            InitializeComponent();
            try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
            txtUsername.Text = "izibiz-test2";
            txtPassword.Text = "izi321";
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
            BuildCompactPremiumLayout();
        }

        private void BuildCompactPremiumLayout()
        {
            // Remove previous brand panel if any
            var oldBrand = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Tag?.ToString() == "BrandPanel");
            if (oldBrand != null) this.Controls.Remove(oldBrand);

            // Form Background
            this.BackColor = Color.FromArgb(226, 236, 248); // Çok şık, yumuşak bir kurumsal mavi
            this.Paint += FrmLogin_Paint; // Drop shadow

            // Compact Card setup
            pnlLoginCard.Dock = DockStyle.None;
            pnlLoginCard.Size = new Size(460, 540);
            pnlLoginCard.BackColor = Color.White;
            RoundedPathHelper.ApplyRoundedRegion(pnlLoginCard, 20);
            pnlLoginCard.Paint += pnlLoginCard_Paint; 

            // Logo
            if (!pnlLoginCard.Controls.Contains(pictureBox1))
            {
                pnlLoginCard.Controls.Add(pictureBox1);
            }
            pictureBox1.Size = new Size(240, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Removed Welcome Text as requested

            // Wrapper for txtUsername
            if (!pnlLoginCard.Controls.OfType<Panel>().Any(p => p.Tag?.ToString() == "UserWrapper"))
            {
                Panel pnlUser = new Panel();
                pnlUser.BackColor = Color.FromArgb(245, 247, 250);
                pnlUser.Size = new Size(360, 45);
                pnlUser.Tag = "UserWrapper";
                RoundedPathHelper.ApplyRoundedRegion(pnlUser, 8);
                
                txtUsername.BorderStyle = BorderStyle.None;
                txtUsername.BackColor = pnlUser.BackColor;
                txtUsername.Font = new Font("Segoe UI", 12F);
                txtUsername.Location = new Point(15, 12);
                txtUsername.Width = 330;
                pnlUser.Controls.Add(txtUsername);
                pnlLoginCard.Controls.Add(pnlUser);
            }
            
            // Wrapper for txtPassword
            if (!pnlLoginCard.Controls.OfType<Panel>().Any(p => p.Tag?.ToString() == "PassWrapper"))
            {
                Panel pnlPass = new Panel();
                pnlPass.BackColor = Color.FromArgb(245, 247, 250);
                pnlPass.Size = new Size(360, 45);
                pnlPass.Tag = "PassWrapper";
                RoundedPathHelper.ApplyRoundedRegion(pnlPass, 8);
                
                txtPassword.BorderStyle = BorderStyle.None;
                txtPassword.BackColor = pnlPass.BackColor;
                txtPassword.Font = new Font("Segoe UI", 12F);
                txtPassword.Location = new Point(15, 12);
                txtPassword.Width = 330;
                pnlPass.Controls.Add(txtPassword);
                pnlLoginCard.Controls.Add(pnlPass);
            }
            
            // Button Style improvements
            btnLogin.Height = 45;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.BackColor = izibiz.UI.Controls.BrandColors.Green; // Izibiz Theme Green
            btnLogin.FlatAppearance.MouseOverBackColor = izibiz.UI.Controls.BrandColors.GreenHover;
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            RoundedPathHelper.ApplyRoundedRegion(btnLogin, 8);

            // Font styles for all text elements to match the logo (Segoe UI)
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.ForeColor = izibiz.UI.Controls.BrandColors.TextDark;
            
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = izibiz.UI.Controls.BrandColors.TextDark;

            chkShowPass.Font = new Font("Segoe UI", 10F);
            chkShowPass.ForeColor = izibiz.UI.Controls.BrandColors.TextDark;

            // Language Menu Style enhancements (Professional Look)
            menuStrip.Renderer = new CleanRenderer();
            menuStrip.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chooseLanguage_ToolStripMenuItem.ForeColor = izibiz.UI.Controls.BrandColors.TextDark;

            // Language Menu Top Right
            menuStrip.Dock = DockStyle.None;
            menuStrip.AutoSize = true;
            menuStrip.BackColor = Color.Transparent;
            this.Controls.Add(menuStrip);
            menuStrip.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            menuStrip.Location = new Point(this.ClientSize.Width - menuStrip.Width - 20, 20);

            FrmLogin_Resize(this, EventArgs.Empty);
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            // Center pnlLoginCard statically
            int cardCenterX = (this.ClientSize.Width - pnlLoginCard.Width) / 2;
            int cardCenterY = (this.ClientSize.Height - pnlLoginCard.Height) / 2;
            
            pnlLoginCard.Location = new Point(cardCenterX, cardCenterY);
            if (menuStrip != null) menuStrip.Location = new Point(this.ClientSize.Width - menuStrip.Width - 20, 20);

            // Center contents inside pnlLoginCard
            int contentWidth = 360;
            int contentCenterX = (pnlLoginCard.Width - contentWidth) / 2;
            
            if (pictureBox1 != null)
            {
                pictureBox1.Location = new Point(
                    (pnlLoginCard.Width - pictureBox1.Width) / 2,
                    30
                );
            }

            // lblWelcome removed

            var pnlUser = pnlLoginCard.Controls.OfType<Panel>().FirstOrDefault(p => p.Tag?.ToString() == "UserWrapper");
            var pnlPass = pnlLoginCard.Controls.OfType<Panel>().FirstOrDefault(p => p.Tag?.ToString() == "PassWrapper");

            lblUsername.Location = new Point(contentCenterX, 220);
            if (pnlUser != null)
            {
                pnlUser.Location = new Point(contentCenterX, 250);
                pnlUser.Width = contentWidth;
                txtUsername.Width = contentWidth - 30; // 15px padding on each side
            }
            else
            {
                txtUsername.Location = new Point(contentCenterX, 250);
                txtUsername.Width = contentWidth;
            }

            lblPassword.Location = new Point(contentCenterX, 310);
            if (pnlPass != null)
            {
                pnlPass.Location = new Point(contentCenterX, 340);
                pnlPass.Width = contentWidth;
                txtPassword.Width = contentWidth - 30;
            }
            else
            {
                txtPassword.Location = new Point(contentCenterX, 340);
                txtPassword.Width = contentWidth;
            }

            chkShowPass.Location = new Point(contentCenterX, 400);
            
            btnLogin.Location = new Point(contentCenterX, 440);
            btnLogin.Width = contentWidth;

            this.Invalidate();
        }

        private void pnlLoginCard_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, pnlLoginCard.Width - 1, pnlLoginCard.Height - 1);
            RoundedPathHelper.DrawBorder(e.Graphics, rect, 20, Color.FromArgb(226, 232, 240));
        }

        private void FrmLogin_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(pnlLoginCard.Left + 4, pnlLoginCard.Top + 4, pnlLoginCard.Width, pnlLoginCard.Height);
            using (var path = RoundedPathHelper.GetPath(rect, 20))
            using (var brush = new SolidBrush(Color.FromArgb(25, 0, 0, 0)))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(brush, path);
            }
        }
        
        private void CenterLoginCard() { }



        private void localizationItemTextWrite()
        {
            //dil secimini sorgula
            if (Settings.Default.language == "English")
            {
                Lang.Culture = new CultureInfo("en-US");
            }

            else
            {
                Lang.Culture = new CultureInfo("");
            }
            #region writeItemInForm
            //eleman text yazdır
            this.Text = Lang.formLoginPage;
            lblUsername.Text = Lang.usurname;
            lblPassword.Text = Lang.password;
            btnLogin.Text = Lang.login;
            chooseLanguage_ToolStripMenuItem.Text = Lang.chooseLanguage;
            chkShowPass.Text = Lang.showPassword;
            #endregion
        }



        private void chkShowPass_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }



        private void englishToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Settings.Default.language = "English";
            Settings.Default.Save();
            localizationItemTextWrite();
        }



        private void turkishToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Settings.Default.language = "Turkish";
            Settings.Default.Save();
            localizationItemTextWrite();
        }




        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtUsername.Text.Trim()) || String.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    MessageBox.Show(Lang.loginBadRequest, Lang.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (Singl.authControllerGet.Login(txtUsername.Text, txtPassword.Text)) //true ise
                    {
                        usurname = txtUsername.Text;
                        password = txtPassword.Text;

                        // REST Client initialization
                        Singl.InitRest(usurname, password);

                        // Async olarak token alalım ve cache'de tutalım (isteğe bağlı ama faydalı)
                        _ = Singl.TokenProviderGet.GetTokenAsync();

                        FrmHome frmHome = new FrmHome();
                        this.Hide();
                        frmHome.Show();
                        
                    }
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        









    }

    public class CleanRenderer : ToolStripProfessionalRenderer
    {
        public CleanRenderer() : base(new CleanColorTable()) { }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }
    }

    public class CleanColorTable : ProfessionalColorTable
    {
        public override Color ToolStripBorder => Color.Transparent;
        public override Color MenuItemBorder => Color.Transparent;
        public override Color MenuItemSelected => Color.FromArgb(210, 225, 240); // Hover için hafif koyu mavi
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(210, 225, 240);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(210, 225, 240);
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(210, 225, 240);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(210, 225, 240);
        public override Color ToolStripDropDownBackground => Color.White;
        public override Color ImageMarginGradientBegin => Color.White;
        public override Color ImageMarginGradientMiddle => Color.White;
        public override Color ImageMarginGradientEnd => Color.White;
    }
}
