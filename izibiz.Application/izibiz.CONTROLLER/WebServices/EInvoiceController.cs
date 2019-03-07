using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using izibiz.MODEL.Model;
using izibiz.SERVICES.serviceOib;
using izibiz.MODEL;

namespace izibiz.CONTROLLER.Web_Services
{
    public class EInvoiceController
    {

        private EFaturaOIBPortClient EFaturaOIBPortClient = new EFaturaOIBPortClient();
        private REQUEST_HEADERType requestHeader;

        public EInvoiceController()
        {
            #region createRequestHeader
            //header hepsinde aynı oldugu için contr'da olustur
            requestHeader = new REQUEST_HEADERType()
            {
                SESSION_ID = Session.Default.id,
                APPLICATION_NAME = "izibiz.Aplication",
                COMPRESSED = "N"
            };
            #endregion

        }




        public List<Invoice> getIncomingInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest //sistemdeki gelen efatura listesi için request parametreleri
                {
                    REQUEST_HEADER = requestHeader,
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

                if (DataListInvoice.incommingInvioces == null)
                {
                    DataListInvoice.incommingInvioces = invoiceList;
                }
                else
                {
                    DataListInvoice.incommingInvioces.AddRange(invoiceList);
                }
                return DataListInvoice.incommingInvioces;
            }
        }



        public List<Invoice> getSentInvoice()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest //sistemdeki gelen efatura listesi için request parametreleri
                {
                    REQUEST_HEADER = requestHeader,
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
                    REQUEST_HEADER = requestHeader,
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
            return invoiceList;

        }


        private string invoiceMarkRead(INVOICE[] invoiceList)
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var markReq = new MarkInvoiceRequest() //sistemdeki gelen efatura listesi için request parametreleri
                {
                    REQUEST_HEADER = requestHeader,
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
                    REQUEST_HEADER = requestHeader,
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
                    REQUEST_HEADER = requestHeader,
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


        public void downloadPdf(string invoiceID)
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                GetInvoiceWithTypeRequest req = new GetInvoiceWithTypeRequest()
                {
                    REQUEST_HEADER = requestHeader,

                    INVOICE_SEARCH_KEY = new GetInvoiceWithTypeRequestINVOICE_SEARCH_KEY()
                    {
                        READ_INCLUDED = false,
                        READ_INCLUDEDSpecified = true,
                        DIRECTION = "IN",
                        ID = invoiceID,
                        TYPE = "PDF"//XML,PDF,HTML
                    }
                };
         
                INVOICE[] invoiceList = EFaturaOIBPortClient.GetInvoiceWithType(req);
                foreach (INVOICE invoice in invoiceList)
                {
                  //  saveInvoiceType(invoice);
                }
            }
        }

/*
        private void saveInvoiceType(INVOICE invoice)
        {
            createInboxIfDoesNotExist(inboxFolder);
            string xmlContentStr = Encoding.UTF8.GetString(invoice.CONTENT.Value);

            //xml diske yazılıyor
            string filePath = Path.Combine(inboxFolder, invoice.ID + ".html");
            using (StreamWriter outFile = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                outFile.Write(xmlContentStr);
                outFile.Close();
            }

        }
        */



    }
}

