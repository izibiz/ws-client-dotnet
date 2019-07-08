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

namespace izibiz.UI
{

    public partial class FrmLogin : Form
    {

        public static string usurname;
        public static string password;
        int saniye = 0;

        //   private static RemoteCertificateValidationCallback cert;


        public FrmLogin()
        {
            //   ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            //  cert = ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);


            InitializeComponent();
            txtUsername.Text = "izibiz-test2";
            txtPassword.Text = "izi321";
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
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
                        FrmHome frmHome = new FrmHome();
                        frmHome.Show();
                        this.Hide();
                        
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
