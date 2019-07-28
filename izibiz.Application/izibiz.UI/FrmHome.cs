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
using izibiz.COMMON.Language;


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
                Lang.Culture = new CultureInfo("en-US");
            }
            else
            {
                Lang.Culture = new CultureInfo("");
            }

            #region writeFormInItem
            //eleman text yazdır
            this.Text = Lang.formHomePage;
            btnInvoice.Text = Lang.eInvoice;
            btnArchive.Text = Lang.eArchive;
            btnIrsaliye.Text = Lang.eDispatch;
            btnMutabakat.Text = Lang.eReconciliation;
            btnSmm.Text = Lang.eFreeJob;
            btnMüstahsil.Text = Lang.eManufacturer;
            #endregion
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            FrmInvoice frmInvoice = new FrmInvoice();
            frmInvoice.Show();
            this.Hide();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            FrmArchive frmArchive = new FrmArchive();
            frmArchive.Show();
            this.Hide();
        }


        private void FrmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        private void btnIrsaliye_Click(object sender, EventArgs e)
        {
            FrmDespatch frmDespatch = new FrmDespatch();
            frmDespatch.Show();
            this.Hide();
        }

        private void BtnMutabakat_Click(object sender, EventArgs e)
        {
            FrmReconcilation frmReconsilation = new FrmReconcilation();
            frmReconsilation.Show();
            this.Hide();
        }
    }
}
