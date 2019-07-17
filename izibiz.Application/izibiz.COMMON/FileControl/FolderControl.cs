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
         static string inboxInvoiceFolderIn { get; } = "C:\\temp\\INVOICE\\GELEN\\";
         static string inboxInvoiceFolderOut { get; } = "C:\\temp\\INVOICE\\GİDEN\\";
         static string inboxInvoiceFolderDraft { get; } = "C:\\temp\\INVOICE\\TASLAK\\";
        public static string inboxFolderArchive { get; } = "C:\\temp\\ARŞİV\\";
        public static string inboxFolderArchiveReport { get; } = "C:\\temp\\ARSIVRAPOR\\";
        static string inboxDespatchFolderIn { get; } = "C:\\temp\\DESPATCH\\GELEN\\";
        static string inboxDespatchFolderOut { get; } = "C:\\temp\\DESPATCH\\GİDEN\\";
        static string inboxDespatchFolderDraft { get; } = "C:\\temp\\DESPATCH\\TASLAK\\";



        public static void deleteFileFromPath(string path)
        {
            File.Delete(path);
        }



        public static string createInvoiceDocPath(string docName, string direction, string docType)
        {
            if (direction.Equals(nameof(EI.Direction.IN)))
            {
                return inboxInvoiceFolderIn + docName + "." + docType;
            }
            else if (direction.Equals(nameof(EI.Direction.OUT)))
            {
                return inboxInvoiceFolderOut + docName + "." + docType;
            }
            else  //draft
            {
                return inboxInvoiceFolderDraft + docName + "." + docType;
            }
        }



        public static string createDespatchDocPath(string docName, string direction, string docType)
        {
            if (direction.Equals(nameof(EI.Direction.IN)))
            {
                return inboxDespatchFolderIn + docName + "." + docType;
            }
            else if (direction.Equals(nameof(EI.Direction.OUT)))
            {
                return inboxDespatchFolderOut + docName + "." + docType;
            }
            else  //draft
            {
                return inboxDespatchFolderDraft + docName + "." + docType;
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
                xmlPath = inboxInvoiceFolderDraft + createdUBL.ID.Value + "." + nameof(EI.DocumentType.XML);
            }
            else if (invoiceType == nameof(EI.Invoice.ArchiveInvoices))
            {
                xmlPath = inboxFolderArchive + createdUBL.ID.Value + "." + nameof(EI.DocumentType.XML);
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
                inboxFolder = inboxInvoiceFolderIn;
            }
            else if (invDirection == nameof(EI.Direction.OUT))
            {
                inboxFolder = inboxInvoiceFolderOut;
            }
            else
            {
                inboxFolder = inboxInvoiceFolderDraft;
            }
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            System.IO.File.WriteAllBytes(inboxFolder + fileName + "." + docType, content);
            return Path.Combine(inboxFolder, fileName + "." + docType);  //return fılepath
        }



    }
}
