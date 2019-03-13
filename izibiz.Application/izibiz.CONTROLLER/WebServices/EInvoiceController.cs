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

namespace izibiz.CONTROLLER.Web_Services
{
    public class EInvoiceController
    {

        private EFaturaOIBPortClient EFaturaOIBPortClient = new EFaturaOIBPortClient();
        string inboxFolder = "D:\\temp\\GELEN\\";
      

        
  


        public List<Invoice> getIncomingInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest //sistemdeki gelen efatura listesi için request parametreleri
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    INVOICE_SEARCH_KEY = new GetInvoiceRequestINVOICE_SEARCH_KEY()
                    {
                        LIMIT = 10,
                        LIMITSpecified = true,
                        READ_INCLUDEDSpecified = true,
                        READ_INCLUDED = true
                    },
                    HEADER_ONLY = "Y"
                };
                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);
                invoiceMarkRead(invoiceArray);
                List<Invoice> invoiceList = transferInvoiceArrayToList(invoiceArray);

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



        public List<Invoice> getSentInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest //sistemdeki gelen efatura listesi için request parametreleri
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    INVOICE_SEARCH_KEY = new GetInvoiceRequestINVOICE_SEARCH_KEY()
                    {
                        LIMIT = 10,
                        LIMITSpecified = true,
                        READ_INCLUDEDSpecified = true,
                        READ_INCLUDED = true,
                        DIRECTION = "OUT"
                    },
                    HEADER_ONLY = "Y"
                };

                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);
                invoiceMarkRead(invoiceArray);          //okundu ısaretle
                List<Invoice> invoiceList = transferInvoiceArrayToList(invoiceArray);

                if (DataListInvoice.sentInvoices == null)
                {
                    DataListInvoice.sentInvoices = invoiceList;
                }
                else
                {
                    DataListInvoice.sentInvoices.AddRange(invoiceList);
                }
                return DataListInvoice.sentInvoices;
            }
        }


        public List<Invoice> getDraftInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest //sistemdeki gelen efatura listesi için request parametreleri
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    INVOICE_SEARCH_KEY = new GetInvoiceRequestINVOICE_SEARCH_KEY()
                    {
                        LIMIT = 10,
                        LIMITSpecified = true,
                        READ_INCLUDEDSpecified = true,
                        READ_INCLUDED = true,
                        DIRECTION = "OUT"
                    },
                    HEADER_ONLY = "Y"
                };
                INVOICE[] invoiceArray = EFaturaOIBPortClient.GetInvoice(req);
                invoiceMarkRead(invoiceArray);

                List<Invoice> invoiceList = transferInvoiceArrayToList(invoiceArray);
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


        private List<Invoice> transferInvoiceArrayToList(INVOICE[] invoiceArray)
        {
            List<Invoice> invoiceList = new List<Invoice>();
            foreach (var inv in invoiceArray)
            {
                if (DataListInvoice.incomingInvioces == null  ||  DataListInvoice.incomingInvioces.Where(x => x.ettn == inv.UUID) == null)
                {                                                                                          //db eklenınce mark ınvoıce calısıp if satırı kalkacak
                    Invoice invoice = new Invoice();
                    invoice.ID = inv.ID;
                    invoice.ettn = inv.UUID;
                    invoice.issueDate = inv.HEADER.ISSUE_DATE;
                    invoice.profileid = inv.HEADER.PROFILEID;
                    invoice.type = inv.HEADER.INVOICE_TYPE_CODE;
                    invoice.supplier = inv.HEADER.SUPPLIER;
                    invoice.sender = inv.HEADER.SENDER;
                    invoice.cDate = inv.HEADER.CDATE;
                    invoice.envelopeIdentifier = inv.HEADER.ENVELOPE_IDENTIFIER;
                    invoice.status = inv.HEADER.STATUS;
                    invoice.gibStatus = inv.HEADER.GIB_STATUS_CODE;
                    invoice.gibSatusDescription = inv.HEADER.GIB_STATUS_DESCRIPTION;
                    invoice.Uuid = inv.UUID;
                    invoice.from = inv.HEADER.FROM;
                    invoice.to = inv.HEADER.TO;

                    invoiceList.Add(invoice);
                }
            }
            return invoiceList;
        }

        private string invoiceMarkRead(INVOICE[] invoiceList)
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
                if (markRes.REQUEST_RETURN.RETURN_CODE == 0)
                {
                    return "succes";
                }
                else
                {
                    return "unsuccessful";
                }
            }
        }


        public string sendInvoiceResponse(string[] invoiceID, string status)
        {
            INVOICE[] arrayInvoice = new INVOICE[invoiceID.Length];
            for (int i = 0; i < invoiceID.Length; i++)
            {
                INVOICE invoice = new INVOICE();
                invoice.ID = invoiceID[i];
                arrayInvoice[i] = invoice;
            }
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                SendInvoiceResponseWithServerSignRequest req = new SendInvoiceResponseWithServerSignRequest()
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    STATUS = status,
                    INVOICE = arrayInvoice,
                };

                SendInvoiceResponseWithServerSignResponse res = EFaturaOIBPortClient.SendInvoiceResponseWithServerSign(req);
                if (res.REQUEST_RETURN.RETURN_CODE == 0)
                {
                    return "succes";
                }
                else
                {
                    return "unsuccessful";
                }
            }
        }


        public InvoiceStatus getInvoiceState(string invoiceID)
        {
            INVOICE invoice = new INVOICE();
            invoice.ID = invoiceID;

            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceStatusRequest req = new GetInvoiceStatusRequest()
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,
                    INVOICE = invoice
                };
                InvoiceStatus invoiceStatus = new InvoiceStatus();
                GetInvoiceStatusResponse res = EFaturaOIBPortClient.GetInvoiceStatus(req);

                invoiceStatus.statusID = res.INVOICE_STATUS.ID;
                invoiceStatus.status = res.INVOICE_STATUS.STATUS;
                invoiceStatus.statusDescription = res.INVOICE_STATUS.STATUS_DESCRIPTION;
                invoiceStatus.gibStatusCode = res.INVOICE_STATUS.GIB_STATUS_CODE;
                invoiceStatus.gibStatusDescription = res.INVOICE_STATUS.GIB_STATUS_DESCRIPTION;
                invoiceStatus.cDate = res.INVOICE_STATUS.CDATE;

                return invoiceStatus;
            }
        }



    


        private void createInboxIfDoesNotExist(String inboxFolder)
        {
            if (!Directory.Exists(inboxFolder))
            {
                Directory.CreateDirectory(inboxFolder);
            }              
        }


        private string saveInvoiceType(INVOICE invoice,string type)
        {
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            string filePath;
            if (type == "PDF") //uzantı neyse ona gore kaydet
            {
                filePath = inboxFolder + invoice.ID + ".pdf";


        /*        System.IO.FileStream fs = new System.IO.FileStream( inboxFolder+ "\\" + filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                byte[] ar = new byte[(int)fs.Length];
                fs.Read(ar, 0, (int)fs.Length);
                fs.Close();*/


            }
            else
            {
                filePath = inboxFolder + invoice.ID + ".xml";
            }
             
            System.IO.File.WriteAllBytes(filePath, invoice.CONTENT.Value);
            return filePath;
        }
      

        public void downloadInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceRequest req = new GetInvoiceRequest()
                {
                    REQUEST_HEADER = new REQUEST_HEADERType()
                    {
                        SESSION_ID=AuthenticationController.sesionID,
                        APPLICATION_NAME= "izibiz.Aplication",
                        COMPRESSED ="Y"
                    },
                    INVOICE_SEARCH_KEY = new GetInvoiceRequestINVOICE_SEARCH_KEY()
                    {
                        LIMIT=100,
                        READ_INCLUDED = true,
                        READ_INCLUDEDSpecified = true,
                        DIRECTION="IN"                   
                    },
                    HEADER_ONLY="N"
                };
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

                                System.IO.File.WriteAllBytes(inboxFolder + invoice.ID + ".xml",unzippedArray);
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
                GetInvoiceWithTypeRequest req = new GetInvoiceWithTypeRequest()
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,

                    INVOICE_SEARCH_KEY = new GetInvoiceWithTypeRequestINVOICE_SEARCH_KEY()
                    {
                        ID = invoiceId,
                        READ_INCLUDED = true,
                        READ_INCLUDEDSpecified = true,
                        TYPE = type//XML,PDF
                    },
                    HEADER_ONLY = "N"
                };
                INVOICE[] invoice = EFaturaOIBPortClient.GetInvoiceWithType(req);
                string filePath;
                filePath= saveInvoiceType(invoice[0],type);
                return filePath;
            }
        }


        public byte[] getInvoiceXml(string invoiceUuid)
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceWithTypeRequest req = new GetInvoiceWithTypeRequest()
                {
                    REQUEST_HEADER = RequestHeader.requestHeader,

                    INVOICE_SEARCH_KEY = new GetInvoiceWithTypeRequestINVOICE_SEARCH_KEY()
                    {
                        UUID = invoiceUuid,
                        READ_INCLUDED = true,
                        READ_INCLUDEDSpecified = true,
                        TYPE = "PDF"//XML,PDF,HTML
                    },
                    HEADER_ONLY = "N"
                };
                INVOICE[] invoice = EFaturaOIBPortClient.GetInvoiceWithType(req);
                return invoice[0].CONTENT.Value;
            }
        }




    }
    }


