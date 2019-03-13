using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using izibiz.SERVICES.serviceOib;

namespace izibiz.CONTROLLER
{
   public class InvoiceSearchKey
    {
        public static GetInvoiceRequestINVOICE_SEARCH_KEY getInvoiceRequestInvoiceSearchKey;
        public static GetInvoiceWithTypeRequestINVOICE_SEARCH_KEY getInvoiceWithTypeRequestInvoiceSearchKey;


        public static void createGetInvoiceRequestInvoiceSearchKey()
        {
            getInvoiceRequestInvoiceSearchKey = new GetInvoiceRequestINVOICE_SEARCH_KEY() //default degerler ısterse degısebılır
            {
                LIMIT = 100,
                READ_INCLUDED = true,
                READ_INCLUDEDSpecified = true,
                DIRECTION = "IN"
            };
        }




    }
}
