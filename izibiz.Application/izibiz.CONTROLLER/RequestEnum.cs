using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER
{
   public class RequestEnum
    {
        public enum MarkInvoiceRequestMARKValue
        {
            /// <remarks/>
            READ,

            /// <remarks/>
            UNREAD,
        }
        public enum InvoiceSearchKeyDirection
        {
            IN,
            OUT
        }

        public enum SendInvoiceResponseWithServerSignRequestStatus
        {
           RED,
           KABUL
        }

        public enum RequestHeaderOnly
        {
          Y,
          N
        }

        public  enum RequestHeaderTypeCompressed
        {
           Y,
           N
        }

        public enum GetInvoiceResponseInvoiceProfileid
        {
           TEMELFATURA,
           TICARIFATURA
        }

    

        public enum InvoiceSearchKeyType
        {
           PDF,
           XML,
           HTML
        }

    }
}
