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





        public enum DocumentType
        {
            PDF,
            XML,
            HTML,
            XSLT,
            ZİP
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



        public enum Invoice
        {
            Invoices,
            ArchiveInvoices,
            ID,
            uuid,
            direction,
            issueDate,
            profileid,
            invoiceType,
            suplier,
            senderVkn,
            receiverVkn,
            cDate,
            envelopeIdentifier,
            stateNote,
            state,
            status,
            statusDesc,
            gibStatusCode,
            gibStatusDescription,
            senderAlias,
            receiverAlias,
            content,
            folderPath,
            draftFlag,
            draftFlagDesc,
            //archive
            senderName,
            statusCode,
            eArchiveType,
            sendingType,
            currencyCode,
            totalAmount,
            mailStatus,
            DraftArchive,
            receiverMail,
            reportFlag,
            reportFlagDesc

        }


        public enum InvoiceProfileid
        {
            TEMELFATURA,
            TICARIFATURA,
            EARSIVFATURA
        }


        public enum InvLineGridRowClm
        {
            productName,
            quantity,
            unit,
            unitPrice,
            taxPercent,
            taxAmount,
            total
        }


        public enum UserInformation
        {
            UserInformation,
            vknTckn,
            firstName,
            familyName,
            partyName,
            mail,
            phone,
            fax,
            webUri,
            sicilNo,
            taxScheme,
            country,
            cityName,
            citySubdivisionName,
            streetName,
            buldingName,
            buldingNumber,
            postalZone
        }

        public enum ArchiveReports
        {
            ArchiveReports,
            ID,
            reportNo,
            periodStart,
            periodEnd,
            chapter,
            chapterStart,
            chapterEnd,
            archiveInvCount,
            status,
            gibSendDate,
            gibConfirmationDate,
            description
        }


        public enum InvoiceIdSerial
        {
            InvoiceIdSerials,
            serialName,
            year,
            seriNo
        }


        public enum GibUser
        {
            GibUsers,
            aliasPk,
            identifier,
            title
        }

        public enum GridBtnClmName
        {
            previewHtml,
            previewPdf
        }

        public enum InvoiceTypeCodeValue
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

        public enum Mersis
        {
            MERSISNO
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

        public enum ProductType
        {
            INVOICE,
            DESPATCHADVICE,
            ALL
        }

        public enum StateNote
        {
            CREATED,
            SENDRESPONSE,
            LOAD,
            SEND,
            CANCEL,
            IPTAL
        }


        public enum ArchiveType
        {
            NORMAL,
            INTERNET,
        }


        public enum ArchiveSendingType
        {
            ELEKTRONIK,
            KAGIT,
        }

        public enum ArchivePaymentType
        {
            KREDIKARTI_BANKAKARTI,
            EFT_HAVALE,
            KAPIDAODEME,
            DIGER
        }




    }
}
