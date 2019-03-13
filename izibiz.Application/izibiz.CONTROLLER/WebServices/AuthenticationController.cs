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

        AuthenticationServicePortClient Auth;
        REQUEST_HEADERType authRequestHeader;
        public static string sesionID;


        public AuthenticationController()
        {
            Auth = new AuthenticationServicePortClient();
        }

        private  REQUEST_HEADERType createAuthRequestHeader()
        {
            authRequestHeader = new REQUEST_HEADERType()
            {
                SESSION_ID = "-1",
                APPLICATION_NAME = "izibiz.Application",
            };
            return authRequestHeader;
        }



        public bool Login(string usurname, string password)
        {
            var req = new LoginRequest
            {
                REQUEST_HEADER = createAuthRequestHeader(),
                USER_NAME = usurname,
                PASSWORD = password
            };
            LoginResponse loginRes = Auth.Login(req);

            if (loginRes.ERROR_TYPE == null)
            {
                sesionID = loginRes.SESSION_ID;
                RequestHeader.createRequestHeader();
                return true;
            }
            else
            {
                MessageBox.Show(loginRes.ERROR_TYPE.ERROR_CODE + " " + loginRes.ERROR_TYPE.ERROR_SHORT_DES);
                return false;
            }
        }







    }
}
