using izibiz.COMMON;
using izibiz.CONTROLLER.InvoiceRequestSection;
using izibiz.MODEL.DbModels;
using izibiz.SERVICES.serviceArchive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.WebServicesController
{
  public  class ArchiveController
    {

        private EFaturaArchivePortClient eArchiveInvoicePortClient = new EFaturaArchivePortClient();


        public ArchiveController()
        {
            InvoiceSearchKey.createInvoiceSearchKeyGetInvoiceRequest();
            InvoiceSearchKey.createinvoiceSearchKeyGetInvoiceWithTypeRequest();
        }




        //public List<ArchiveInvoices> getInvoiceListOnService(bool isDraft)
        //{
        //    //using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
        //    //{
        //    //    var req = new GetEArchiveInvoiceListRequest(); //sistemdeki gelen efatura listesi için request parametreleri
        //    //    req.REQUEST_HEADER =
        //    //    req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
        //    //    req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
        //    //    req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

        //    //    if (direction.Equals(nameof(EI.InvDirection.DRAFT))) //direction taslak fatura ıse
        //    //    {
        //    //        req.INVOICE_SEARCH_KEY.DIRECTION = EI.InvDirection.OUT.ToString();
        //    //        req.INVOICE_SEARCH_KEY.DRAFT_FLAG = EI.ActiveOrPasive.Y.ToString();
        //    //    }
        //    //    else
        //    //    {
        //    //        req.INVOICE_SEARCH_KEY.DIRECTION = direction;
        //    //    }

        //    //    INVOICE[] invoiceArray = eInvoiceOIBPortClient.GetInvoice(req);
        //    //    if (invoiceArray.Length > 0)
        //    //    {
        //    //        invoiceMarkRead(invoiceArray);
        //    //        //getirilen faturaları db ye kaydet
        //    //        SaveInvoiceArrayToDb(invoiceArray, direction);
        //    //    }
        //    //    return Singl.invoiceDalGet.getInvoiceList(direction);
        //    //}
        //}











    }
}
