using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using izibiz.MODEL.Models;
using izibiz.SERVICES.serviceOib;
using izibiz.MODEL;
using System.IO;
using System.IO.Compression;
using izibiz.COMMON;
using System.Data;
using izibiz.MODEL.Data;
using System.Data.Entity;
using izibiz.CONTROLLER.Singleton;
using System.Xml.Serialization;
using izibiz.COMMON.UblSerializer;
using Ubl_Invoice_2_1;
using izibiz.COMMON.Zip;
using izibiz.CONTROLLER.InvoiceRequestSection;
using izibiz.COMMON.File;

namespace izibiz.CONTROLLER.Web_Services
{



    public class EInvoiceController
    {

        private EFaturaOIBPortClient eInvoiceOIBPortClient = new EFaturaOIBPortClient();
        string inboxFolderIn { get; } = "D:\\temp\\GELEN\\";
        string inboxFolderOut { get; } = "D:\\temp\\GİDEN\\";
         string inboxFolderDraft { get; } = "D:\\temp\\TASLAK\\";
        List<INVOICE> invoiceList = new List<INVOICE>();




        public EInvoiceController()
        {
            InvoiceSearchKey.createInvoiceSearchKeyGetInvoiceRequest();
            InvoiceSearchKey.createinvoiceSearchKeyGetInvoiceWithTypeRequest();
        }



        public List<Invoices> getInvoiceListOnService(string direction)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeaderOib.requestHeaderOib;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                if (direction.Equals(nameof(EI.InvDirection.DRAFT))) //direction taslak fatura ıse
                {
                    req.INVOICE_SEARCH_KEY.DIRECTION = EI.InvDirection.OUT.ToString();
                    req.INVOICE_SEARCH_KEY.DRAFT_FLAG = EI.ActiveOrPasive.Y.ToString();
                }
                else
                {
                    req.INVOICE_SEARCH_KEY.DIRECTION = direction;
                }

