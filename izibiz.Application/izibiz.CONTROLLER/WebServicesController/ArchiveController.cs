using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.InvoiceRequestSection;
using izibiz.CONTROLLER.Singleton;
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
    public class ArchiveController
    {

        private EFaturaArchivePortClient eArchiveInvoicePortClient = new EFaturaArchivePortClient();


        public ArchiveController()
        {
            //InvoiceSearchKey.createInvoiceSearchKeyGetInvoiceRequest();
            //InvoiceSearchKey.createinvoiceSearchKeyGetInvoiceWithTypeRequest();
        }





        public List<ArchiveInvoices> getInvoiceListOnService()
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                var req = new GetEArchiveInvoiceListRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.LIMIT = 10;
                req.REPORT_INCLUDED = true;
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();
                req.CONTENT_TYPE = EI.DocumentType.XML.ToString();
                req.READ_INCLUDED = true.ToString();

                EARCHIVEINV[] archiveArr = eArchiveInvoicePortClient.GetEArchiveInvoiceList(req).INVOICE;
                if (archiveArr.Length > 0)
                {
                    archiveMarkRead(archiveArr);
                    //getirilen faturaları db ye kaydet
                    SaveArchiveArrToDb(archiveArr);
                }
                return Singl.archiveInvoiceDalGet.getArchiveReportList();
            }
        }




        private void SaveArchiveArrToDb(EARCHIVEINV[] archiveArr)
        {
            foreach (var arc in archiveArr)
            {
                ArchiveInvoices archive = new ArchiveInvoices();

                archive.ID = arc.HEADER.INVOICE_ID;
                archive.uuid = arc.HEADER.UUID;
                archive.issueDate = Convert.ToDateTime(arc.HEADER.ISSUE_DATE);
                archive.profileid = arc.HEADER.PROFILE_ID;
                archive.invoiceType = arc.HEADER.INVOICE_TYPE;
                archive.sendingType = arc.HEADER.SENDING_TYPE;
                archive.eArchiveType = arc.HEADER.EARCHIVE_TYPE;
                archive.senderName = arc.HEADER.SENDER_NAME;
                archive.senderVkn = arc.HEADER.SENDER_IDENTIFIER;
                archive.receiverVkn = arc.HEADER.CUSTOMER_IDENTIFIER;
                archive.status = arc.HEADER.STATUS;
                archive.statusCode = arc.HEADER.STATUS_CODE;
                archive.currenyCode = arc.HEADER.CURRENCY_CODE;              
                archive.folderPath = FolderControl.inboxFolderArchive + "." + nameof(EI.DocumentType.XML);

                byte[] unCompressedContent = Compress.UncompressFile(arc.CONTENT.Value);
                archive.content = Encoding.UTF8.GetString(unCompressedContent);  //xml db de tututlur

                FolderControl.writeFileOnDiskWithString(archive.content, archive.folderPath);

                Singl.archiveInvoiceDalGet.addArchive(archive);
            }
            Singl.archiveInvoiceDalGet.dbSaveChanges();
        }




        private void archiveMarkRead(EARCHIVEINV[] ArchiveArr)
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                var markReq = new MarkEArchiveInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri

                markReq.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                markReq.MARK = new MarkEArchiveInvoiceRequestMARK();
                markReq.MARK.EARCHIVE_INVOICE = ArchiveArr;
                markReq.MARK.value = MarkEArchiveInvoiceRequestMARKValue.READ;
                markReq.MARK.valueSpecified = true;

                var markRes = eArchiveInvoicePortClient.MarkEArchiveInvoice(markReq);
            }
        }







        public void getReadFromEArchive(string invoiceUuid, string docType)
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {

                ArchiveInvoiceReadRequest req = new ArchiveInvoiceReadRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                req.INVOICEID = invoiceUuid;
                req.PORTAL_DIRECTION = nameof(EI.InvDirection.OUT);
                req.PROFILE = docType;

                base64Binary[] contentArr = eArchiveInvoicePortClient.ReadFromArchive(req).INVOICE;

                foreach (base64Binary content in contentArr)
                {
                    string contentStr = Convert.ToBase64String(content.Value);
                    //contentı yazdır
                    string filePath = FolderControl.inboxFolderArchive + "." + nameof(EI.DocumentType.ZİP);
                    FolderControl.writeFileOnDiskWithString(contentStr, filePath);
                }
            }
        }






    }
}
