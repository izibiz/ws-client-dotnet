using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.InvoiceRequestSection;
using izibiz.CONTROLLER.Model;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbModels;
using izibiz.SERVICES.serviceArchive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.WebServicesController
{
    public class ArchiveController
    {

        private SERVICES.serviceArchive.EFaturaArchivePortClient eArchiveInvoicePortClient = new SERVICES.serviceArchive.EFaturaArchivePortClient();


        List<CancelEArchiveInvoiceRequestCancelEArsivInvoiceContent> contentCancelList = new List<CancelEArchiveInvoiceRequestCancelEArsivInvoiceContent>();
        List<ArchiveInvoiceExtendedContentINVOICE_PROPERTIES> contentPropsList = new List<ArchiveInvoiceExtendedContentINVOICE_PROPERTIES>();


        public ArchiveController()
        {
        }




        public List<ArchiveInvoices> getArchiveListOnService()
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                var req = new GetEArchiveInvoiceListRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.LIMIT = 10;
                req.LIMITSpecified = true;
                req.PERIOD = getThisMonth() + DateTime.Now.Year.ToString();
                req.REPORT_INCLUDED = true;
                req.REPORT_FLAG = EI.ActiveOrPasive.Y.ToString(); //raporlananaları alıyor
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();
                req.CONTENT_TYPE = EI.DocumentType.XML.ToString();
                req.READ_INCLUDED = false.ToString();

                EARCHIVEINV[] archiveArr = eArchiveInvoicePortClient.GetEArchiveInvoiceList(req).INVOICE;

                if (archiveArr != null && archiveArr.Length > 0)
                {
                    archiveMarkRead(archiveArr);
                    //getirilen faturaları db ye kaydet
                    SaveArchiveArrToDb(archiveArr);
                }
                return Singl.archiveInvoiceDalGet.getArchiveList(false); //db den taslak olmayanları getır
            }
        }




        private void SaveArchiveArrToDb(EARCHIVEINV[] archiveArr)
        {
            foreach (var arc in archiveArr)
            {
                ArchiveInvoices archive = new ArchiveInvoices();

              
                //bu row unıque degerı dbye daha once eklenmemısse
                if (Singl.databaseContextGet.archiveInvoices.Find(archive.uuid) == null)
                {
                    archive.ID = arc.HEADER.INVOICE_ID;
                    archive.uuid = arc.HEADER.UUID;
                    archive.totalAmount = Convert.ToDecimal(arc.HEADER.PAYABLE_AMOUNT);
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
                    archive.currencyCode = arc.HEADER.CURRENCY_CODE;
                    archive.folderPath = FolderControl.inboxFolderArchive + archive.uuid + "." + nameof(EI.DocumentType.XML);

                    archive.content = Encoding.UTF8.GetString(Compress.UncompressFile(arc.CONTENT.Value));
                    FolderControl.writeFileOnDiskWithString(archive.content, archive.folderPath);

                    Singl.archiveInvoiceDalGet.addArchive(archive);
                }
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

                eArchiveInvoicePortClient.MarkEArchiveInvoice(markReq);
            }
        }


        private string getThisMonth()
        {
            string month = DateTime.Now.Month.ToString();
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            return month;
        }



        public List<ArchiveReports> getReportListOnService()
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                var req = new GetEArchiveReportRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;

                req.REPORT_PERIOD = DateTime.Now.Year.ToString() + getThisMonth();
                req.REPORT_STATUS_FLAG = EI.ActiveOrPasive.Y.ToString();

                REPORT[] reportArr = eArchiveInvoicePortClient.GetEArchiveReport(req).REPORT;

                if (reportArr != null && reportArr.Length > 0)
                {
                    //getirilen raporları db ye kaydet
                    SaveReportArrToDb(reportArr);
                }
                return Singl.ArchiveReportsDalGet.getReportList();
            }
        }



        private void SaveReportArrToDb(REPORT[] reportArr)
        {
            foreach (var rep in reportArr)
            {
                ArchiveReports report = new ArchiveReports();

                if (Singl.databaseContextGet.archiveInvoices.Find(report.reportNo) == null)
                {
                    report.reportNo = rep.REPORT_NO;
                    report.status = rep.REPORT_SUB_STATUS;

                    Singl.ArchiveReportsDalGet.addReport(report);
                }
            }
            Singl.databaseContextGet.SaveChanges();
        }



        /// <summary>
        /// EGER DİSKE YAZDIGIM XML DOSYASI SILINMIS ISE SILINEN ARCHİVEİN CONTENTINI DISKE YAZMAK ICIN TEKRAR CAGIRIRIM
        /// </summary>
        public string getArchiveWithUuidOnService(string uuid)
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                var req = new GetEArchiveInvoiceListRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.UUID = uuid;
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();
                req.CONTENT_TYPE = EI.DocumentType.XML.ToString();
                req.READ_INCLUDED = true.ToString();  //daha onceden cektıgımız ıcın mark ınv yapılmıstır o yuzden true

                EARCHIVEINV[] archiveArray = eArchiveInvoicePortClient.GetEArchiveInvoiceList(req).INVOICE;

                if (archiveArray != null && archiveArray.Length != 0 && archiveArray[0].CONTENT != null)
                {
                    //getirilen faturanın contentını zipten cıkar,string halınde dondur
                    return Encoding.UTF8.GetString(Compress.UncompressFile(archiveArray[0].CONTENT.Value));
                }
                return null;
            }
        }




        public string getArchiveContentXml(string uuid)
        {
            //db den pathı getırdı           
            string xmlPath = Singl.archiveInvoiceDalGet.findArchive(uuid).folderPath;

            if (FolderControl.xmlFileIsInFolder(xmlPath)) // xml dosyası verılen pathde bulunuyorsa
            {
                return File.ReadAllText(xmlPath);
            }
            else
            {
                //servisten, gonderilen uuıd ye aıt faturanın contentını getır
                return getArchiveWithUuidOnService(uuid);
            }
        }



        public byte[] getReadFromEArchive(string uuid, string docType)
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                ArchiveInvoiceReadRequest req = new ArchiveInvoiceReadRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                req.INVOICEID = uuid;
                req.PORTAL_DIRECTION = nameof(EI.InvDirection.OUT);
                req.PROFILE = docType;
                if (docType == nameof(EI.DocumentType.XML))
                {
                    req.PROFILE = "EA_CUST_XML_SIGNED";//İmzalı XML indirir
                }

                var res = eArchiveInvoicePortClient.ReadFromArchive(req);
                if (res.REQUEST_RETURN != null && res.REQUEST_RETURN.RETURN_CODE == 0)
                {
                    if (res.INVOICE.Length != 0)
                    {
                        //contentı yazdır
                        //xml olarak ındırde ıkı kere ziplenmıs bu yuzden ıkı kere cmpres cagırmamız gerewk
                        if (docType != nameof(EI.DocumentType.PDF))
                        {
                            return Compress.UncompressFile(Compress.UncompressFile(res.INVOICE[0].Value));
                        }

                        return Compress.UncompressFile(res.INVOICE[0].Value);
                    }
                }
                //servisten uuid aıt content getırılemedıyse null doner
                return null;
            }
        }









        /// <summary>
        /// islem basarılıysa null doner, basarısızsa error message doner
        /// </summary>
        /// <returns></returns>
        public string cancelEarchive()
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                CancelEArchiveInvoiceRequest req = new CancelEArchiveInvoiceRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                req.CancelEArsivInvoiceContent = contentCancelList.ToArray();

                contentCancelList.Clear();

                var res = eArchiveInvoicePortClient.CancelEArchiveInvoice(req);
                if (res.REQUEST_RETURN != null && res.REQUEST_RETURN.RETURN_CODE == 0)
                {
                    return null;
                }
                return res.ERROR_TYPE.ERROR_SHORT_DES;
            }
        }




        public void addContentCancelArcOnCancelContentArr(bool reportFlag,string uuid, string id)
        {
            CancelEArchiveInvoiceRequestCancelEArsivInvoiceContent contentCancel = new CancelEArchiveInvoiceRequestCancelEArsivInvoiceContent();

            contentCancel.FATURA_UUID = uuid;
            contentCancel.FATURA_ID = id;
            contentCancel.IPTAL_TARIHI = new DateTime();
            contentCancel.EARSIV_CANCEL_EMAIL = Singl.userInformationDalGet.getUserInformation().mail;
            if (!reportFlag)//raporlanmamıssa
            {
                contentCancel.DELETE_FLAG = nameof(EI.ActiveOrPasive.Y);
            }

            contentCancelList.Add(contentCancel);
        }



        public string getArchiveStatus(string[] uuidArr)
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                GetEArchiveInvoiceStatusRequest eArchiveStatus = new GetEArchiveInvoiceStatusRequest();
                eArchiveStatus.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                eArchiveStatus.UUID = uuidArr;

                var res= eArchiveInvoicePortClient.GetEArchiveInvoiceStatus(eArchiveStatus);

                if (res.REQUEST_RETURN != null && res.REQUEST_RETURN.RETURN_CODE == 0)
                {
                    foreach (EARCHIVE_INVOICE arc in res.INVOICE)
                    {
                        Singl.archiveInvoiceDalGet.updateArchiveStatus(arc);
                    }
                    Singl.archiveInvoiceDalGet.dbSaveChanges();
                    return null;
                }

               return res.ERROR_TYPE.ERROR_SHORT_DES;           
            }
        }





        public string sendArchiveMail(string uuid, string mails)
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                GetEmailEarchiveInvoiceRequest req = new GetEmailEarchiveInvoiceRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                req.FATURA_UUID = uuid;
                req.EMAIL = mails;

                var res = eArchiveInvoicePortClient.GetEmailEarchiveInvoice(req);
                if (res.REQUEST_RETURN != null && res.REQUEST_RETURN.RETURN_CODE == 0)
                {
                    return null;
                }
                return res.ERROR_TYPE.ERROR_SHORT_DES;
            }
        }



        private string getReportSignedXml(string reportNo)
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                ReadEArchiveReportRequest req = new ReadEArchiveReportRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                req.RAPOR_NO = reportNo;//"d2103e97-a63c-4f1a-9644-138d21da2581";

                var res = eArchiveInvoicePortClient.ReadEArchiveReport(req);
                if (res.REQUEST_RETURN != null && res.REQUEST_RETURN.RETURN_CODE == 0)
                {
                    if (res.EARCHIVEREPORT[0] != null && res.EARCHIVEREPORT[0].Value != null)
                    {
                        string xmlContent = Encoding.UTF8.GetString(Compress.UncompressFile(res.EARCHIVEREPORT[0].Value));
                        return xmlContent;
                    }
                }
                return null;
            }
        }


        public string getArchiveReportXml(string reportNo)
        {
            //        reportNo= "d2103e97-a63c-4f1a-9644-138d21da2581";
            //db den pathı getırdı
            string xmlPath = FolderControl.inboxFolderArchiveReport + reportNo + "." + nameof(EI.DocumentType.XML);

            if (!FolderControl.xmlFileIsInFolder(xmlPath)) // xml dosyası verılen pathde bulunmuyorsa
            {
                // repor no ya ait servisten raporun ımzalı xmlını  getır
                return getReportSignedXml(reportNo);
            }
            else
            {
                return File.ReadAllText(xmlPath);
            }
        }


        public void addContentPropertiesToList(ArchiveContentPropertiesModel propertiesModel)
        {

            EARSIV_PROPERTIES archiveProperties = new EARSIV_PROPERTIES();
            archiveProperties.SUB_STATUS = SUB_STATUS_VALUE.NEW;
            //  archiveProperties.SERI = seriName; //burayı dıkkate almıyor neden ?
            if (propertiesModel.mail != null) //null degılse maıl gonderılmek ıstıyoddur,nullsa ıstemıyo
            {
                archiveProperties.EARSIV_EMAIL_FLAG = FLAG_VALUE.Y;
                archiveProperties.EARSIV_EMAIL = new string[] { propertiesModel.mail };
            }
            if (propertiesModel.archiveType == EARSIV_TYPE_VALUE.NORMAL.ToString())
            {
                archiveProperties.EARSIV_TYPE = EARSIV_TYPE_VALUE.NORMAL;
            }
            else
            {
                archiveProperties.EARSIV_TYPE = EARSIV_TYPE_VALUE.INTERNET;
            }

            ArchiveInvoiceExtendedContentINVOICE_PROPERTIES contentProps = new ArchiveInvoiceExtendedContentINVOICE_PROPERTIES();
            contentProps.EARSIV_PROPERTIES = archiveProperties;
            contentProps.EARSIV_FLAG = FLAG_VALUE.Y;
            contentProps.INVOICE_CONTENT = new base64Binary { Value = Compress.compressFile(propertiesModel.content) };

            contentPropsList.Add(contentProps);

        }




        public string sendEarchive()
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                ArchiveInvoiceExtendedRequest sendArchieveInvoiceRequest = new ArchiveInvoiceExtendedRequest();
                sendArchieveInvoiceRequest.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                sendArchieveInvoiceRequest.ArchiveInvoiceExtendedContent = contentPropsList.ToArray();

                contentPropsList.Clear();

               ArchiveInvoiceExtendedResponse sendInvoiceResponse = eArchiveInvoicePortClient.WriteToArchiveExtended(sendArchieveInvoiceRequest);
                if (sendInvoiceResponse.ERROR_TYPE != null)
                {
                    return sendInvoiceResponse.ERROR_TYPE.ERROR_SHORT_DES;
                }
                return null;
            }
        }





    }
}
