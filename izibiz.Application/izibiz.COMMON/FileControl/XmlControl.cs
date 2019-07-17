using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;


namespace izibiz.COMMON.FileControl
{
    public class XmlControl
    {
        /// <summary>
        /// VERİLEN  XMLIN ICINDEKI ID YI DEGISTIRIR,  XML PATH DONER
        /// </summary>
        /// <returns> XML STRING </returns>
        public static string xmlInvoiceChangeIdValue(string xmlContent, string newInvId)
        {
     
            XDocument doc = XDocument.Parse(xmlContent);

            foreach (XElement element in doc.Descendants()/*.Where(
                   e => e.Name.LocalName.ToString().Equals("ID")
                   && e.Parent.Name.LocalName.ToString().Equals("Invoice")  ||

                      e.Name.LocalName.ToString().Equals("EmbeddedDocumentBinaryObject")
                       && e.Parent.Name.LocalName.ToString().Equals("Attachment")*/
                   )
            {
                if (element.Name.LocalName.ToString().Equals("ID")
                   && element.Parent.Name.LocalName.ToString().Equals("Invoice"))
                {
                    element.Value = newInvId;

                }
                else if (element.Name.LocalName.ToString().Equals("EmbeddedDocumentBinaryObject")
                       && element.Parent.Name.LocalName.ToString().Equals("Attachment"))
                {
                    element.LastAttribute.Value = newInvId + ".xslt";
                    break;
                }
            }
            //yenı id eklenmıs xmli diske kaydet
    //        doc.Save(saveXmlPath);
            return doc.ToString();
        }



        public static string xmlDespatchChangeIdValue(string xmlContent, string newInvId)
        {

            XDocument doc = XDocument.Parse(xmlContent);

            foreach (XElement element in doc.Descendants())
            {
                if (element.Name.LocalName.ToString().Equals("ID")
                   && element.Parent.Name.LocalName.ToString().Equals("DespatchAdvice"))
                {
                    element.Value = newInvId;

                }
                else if (element.Name.LocalName.ToString().Equals("EmbeddedDocumentBinaryObject")
                       && element.Parent.Name.LocalName.ToString().Equals("Attachment"))
                {
                    element.LastAttribute.Value = newInvId + ".xslt";//yanı fileName
                    break;
                }
            }
            //yenı id eklenmıs xmli diske kaydet
            //        doc.Save(saveXmlPath);
            return doc.ToString();
        }






        //public static void PdfSharpConvert(String xmlPath)
        //{
        //    XmlReader xml = new XmlTextReader("data.xml");
        //    XslCompiledTransform xsl = new XslCompiledTransform(); xsl.Load("transform.xslt");

        //      Stream converted = new MemoryStream(); xsl.Transform(xml, null, converted); converted.Position = 0;

        //     Document document = new Document();

        //    XmlReader reader = new XmlTextReader(converted);
        //    document.Read(reader);

        //    using (FileStream file = new FileStream("out3.pdf", FileMode.Create))
        //    {
        //        document.Write(file);
        //        file.
        //    }
        //}

        //public static Byte[] PdfSharpConvert(String html)
        //{
        //    Byte[] res = null;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
        //        pdf.Save(ms);
        //        res = ms.ToArray();
        //    }
        //    return res;
        //}



        //public static byte[] viewToPdf(string xslEncoded, string xmlPath)
        //{
        //    //xslt text cevırme
        //    byte[] data = Convert.FromBase64String(xslEncoded);
        //    string decodedXslt = Encoding.UTF8.GetString(data);
        //    //pathdekı xmli okuyoruz
        //    string inputXml = File.ReadAllText(xmlPath);


        //}



        public static string xmlToHtml(string xslEncoded, string inputXml)
        {
            //xslt text cevırme
            byte[] data = System.Convert.FromBase64String(xslEncoded);
          string decodedXslt = System.Text.UTF8Encoding.UTF8.GetString(data);
          //  string decodedXslt = Encoding.UTF8.GetString(Convert.FromBase64String(xslEncoded));


            using (StringReader srt = new StringReader(decodedXslt)) // xslInput is a string that contains xsl
            using (StringReader sri = new StringReader(inputXml)) // xmlInput is a string that contains xml
            {
                using (XmlReader xrt = XmlReader.Create(srt))
                using (XmlReader xri = XmlReader.Create(sri))
                {
                    XslCompiledTransform xslt = new XslCompiledTransform();
                    xslt.Load(xrt);
                    using (StringWriter sw = new StringWriter())
                    using (XmlWriter xwo = XmlWriter.Create(sw, xslt.OutputSettings)) // use OutputSettings of xsl, so it can be output as HTML
                    {
                        xslt.Transform(xri, xwo);
                        return sw.ToString();
                    }
                }
            }
        }




    }
}