                INVOICE[] invoiceArray = eInvoiceOIBPortClient.GetInvoice(req);
                if (invoiceArray.Length > 0)
                {
                    invoiceMarkRead(invoiceArray);
                    //getirilen faturaları db ye kaydet
                    SaveInvoiceArrayToDb(invoiceArray, direction);
                }
                return Singl.invoiceDalGet.getInvoiceList(direction);
            }
        }


        private void SaveInvoiceArrayToDb(INVOICE[] invoiceArray, string direction)
        {
            foreach (var inv in invoiceArray)
            {
                Invoices invoice = new Invoices();

                invoice.ID = inv.ID;
                invoice.uuid = inv.UUID;
                invoice.invType = direction;
                invoice.issueDate = inv.HEADER.ISSUE_DATE;
                invoice.profileid = inv.HEADER.PROFILEID;
                invoice.type = inv.HEADER.INVOICE_TYPE_CODE;
                invoice.suplier = inv.HEADER.SUPPLIER;
                invoice.senderVkn = inv.HEADER.SENDER;
                invoice.receiverVkn = inv.HEADER.RECEIVER;
                invoice.cDate = inv.HEADER.CDATE;
                invoice.envelopeIdentifier = inv.HEADER.ENVELOPE_IDENTIFIER;
                invoice.status = inv.HEADER.STATUS;
                invoice.statusDesc = inv.HEADER.STATUS;
                invoice.gibStatusCode = inv.HEADER.GIB_STATUS_CODE;
                invoice.gibStatusDescription = inv.HEADER.GIB_STATUS_DESCRIPTION;
                invoice.fromm = inv.HEADER.FROM;
                invoice.too = inv.HEADER.TO;

                byte[] unCompressedContent = Compress.UncompressFile(inv.CONTENT.Value);
                invoice.content = Encoding.UTF8.GetString(unCompressedContent);  //xml db de tututlur

                //contentı dıske yazdır pathını db ye kaydet
                if (direction.Equals(nameof(EI.InvDirection.IN)))//direction gelen ıse
                {
                    invoice.folderPath = saveContentWithByte(unCompressedContent, inboxFolderIn, inv.UUID, nameof(EI.DocumentType.XML));
                }
                else if (direction.Equals(nameof(EI.InvDirection.OUT)))
                {
                    invoice.folderPath = saveContentWithByte(unCompressedContent, inboxFolderOut, inv.UUID, nameof(EI.DocumentType.XML));
                }
                else
                {
                    invoice.draftFlag = EI.ActiveOrPasive.Y.ToString();  //servisten cektıklerımız flag Y  ☺
                    invoice.folderPath = saveContentWithByte(unCompressedContent, inboxFolderDraft, inv.UUID, nameof(EI.DocumentType.XML));
                }

                Singl.invoiceDalGet.addInvoice(invoice);
            }
            Singl.invoiceDalGet.dbSaveChanges();
        }



        /// <summary>
        /// EGER DİSKE YAZDIGIM XML DOSYASI SILINMIS ISE SILINEN INVOICESIN CONTENTINI DISKE YAZMAK ICIN TEKRAR CAGIRIRIM
        /// </summary>
        public string getInvoiceWithUuidOnService(string uuid, string direction)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeaderOib.requestHeaderOib;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.UUID = uuid;
                req.INVOICE_SEARCH_KEY.READ_INCLUDED = true;  //daha onceden cektıgımız ıcın mark ınv yapılmıstır o yuzden true
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                if (direction.Equals(nameof(EI.InvDirection.DRAFT))) //direction taslak fatura ıse
                {
                    req.INVOICE_SEARCH_KEY.DIRECTION = EI.InvDirection.OUT.ToString();
                    req.INVOICE_SEARCH_KEY.DRAFT_FLAG = EI.ActiveOrPasive.Y.ToString();
                }
                else
                {
                    req.INVOICE_SEARCH_KEY.DIRECTION = direction;
                }
                INVOICE[] invoiceArray = eInvoiceOIBPortClient.GetInvoice(req);

                byte[] unCompressedContent; //servisten getırılemezse content null doner

                if (invoiceArray.Length != 0)
                {
                    //getirilen faturanın contentını zipten cıkar
                    unCompressedContent = Compress.UncompressFile(invoiceArray[0].CONTENT.Value);
                    return Encoding.UTF8.GetString(unCompressedContent);
                }

                return null;
            }
        }



        private void invoiceMarkRead(INVOICE[] invoiceList)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var markReq = new MarkInvoiceRequest() //sistemdeki gelen efatura listesi için request parametreleri
                {
                    REQUEST_HEADER = RequestHeaderOib.requestHeaderOib,
                    MARK = new MarkInvoiceRequestMARK()
                    {
                        INVOICE = invoiceList,
                        value = MarkInvoiceRequestMARKValue.READ,
                        valueSpecified = true
                    }
                };
                MarkInvoiceResponse markRes = eInvoiceOIBPortClient.MarkInvoice(markReq);
            }
        }


        public void createInvContentCompress(bool withZip, string contentString)
        {
            INVOICE invoice = new INVOICE();

            base64Binary contentByte = new base64Binary();
            if (withZip) //zipli gönderilmek isteniyorsa
            {
                contentByte.Value = Compress.compressContent(contentString);
            }
            else  //zipsiz content value
            {
                contentByte.Value = Encoding.UTF8.GetBytes(contentString);
            }
            invoice.CONTENT = contentByte;

            invoiceList.Add(invoice);
        }



        public string getContentOnDisk(string uuid, string direction)
        {
            string folderPath = Singl.invoiceDalGet.getInvoice(uuid, direction).folderPath;

            if (!invoiceXmlFileIsInFolder(folderPath)) // xml dıskte bulunmuyorsa
            { 
                //servisten cekılemedıyse content db deki contentı diske kaydet
                if (getInvoiceWithUuidOnService(uuid, direction) == null)
                {                    
                    saveContentWithString(Singl.invoiceDalGet.getInvoice(uuid, direction).content, inboxFolderDraft, uuid, nameof(EI.DocumentType.XML));
                }                  
            }
            return File.ReadAllText(folderPath, Encoding.UTF8);
        }

     



        public int sendInvoice(string receiverAlias, bool isWithZip)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var req = new SendInvoiceRequest();
                req.REQUEST_HEADER = RequestHeaderOib.requestHeaderOib;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.N.ToString();
                req.SENDER = new SendInvoiceRequestSENDER();
                req.RECEIVER = new SendInvoiceRequestRECEIVER();
                req.RECEIVER.alias = receiverAlias;

                req.INVOICE = invoiceList.ToArray();

                invoiceList.Clear();

                return eInvoiceOIBPortClient.SendInvoice(req).REQUEST_RETURN.RETURN_CODE;
            }
        }



        public int loadInvoice(bool isWithZip)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var req = new LoadInvoiceRequest();

                req.REQUEST_HEADER = RequestHeaderOib.requestHeaderOib;
                if (isWithZip) //zipli gonderılmek ıstenıyorsa
                {
                    req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                }
                else //zipsiz ise
                {
                    req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.N.ToString();
                }
                req.INVOICE = invoiceList.ToArray();

                invoiceList.Clear();

                return eInvoiceOIBPortClient.LoadInvoice(req).REQUEST_RETURN.RETURN_CODE;
            }
        }



        public void sendInvoiceResponse(string status, List<string> description)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                SendInvoiceResponseWithServerSignRequest req = new SendInvoiceResponseWithServerSignRequest()
                {
                    REQUEST_HEADER = RequestHeaderOib.requestHeaderOib,
                    STATUS = status,
                    INVOICE = invoiceList.ToArray(),
                    DESCRIPTION = description.ToArray(),
                };
                invoiceList.Clear();

                eInvoiceOIBPortClient.SendInvoiceResponseWithServerSign(req);
            }
        }



        public void addInvToStateList(string uuid)
        {
            INVOICE invoice = new INVOICE();
            invoice.UUID = uuid;
            invoiceList.Add(invoice);
        }



        /*  public INVOICE[] ArrayUuidToInvoice(string[] invoiceUuid)
          {
              INVOICE[] invoiceArray = new INVOICE[invoiceUuid.Length];
              for(int i = 0; i <= invoiceUuid.Length; i++)
              {
                  INVOICE invoice = new INVOICE();
                  invoice.UUID = invoiceUuid[i];
              }
              return invoiceArray;
          }*/



        public GetInvoiceStatusResponseINVOICE_STATUS getInvoiceState(string invoiceUuid)
        {
            INVOICE invoice = new INVOICE();
            invoice.UUID = invoiceUuid;

            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                GetInvoiceStatusRequest req = new GetInvoiceStatusRequest()
                {
                    REQUEST_HEADER = RequestHeaderOib.requestHeaderOib,
                    INVOICE = invoice,
                };

                return eInvoiceOIBPortClient.GetInvoiceStatus(req).INVOICE_STATUS;
            }
        }

        /// <summary>
        /// DOSYA YOLU YOKSA FALSE DONDUR VE OLUSTUR
        /// </summary>
        private bool createInboxIfDoesNotExist(String inboxFolder)
        {
            if (!Directory.Exists(inboxFolder))
            {
                Directory.CreateDirectory(inboxFolder);
                return false;
            }
            return true;
        }


        private bool invoiceXmlFileIsInFolder(string invoiceXmlPath)
        {
            string folderPath = Path.GetDirectoryName(invoiceXmlPath);

            if (createInboxIfDoesNotExist(folderPath)) //dosya yolu varsa dosyanın ıcınden ara yoksa false dondur
            {
                var filesNameArr = Directory.GetFiles(folderPath, "*XML");
                foreach (string file in filesNameArr)
                {
                    if (file == invoiceXmlPath)
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        /// <summary>
        /// web servıse ugramadan db ye ındırelen faturaların contentlerını dıske kaydeder
        /// </summary>

        //public void writeDiskInvoice(string direction)
        //{
        //    //db deki faturalardan dırectıon "IN"(gelen) olanların contentını alıp dıske kaydet
        //    List<Invoices> listInv = Singl.invoiceDalGet.getInvoiceList(direction);
        //    if (listInv.Count > 0)
        //    {
        //        foreach (Invoices invoice in listInv)
        //        {
        //            saveContentWithString(invoice.content, inboxFolder, invoice.ID, nameof(EI.DocumentType.XML));
        //        }
        //    }
        //}






        public string getInvoiceType(string invoiceUuid, string documentType, string direction)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                GetInvoiceWithTypeRequest req = new GetInvoiceWithTypeRequest();

                req.REQUEST_HEADER = RequestHeaderOib.requestHeaderOib;

                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceWithTypeRequest;
                req.INVOICE_SEARCH_KEY.UUID = invoiceUuid;
                req.INVOICE_SEARCH_KEY.TYPE = documentType;//XML,PDF 
                req.INVOICE_SEARCH_KEY.DIRECTION = direction;
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoice = eInvoiceOIBPortClient.GetInvoiceWithType(req);
                return saveContentWithByte(invoice[0].CONTENT.Value, inboxFolderIn, invoice[0].ID, documentType);
            }
        }



        private string saveContentWithByte(Byte[] content, string inboxFolder, string fileName, string docType)
        {
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            System.IO.File.WriteAllBytes(inboxFolder + fileName + "." + docType, content);
            return Path.Combine(inboxFolder, fileName, "." + docType);  //return fılepath
        }



        public string saveContentWithString(string content, string inboxFolder, string fileName, string docType)
        {
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            System.IO.File.WriteAllText(inboxFolder + fileName + "." + docType, content);
            return Path.Combine(inboxFolder, fileName, "." + docType);  //return fılepath
        }




        //public byte[] getInvoiceXml(string invoiceUuid)
        //{
        //    using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
        //    {
        //        GetInvoiceWithTypeRequest req = new GetInvoiceWithTypeRequest();
        //        req.REQUEST_HEADER = RequestHeaderOib.requestHeaderOib;

        //        req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceWithTypeRequest;
        //        req.INVOICE_SEARCH_KEY.UUID = invoiceUuid;
        //        req.INVOICE_SEARCH_KEY.TYPE = EI.DocumentType.PDF.ToString();
        //        req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

        //        INVOICE[] invoice = eInvoiceOIBPortClient.GetInvoiceWithType(req);
        //        return invoice[0].CONTENT.Value;
        //    }
        //}


        public string createInvUblToXml(InvoiceType createdUBL)
        {

            //olusturulan xmli diske kaydediyor
            createInboxIfDoesNotExist(inboxFolderDraft); //dosya yolu yoksa olustur
            string inboxFolder = Path.Combine(inboxFolderDraft, createdUBL.UUID.Value.ToString() + "." + nameof(EI.DocumentType.XML));

            using (FileStream stream = new FileStream(inboxFolder, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());
                xmlSerializer.Serialize(stream, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
            }
            return inboxFolder;
            ////
            ////xmli strıng durunde return edıyoruz contentını db ye kaydetmek ıcın asagıdakı kodu acarız
            //using (StringWriter textWriter = new StringWriter())
            //{
            //    XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());

            //    xmlSerializer.Serialize(textWriter, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
            //    return textWriter.ToString();
            //}
        }






    }
}


