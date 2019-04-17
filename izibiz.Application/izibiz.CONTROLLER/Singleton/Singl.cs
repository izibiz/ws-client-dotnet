using izibiz.CONTROLLER.Dal;
using izibiz.CONTROLLER.Web_Services;
using izibiz.MODEL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace izibiz.CONTROLLER.Singleton
{
   public class Singl
    {

        private static AuthenticationController authenticationController = null;
        private static EInvoiceController invoiceController = null;
        private static DatabaseContext databaseContext = null;
        private static InvoiceDAL InvoiceDAL = null;
        //private static CreateInvoiceUBL createInv = null;

        private Singl()
        {      
        }


        //public static CreateInvoiceUBL createInvoice
        //{
        //    get
        //    {
        //        if (null == createInv)
        //        {
        //            createInv = new CreateInvoiceUBL();
        //        }
        //        return createInv;
        //    }
        //}


        public static InvoiceDAL invoiceDALGet
        {
            get
            {
                if (null == InvoiceDAL)
                {
                    InvoiceDAL = new InvoiceDAL();
                }

                return InvoiceDAL;
            }
        }

        public static DatabaseContext databaseContextGet
        {
            get
            {
                if (null == databaseContext)
                {
                    databaseContext = new DatabaseContext();
                }

                return databaseContext;
            }
        }


        public static AuthenticationController authControllerGet
        {
            get
            {
                if (null == authenticationController)
                {
                    authenticationController = new AuthenticationController();
                }

                return authenticationController;
            }
        }

        public static EInvoiceController invoiceControllerGet
        {
            get
            {
                if (null == invoiceController)
                {
                    invoiceController = new EInvoiceController();
                }

                return invoiceController;
            }
        }


    }
}
