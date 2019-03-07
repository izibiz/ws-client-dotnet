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
using izibiz.UI.Exceptions;
using izibiz.UI.Languages;

namespace izibiz.UI
{
    public partial class FrmLogin : Form
    {

        public static string usurname;
        public static string password;

        public FrmLogin()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
            txtUsername.Text = "izibiz-test2";
            txtPassword.Text = "izi321";
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtUsername.Text.Trim()) || String.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    throw new NullUserPassExceptions(Localization.loginBadRequest);
                }
                else
                {
                    if(Singleton.instanceAuthGet.Login(txtUsername.Text, txtPassword.Text))
                    {
                        usurname = txtUsername.Text;
                        password = txtPassword.Text;
                        FrmHome frmHome = new FrmHome();
                        frmHome.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(Localization.loginWarring);
                    }                             
                }
            }
            catch (NullUserPassExceptions ex)
            {
                MessageBox.Show(ex.Message, Localization.warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }




        private void localizationItemTextWrite()
        {
            //dil secimini sorgula
            if (Settings.Default.language == "English")
            {
                Localization.Culture = new CultureInfo("en-US");
            }

            else
            {
                Localization.Culture = new CultureInfo("");
            }
            #region writeItemInForm
            //eleman text yazdır
            this.Text = Localization.formLoginPage;
            lblUsername.Text = Localization.usurname;
            lblPassword.Text = Localization.password;
            btnLogin.Text = Localization.login;
            chooseLanguage_ToolStripMenuItem.Text = Localization.chooseLanguage;
            chkShowPass.Text = Localization.showPassword;
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
    }
}
