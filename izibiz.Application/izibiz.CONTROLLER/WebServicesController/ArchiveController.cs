using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.InvoiceRequestSection;
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


        public ArchiveController()
        {
        }


        private string getThisMonthPeriod()
        {
            string month = DateTime.Now.Month.ToString();
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            return month + DateTime.Now.Year.ToString();  //bu aya ait faturaları al
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
                req.PERIOD = getThisMonthPeriod();  //bu aya ait faturaları al
                req.REPORT_INCLUDED = true;
                req.REPORT_FLAG = EI.ActiveOrPasive.Y.ToString();
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
                return Singl.archiveInvoiceDalGet.getArchiveList();
            }
        }




        private void SaveArchiveArrToDb(EARCHIVEINV[] archiveArr)
        {
            foreach (var arc in archiveArr)
            {
                ArchiveInvoices archive = new ArchiveInvoices();

                //aynı id ve uuid sahıp faturalar gelebıldıgı ıcın unıque row olusturduk
                archive.rowUnique = arc.HEADER.INVOICE_ID + "/" + arc.HEADER.UUID + "/" + arc.HEADER.PROFILE_ID;

                //bu row unıque degerı dbye daha once eklenmemısse
                //bu kontrolu yapmamızın sebebı markRead calısmamasıdır calıstıgında kontrol kaldrılacaktır
                if (Singl.databaseContextGet.archiveInvoices.Find(archive.rowUnique) == null)
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
                    archive.reportFlag = true;  //raporluları getırdıgımız ıcın true
                    archive.folderPath = FolderControl.inboxFolderArchive + archive.uuid + "." + nameof(EI.DocumentType.XML);

                    //archive.content = Encoding.UTF8.GetString(Compress.UncompressFile(arc.CONTENT.Value));
                    //FolderControl.writeFileOnDiskWithString(archive.content, archive.folderPath);

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

                var res = eArchiveInvoicePortClient.MarkEArchiveInvoice(markReq);
            }
        }





        public List<ArchiveReports> getReportListOnService()
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                var req = new GetEArchiveReportRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;

                req.REPORT_PERIOD = getThisMonthPeriod();  //bu aya ait faturaları al    
                req.REPORT_STATUS_FLAG = EI.ActiveOrPasive.Y.ToString();

                REPORT[] reportArr = eArchiveInvoicePortClient.GetEArchiveReport(req).REPORT;

                if (reportArr != null && reportArr.Length > 0)
                {
                    //getirilen raporları db ye kaydet
                    SaveReportArrToDb(reportArr);
                    //READ REPORT YAPCAK MIYIZ
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
                    report.status = rep.REPORT_STATUS;

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
                req.READ_INCLUDED = 1.ToString();  //daha onceden cektıgımız ıcın mark ınv yapılmıstır o yuzden true

                EARCHIVEINV[] archiveArray = eArchiveInvoicePortClient.GetEArchiveInvoiceList(req).INVOICE;

                if (archiveArray.Length != 0)
                {
                    //getirilen faturanın contentını zipten cıkar,string halınde dondur
                    return Encoding.UTF8.GetString(Compress.UncompressFile(archiveArray[0].CONTENT.Value));
                }
                return null;
            }
        }




        public string getArchiveContentXml(string uuid, string rowUnique)
        {
            //db den pathı getırdı
            string xmlPath = Singl.archiveInvoiceDalGet.findArchive(rowUnique).folderPath;

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
                else if (docType == nameof(EI.DocumentType.PDF))
                {
                    req.PROFILE = "EA_CUST_PDF_SIGNED";//İmzalı PDF indirir
                }

                base64Binary[] contentArr = eArchiveInvoicePortClient.ReadFromArchive(req).INVOICE;
                if (contentArr.Length != 0)
                {
                    //contentı yazdır

                    //xml olarak ındırde ıkı kere ziplenmıs bu yuzden ıkı kere cmpres cagırmamız gerewk
                    if (docType != nameof(EI.DocumentType.PDF))
                    {
                        return Compress.UncompressFile(Compress.UncompressFile(contentArr[0].Value));
                    }

                    return Compress.UncompressFile(contentArr[0].Value);
                }
                //servisten uuid aıt content getırılemedıyse null doner
                return null;
            }
        }



        public bool cancelEarchive()
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
                    return true;
                }
                return false;
            }
        }




        public void addContentCancelArcOnCancelContentArr(string uuid, string id, decimal totalMoney)
        {
            CancelEArchiveInvoiceRequestCancelEArsivInvoiceContent contentCancel = new CancelEArchiveInvoiceRequestCancelEArsivInvoiceContent();

            contentCancel.FATURA_UUID = uuid;
            contentCancel.FATURA_ID = id;
            contentCancel.IPTAL_TARIHI = new DateTime();
            contentCancel.TOPLAM_TUTAR = totalMoney;
            contentCancel.EARSIV_CANCEL_EMAIL = Singl.userInformationDalGet.getUserInformation().mail;
            contentCancel.UPLOAD_FLAG = FLAG_VALUE.Y;  // tamamen mı ıptal edıcez

            contentCancelList.Add(contentCancel);
        }



        public EARCHIVE_INVOICE[] getArchiveStatus(string[] uuidArr)
        {
            using (new OperationContextScope(eArchiveInvoicePortClient.InnerChannel))
            {
                GetEArchiveInvoiceStatusRequest eArchiveStatus = new GetEArchiveInvoiceStatusRequest();
                eArchiveStatus.REQUEST_HEADER = RequestHeader.getRequestHeaderArchive;
                eArchiveStatus.UUID = uuidArr;

                return eArchiveInvoicePortClient.GetEArchiveInvoiceStatus(eArchiveStatus).INVOICE;
            }
        }




        public bool sendArchiveMail(string uuid, string mails)
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
                    return true;
                }
                return false;
            }
        }




    }
}
