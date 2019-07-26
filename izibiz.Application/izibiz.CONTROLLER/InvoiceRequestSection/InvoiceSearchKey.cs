using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using izibiz.SERVICES.serviceOib;
using izibiz.SERVICES.serviceDespatch;


namespace izibiz.CONTROLLER.InvoiceRequestSection
{
   public class InvoiceSearchKey
    {

        public static GetInvoiceRequestINVOICE_SEARCH_KEY invoiceSearchKeyGetInvoice;
        public static GetInvoiceWithTypeRequestINVOICE_SEARCH_KEY invoiceSearchKeyGetInvoiceWithType;
        public static GetDespatchAdviceRequestSEARCH_KEY invoiceSearchKeyGetDespatch;
      


        public static void createInvoiceSearchKeyGetInvoiceRequest()
        {
            invoiceSearchKeyGetInvoice = new GetInvoiceRequestINVOICE_SEARCH_KEY() //default degerler ısterse degısebılır
            {
                LIMIT = 10,
                LIMITSpecified =true,
                READ_INCLUDED = true,
                READ_INCLUDEDSpecified = true,              
            };
        }


        public static void createinvoiceSearchKeyGetInvoiceWithTypeRequest()
        {
            invoiceSearchKeyGetInvoiceWithType = new GetInvoiceWithTypeRequestINVOICE_SEARCH_KEY() //default degerler ısterse degısebılır
            {
                LIMIT = 10,
                LIMITSpecified = true,
                READ_INCLUDED = true,
                READ_INCLUDEDSpecified = true,          
            };
        }


        public static void createDespatchSearchKey()
        {
            invoiceSearchKeyGetDespatch = new GetDespatchAdviceRequestSEARCH_KEY() //default degerler ısterse degısebılır
            {
                LIMIT = 10,
                LIMITSpecified = true,
                READ_INCLUDED = true,
                READ_INCLUDEDSpecified = true,
            };
        }


    }
}
