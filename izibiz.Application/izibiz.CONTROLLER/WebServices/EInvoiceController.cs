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
            using(new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
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
                    invoice.faturaNumarası = inv.ID;
                    invoice.ettn = inv.UUID;
                    invoice.faturaTarihi = inv.HEADER.ISSUE_DATE;
                    invoice.senaryo = inv.HEADER.PROFILEID;
                    invoice.faturaTipi = inv.HEADER.INVOICE_TYPE_CODE;
                    invoice.gönderenUnvan = inv.HEADER.SUPPLIER;
                    invoice.gönderenVknTckn = inv.HEADER.SENDER;
                    invoice.ulastıgiTarih = inv.HEADER.CDATE;
                    invoice.zarfID = inv.HEADER.ENVELOPE_IDENTIFIER;
                    invoice.durum = inv.HEADER.STATUS;
                    invoice.gibDurum = inv.HEADER.GIB_STATUS_CODE;
                    invoice.gibDurumAciklama = inv.HEADER.GIB_STATUS_DESCRIPTION;
                    invoice.uygulamaYanitDurumu = inv.UUID;
                    invoice.gönderenGB = inv.HEADER.FROM;
                    invoice.alıcıPK = inv.HEADER.TO;

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


        public string sendInvoiceResponse(string[] invoiceID,string status)
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

                    SendInvoiceResponseWithServerSignResponse res= EFaturaOIBPortClient.SendInvoiceResponseWithServerSign(req);
                    if (res.REQUEST_RETURN.RETURN_CODE==0)
                    {
                        return "succes";
                    }
                    else
                    {
                        return "unsuccessful";
                    }
                }
            }
           


        }


    }

