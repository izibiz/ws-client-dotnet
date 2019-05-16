using izibiz.COMMON.Ubl_Tr;
using izibiz.CONTROLLER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubl_Invoice_2_1;

namespace izibiz.COMMON.UBLCreate
{
    public class InvoiceUBL : BaseInvoiceUBL
    {


        public InvoiceUBL(string profileId, string invoiceTypeCode)
           : base(profileId, invoiceTypeCode)
        {

            addAdinationalDocRefXslt();
        }



        private void addAdinationalDocRefXslt()
        {

            var idRef = new DocumentReferenceType();
            idRef.ID = new IDType { Value = Guid.NewGuid().ToString() };
            idRef.IssueDate = BaseUBL.IssueDate;
            idRef.DocumentType = new DocumentTypeType { Value = nameof(EI.DocumentType.XSLT) };
            idRef.Attachment = new AttachmentType();
            idRef.Attachment.EmbeddedDocumentBinaryObject = new EmbeddedDocumentBinaryObjectType();

            idRef.Attachment.EmbeddedDocumentBinaryObject.characterSetCode = "UTF-8";
            idRef.Attachment.EmbeddedDocumentBinaryObject.encodingCode = "Base64";
            idRef.Attachment.EmbeddedDocumentBinaryObject.filename = BaseUBL.ID.Value.ToString() + ".xslt";
            idRef.Attachment.EmbeddedDocumentBinaryObject.mimeCode = "application/xml";
            //invoice olusturuldugunda xslt invoice olarak verılecegı ıcın
            idRef.Attachment.EmbeddedDocumentBinaryObject.Value = Convert.FromBase64String(Xslt.xsltGibInvoice);



            docRefList.Add(idRef);
            BaseUBL.AdditionalDocumentReference = docRefList.ToArray();
        }




    }
}
