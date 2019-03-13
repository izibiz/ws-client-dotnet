using izibiz.CONTROLLER.Web_Services;
using izibiz.SERVICES.serviceOib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER
{
   public  class RequestHeader
    {

        public static REQUEST_HEADERType requestHeader;



        public static void createRequestHeader()
        {
            requestHeader = new REQUEST_HEADERType() //default degerler ısterse degısebılır
            {
                SESSION_ID = AuthenticationController.sesionID,
                APPLICATION_NAME = "izibiz.Application",
                COMPRESSED = "N"
            };
        }
     


    }
}
