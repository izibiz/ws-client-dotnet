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
         static string inboxFolderDraft { get; } = "D:\\temp\\TASLAK\\";


        public static void deleteFileFromPath(string path)
        {
            File.Delete(path);
        }



        public static string createXmlPath(string xmlName, string direction)
        {
            if (direction.Equals(nameof(EI.InvDirection.IN)))
            {
                return Path.Combine(inboxFolderIn+ xmlName + "." + nameof(EI.DocumentType.XML));
            }
            else if (direction.Equals(nameof(EI.InvDirection.OUT)))
            {
                return Path.Combine(inboxFolderOut + xmlName + "." + nameof(EI.DocumentType.XML));
            }
            else //draft
            {
                return Path.Combine(inboxFolderDraft +xmlName + "." + nameof(EI.DocumentType.XML));
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



        public static string createInvUblToXml(InvoiceType createdUBL)
        {
            //olusturulan xmli diske kaydediyor
            createInboxIfDoesNotExist(inboxFolderDraft); //dosya yolu yoksa olustur

            string inboxFolder = createXmlPath(createdUBL.UUID.Value, nameof(EI.InvDirection.DRAFT));


            using (FileStream stream = new FileStream(inboxFolder, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());
                xmlSerializer.Serialize(stream, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
            }
            return inboxFolder;
            ////
            ////xmli strıng durunde return edıyoruz contentını db ye kaydetmek ıcın asagıdakı kodu acarız
            //using (StringWriter textWriter = new StringWriter())
            //{
            //    XmlSerializer xmlSerializer = new XmlSerializer(createdUBL.GetType());

            //    xmlSerializer.Serialize(textWriter, createdUBL, InvoiceSerializer.GetXmlSerializerNamespace());
            //    return textWriter.ToString();
            //}
        }




        public static void writeFileOnDiskWithByte(byte[] fileDoc, string filePath)
        {
            string folderPath = Path.GetDirectoryName(filePath);
            createInboxIfDoesNotExist(folderPath); //dosya yolu yoksa olustur
            System.IO.File.WriteAllBytes(filePath, fileDoc);
        }




        public static void writeFileOnDiskWithString(string fileDoc, string filePath)
        {
            string folderPath = Path.GetDirectoryName(filePath);
            createInboxIfDoesNotExist(folderPath); //dosya yolu yoksa olustur
            System.IO.File.WriteAllText(filePath, fileDoc);
        }




        //suan kullanılmıyor///
        public static string saveXmlContentWithString(string xmlStr, string direction, string fileName)
        {
            string inboxFolder;
            if (direction == nameof(EI.InvDirection.IN))
            {
                inboxFolder = inboxFolderIn;
            }
            else if (direction == nameof(EI.InvDirection.OUT))
            {
                inboxFolder = inboxFolderOut;
            }
            else
            {
                inboxFolder = inboxFolderDraft;
            }
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            System.IO.File.WriteAllText(inboxFolder + fileName + "." + nameof(EI.DocumentType.XML), xmlStr);
            return Path.Combine(inboxFolder, fileName+ "." + nameof(EI.DocumentType.XML));  //return fılepath
        }


        public static string saveInvDocContentWithByte(byte[] content, string direction, string fileName,string docType)
        {
            string inboxFolder;
            if (direction == nameof(EI.InvDirection.IN))
            {
                inboxFolder = inboxFolderIn;
            }
            else if (direction == nameof(EI.InvDirection.OUT))
            {
                inboxFolder = inboxFolderOut;
            }
            else
            {
                inboxFolder = inboxFolderDraft;
            }
            createInboxIfDoesNotExist(inboxFolder); //dosya yolu yoksa olustur
            System.IO.File.WriteAllBytes(inboxFolder + fileName + "." + docType, content);
            return Path.Combine(inboxFolder, fileName+ "." + docType);  //return fılepath
        }



    }
}
