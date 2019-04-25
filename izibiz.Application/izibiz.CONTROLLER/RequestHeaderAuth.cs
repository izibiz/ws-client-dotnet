using izibiz.COMMON;
using izibiz.CONTROLLER.Web_Services;
using izibiz.SERVICES.serviceAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER
{
    public class RequestHeaderAuth
    {

        public static REQUEST_HEADERType getRequestHeaderAuth;

        public RequestHeaderAuth()
        {
            getRequestHeaderAuth = new REQUEST_HEADERType() //default degerler ısterse degısebılır
            {
                SESSION_ID = AuthenticationController.sesionID,
                APPLICATION_NAME = "izibiz.Application",
                COMPRESSED = EI.ActiveOrPasive.Y.ToString()
            };
        }


    }
}
