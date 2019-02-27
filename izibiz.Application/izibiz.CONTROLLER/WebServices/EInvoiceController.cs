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




        public List<Invoice> getComingInvoice()
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
                List<Invoice> invoiceList = addToModel(invoiceArray,DataListInvoice.incommingInvioces);

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
                List<Invoice> invoiceList = addToModel(invoiceArray, DataListInvoice.sentInvoices);

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
                List<Invoice> invoiceList = addToModel(invoiceArray, DataListInvoice.sentInvoices);

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



        private List<Invoice> addToModel(INVOICE[] invoiceArray,List<Invoice> dataInvoice)
        {
            List<Invoice> invoiceList = new List<Invoice>();
            foreach (var inv in invoiceArray)
            {
                //GelenFaturalar bos ya da daha once bu FaturaNumarası eklenmemisse ekle
                if (dataInvoice == null || dataInvoice.Where(x => x.faturaNumarası == inv.ID).FirstOrDefault() == null)
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
            }
            return invoiceList;

        }
    

      





    }
}
