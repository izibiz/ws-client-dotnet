using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using izibiz.COMMON;
using izibiz.SERVICES.serviceAuth;


namespace izibiz.CONTROLLER.Web_Services
{
    public class AuthenticationController
    {

        AuthenticationServicePortClient authenticationPortClient;
        REQUEST_HEADERType authRequestHeader;
        public static string sesionID;


        public AuthenticationController()
        {
            authenticationPortClient = new AuthenticationServicePortClient();
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
            LoginResponse loginRes = authenticationPortClient.Login(req);

            if (loginRes.ERROR_TYPE == null)
            {
                sesionID = loginRes.SESSION_ID;
                RequestHeaderOib.getRequestHeaderOib();
                return true;
            }
            else
            {
                MessageBox.Show(loginRes.ERROR_TYPE.ERROR_CODE + " " + loginRes.ERROR_TYPE.ERROR_SHORT_DES);
                return false;
            }
        }



        public void getGibUserList()
        {
            using (new OperationContextScope(authenticationPortClient.InnerChannel))
            {
                GetGibUserListRequest req = new GetGibUserListRequest();

                req.REQUEST_HEADER = RequestHeaderAuth.getRequestHeaderAuth;
                req.TYPE = GetGibUserListRequestTYPE.XML;
                req.DOCUMENT_TYPE = nameof(EI.ProductType.INVOICE);

                GetGibUserListResponse getUserListRes = authenticationPortClient.GetGibUserList(req);

                //servısten cekılen verıyı db ye kaydet

            }
        }



    }
}
