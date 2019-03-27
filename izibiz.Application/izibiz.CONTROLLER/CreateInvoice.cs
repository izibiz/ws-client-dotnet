using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubl_Invoice_2_1;

namespace izibiz.CONTROLLER
{
   public class CreateInvoice
    {
        public void createInvoiceHeader(InvoiceType invoice, string profileid, string invTypeCode)
        {
            UBLVersionIDType ublVersionId = new UBLVersionIDType();
            ublVersionId.Value = "2.1";
            invoice.UBLVersionID = ublVersionId;

            CustomizationIDType CustomizationIDType = new CustomizationIDType();
            CustomizationIDType.Value = "TR1.2";
            invoice.CustomizationID = CustomizationIDType;

            ProfileIDType ProfileIDType = new ProfileIDType();
            ProfileIDType.Value = profileid;
            invoice.ProfileID = ProfileIDType;

            IDType id = new IDType();
            id.Value = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
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
            InvoiceTypeCodeType.Value = invTypeCode;
            invoice.InvoiceTypeCode = InvoiceTypeCodeType;
        }


    }
}
