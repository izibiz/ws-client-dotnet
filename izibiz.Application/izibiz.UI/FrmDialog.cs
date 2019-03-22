using izibiz.MODEL.Model;
using izibiz.COMMON.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ubl_Invoice_2_1;
using izibiz.COMMON;

namespace izibiz.UI
{
    public partial class FrmDialog : Form
    {
        

        public FrmDialog()
        {
            InitializeComponent();
        }

    

        private void FrmShowInvoiceState_Load(object sender, EventArgs e)
        {
           
        }


        private void localizationItemTextWrite()
        {
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            InvoiceType ınvoiceType = new InvoiceType();
            createInvoiceHeader(ınvoiceType);





        }

        private void createInvoiceHeader(InvoiceType invoice)
        {
            UBLVersionIDType ublVersionId = new UBLVersionIDType();
            ublVersionId.Value = "2.1";
            invoice.UBLVersionID = ublVersionId;

            CustomizationIDType CustomizationIDType = new CustomizationIDType();
            CustomizationIDType.Value = "TR1.2";
            invoice.CustomizationID = CustomizationIDType;

            ProfileIDType ProfileIDType = new ProfileIDType();
            ProfileIDType.Value = "TEMELFATURA";
            invoice.ProfileID = ProfileIDType;

            IDType id = new IDType();
            id.Value = "YSR2015000012104";
            invoice.ID = id;

            CopyIndicatorType CopyIndicatorType = new CopyIndicatorType();
            CopyIndicatorType.Value = false;
            invoice.CopyIndicator = CopyIndicatorType;

            UUIDType UUIDType = new UUIDType();
            UUIDType.Value = System.Guid.NewGuid().ToString();
            invoice.UUID = UUIDType;

            IssueDateType issuedate = new IssueDateType();
            issuedate.Value = DateTime.Now;
            invoice.IssueDate = issuedate;

            IssueTimeType issuetime = new IssueTimeType();
            issuetime.Value = DateTime.Now;
            invoice.IssueTime = issuetime;

            InvoiceTypeCodeType InvoiceTypeCodeType = new InvoiceTypeCodeType();
            InvoiceTypeCodeType.Value = "SATIS";
            invoice.InvoiceTypeCode = InvoiceTypeCodeType;



        }


    }
}
