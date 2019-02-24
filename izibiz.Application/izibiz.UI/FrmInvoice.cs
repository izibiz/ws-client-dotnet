using izibiz.CONTROLLER.Web_Services;
using izibiz.SERVICES.serviceOib;
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

            //eleman text yazdır
            this.Text = Localization.formFatura;
            itemComingInvoice.Text = Localization.commingInvoice;
            itemComingListInvoice.Text = Localization.listCommingInvoice;
            itemSentInvoice.Text = Localization.sentInvoice;
            itemDraftInvoice.Text = Localization.arshiveInvoice;
            itemNewInvoice.Text = Localization.newInvoice;

        }

        private void itemComingListInvoice_Click(object sender, EventArgs e)
        {

            lblTitle.Text = Localization.commingInvoice; 
            InvoiceWebService invoiceWebService = new InvoiceWebService();

            tableGrid.DataSource = invoiceWebService.getInvoiceList();

            ListInvoiceAddToButtonDataGrid();

        }



        private void ListInvoiceAddToButtonDataGrid()
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




    }
}
