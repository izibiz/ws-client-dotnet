using izibiz.CONTROLLER.Singleton;
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
    public partial class FrmInvoice : Form
    {




        public FrmInvoice()
        {
            InitializeComponent();
        }

        private void FrmInvoice_Load(object sender, EventArgs e)
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

            #region writeAllFormItem
            //eleman text yazdır
            this.Text = Localization.formInvoice;
            itemIncomingInvoice.Text = Localization.incomingInvoice;
            itemComingListInvoice.Text = Localization.listInvoice;
            itemSentInvoice.Text = Localization.sentInvoice;
            itemDraftInvoice.Text = Localization.draftInvoice;
            itemNewInvoice.Text = Localization.newInvoice;
            itemSentInvoiceList.Text = Localization.listInvoice;
            itemDraftInvoiceList.Text = Localization.listDraftInvoice;
            #endregion
        }



        private void itemComingListInvoice_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Localization.incomingInvoice;
            panelConfirmation.Visible = false;
            btnIncomingRefresh.Visible = true;

            tableGrid.DataSource = null;
            tableGrid.DataSource = Singleton.instanceInvoiceGet.getComingInvoice();

        }





        private void itemSentInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Localization.sentInvoice;
            btnIncomingRefresh.Visible = false;
            panelConfirmation.Visible = false;

            tableGrid.DataSource = null;
            tableGrid.DataSource = Singleton.instanceInvoiceGet.getSentInvoice();

        }

        private void itemDraftInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Localization.draftInvoice;
            btnIncomingRefresh.Visible = false;
            panelConfirmation.Visible = false;

            tableGrid.DataSource = null;

        }







        private void btnIncomingRefresh_Click(object sender, EventArgs e)
        {
            panelConfirmation.Visible = false;

            tableGrid.DataSource = null;
            tableGrid.DataSource = Singleton.instanceInvoiceGet.getComingInvoice();
        }

        private void tableGrid_Click(object sender, EventArgs e)
        {
            panelConfirmation.Visible = true;

            foreach (DataGridViewRow row in tableGrid.SelectedRows)
            {
                if (row.Cells[9].Value != null && row.Cells[9].Value.ToString() != "RECEIVE - WAIT_APPLICATION_RESPONSE")//olmayan varsa
                {
                    btnAccept.Enabled = false;
                    btnReject.Enabled = false;
                    break;
                }
                else
                {
                    btnAccept.Enabled = true;
                    btnReject.Enabled = true;
                }
            }
        }



    }
}
