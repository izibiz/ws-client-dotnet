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

namespace izibiz.CONTROLLER.Web_Services
{
    public class EInvoiceController
    {

        private EFaturaOIBPortClient EFaturaOIBPortClient = new EFaturaOIBPortClient();
        string inboxFolder = "D:\\temp\\GELEN\\";
        INVOICE[] stateInvoice = null;
        //  private SqlDbConnect con;



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
                    //  dbSaveInvoices(invoiceArray, EI.InvTableName.IncomingInvoices.ToString());
                    SaveInvoiceArrayToEntitiy(invoiceArray, Singl.databaseContextGet.Invoices, EI.InvType.INCOMING.ToString());
                }
                //return dbGetInvoices(EI.InvTableName.IncomingInvoices.ToString());
                return Singl.databaseContextGet.Invoices.Where(x => x.invType == nameof(EI.InvType.INCOMING)).ToList();
            }
        }

        private void SaveInvoiceArrayToEntitiy(INVOICE[] invoiceArray, DbSet<Invoices> entitiyInv, string type)
        {
            foreach (var inv in invoiceArray)
            {
                //getirilen fatura turu taslaksa load succed olanlar
                if ( type !=EI.InvType.DRAFT.ToString() || (inv.HEADER.STATUS.Contains(EI.StatusType.LOAD.ToString()) && inv.HEADER.STATUS.Contains(EI.SubStatusType.SUCCEED.ToString())) )
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
                    // dbSaveInvoices(invoiceArray, EI.InvTableName.SentInvoices.ToString());
                    SaveInvoiceArrayToEntitiy(invoiceArray, Singl.databaseContextGet.Invoices, EI.InvType.SENT.ToString());

                }
                //  return dbGetInvoices(EI.InvTableName.SentInvoices.ToString());
                return Singl.databaseContextGet.Invoices.Where(x => x.invType == nameof(EI.InvType.SENT)).ToList();
            }
        }

        /*  private void dbSaveInvoices(INVOICE[] invoiceArray, string tableName)
          {
              con = new SqlDbConnect();
              foreach (var inv in invoiceArray)
              {
                  con.sqlQuery("insert into " + tableName + " (ID,uuid,issueDate,profileid,type,suplier,sender,cDate,envelopeIdentifier,status,gibStatusCode,gibStatusDescription,fromm,too) " +
              "Values('" + inv.ID + "','" + inv.UUID + "','" + inv.HEADER.ISSUE_DATE + "','" + inv.HEADER.PROFILEID + "','" + inv.HEADER.INVOICE_TYPE_CODE + "','" + inv.HEADER.SUPPLIER + "','"
              + inv.HEADER.SENDER + "','" + inv.HEADER.CDATE + "','" + inv.HEADER.ENVELOPE_IDENTIFIER + "','" + inv.HEADER.STATUS + "','" + inv.HEADER.GIB_STATUS_CODE + "','"
              + inv.HEADER.GIB_STATUS_DESCRIPTION + "','" + inv.HEADER.FROM + "','" + inv.HEADER.TO + "')");

                  con.nonQueryEx();
              }
          }*/

        /*  private DataTable dbGetInvoices(string tableName)
          {
              con = new SqlDbConnect();
              con.sqlQuery("select *  from " + tableName + " ");
              return con.queryEx();
          }*/


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

                SaveInvoiceArrayToEntitiy(invoiceArray, Singl.databaseContextGet.Invoices, EI.InvType.SENT.ToString());
                // dbSaveInvoices(invoiceArray, EI.InvTableName.DraftInvoices.ToString());
                //  return dbGetInvoices(EI.InvTableName.DraftInvoices.ToString());
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

        public string sendInvAgain(string invoiceUuid)
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




    }
}


