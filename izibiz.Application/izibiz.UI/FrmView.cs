using izibiz.COMMON;
using izibiz.COMMON.Ubl_Tr;
using izibiz.COMMON.FileControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using Ubl_Invoice_2_1;

namespace izibiz.UI
{
    public partial class FrmView : Form
    {

        private string xmlPath;
        private string docType;

        public FrmView(string xmlPath, string docType)
        {
            InitializeComponent();
            this.xmlPath = xmlPath;
            this.docType = docType;
        }

        private void PreviewInvoices_Load(object sender, EventArgs e)
        {

            if (docType.Equals(nameof(EI.DocumentType.XML)))
            {
                webBrowser1.DocumentText = Xml.xmlToHtml(Xslt.xsltGib, xmlPath);
            }
            else
            {
                //var data=Xml.viewToPdf(Xslt.xsltGib,xmlPath);
                //webBrowser1.DocumentText=(Encoding.ASCII.GetString(data));


            }


        }



        public string transformXMLToHTML(string inputXml, string xsltString)
        {
            XslCompiledTransform transform = new XslCompiledTransform();
            using (XmlReader reader = XmlReader.Create(new StringReader(xsltString)))
            {
                transform.Load(reader);
            }
            StringWriter results = new StringWriter();
            using (XmlReader reader = XmlReader.Create(new StringReader(inputXml)))
            {
                transform.Transform(reader, null, results);
            }
            return results.ToString();
        }

        public string viewInvoice()
        {
            String xslt = "C:\\Users\\gamze\\Desktop\\a.xslt";
            String input = xmlPath;
            String output = "C:/Users/gamze/Desktop/TransformOutputXml.xml";

            XPathDocument myXMLPath = new XPathDocument(input);
            XslCompiledTransform myXSLTrans = new XslCompiledTransform();
            myXSLTrans.Load(xslt);
            XmlTextWriter myWriter = new XmlTextWriter(output, null);
            myXSLTrans.Transform(myXMLPath, null, myWriter);
            myWriter.Close();
            System.IO.FileStream fileXml = new System.IO.FileStream(output, FileMode.Open, FileAccess.Read);
            System.IO.StreamReader sr = new System.IO.StreamReader(fileXml, Encoding.UTF8);
            return sr.ReadToEnd();

        }




    }

   
}
