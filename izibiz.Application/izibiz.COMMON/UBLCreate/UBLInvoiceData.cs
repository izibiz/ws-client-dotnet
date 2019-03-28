using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER
{
    class UBLInvoiceData
    {

        private BaseInvoiceUBL GetUBLInvoiceData()
        {
            BaseInvoiceUBL ublInvoice = new InvoiceUBL("TICARIFATURA", "SATIS", "TRY");
            ublInvoice.SetCustInvIdDocumentReference();
            ublInvoice.SetSignature();
            ublInvoice.SetInvoiceLines(ublInvoice.GetInvoiceLines());
            switch (txtTcVkn.Text.Length)
            {
                case 10:
                    ublInvoice.SetSupplierParty(ublInvoice.GetParty(txtTcVkn.Text, "VKN"));
                    ublInvoice.SetCustomerParty(ublInvoice.GetParty(txtTcVkn.Text, "VKN"));
                    break;
                case 11:
                    ublInvoice.SetSupplierParty(ublInvoice.GetParty(txtTcVkn.Text, "TCKN"));
                    ublInvoice.SetCustomerParty(ublInvoice.GetParty(txtTcVkn.Text, "TCKN"));
                    break;
            }

            ublInvoice.SetLegalMonetaryTotal(ublInvoice.CalculateLegalMonetaryTotal());
            ublInvoice.SetTaxTotal(ublInvoice.CalculateTaxTotal());
            ublInvoice.SetAllowanceCharge(ublInvoice.CalculateAllowanceCharges());
            return ublInvoice;
        }




    }
}
