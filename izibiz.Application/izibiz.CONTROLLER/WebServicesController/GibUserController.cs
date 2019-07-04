using izibiz.COMMON;
using izibiz.CONTROLLER.InvoiceRequestSection;
using izibiz.SERVICES.serviceOib;
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

        private EFaturaOIBPortClient eInvoiceOIBPortClient = new EFaturaOIBPortClient();





        public List<GIBUSER> getGibUserList(string ProductType)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                GetUserListRequest req = new GetUserListRequest();

                req.REQUEST_HEADER = RequestHeader.getRequestHeaderOib;
                req.DOCUMENT_TYPE = ProductType;
                GetUserListResponse response = eInvoiceOIBPortClient.GetUserList(req);

                return response.Items.ToList();
            }
        }



    }
}
