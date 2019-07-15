using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using izibiz.COMMON;
using izibiz.CONTROLLER.InvoiceRequestSection;
using izibiz.SERVICES.serviceAuth;


namespace izibiz.CONTROLLER.Web_Services
{
    public class AuthenticationController
    {

        AuthenticationServicePortClient authenticationPortClient;

        public static string sesionID;


        public AuthenticationController()
        {
            authenticationPortClient = new AuthenticationServicePortClient();
        }





        public bool Login(string usurname, string password)
        {
            var req = new LoginRequest
            {
                REQUEST_HEADER = new REQUEST_HEADERType
                {
                    SESSION_ID = "-1",
                    APPLICATION_NAME = "izibiz.Application",
                    COMPRESSED = EI.ActiveOrPasive.Y.ToString()
                },
                USER_NAME = usurname,
                PASSWORD = password
            };
            LoginResponse loginRes = authenticationPortClient.Login(req);

            if (loginRes.ERROR_TYPE == null)
            {
                sesionID = loginRes.SESSION_ID;
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
