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




        private void btnFatura_Click(object sender, EventArgs e)
        {
            FrmInvoice frmInvoice = new FrmInvoice();
            frmInvoice.Show();
            this.Hide();
        }



        private void localizationItemTextWrite()
        {
            //dil secimini sorgula
            if (Settings.Default.language == "English"){
                Localization.Culture = new CultureInfo("en-US");
            }

            else{
                Localization.Culture = new CultureInfo("");
            }

            //eleman text yazdır
            this.Text = Localization.formHomeTitle;
            btnFatura.Text = Localization.eFatura;
            btnArsiv.Text = Localization.eArsiv;
            btnIrsaliye.Text = Localization.eIrsaliye;
            btnAyarlar.Text =Localization.settings;
            btnMutabakat.Text =Localization.eReconciliation;
            btnSmm.Text = Localization.eSerbestMeslek;
            btnMüstahsil.Text = Localization.eMustahsil;

        }

        private void btnFatura_Click_1(object sender, EventArgs e)
        {
            FrmInvoice frmInvoice = new FrmInvoice();
            frmInvoice.Show();
            this.Hide();
        }
    }
}
