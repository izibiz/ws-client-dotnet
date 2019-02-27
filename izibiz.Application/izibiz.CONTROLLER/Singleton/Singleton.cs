using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using izibiz.CONTROLLER.Web_Services;

namespace izibiz.CONTROLLER.Singleton
{
   public class Singleton 
    {

        private static AuthenticationController instanceAuth = null;
        private static EInvoiceController instanceInvoice = null;
        private Singleton()
        {      
        }

        public static AuthenticationController instanceAuthGet
        {
            get
            {
                if (null == instanceAuth)
                {
                    instanceAuth = new AuthenticationController();
                }

                return instanceAuth;
            }
        }

        public static EInvoiceController instanceInvoiceGet
        {
            get
            {
                if (null == instanceInvoice)
                {
                    instanceInvoice = new EInvoiceController();
                }

                return instanceInvoice;
            }
        }


    }
}
