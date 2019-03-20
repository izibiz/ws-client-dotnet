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

namespace izibiz.CONTROLLER.Web_Services
{
    public class EInvoiceController
    {

        private EFaturaOIBPortClient EFaturaOIBPortClient = new EFaturaOIBPortClient();
        string inboxFolder = "D:\\temp\\GELEN\\";
        INVOICE[] stateInvoice = null;
        private SqlDbConnect con;

        public EInvoiceController()
        {
            InvoiceSearchKey.createInvoiceSearchKeyGetInvoiceRequest();
            InvoiceSearchKey.createinvoiceSearchKeyGetInvoiceWithTypeRequest();
        }



        public List<Invoice> getIncomingInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.Direction.IN.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.Y.ToString();

                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);
                invoiceMarkRead(invoiceArray);


                List<Invoice> invoiceList = transferInvoiceArrayToList(invoiceArray,DataListInvoice.sentInvoices);

                if (DataListInvoice.incomingInvioces == null)
                {
                    DataListInvoice.incomingInvioces = invoiceList;
                }
                else
                {
                    DataListInvoice.incomingInvioces.AddRange(invoiceList);
                }
                return DataListInvoice.incomingInvioces;
            }
        }



        public DataTable getSentInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest();//sistemdeki gelen efatura listesi için request parametreleri

                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.Direction.OUT.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.Y.ToString();

                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);
                dbSaveInvoices(invoiceArray);
                return dbGetIncomingInvoices();
                /*
                List<Invoice> invoiceList = transferInvoiceArrayToList(invoiceArray,DataListInvoice.sentInvoices);

                if (DataListInvoice.sentInvoices == null)
                {
                    DataListInvoice.sentInvoices = invoiceList;
                }
                else
                {
                    DataListInvoice.sentInvoices.AddRange(invoiceList);
                }
                
                return DataListInvoice.sentInvoices;*/
            }
        }

        private void dbSaveInvoices(INVOICE[] invoiceArray)
        {
            con = new SqlDbConnect();
            foreach (var inv in invoiceArray)
            {
                con.sqlQuery("insert into invoices(ID,uuid,issueDate,profileid,type,suplier,sender,cDate,envelopeIdentifier,status,gibStatusCode,gibStatusDescription,from,to) " +
            "Values('"+inv.ID+ "','" + inv.UUID + "','" + inv.HEADER.ISSUE_DATE + "','" + inv.HEADER.PROFILEID + "','" + inv.HEADER.INVOICE_TYPE_CODE + "','" + inv.HEADER.SUPPLIER + "','"
            + inv.HEADER.SENDER + "','" + inv.HEADER.CDATE + "','" + inv.HEADER.ENVELOPE_IDENTIFIER + "','" + inv.HEADER.STATUS + "','" + inv.HEADER.GIB_STATUS_CODE + "','"
            + inv.HEADER.GIB_STATUS_DESCRIPTION + "','" + inv.HEADER.FROM + "',)'" + inv.HEADER.TO +"' ");
            }             
            con.nonQueryEx();  
        }

        private DataTable dbGetIncomingInvoices()
        {
            con = new SqlDbConnect();
            con.sqlQuery("select *  from invoices");
            return con.queryEx();
        }


        public List<Invoice> getDraftInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri

                req.REQUEST_HEADER = RequestHeader.requestHeader;
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.DIRECTION = EI.Direction.OUT.ToString();
                req.HEADER_ONLY = EI.ActiveOrPasive.Y.ToString();

                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);
                invoiceMarkRead(invoiceArray);
                //DB YE KAYDET
              //  dbSaveInvoices(invoiceArray);


                
                                List<Invoice> invoiceList = transferInvoiceArrayToList(invoiceArray,DataListInvoice.draftInvoices);
                                if (DataListInvoice.draftInvoices == null)
                                {
                                    DataListInvoice.draftInvoices = invoiceList;
                                }
                                else
                                {
                                    DataListInvoice.draftInvoices.AddRange(invoiceList);
                                }
                                return DataListInvoice.draftInvoices;
                            }
            }
      


        private List<Invoice> transferInvoiceArrayToList(INVOICE[] invoiceArray, List<Invoice> dataListInv)
        {
            List<Invoice> invoiceList = new List<Invoice>();
            foreach (var inv in invoiceArray)
            {
                if (dataListInv == null || dataListInv.Where(x => x.Uuid == inv.UUID) == null)
                {                                                                                          //db eklenınce mark ınvoıce calısıp if satırı kalkacak
                    Invoice invoice = new Invoice();
                    invoice.ID = inv.ID;
                    invoice.Uuid = inv.UUID;
                    invoice.issueDate = inv.HEADER.ISSUE_DATE;
                    invoice.profileid = inv.HEADER.PROFILEID;
                    invoice.type = inv.HEADER.INVOICE_TYPE_CODE;
                    invoice.supplier = inv.HEADER.SUPPLIER;
                    invoice.sender = inv.HEADER.SENDER;
                    invoice.cDate = inv.HEADER.CDATE;
                    invoice.envelopeIdentifier = inv.HEADER.ENVELOPE_IDENTIFIER;
                    invoice.status = inv.HEADER.STATUS;
                    invoice.gibStatusCode = inv.HEADER.GIB_STATUS_CODE;
                    invoice.gibSatusDescription = inv.HEADER.GIB_STATUS_DESCRIPTION;
                    invoice.from = inv.HEADER.FROM;
                    invoice.to = inv.HEADER.TO;

                    invoiceList.Add(invoice);
                }
            }
            return invoiceList;
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

        public void createInvoiceWithId(int arrayLength, string invoiceID, int i)
        {
            stateInvoice = new INVOICE[arrayLength];
            INVOICE invoice = new INVOICE();
            invoice.ID = invoiceID;
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
            }
        }


        private void ınvoiceToUnzip(INVOICE invoice)
        {
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




    }
}


