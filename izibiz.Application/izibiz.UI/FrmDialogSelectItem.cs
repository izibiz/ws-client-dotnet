using izibiz.COMMON.Language;
using izibiz.CONTROLLER.DAL;
using izibiz.CONTROLLER.Singleton;
using izibiz.SERVICES.serviceOib;
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

namespace izibiz.UI
{
    public partial class FrmDialogSelectItem : Form
    {
        IdSerilazeDal idSerilazeDal;
        public string selectedValue;


        public FrmDialogSelectItem(bool isSeriName, string vknTckn)
        {
            try
            {
                InitializeComponent();
                if (isSeriName)  //seri no sectırıceksek
                {
                    lblInformation.Text = Lang.selectSeriName;
                    cmbSeriNames.DataSource = Singl.invIdSerilazeDalGet.getSeriNames();
                    linkLblAddSeriName.Text = Lang.addSeriName;
                    btnAddSeriName.Text = Lang.add;
                    linkLblAddSeriName.Visible = true;
                }
                else //alias ...posta kutusu sectiriceksek
                {
                    lblInformation.Text = Lang.selectAlias;
                    cmbSeriNames.DataSource = Singl.gibUsersDalGet.getGibUserAliasList(vknTckn);
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex) //oib req error
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void FrmDialogIdSeriName_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
            idSerilazeDal = new IdSerilazeDal();
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
            #region writeAllFormItem  
            this.Text = Lang.formDialogSeriName;
            btnOk.Text = Lang.okey;
            #endregion
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbSeriNames.Text))
            {
                MessageBox.Show(Lang.dontEmpty);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                selectedValue = cmbSeriNames.Text;
                this.Close();
            }
        }



        private void linkLblAddSeriName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpAddSeriName.Visible = true;
        }



        private void btnAddSeriName_Click(object sender, EventArgs e)
        {
            try
            {

                if (msdAddSeriName.Text != null && msdAddSeriName.Text.Length == 3 && !msdAddSeriName.Text.Any(char.IsLower))
                {
                    idSerilazeDal.addSeriName(msdAddSeriName.Text);
                    idSerilazeDal.dbSaveChanges();
                    cmbSeriNames.DataSource = idSerilazeDal.getSeriNames();
                    MessageBox.Show(Lang.addedSucc);
                }
                else
                {
                    MessageBox.Show(Lang.seriNameControl);//seri name;  bos olamaz,karakter sayısı 3 den kucuk veya kucuk harf olamaz
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex) //oib req error
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }




    }
}
