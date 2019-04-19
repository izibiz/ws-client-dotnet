using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.COMMON
{
   public partial class EI

    {
     

        public enum InvDirection
        {
            IN,
            OUT,
            DRAFT
        }



        public enum InvoiceResponseStatus
        {
           RED,
           KABUL
        }

        public enum ActiveOrPasive
        {
          Y,
          N
        }

      

        public enum InvoiceProfileid
        {
           TEMELFATURA,
           TICARIFATURA
        }

    

        public enum DocumentType
        {
           PDF,
           XML,
           HTML,
           XSLT
        }

        public enum StatusType
        {
            RECEIVE,
            ACCEPT,
            REJECT,
            LOAD,
            PACKAGE,
            SEND,
            ACCEPTED,
            REJECTED,
            SIGN,
            CREATED//bunu ben ekledım yenı olusturulan taslak faturalar ıcın
        }

        public enum SubStatusType
        {
            SUCCEED,
            FAILED,
            PROCESSING,
            WAIT_GIB_RESPONSE,
            WAIT_SYSTEM_RESPONSE,
            WAIT_APPLICATION_RESPONSE
        }

    

        public enum InvClmName
        {
            ID,
            uuid,
            invType,
            issueDate,
            profileid,
            type,
            suplier,
            senderVkn,
            receiverVkn,
            cDate,
            envelopeIdentifier,
            status,
            statusDesc,
            gibStatusCode,
            gibStatusDescription,
            fromm,
            too,
            content,
            draftFlag
        }

        public enum gridBtnClmName
        {
            previewXml,
            previewPdf
        }

        public enum invoiceTypeCodeValue
        {
            SATIS,
            IADE,
            TEVKİFAT,
            ISTISNA,
            OZELMATRAH,
            IHRACKAYITLI
        }

        public enum Unit
        {
            ADET,
            KILO,
            GRAM,
            PAKET
        }

        public enum CurrencyCode
        {
            USD,
            TRY
        }
   

        public enum TaxType
        {
            KDV
        }

        public enum VknTckn
        {
            VKN,
            TCKN
        }
    }
}
