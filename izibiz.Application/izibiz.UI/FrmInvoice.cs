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
            itemComingInvoice.Text = Localization.commingInvoice;
            itemComingListInvoice.Text = Localization.listInvoice;
            itemSentInvoice.Text = Localization.sentInvoice;
            itemDraftInvoice.Text = Localization.draftInvoice;
            itemNewInvoice.Text = Localization.newInvoice;
            itemSentInvoiceList.Text = Localization.listInvoice;
            itemDraftInvoiceList.Text = Localization.listInvoice;
            #endregion
        }



        private void itemComingListInvoice_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Localization.commingInvoice;

            tableGrid.Columns.Clear();
            tableGrid.DataSource = null;
            tableGrid.DataSource = Singleton.instanceInvoiceGet.getComingInvoice();
            ComingListInvoiceAddToButtonDataGrid();
        }



        private void ComingListInvoiceAddToButtonDataGrid()
        {
            DataGridViewButtonColumn accept = new DataGridViewButtonColumn();
            {
                accept.Name = "accept";
                accept.HeaderText = "";
                accept.Text = Localization.accept;
                accept.UseColumnTextForButtonValue = true;
                if (tableGrid.Columns["accept"] == null)
                {
                    this.tableGrid.Columns.Add(accept);
                }      
            }   
            DataGridViewButtonColumn reject = new DataGridViewButtonColumn();
            {
                reject.Name = "reject";
                reject.HeaderText = "";
                reject.Text = Localization.reject;
                reject.UseColumnTextForButtonValue = true;
                if (tableGrid.Columns["reject"] == null)
                {
                    this.tableGrid.Columns.Add(reject);
                }
            }
        }

        private void itemSentInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Localization.sentInvoice;

            tableGrid.Columns.Clear();
            tableGrid.DataSource = null;
            tableGrid.DataSource = Singleton.instanceInvoiceGet.getSentInvoice();
    
        }

        private void itemDraftInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Localization.draftInvoice;

            tableGrid.Columns.Clear();
            tableGrid.DataSource = null;

        }
    }
}
