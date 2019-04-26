using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace izibiz.COMMON.File
{
   public static class Compress
    {

        //public static byte[] CompressFile(byte[] xml, object fileName)
        //{

        //    MemoryStream zipStream = new MemoryStream();

        //    using (ZipArchive zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
        //    {
        //        ZipArchiveEntry zipElaman = zip.CreateEntry(fileName + ".xml");
        //        Stream entryStream = zipElaman.Open();
        //        entryStream.Write(xml, 0, xml.Length);
        //        entryStream.Flush();
        //        entryStream.Close();
        //    }
        //    zipStream.Position = 0;
        //    return zipStream.ToArray();

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


        public static byte[] compressContent(string uncompressedString)
        {
            using (var uncompressedStream = new MemoryStream(Encoding.UTF8.GetBytes(uncompressedString)))
            {
                var compressedStream = new MemoryStream();
      
                using (var compressorStream = new DeflateStream(compressedStream, CompressionLevel.Fastest, true))
                {
                    uncompressedStream.CopyTo(compressorStream);
                }

                return compressedStream.ToArray();
            };
        }




        //    private void invoiceSaveToUnzip(byte[] content, string fileName)
        //    {
        //        using (var zippedStream = new MemoryStream(content))
        //        {
        //            using (var archive = new ZipArchive(zippedStream))
        //            {
        //                var entry = archive.Entries.FirstOrDefault();
        //                if (entry != null)
        //                {
        //                    using (var unzippedEntryStream = entry.Open())
        //                    {
        //                        using (var ms = new MemoryStream())
        //                        {
        //                            unzippedEntryStream.CopyTo(ms);
        //                            var unzippedArray = ms.ToArray();

        //                            System.IO.File.WriteAllBytes(inboxFolder + fileName + ".xml", unzippedArray);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        }
    }
