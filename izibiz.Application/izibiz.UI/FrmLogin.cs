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

            RoundedPathHelper.ApplyRoundedRegion(pnlLoginCard, 20);
            RoundedPathHelper.ApplyRoundedRegion(btnLogin, 10);
            CenterLoginCard();
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            CenterLoginCard();
            this.Invalidate();
        }

        private void CenterLoginCard()
        {
            pnlLoginCard.Location = new Point(
                (this.ClientSize.Width - pnlLoginCard.Width) / 2,
                (this.ClientSize.Height - pnlLoginCard.Height) / 2 + 15);
        }

        private void pnlLoginCard_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, pnlLoginCard.Width - 1, pnlLoginCard.Height - 1);
            RoundedPathHelper.DrawBorder(e.Graphics, rect, 20, Color.FromArgb(226, 232, 240));
        }

        /// <summary>
        /// Giriş kutusunun altına yumuşak bir gölge çizer (Form'un kendi Paint'inde, kart üzerine gelmeden önce).
        /// </summary>
        private void FrmLogin_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(pnlLoginCard.Left + 4, pnlLoginCard.Top + 4, pnlLoginCard.Width, pnlLoginCard.Height);
            using (var path = RoundedPathHelper.GetPath(rect, 20))
            using (var brush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(brush, path);
            }
        }



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
}
