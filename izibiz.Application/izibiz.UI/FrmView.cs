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
using UblInvoice;
using izibiz.COMMON.Language;

namespace izibiz.UI
{
    public partial class FrmView : Form
    {

        private string xmlContent;
        private string invoiceType;
        private bool isHtml;

        public FrmView(string xmlContent, string invoiceType, bool isHtml = false)
        {
            InitializeComponent();
            try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
            this.xmlContent = xmlContent;
            this.invoiceType = invoiceType;
            this.isHtml = isHtml;
        }

        private void PreviewInvoices_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
            try
            {
                if (isHtml)
                {
                    viewDoc.DocumentText = xmlContent;
                    return;
                }

                if (invoiceType == EI.Invoice.ArchiveInvoices.ToString())
                {
                    viewDoc.DocumentText = XmlControl.xmlToHtml(Xslt.xsltGibArchive, xmlContent);
                }
                else if (invoiceType == EI.Invoice.Invoices.ToString())
                {
                    viewDoc.DocumentText = XmlControl.xmlToHtml(Xslt.xsltGibInvoice, xmlContent);
                }
                else if (invoiceType == EI.ArchiveReports.ArchiveReports.ToString())
                {
                    viewDoc.DocumentText = XmlControl.xmlToHtml(Xslt.xsltGibArchiveReport, xmlContent);
                }
                else if (invoiceType == EI.Despatch.DespatchAdvices.ToString())
                {
                    viewDoc.DocumentText = XmlControl.xmlToHtml(Xslt.xsltGibDespatch, xmlContent);
                }
                else if (invoiceType == EI.SelfEmploymentReceipt.SelfEmploymentReceipts.ToString())
                {
                    viewDoc.DocumentText = XmlControl.xmlToHtml(Xslt.xsltGibSmm, xmlContent);
                }
                else if (invoiceType == EI.SmmReports.SmmReports.ToString())
                {
                    viewDoc.DocumentText = XmlControl.xmlToHtml(Xslt.xsltGibSmmReport, xmlContent);
                }
                else if (invoiceType == EI.CreditNote.CreditNotes.ToString())
                {
                    viewDoc.DocumentText = XmlControl.xmlToHtml(Xslt.xsltGibCreditNote, xmlContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void localizationItemTextWrite()
        {
            this.Text = Lang.formView;
        }





    }


}
