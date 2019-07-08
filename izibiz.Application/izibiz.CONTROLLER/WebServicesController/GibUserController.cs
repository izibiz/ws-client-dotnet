using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.InvoiceRequestSection;
using izibiz.SERVICES.serviceAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.WebServicesController
{
    public class GibUserController
    {

        private AuthenticationServicePortClient authenticationPortClient = new AuthenticationServicePortClient();


        public GibUserController()
        {
            RequestHeader.createrequestHeaderAuth();
        }


        public void getGibUserList(string ProductType)
        {
            using (new OperationContextScope(authenticationPortClient.InnerChannel))
            {
                GetGibUserListRequest req = new GetGibUserListRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderAuth;
                req.DOCUMENT_TYPE = ProductType;
                req.REGISTER_TIME_START = DateTime.Now;
                GetGibUserListResponse response = authenticationPortClient.GetGibUserList(req);

                base64Binary content = (base64Binary)response.Item;

                if (content.Value != null)
                {
                    byte[] unCompressedContent = Compress.UncompressFile(content.Value);
                    string f = Encoding.UTF8.GetString(unCompressedContent);
              //      System.IO.File.WriteAllText("D:\\Y",f);
                    int i = 0;
                }



            }
        }





    }
}
