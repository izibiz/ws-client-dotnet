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
                Lcl.Culture = new CultureInfo("en-US");
            }
            else
            {
                Lcl.Culture = new CultureInfo("");
            }

            #region writeFormInItem
            //eleman text yazdır
            this.Text = Lcl.formHomePage;
            btnInvoice.Text = Lcl.eInvoice;
            btnArchive.Text = Lcl.eArchive;
            btnIrsaliye.Text = Lcl.eDispatch;
            btnAyarlar.Text =Lcl.settings;
            btnMutabakat.Text =Lcl.eReconciliation;
            btnSmm.Text = Lcl.eFreeJob;
            btnMüstahsil.Text = Lcl.eManufacturer;
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
