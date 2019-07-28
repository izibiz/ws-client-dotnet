using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace izibiz.COMMON.FileControl
{
    public static class Compress
    {
        private static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }


        //public static string Unzip(byte[] bytes)
        //{
        //    using (var msi = new MemoryStream(bytes))
        //    using (var mso = new MemoryStream())
        //    {
        //        using (var gs = new GZipStream(msi, CompressionMode.Decompress))
        //        {
        //            //gs.CopyTo(mso);
        //            CopyTo(gs, mso);
        //        }

        //        return Encoding.UTF8.GetString(mso.ToArray());
        //    }
        //}


        public static byte[] UncompressFile(byte[] docData)
        {
            byte[] zipsizData = { };
            MemoryStream zippedStream = new MemoryStream(docData);
            using (ZipArchive archive = new ZipArchive(zippedStream))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    MemoryStream ms = new MemoryStream();
                    Stream zipStream = entry.Open();
                    zipStream.CopyTo(ms);
                    zipsizData = ms.ToArray();
                }
            }
            return zipsizData;
        }




        public static byte[] compressFile(string xmlContent)
        {
            byte[] xml = Encoding.UTF8.GetBytes(xmlContent);

            MemoryStream zipStream = new MemoryStream();
            using (ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                ZipArchiveEntry zipElaman = zip.CreateEntry("filename" + ".xml");
                Stream entryStream = zipElaman.Open();
                entryStream.Write(xml, 0, xml.Length);
                entryStream.Flush();
                entryStream.Close();
            }
            zipStream.Position = 0;
            return zipStream.ToArray();
        }




        //public static byte[] compressContent(string xmlPath)
        //{

        //    String zipPaht = @"D:\temp\TASLAK\aaanew.zip";  //buffer gorevı gorur

        //    using (ZipArchive newFile = ZipFile.Open(zipPaht, ZipArchiveMode.Create))
        //    {
        //        newFile.CreateEntryFromFile(xmlPath, Path.GetFileName(xmlPath), CompressionLevel.Optimal);
        //        newFile.Dispose();
        //    }

        //    var xmlZipContent = File.ReadAllBytes(zipPaht);
        //    File.Delete(zipPaht);

        //    return xmlZipContent;

        //}




    }
}
