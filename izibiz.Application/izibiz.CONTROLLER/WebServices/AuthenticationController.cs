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

       AuthenticationServicePortClient  Auth= new AuthenticationServicePortClient();
        private REQUEST_HEADERType authRequestHeader;


        public AuthenticationController()
        {
            #region createRequestHeader   
            authRequestHeader = new REQUEST_HEADERType()
            {
                SESSION_ID = "-1",
                CLIENT_TXN_ID = System.Guid.NewGuid().ToString(),
                APPLICATION_NAME = "İZİBİZ MASAUSTU V1.0",
                CHANNEL_NAME = "İZİBİZ",
                HOSTNAME = "HOST-İZİBİZ-DEFAULT"
            };
            #endregion
        }




        public string Login(string usurname, string password)
        {

            var req = new LoginRequest
                {
                REQUEST_HEADER = authRequestHeader,
                USER_NAME = usurname,
                PASSWORD = password
            };

                LoginResponse loginRes = Auth.Login(req);
                string sesionId = loginRes.SESSION_ID;

                //kullanıcı bulunmadı
                if (loginRes.ERROR_TYPE != null && loginRes.ERROR_TYPE.ERROR_CODE == 10013)
                {
                    MessageBox.Show(loginRes.ERROR_TYPE.ERROR_SHORT_DES);
                    return "no-user";
                }
                //basarılı gırıs
                else
                {
                Session.Default.id = sesionId;
                return sesionId;
                }

        }
           
           


     
        

        }
    }
