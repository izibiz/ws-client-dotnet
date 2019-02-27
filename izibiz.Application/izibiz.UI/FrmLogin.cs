using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using izibiz.CONTROLLER.Singleton;
using izibiz.UI.Languages;

namespace izibiz.UI
{
    public partial class FrmLogin : Form
    {



        public FrmLogin()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
        }


        private void btn_login_Click(object sender, EventArgs e)
        {
           
            if(String.IsNullOrEmpty(txtUsername.Text.Trim()) ||  String.IsNullOrEmpty(txtPassword.Text.Trim())){
                MessageBox.Show(Localization.loginBadRequest);
            }
            else{
                try{             
                    string sesoin= Singleton.instanceAuthGet.Login(txtUsername.Text, txtPassword.Text);
                    if (sesoin != "no-user"){
                        FrmHome frmHome = new FrmHome();
                        frmHome.Show();
                        this.Hide();
                    }
                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }           
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

            //eleman text yazdır
            this.Text = Localization.formLoginPage;
            lblUsername.Text = Localization.usurname;
            lblPassword.Text = Localization.password;
            btn_login.Text = Localization.login;
            chooseLanguage_ToolStripMenuItem.Text = Localization.chooseLanguage;
            chkShowPass.Text = Localization.showPassword;
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
