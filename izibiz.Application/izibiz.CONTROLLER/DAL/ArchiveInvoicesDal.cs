using izibiz.COMMON;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbModels;
using izibiz.SERVICES.serviceArchive;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubl_Invoice_2_1;

namespace izibiz.CONTROLLER.DAL
{
    public class ArchiveInvoicesDal
    {
        //☻

        public List<ArchiveInvoices> getArchiveList(bool draftFlag)
        {
            return Singl.databaseContextGet.archiveInvoices.Where(arc=>arc.draftFlag == draftFlag).ToList(); 

        }


        public List<string> getArchiveUuidList(bool draftFlag)
        {
            return Singl.databaseContextGet.archiveInvoices.Where(arc => arc.draftFlag == draftFlag).Select(arc=>arc.uuid).ToList();

        }

        public List<ArchiveInvoices> getArchiveReportList()
        {
            return Singl.databaseContextGet.archiveInvoices.Where(arc => arc.reportFlag == true).ToList();
        }



        public ArchiveInvoices getArchive(string uuid)
        {
            return Singl.databaseContextGet.archiveInvoices.Where(arc => arc.uuid == uuid).FirstOrDefault();
        }


        public ArchiveInvoices findArchive(string rowUnique)
        {
            return Singl.databaseContextGet.archiveInvoices.Find(rowUnique);
        }


        public void addArchive(ArchiveInvoices archive)
        {
            Singl.databaseContextGet.archiveInvoices.Add(archive);
        }



        public void updateArchiveStatus(EARCHIVE_INVOICE archive)
        {
            ArchiveInvoices archiveOnDb = Singl.databaseContextGet.archiveInvoices.Where(arc => arc.uuid == archive.HEADER.UUID).FirstOrDefault();

            archiveOnDb.status = archive.HEADER.STATUS_DESC;
            if(archive.HEADER.REPORT_ID != 0)
            {
                archiveOnDb.reportFlag = true;
            }
            archiveOnDb.mailStatus = archive.HEADER.EMAIL_STATUS_DESC;
        }

        public void insertArchiveOnDbFromUbl(InvoiceType invoiceUbl, string xmlPath,bool sendMailWhenReporting)
        {
           
            ArchiveInvoices createdArchive = new ArchiveInvoices();

            createdArchive.rowUnique = invoiceUbl.ID.Value + invoiceUbl.UUID.Value + invoiceUbl.ProfileID.Value;
            createdArchive.ID = invoiceUbl.ID.Value;
            createdArchive.uuid = invoiceUbl.UUID.Value;
            createdArchive.totalAmount = invoiceUbl.LegalMonetaryTotal.PayableAmount.Value;
            createdArchive.draftFlag = true;
            createdArchive.issueDate = invoiceUbl.IssueDate.Value;
            createdArchive.profileid = invoiceUbl.ProfileID.Value;
            createdArchive.invoiceType = invoiceUbl.InvoiceTypeCode.Value;
            if (invoiceUbl.AdditionalDocumentReference.Length== 3)  //ınternet ıse 2.ındexdekı addDocRef vardır
            {
                createdArchive.eArchiveType = invoiceUbl.AdditionalDocumentReference[2].DocumentTypeCode.Value;
            }
            else
            {
                createdArchive.eArchiveType =nameof(EI.ArchiveType.NORMAL);
            }
            createdArchive.sendingType = invoiceUbl.AdditionalDocumentReference[1].DocumentType.Value; 
            createdArchive.senderName = invoiceUbl.AccountingSupplierParty.Party.PartyName.Name.Value;
            createdArchive.senderVkn = invoiceUbl.AccountingSupplierParty.Party.PartyIdentification.First().ID.Value;  //sıfırıncı ındexde tc ya da vkn tutuluyor         
            createdArchive.receiverVkn = invoiceUbl.AccountingCustomerParty.Party.PartyIdentification.First().ID.Value;
            createdArchive.stateNote = nameof(EI.StateNote.CREATED);
            createdArchive.status = "";
            createdArchive.statusCode ="";
            if (sendMailWhenReporting) //mail gonder secılı ıse
            {
                createdArchive.receiverMail = invoiceUbl.AccountingCustomerParty.Party.Contact.ElectronicMail.Value;
            }
            createdArchive.content = File.ReadAllText(xmlPath, Encoding.UTF8);
            createdArchive.folderPath = xmlPath;

            Singl.databaseContextGet.archiveInvoices.Add(createdArchive);
        }


        public void dbSaveChanges()
        {
            Singl.databaseContextGet.SaveChanges();
        }
    }
}
