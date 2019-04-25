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


namespace izibiz.CONTROLLER.Web_Services
{



    public class EInvoiceController
    {

        private EFaturaOIBPortClient eInvoiceOIBPortClient = new EFaturaOIBPortClient();
        string inboxFolder = "D:\\temp\\GELEN\\";
        List<INVOICE> invoiceList = new List<INVOICE>();





        public EInvoiceController()
        {
            InvoiceSearchKey.createInvoiceSearchKeyGetInvoiceRequest();
            InvoiceSearchKey.createinvoiceSearchKeyGetInvoiceWithTypeRequest();
        }



        public List<Invoices> getIncomingInvoice()
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeaderOib.requestHeaderOib;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.InvDirection.IN.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoiceArray = eInvoiceOIBPortClient.GetInvoice(req);
                if (invoiceArray.Length > 0)
                {
                    invoiceMarkRead(invoiceArray);
                    SaveInvoiceArrayToDb(invoiceArray, EI.InvDirection.IN.ToString());
                }
                return Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.IN));
            }
        }




        public List<Invoices> getSentInvoice()
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest();//sistemdeki gelen efatura listesi için request parametreleri

                req.REQUEST_HEADER = RequestHeaderOib.requestHeaderOib;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.InvDirection.OUT.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoiceArray = eInvoiceOIBPortClient.GetInvoice(req);
                if (invoiceArray.Length > 0)
                {
                    invoiceMarkRead(invoiceArray);
                    SaveInvoiceArrayToDb(invoiceArray, EI.InvDirection.OUT.ToString());
                }
                return Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.OUT));
            }
        }



        public List<Invoices> getDraftInvoice()
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri

                req.REQUEST_HEADER = RequestHeaderOib.requestHeaderOib;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.InvDirection.OUT.ToString();
                req.INVOICE_SEARCH_KEY.DRAFT_FLAG = EI.ActiveOrPasive.Y.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoiceArray = eInvoiceOIBPortClient.GetInvoice(req);
                if (invoiceArray.Length > 0)
                {
                    invoiceMarkRead(invoiceArray);
                    SaveInvoiceArrayToDb(invoiceArray, EI.InvDirection.DRAFT.ToString());
                }
                return Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.DRAFT));
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

                byte[] unCompressedContent=Compress.UncompressFile(inv.CONTENT.Value); 
                invoice.content = Encoding.UTF8.GetString(unCompressedContent);  //xml db de tututlur
                
                //contentı dıske yazdır pathını db ye kaydet
                invoice.folderPath=saveContentWithByte(unCompressedContent, inboxFolder, inv.ID, nameof(EI.DocumentType.XML));

                if (direction == EI.InvDirection.DRAFT.ToString())
                {
                    invoice.draftFlag = EI.ActiveOrPasive.Y.ToString();  //servisten cektıklerımız flag Y  ☺
                }
                Singl.invoiceDalGet.addInvoice(invoice);
            }
            Singl.invoiceDalGet.dbSaveChanges();
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





        public int sendInvoice(string receiverAlias)
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



        public void createInvContentCompress(string contentString)
        {
            INVOICE invoice = new INVOICE();

            base64Binary contentByte = new base64Binary();
            contentByte.Value = Compress.compressContent(contentString);
   

          //  contentByte.Value= Encoding.ASCII.GetBytes(contentString);
            invoice.CONTENT = contentByte;

            invoiceList.Add(invoice);

        }


        public string getContentNewInvId(string uuid, string direction, string newId)
        {
            return XmlSet.xmlChangeIdValue(Singl.invoiceDalGet.getInvoice(uuid, direction).content, newId);
        }





        public int loadInvoice()
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var req = new LoadInvoiceRequest();

                req.REQUEST_HEADER = RequestHeaderOib.requestHeaderOib;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.N.ToString();
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




        private void createInboxIfDoesNotExist(String inboxFolder)
        {
            if (!Directory.Exists(inboxFolder))
            {
                Directory.CreateDirectory(inboxFolder);
            }
        }





        /// <summary>
        /// web servıse ugramadan db ye ındırelen faturaların contentlerını dıske kaydeder
        /// </summary>

        public void downloadInvoice()
        {
            //db deki faturalardan dırectıon "IN"(gelen) olanların contentını alıp dıske kaydet
            List<Invoices> listInv = Singl.invoiceDalGet.getInvoiceList(nameof(EI.InvDirection.IN));
            if (listInv.Count > 0)
            {
                foreach (Invoices invoice in listInv)
                {
                    saveContentWithString(invoice.content, inboxFolder, invoice.ID, nameof(EI.DocumentType.XML));
                }
            }
        }




        //BU FONK SOR HANGISINI KULLANALIM USSTEKI MI ALLTAKI MI
        /// <summary>
        /// web servısten ınv ları xml turunde ındırır diske yazar
        /// </summary>

        //public void downloadInvoice()
        //{
        //    using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
        //    {
        //        GetInvoiceRequest req = new GetInvoiceRequest();
        //        req.REQUEST_HEADER = RequestHeader.requestHeader;
        //        req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
        //        req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
        //        req.INVOICE_SEARCH_KEY.DIRECTION = EI.InvDirection.IN.ToString();
        //        req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

        //        INVOICE[] invoiceList = EFaturaOIBPortClient.GetInvoice(req);
        //        if (invoiceList.Length > 0)
        //        {
        //            foreach (INVOICE invoice in invoiceList)
        //            {
        //                //compreslenen contentı dıske yazar
        //                saveInvoiceWithType(Compress.UncompressFile(invoice.CONTENT.Value), inboxFolder, invoice.ID, nameof(EI.DocumentType.XML));
        //                //mark ınv yapmadan once ınvlist contentını temızlıyoruz sıstemı yormamak ıcın
        //                Array.Clear(invoice.CONTENT.Value, 0, invoice.CONTENT.Value.Length);
        //            }
        //            invoiceMarkRead(invoiceList);

        //            if (invoiceList.Length == 100)
        //            {
        //                downloadInvoice();
        //            }
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
                return saveContentWithByte(invoice[0].CONTENT.Value, inboxFolder, invoice[0].ID, documentType);
            }
        }



        private string saveContentWithByte(Byte[] content, string inboxFolder, string fileName, string docType)
        {
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            System.IO.File.WriteAllBytes(inboxFolder + fileName + "." + docType, content);
            return Path.Combine(inboxFolder, fileName, "." + docType);  //return fılepath
        }



        private string saveContentWithString(string content, string inboxFolder, string fileName, string docType)
        {
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            System.IO.File.WriteAllText(inboxFolder + fileName + "." + docType, content);
            return Path.Combine(inboxFolder, fileName, "." + docType);  //return fılepath
        }




        //public byte[] getInvoiceXml(string invoiceUuid)
        //{
        //    using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
        //    {
        //        GetInvoiceWithTypeRequest req = new GetInvoiceWithTypeRequest();
        //        req.REQUEST_HEADER = RequestHeader.requestHeader;

        //        req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceWithTypeRequest;
        //        req.INVOICE_SEARCH_KEY.UUID = invoiceUuid;
        //        req.INVOICE_SEARCH_KEY.TYPE = EI.DocumentType.PDF.ToString();
        //        req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

        //        INVOICE[] invoice = EFaturaOIBPortClient.GetInvoiceWithType(req);
        //        return invoice[0].CONTENT.Value;
        //    }
        //}


        public string createInvUblToXml(InvoiceType createdUBL)
        {
            /////// DİSKE KAYDETMEK İSTERSEK ASAGIDAKI KODU ACARIZ 

            //string draftPath = "D://Taslak//";
            //createInboxIfDoesNotExist(draftPath); //dosya yolu yoksa olustur
            //inboxFolder = Path.Combine(draftPath, createdUBL.UUID.Value.ToString() + ".xml");


            //using (FileStream stream = new FileStream(inboxFolder, FileMode.Create))
            //{
            //    XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());

            //    xmlSerializer.Serialize(stream, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
            //}

            using (StringWriter textWriter = new StringWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());

                xmlSerializer.Serialize(textWriter, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
                return textWriter.ToString();
            }
        }


       



    }
}


