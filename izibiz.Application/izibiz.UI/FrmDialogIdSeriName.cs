using izibiz.COMMON.Language;
using izibiz.CONTROLLER.Singleton;
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

namespace izibiz.UI
{
    public partial class FrmDialogSelectCombo : Form
    {

        public string selectedValue;
        private List<string> listİtem = new List<string>();

        public FrmDialogSelectCombo(List<string> listComboItems,bool selectSeriName)
        {
            InitializeComponent();
            listİtem = listComboItems;
            if (selectSeriName)
            {
                lblInformation.Text = Lang.selectSeriName;
            }
            else
            {
                lblInformation.Text = Lang.selectAlias;
            }
        }

        private void FrmDialogIdSeriName_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
            cmbSeriNames.DataSource = listİtem;
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
            this.DialogResult = DialogResult.OK;
            selectedValue = cmbSeriNames.Text;
            this.Close();
        }
    }
}
