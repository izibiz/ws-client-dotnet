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
            try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
        }



        private void FrmHome_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
            ArrangeProductGrid();
        }

        private void FrmHome_Resize(object sender, EventArgs e)
        {
            ArrangeProductGrid();
        }

        /// <summary>
        /// 6 ürünü ekranýn ortasýnda, 3x2 modern bir kart düzeninde konumlandýrýr.
        /// Pencere yeniden boyutlandýrýldýðýnda da yeniden hesaplanýr (Resize event'i ile).
        /// </summary>
        private void ArrangeProductGrid()
        {
            var buttons = new[] { btnInvoice, btnArchive, btnIrsaliye, btnMutabakat, btnSmm, btnMüstahsil };
            var labels = new Label[] { lblInvoiceTitle, lblArchiveTitle, lblIrsaliyeTitle, lblMutabakatTitle, lblSmmTitle, lblMustahsilTitle };

            const int iconSize = 200;
            const int colGap = 80;
            const int rowGap = 60;
            const int labelHeight = 32;
            const int cols = 3;
            const int rows = 2;

            int gridWidth = cols * iconSize + (cols - 1) * colGap;
            int gridHeight = rows * (iconSize + 8 + labelHeight) + (rows - 1) * rowGap;

            int startX = (this.ClientSize.Width - gridWidth) / 2;
            int startY = (this.ClientSize.Height - gridHeight) / 2;

            for (int i = 0; i < buttons.Length; i++)
            {
                int col = i % cols;
                int row = i / cols;
                int x = startX + col * (iconSize + colGap);
                int y = startY + row * (iconSize + 8 + labelHeight + rowGap);

                buttons[i].Location = new Point(x, y);
                buttons[i].Size = new Size(iconSize, iconSize);

                labels[i].Location = new Point(x, y + iconSize + 8);
                labels[i].Size = new Size(iconSize, labelHeight);
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

            #region writeFormInItem
            //eleman text yazdýr
            this.Text = Lang.formHomePage;
            lblInvoiceTitle.Text = Lang.eInvoice;
            lblArchiveTitle.Text = Lang.eArchive;
            lblIrsaliyeTitle.Text = Lang.eDispatch;
            lblMutabakatTitle.Text = Lang.eReconciliation;
            lblSmmTitle.Text = Lang.eFreeJob;
            lblMustahsilTitle.Text = "E-Müstahsil";
            #endregion
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            FrmInvoice frmInvoice = new FrmInvoice();
            this.Hide();
            frmInvoice.Show();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            FrmArchive frmArchive = new FrmArchive();
            this.Hide();
            frmArchive.Show();
        }


        private void FrmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        private void btnIrsaliye_Click(object sender, EventArgs e)
        {
            FrmDespatch frmDespatch = new FrmDespatch();
            this.Hide();
            frmDespatch.Show();
        }

        private void BtnMutabakat_Click(object sender, EventArgs e)
        {
            FrmReconcilation frmReconsilation = new FrmReconcilation();
            this.Hide();
            frmReconsilation.Show();
        }

        private void BtnSmm_Click(object sender, EventArgs e)
        {
            FrmSelfEmployment frmSelfEmployment = new FrmSelfEmployment();
            this.Hide();
            frmSelfEmployment.Show();
        }

        private void BtnMüstahsil_Click(object sender, EventArgs e)
        {
            FrmCreditNote frmCreditNote = new FrmCreditNote();
            this.Hide();
            frmCreditNote.Show();
        }
    }
}
