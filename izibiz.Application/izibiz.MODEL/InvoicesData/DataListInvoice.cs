using izibiz.MODEL.Model;
using System.Collections.Generic;

namespace izibiz.MODEL
{
    public class DataListInvoice: Invoice
    {
        public static List<Invoice> incomingInvioces;
        public static List<Invoice> sentInvoices;
        public static List<Invoice> draftInvoices;
    }
}
