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
            try
            {

                if (docType.Equals(nameof(EI.DocumentType.XML)))
                {
                    viewDoc.DocumentText = XmlControl.xmlToHtml(Xslt.xsltGib, xmlPath);
                }
                else
                {
                    //var data=Xml.viewToPdf(Xslt.xsltGib,xmlPath);
                    //viewDoc.DocumentText=(Encoding.ASCII.GetString(data));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }







    }


}
