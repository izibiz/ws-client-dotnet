﻿using izibiz.COMMON;
using izibiz.CONTROLLER.Web_Services;
using izibiz.SERVICES.serviceOib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.InvoiceRequestSection
{
   public  class RequestHeaderOib
    {

        public static REQUEST_HEADERType requestHeaderOib;



        public static void getRequestHeaderOib()
        {
            requestHeaderOib = new REQUEST_HEADERType() //default degerler ısterse degısebılır
            {
                SESSION_ID = AuthenticationController.sesionID,
                APPLICATION_NAME = "izibiz.Application",
                COMPRESSED = EI.ActiveOrPasive.Y.ToString()
            };
        }
     


    }
}
