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


        public enum Direction
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



        public enum Despatch
        {
            DespatchAdvices,
            ID,
            uuid,
            direction,
            draftFlag,
            issueDate,
            profileId,
            senderVkn,
            receiverVkn,
            cDate,
            envelopeIdentifier,
            stateNote,
            status,
            gibStatusCode,
            gibStatusDescription,
            folderPath,
            statusCode,
            issueTime,
            shipmentDate,
            shipmentTime,
            typeCode,
        }



        public enum Invoice
        {
            Invoices,
            ArchiveInvoices,
            ID,
            uuid,
            direction,
            issueDate,
            profileId,
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
        public enum ReconcilationAmountType
        {
            ALACAK,
            BORC
        }


        public enum Reconcilation
        {
            Reconcilations,
            EM,
            CM,
            uuid,
            type,
            customerID,
            period,
            cmDate,
            status,
            statusCode,
            createDate,
            email,
            emailStatusCode,
            emailStatusDesc,
            emailStatusDate,
            isSend,
            customerTitle,
            baDocPiece,
            bsDocPiece,
            baDocAmount,
            bsDocAmount,
            currentAmount,
            accountType

        }



        public enum Profileid
        {
            TEMELFATURA,
            TICARIFATURA,
            EARSIVFATURA,
            TEMELIRSALIYE
        }

      


        public enum InvLineGridRowClm
        {
            productName,
            quantity,
            unit,
            unitPrice,
            taxPercent,
            taxAmount,
            total,
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
            postalZone,
            aliasGb
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
            title,
            productType
        }

        public enum GridBtnClmName
        {
            previewHtml,
            previewPdf
        }

        public enum TypeCodeValue
        {
            SATIS,
            IADE,
            TEVKIFAT,
            ISTISNA,
            OZELMATRAH,
            IHRACKAYITLI,
            SEVK
        }

        public enum Unit
        {
            ADET,
            KILO,
            GRAM,
            PAKET,
            GUN,
            AY,
            YIL,
            HAFTA
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
