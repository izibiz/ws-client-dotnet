using izibiz.COMMON;
using izibiz.COMMON.UblSerializer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UblDespatchAdvice;
using UblInvoice;

namespace izibiz.COMMON.FileControl
{
    public class FolderControl
    {
         static string invoiceFolderInPath { get; } = "C:\\temp\\INVOICE\\GELEN\\";
         static string invoiceFolderOutPath { get; } = "C:\\temp\\INVOICE\\GİDEN\\";
         static string invoiceFolderDraftPath { get; } = "C:\\temp\\INVOICE\\TASLAK\\";
        public static string archiveFolderPath { get; } = "C:\\temp\\ARŞİV\\";
        public static string archiveFolderReportPath { get; } = "C:\\temp\\ARSIVRAPOR\\";
        static string despatchFolderInPath { get; } = "C:\\temp\\DESPATCH\\GELEN\\";
        static string despatchFolderOutPath { get; } = "C:\\temp\\DESPATCH\\GİDEN\\";
        static string despatchFolderDraftPath { get; } = "C:\\temp\\DESPATCH\\TASLAK\\";
        public static string smmFolderPath { get; } = "C:\\temp\\E-SMM\\";
        public static string smmReportPath { get; } = "C:\\temp\\E-SMM-RAPOR\\";
        public static string CreditNoteFolderPath { get; } = "C:\\temp\\E-CREDITNOTE\\";
        public static string CreditNoteReportFolderPath { get; } = "C:\\temp\\E-CREDITNOTE-RAPOR\\";


        public static void deleteFileFromPath(string path)
        {
            File.Delete(path);
        }



        public static string createInvoiceDocPath(string docName, string direction, string docType)
        {
            if (direction.Equals(nameof(EI.Direction.IN)))
            {
                return invoiceFolderInPath + docName + "." + docType;
            }
            else if (direction.Equals(nameof(EI.Direction.OUT)))
            {
                return invoiceFolderOutPath + docName + "." + docType;
            }
            else  //draft
            {
                return invoiceFolderDraftPath + docName + "." + docType;
            }
        }



        public static string createDespatchDocPath(string docName, string direction, string docType)
        {
            if (direction.Equals(nameof(EI.Direction.IN)))
            {
                return despatchFolderInPath + docName + "." + docType;
            }
            else if (direction.Equals(nameof(EI.Direction.OUT)))
            {
                return despatchFolderOutPath + docName + "." + docType;
            }
            else  //draft
            {
                return despatchFolderDraftPath + docName + "." + docType;
            }
        }





        /// <summary>
        /// DOSYA YOLU YOKSA FALSE DONDUR VE OLUSTUR
        /// </summary>
        private static bool createInboxIfDoesNotExist(string inboxFolder)
        {
            if (!Directory.Exists(inboxFolder))
            {
                Directory.CreateDirectory(inboxFolder);
                return false;
            }
            return true;
        }


        public static bool xmlFileIsInFolder(string xmlPath)
        {
            string folderPath = Path.GetDirectoryName(xmlPath);

            if (createInboxIfDoesNotExist(folderPath)) //dosya yolu varsa dosyanın ıcınden ara yoksa false dondur
            {
                var filesNameArr = Directory.GetFiles(folderPath, "*XML");  //pathın bulundugu dosyadakı xml tutundekileri  fileArr aktarır
                foreach (string file in filesNameArr)
                {
                    if (file == xmlPath)
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        public static string writeDiscInvoiceConvertUblToXml(InvoiceType createdUBL,string invoiceType)
        {
     
            //olusturulan xmli diske kaydediyor
            string xmlPath="";

            if (invoiceType == nameof(EI.Invoice.Invoices))
            {
                xmlPath = invoiceFolderDraftPath + createdUBL.ID.Value + "." + nameof(EI.DocumentType.XML);
            }
            else if (invoiceType == nameof(EI.Invoice.ArchiveInvoices))
            {
                xmlPath = archiveFolderPath + createdUBL.ID.Value + "." + nameof(EI.DocumentType.XML);
            }

            createInboxIfDoesNotExist(Path.GetDirectoryName(xmlPath)); //dosya yolu yoksa olustur

            using (FileStream stream = new FileStream(xmlPath, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());
                xmlSerializer.Serialize(stream, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
            }
            return xmlPath;
            ////
            ////xmli strıng durunde return edıyoruz contentını dondurmek ıcın  asagıdakı kodu acarız
            //using (StringWriter textWriter = new StringWriter())
            //{
            //    XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());

            //    xmlSerializer.Serialize(textWriter, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
            //    return textWriter.ToString();
            //}
        }


    
        public static string writeDiscDespatchConvertUblToXml(DespatchAdviceType createdUBL)
        {

            //olusturulan xmli diske kaydediyor
            string xmlPath = FolderControl.createDespatchDocPath(createdUBL.ID.Value, nameof(EI.Direction.DRAFT), nameof(EI.DocumentType.XML));

            createInboxIfDoesNotExist(Path.GetDirectoryName(xmlPath)); //dosya yolu yoksa olustur

            using (FileStream stream = new FileStream(xmlPath, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());
                xmlSerializer.Serialize(stream, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
            }
            return xmlPath;
            ////
            ////xmli strıng durunde return edıyoruz contentını dondurmek ıcın  asagıdakı kodu acarız
            //using (StringWriter textWriter = new StringWriter())
            //{
            //    XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());

            //    xmlSerializer.Serialize(textWriter, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
            //    return textWriter.ToString();
            //}
        }


        public static void writeFileOnDiskWithByte(byte[] fileDocContent, string filePath)
        {
            string folderPath = Path.GetDirectoryName(filePath);
            createInboxIfDoesNotExist(folderPath); //dosya yolu yoksa olustur

            System.IO.File.WriteAllBytes(filePath, fileDocContent);
        }




        public static void writeFileOnDiskWithString(string content, string filePath)
        {
            string folderPath = Path.GetDirectoryName(filePath);
            createInboxIfDoesNotExist(folderPath); //dosya yolu yoksa olustur

            System.IO.File.WriteAllText(filePath, content);
        }


        



        public static string saveInvDocContentWithByte(byte[] content, string invDirection, string fileName, string docType)
        {
            string inboxFolder;
            if (invDirection == nameof(EI.Direction.IN))
            {
                inboxFolder = invoiceFolderInPath;
            }
            else if (invDirection == nameof(EI.Direction.OUT))
            {
                inboxFolder = invoiceFolderOutPath;
            }
            else
            {
                inboxFolder = invoiceFolderDraftPath;
            }
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            System.IO.File.WriteAllBytes(inboxFolder + fileName + "." + docType, content);
            return Path.Combine(inboxFolder, fileName + "." + docType);  //return fılepath
        }



    }
}
