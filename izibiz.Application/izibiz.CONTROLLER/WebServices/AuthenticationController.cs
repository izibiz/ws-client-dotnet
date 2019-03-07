using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using izibiz.SERVICES.serviceAuth;


namespace izibiz.CONTROLLER.Web_Services
{
    public class AuthenticationController
    {

        AuthenticationServicePortClient Auth = new AuthenticationServicePortClient();
        private REQUEST_HEADERType authRequestHeader;


        public AuthenticationController()
        {
            #region createRequestHeader   
            authRequestHeader = new REQUEST_HEADERType()
            {
                SESSION_ID = "-1",
                APPLICATION_NAME = "İZİBİZ MASAUSTU V1.0",
                CHANNEL_NAME = "İZİBİZ",
                HOSTNAME = "HOST-İZİBİZ-DEFAULT"
            };
            #endregion
        }




        public bool Login(string usurname, string password)
        {
            var req = new LoginRequest
            {
                REQUEST_HEADER = authRequestHeader,
                USER_NAME = usurname,
                PASSWORD = password
            };
            LoginResponse loginRes = Auth.Login(req);

            if (loginRes.SESSION_ID != null)
            {
                string sesionId = loginRes.SESSION_ID;
                Session.Default.id = sesionId;
                if(EInvoiceController.requestHeader != null)
                {
                    EInvoiceController.createRequestHeader();
                }
                return true;
            }
            else
            {
                return false;
            }       
        }







    }
}
