using izibiz.COMMON;
using izibiz.COMMON.UblSerializer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Ubl_Invoice_2_1;

namespace izibiz.COMMON.FileControl
{
    public class FolderControl
    {
         static string inboxFolderIn { get; } = "D:\\temp\\GELEN\\";
         static string inboxFolderOut { get; } = "D:\\temp\\GİDEN\\";
         static string inboxFolderInvoiceDraft { get; } = "D:\\temp\\TASLAK\\";
        public static string inboxFolderArchive { get; } = "D:\\temp\\ARŞİV\\";
        public static string inboxFolderArchiveReport { get; } = "D:\\temp\\ARSIVRAPOR\\";




        public static void deleteFileFromPath(string path)
        {
            File.Delete(path);
        }



        public static string createInvDocPath(string docName, string direction, string docType)
        {
            if (direction.Equals(nameof(EI.InvDirection.IN)))
            {
                return inboxFolderIn + docName + "." + docType;
            }
            else if (direction.Equals(nameof(EI.InvDirection.OUT)))
            {
                return inboxFolderOut + docName + "." + docType;
            }
            else  //draft
            {
                return inboxFolderInvoiceDraft + docName + "." + docType;
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



        public static string createInvUblToXml(InvoiceType createdUBL,string invoiceType)
        {
            //olusturulan xmli diske kaydediyor
            string xmlPath="";

            if (invoiceType == nameof(EI.Invoice.Invoices))
            {
                xmlPath = inboxFolderInvoiceDraft + createdUBL.UUID.Value + "." + nameof(EI.DocumentType.XML);
            }
            else if (invoiceType == nameof(EI.Invoice.ArchiveInvoices))
            {
                xmlPath = inboxFolderArchive + createdUBL.UUID.Value + "." + nameof(EI.DocumentType.XML);
            }

            createInboxIfDoesNotExist(Path.GetDirectoryName(xmlPath)); //dosya yolu yoksa olustur

            using (FileStream stream = new FileStream(xmlPath, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());
                xmlSerializer.Serialize(stream, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
            }
            return xmlPath;
            ////
            ////xmli strıng durunde return edıyoruz contentını dondurmek ıcın /db ye kaydetmek ıcın asagıdakı kodu acarız
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




        ////suan kullanılmıyor///
        //public static string saveXmlContentWithString(string xmlStr, string direction, string fileName)
        //{
        //    string inboxFolder;
        //    if (direction == nameof(EI.InvDirection.IN))
        //    {
        //        inboxFolder = inboxFolderIn;
        //    }
        //    else if (direction == nameof(EI.InvDirection.OUT))
        //    {
        //        inboxFolder = inboxFolderOut;
        //    }
        //    else
        //    {
        //        inboxFolder = inboxFolderDraft;
        //    }
        //    createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
        //    System.IO.File.WriteAllText(inboxFolder + fileName + "." + nameof(EI.DocumentType.XML), xmlStr);
        //    return Path.Combine(inboxFolder, fileName+ "." + nameof(EI.DocumentType.XML));  //return fılepath
        //}




        public static string saveInvDocContentWithByte(byte[] content, string invDirection, string fileName, string docType)
        {
            string inboxFolder;
            if (invDirection == nameof(EI.InvDirection.IN))
            {
                inboxFolder = inboxFolderIn;
            }
            else if (invDirection == nameof(EI.InvDirection.OUT))
            {
                inboxFolder = inboxFolderOut;
            }
            else
            {
                inboxFolder = inboxFolderInvoiceDraft;
            }
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            System.IO.File.WriteAllBytes(inboxFolder + fileName + "." + docType, content);
            return Path.Combine(inboxFolder, fileName + "." + docType);  //return fılepath
        }



    }
}
