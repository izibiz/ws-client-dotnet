using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using izibiz.SERVICES.serviceOib;

namespace izibiz.CONTROLLER.InvoiceRequestSection
{
   public class InvoiceSearchKey
    {
        public static GetInvoiceRequestINVOICE_SEARCH_KEY invoiceSearchKeyGetInvoiceRequest;
        public static GetInvoiceWithTypeRequestINVOICE_SEARCH_KEY invoiceSearchKeyGetInvoiceWithTypeRequest;


        public static void createInvoiceSearchKeyGetInvoiceRequest()
        {
            invoiceSearchKeyGetInvoiceRequest = new GetInvoiceRequestINVOICE_SEARCH_KEY() //default degerler ısterse degısebılır
            {
                LIMIT = 10,
                LIMITSpecified =true,
                READ_INCLUDED = true,
                READ_INCLUDEDSpecified = true,              
            };
        }


        public static void createinvoiceSearchKeyGetInvoiceWithTypeRequest()
        {
            invoiceSearchKeyGetInvoiceWithTypeRequest = new GetInvoiceWithTypeRequestINVOICE_SEARCH_KEY() //default degerler ısterse degısebılır
            {
                LIMIT = 10,
                LIMITSpecified = true,
                READ_INCLUDED = false,
                READ_INCLUDEDSpecified = false,          
            };
        }

    }
}
