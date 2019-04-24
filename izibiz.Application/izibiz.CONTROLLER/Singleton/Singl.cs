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
        public static object invoiceDALGet;
        private static AuthenticationController authenticationController = null;
        private static EInvoiceController invoiceController = null;
        private static DatabaseContext databaseContext = null;
        private static InvoiceDAL invoiceDal = null;
        private static IdSerilazeDAL idSerilazeDal = null;
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


        public static IdSerilazeDAL invIdSerilazeDalGet
        {
            get
            {
                if (null == idSerilazeDal)
                {
                    idSerilazeDal = new IdSerilazeDAL();
                }

                return idSerilazeDal;
            }
        }


        public static InvoiceDAL invoiceDalGet
        {
            get
            {
                if (null == invoiceDal)
                {
                    invoiceDal = new InvoiceDAL();
                }

                return invoiceDal;
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
