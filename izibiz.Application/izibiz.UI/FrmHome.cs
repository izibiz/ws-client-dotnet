using izibiz.UI.Languages;
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
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }



        private void FrmHome_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
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

            #region writeFormInItem
            //eleman text yazdır
            this.Text = Localization.formHomePage;
            btnInvoice.Text = Localization.eInvoice;
            btnArchive.Text = Localization.eArchive;
            btnIrsaliye.Text = Localization.eDispatch;
            btnAyarlar.Text =Localization.settings;
            btnMutabakat.Text =Localization.eReconciliation;
            btnSmm.Text = Localization.eFreeJob;
            btnMüstahsil.Text = Localization.eManufacturer;
            #endregion
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            FrmInvoice frmInvoice = new FrmInvoice();
            frmInvoice.Show();
            this.Hide();
        }

    }
}
