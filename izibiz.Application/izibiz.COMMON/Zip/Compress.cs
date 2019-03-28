using System.IO;
using System.IO.Compression;
using System.Text;

namespace izibiz.COMMON.Zip
{
   public static class Compress
    {

        public static byte[] CompressFile(byte[] xml, object fileName)
        {


            MemoryStream zipStream = new MemoryStream();

            using (ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                ZipArchiveEntry zipElaman = zip.CreateEntry(fileName + ".xml");
                Stream entryStream = zipElaman.Open();
                entryStream.Write(xml, 0, xml.Length);
                entryStream.Flush();
                entryStream.Close();
            }
            zipStream.Position = 0;
            return zipStream.ToArray();

        }


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

    }
}
