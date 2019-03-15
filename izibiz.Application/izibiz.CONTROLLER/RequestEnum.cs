using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER
{
   public partial class RequestEnum
    {

        public enum InvType
        {
            INCOMİNG,
            SENT
        }


        public enum InvoiceSearchKeyDirection
        {
            IN,
            OUT
        }

        public enum RequestStatus
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

        public enum StatusType
        {
            RECEIVE,
            ACCEPT,
            REJECT,
            LOAD,
            PACKAGE,
            SEND,
            ACCEPTED,
            REJECTED,
            SIGN
        }

        public enum SubStatusType
        {
            SUCCEED,
            FAILED,
            PROCESSING,
            WAIT_GIB_RESPONSE,
            WAIT_SYSTEM_RESPONSE,
            WAIT_APPLICATION_RESPONSE
        }


    }
}
