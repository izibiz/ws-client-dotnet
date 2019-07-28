using izibiz.COMMON;
using izibiz.CONTROLLER.Web_Services;
using izibiz.SERVICES.serviceOib;
using izibiz.SERVICES.serviceAuth;
using izibiz.SERVICES.serviceArchive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.InvoiceRequestSection
{
    public  class RequestHeader
    {


        public static SERVICES.serviceAuth.REQUEST_HEADERType getRequestHeaderAuth;
        public static SERVICES.serviceOib.REQUEST_HEADERType getRequestHeaderOib;
        public static SERVICES.serviceDespatch.REQUEST_HEADERType getRequestHeaderDespatch;
        public static SERVICES.serviceArchive.REQUEST_HEADERType getRequestHeaderArchive;
        public static SERVICES.serviceReconcilation.REQUEST_HEADERType getRequestHeaderReconcilation;






        public static void createrequestHeaderAuth()
        {
            getRequestHeaderAuth = new SERVICES.serviceAuth.REQUEST_HEADERType() //default degerler ısterse degısebılır
            {
                SESSION_ID = AuthenticationController.sesionID,
                APPLICATION_NAME = "izibiz.Application",
                COMPRESSED = EI.ActiveOrPasive.Y.ToString()
            };
        }



        public static void createRequestHeaderOib()
        {
            getRequestHeaderOib = new SERVICES.serviceOib.REQUEST_HEADERType() //default degerler ısterse degısebılır
            {
                SESSION_ID = AuthenticationController.sesionID,
                APPLICATION_NAME = "izibiz.Application",
                COMPRESSED = EI.ActiveOrPasive.Y.ToString()
            };
        }


        public static void createRequestHeaderArchive()
        {
            getRequestHeaderArchive = new SERVICES.serviceArchive.REQUEST_HEADERType() //default degerler ısterse degısebılır
            {
                SESSION_ID = AuthenticationController.sesionID,
                APPLICATION_NAME = "izibiz.Application",
                COMPRESSED = EI.ActiveOrPasive.Y.ToString()
            };
        }


        public static void createRequestHeaderDespatch()
        {
            getRequestHeaderDespatch = new SERVICES.serviceDespatch.REQUEST_HEADERType() 
            {
                SESSION_ID = AuthenticationController.sesionID,
                APPLICATION_NAME = "izibiz.Application",
                COMPRESSED = EI.ActiveOrPasive.Y.ToString()
            };
        }

        public static void createRequestHeaderReconcilation()
        {
            getRequestHeaderReconcilation = new SERVICES.serviceReconcilation.REQUEST_HEADERType()
            {
                SESSION_ID = AuthenticationController.sesionID,
                APPLICATION_NAME = "izibiz.Application",
                COMPRESSED = EI.ActiveOrPasive.Y.ToString()
            };
        }

    }
}
