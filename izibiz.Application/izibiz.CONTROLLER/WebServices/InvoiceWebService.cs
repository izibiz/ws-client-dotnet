using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using izibiz.MODEL.Dto;
using izibiz.SERVICES.serviceOib;
using izibiz.MODEL;

namespace izibiz.CONTROLLER.Web_Services
{
   public class InvoiceWebService
    {

        EFaturaOIBPortClient EFaturaOIBPortClient = new EFaturaOIBPortClient();



        public List<Invoices> getInvoiceList()
        {
            using (new OperationContextScope(EFaturaOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest //sistemdeki gelen efatura listesi için request parametreleri
                {
                    REQUEST_HEADER = new REQUEST_HEADERType()
                    {
                        SESSION_ID = Session.Default.id,
                        APPLICATION_NAME = "izibiz.Aplication",
                        COMPRESSED = "N"
                    },
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
                List<Invoices> invoiceList = new List<Invoices>();

                    foreach (var inv in invoiceArray)
                    {
                    //GelenFaturalar bos ya da daha once bu FaturaNumarası eklenmemisse ekle
                    if (DataListInvoice.GelenFaturalar == null || DataListInvoice.GelenFaturalar.Where(x => x.faturaNumarası == inv.ID).FirstOrDefault() == null)
                        {
                        Invoices invoice = new Invoices();
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

                if (DataListInvoice.GelenFaturalar==null)
                {
                    DataListInvoice.GelenFaturalar=invoiceList;
                }
                else
                {
                    DataListInvoice.GelenFaturalar.AddRange(invoiceList);
                }       
                return DataListInvoice.GelenFaturalar;    
            }
        }



      





    }
}
