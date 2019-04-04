using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using izibiz.MODEL.Model;
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

namespace izibiz.CONTROLLER.Web_Services
{
    public class EInvoiceController
    {

        private EFaturaOIBPortClient EFaturaOIBPortClient = new EFaturaOIBPortClient();
        string inboxFolder = "D:\\temp\\GELEN\\";
        INVOICE[] stateInvoice = null;



        public EInvoiceController()
        {
            InvoiceSearchKey.createInvoiceSearchKeyGetInvoiceRequest();
            InvoiceSearchKey.createinvoiceSearchKeyGetInvoiceWithTypeRequest();
        }



        public List<Invoices> getIncomingInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.Direction.IN.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.Y.ToString();

                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);
                if (invoiceArray.Length > 0)
                {
                    invoiceMarkRead(invoiceArray);
                    SaveInvoiceArrayToEntitiy(invoiceArray, Singl.databaseContextGet.Invoices, EI.InvType.IN.ToString());
                }
                return Singl.databaseContextGet.Invoices.Where(x => x.invType == nameof(EI.InvType.IN)).ToList();
            }
        }

        private void SaveInvoiceArrayToEntitiy(INVOICE[] invoiceArray, DbSet<Invoices> entitiyInv, string type)
        {
            foreach (var inv in invoiceArray)
            {
                //db de aynı uuid ve aynı type ınv varsa ekleme
                if (Singl.databaseContextGet.Invoices.Where(x => x.Uuid == inv.UUID && x.invType == type).FirstOrDefault() == null )
                {
                    Invoices invoiceMaster = new Invoices();

                    invoiceMaster.ID = inv.ID;
                    invoiceMaster.Uuid = inv.UUID;
                    invoiceMaster.invType = type;
                    invoiceMaster.issueDate = inv.HEADER.ISSUE_DATE;
                    invoiceMaster.profileid = inv.HEADER.PROFILEID;
                    invoiceMaster.type = inv.HEADER.INVOICE_TYPE_CODE;
                    invoiceMaster.suplier = inv.HEADER.SUPPLIER;
                    invoiceMaster.sender = inv.HEADER.SENDER;
                    invoiceMaster.cDate = inv.HEADER.CDATE;
                    invoiceMaster.envelopeIdentifier = inv.HEADER.ENVELOPE_IDENTIFIER;
                    invoiceMaster.status = inv.HEADER.STATUS;
                    invoiceMaster.statusDesc = inv.HEADER.STATUS;
                    invoiceMaster.gibStatusCode = inv.HEADER.GIB_STATUS_CODE;
                    invoiceMaster.gibStatusDescription = inv.HEADER.GIB_STATUS_DESCRIPTION;
                    invoiceMaster.fromm = inv.HEADER.FROM;
                    invoiceMaster.too = inv.HEADER.TO;

                    entitiyInv.Add(invoiceMaster);
                    changeDb = true;
                }
            }

                Singl.databaseContextGet.SaveChanges();
         
        }




        public List<Invoices> getSentInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest();//sistemdeki gelen efatura listesi için request parametreleri

                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.Direction.OUT.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.Y.ToString();

                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);
                if (invoiceArray.Length > 0)
                {
                    invoiceMarkRead(invoiceArray);
                    SaveInvoiceArrayToEntitiy(invoiceArray, Singl.databaseContextGet.Invoices, EI.InvType.OUT.ToString());
                }

                return Singl.databaseContextGet.Invoices.Where(x => x.invType == nameof(EI.InvType.OUT)).ToList();
            }
        }

      


        public List<Invoices> getDraftInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri

                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.Direction.OUT.ToString();
                req.INVOICE_SEARCH_KEY.DRAFT_FLAG = EI.ActiveOrPasive.Y.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.Y.ToString();

                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);

                var draft = invoiceArray.Where(x => x.HEADER.STATUS.Contains(EI.StatusType.LOAD.ToString()) 
                && x.HEADER.STATUS.Contains(EI.SubStatusType.SUCCEED.ToString()));

                SaveInvoiceArrayToEntitiy(invoiceArray, Singl.databaseContextGet.Invoices, EI.InvType.OUT.ToString());
                return Singl.databaseContextGet.Invoices.Where(x => x.invType == EI.InvType.DRAFT.ToString()).ToList();
            }
        }



        private void invoiceMarkRead(INVOICE[] invoiceList)
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var markReq = new MarkInvoiceRequest() //sistemdeki gelen efatura listesi için request parametreleri
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    MARK = new MarkInvoiceRequestMARK()
                    {
                        INVOICE = invoiceList,
                        value = MarkInvoiceRequestMARKValue.READ,
                        valueSpecified = true
                    }
                };
                MarkInvoiceResponse markRes = EFaturaOIBPortClient.MarkInvoice(markReq);
            }
        }


        public void sendInvoiceResponse(string status, string[] description)
        {

            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                SendInvoiceResponseWithServerSignRequest req = new SendInvoiceResponseWithServerSignRequest()
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    STATUS = status,
                    INVOICE = stateInvoice,
                    DESCRIPTION = description
                };

                SendInvoiceResponseWithServerSignResponse res = EFaturaOIBPortClient.SendInvoiceResponseWithServerSign(req);
                stateInvoice = null;
            }
        }

        public void createInvoiceWithUuid(int arrayLength, string invoiceUuid, int i)
        {
            stateInvoice = new INVOICE[arrayLength];
            INVOICE invoice = new INVOICE();
            invoice.UUID = invoiceUuid;
            stateInvoice[i] = invoice;
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



        public string getInvoiceState(string invoiceUuid)
        {
            INVOICE invoice = new INVOICE();
            invoice.UUID = invoiceUuid;

            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceStatusRequest req = new GetInvoiceStatusRequest()
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    INVOICE = invoice,
                };

                GetInvoiceStatusResponse res = EFaturaOIBPortClient.GetInvoiceStatus(req);
                return res.INVOICE_STATUS.STATUS;
            }
        }

        public string sendInvAgain(string[] invoiceUuid)
        {
            INVOICE[] invoices = new INVOICE[invoiceUuid.Length];
            for (int i=0;i<invoiceUuid.Length;i++)
            {
                invoices[i].UUID = invoiceUuid[i];
            }
      

            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                LoadInvoiceRequest req = new LoadInvoiceRequest()
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    INVOICE = invoices,
                    
                };

                LoadInvoiceResponse res = EFaturaOIBPortClient.LoadInvoice(req);
                return res.REQUEST_RETURN.CLIENT_TXN_ID;
            }
        }


        private void createInboxIfDoesNotExist(String inboxFolder)
        {
            if (!Directory.Exists(inboxFolder))
            {
                Directory.CreateDirectory(inboxFolder);
            }
        }


        private string saveInvoiceType(INVOICE invoice, string type)
        {
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            string filePath;
            filePath = inboxFolder + invoice.ID + "." + type;

            System.IO.File.WriteAllBytes(filePath, invoice.CONTENT.Value);
            return filePath;
        }


        public void downloadInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceRequest req = new GetInvoiceRequest();

                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.Direction.IN.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoiceList = EFaturaOIBPortClient.GetInvoice(req);
                foreach (INVOICE invoice in invoiceList)
                {
                    ınvoiceToUnzip(invoice);
                }
                invoiceMarkRead(invoiceList);
                if (invoiceList.Length == 100)
                {
                    downloadInvoice();
                }
            }
        }


        private void ınvoiceToUnzip(INVOICE invoice)
        {
            //invoice daha 
            byte[] content = invoice.CONTENT.Value;
            using (var zippedStream = new MemoryStream(content))
            {
                using (var archive = new ZipArchive(zippedStream))
                {
                    var entry = archive.Entries.FirstOrDefault();
                    if (entry != null)
                    {
                        using (var unzippedEntryStream = entry.Open())
                        {
                            using (var ms = new MemoryStream())
                            {
                                unzippedEntryStream.CopyTo(ms);
                                var unzippedArray = ms.ToArray();

                                System.IO.File.WriteAllBytes(inboxFolder + invoice.ID + ".xml", unzippedArray);
                            }
                        }
                    }
                }
            }
        }



        public string getInvoiceType(string invoiceId, string type)
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceWithTypeRequest req = new GetInvoiceWithTypeRequest();

                req.REQUEST_HEADER = RequestHeader.requestHeader;

                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceWithTypeRequest;
                req.INVOICE_SEARCH_KEY.ID = invoiceId;
                req.INVOICE_SEARCH_KEY.TYPE = type;//XML,PDF 
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoice = EFaturaOIBPortClient.GetInvoiceWithType(req);
                string filePath;
                filePath = saveInvoiceType(invoice[0], type);
                return filePath;
            }
        }


        public byte[] getInvoiceXml(string invoiceUuid)
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceWithTypeRequest req = new GetInvoiceWithTypeRequest();
                req.REQUEST_HEADER = RequestHeader.requestHeader;

                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceWithTypeRequest;
                req.INVOICE_SEARCH_KEY.UUID = invoiceUuid;
                req.INVOICE_SEARCH_KEY.TYPE = EI.InvoiceDownloadType.PDF.ToString();

                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoice = EFaturaOIBPortClient.GetInvoiceWithType(req);
                return invoice[0].CONTENT.Value;
            }
        }


        public void CreateInvoiceXml(CreateInvoiceUBL invoice)
        {
            var createdUBL = invoice.BaseUBL;  // Fatura UBL i oluşturulur

            inboxFolder = Path.Combine("D:/", createdUBL.UUID.Value.ToString() + ".xml");
            using (FileStream stream=new FileStream(inboxFolder, FileMode.Create))
            {
                XmlSerializer x = new XmlSerializer(createdUBL.GetType());
                x.Serialize(stream, createdUBL, InvoiceSerializer.SerializerNamespace);   
            }
        }




    }
}


