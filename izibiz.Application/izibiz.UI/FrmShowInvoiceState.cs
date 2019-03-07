using izibiz.MODEL.Model;
using izibiz.UI.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace izibiz.UI
{
    public partial class FrmShowInvoiceState : Form
    {
        InvoiceStatus invoiceStatus;

        public FrmShowInvoiceState()
        {
            InitializeComponent();
        }

        public FrmShowInvoiceState(InvoiceStatus invStatus)
        {
            InitializeComponent();
            invoiceStatus = invStatus;
            localizationItemTextWrite();
            showStatus();    
        }

        private void FrmShowInvoiceState_Load(object sender, EventArgs e)
        {
           
        }


        private void localizationItemTextWrite()
        {
            this.Text = Localization.frmShowInvoiceStatus;
        }





        private void showStatus()
        {
            var dt = new DataTable();
            dt.Columns.Add("StatusID");
            dt.Columns.Add("Status");
            dt.Columns.Add("StatusDescription");
            dt.Columns.Add("GibStatusCode");
            dt.Columns.Add("GibStatusDescription");
            dt.Columns.Add("CDate");

            var dRow = dt.NewRow();

            dRow["StatusID"] = invoiceStatus.statusID;
            dRow["Status"] = invoiceStatus.status;
            dRow["StatusDescription"] = invoiceStatus.statusDescription;
            dRow["GibStatusCode"] = invoiceStatus.gibStatusCode;
            dRow["GibStatusDescription"] = invoiceStatus.gibStatusDescription;
            dRow["CDate"] = invoiceStatus.cDate;
 
            dt.Rows.Add(dRow);
            
            dataGridView1.DataSource = dt;
        }



    }
}
