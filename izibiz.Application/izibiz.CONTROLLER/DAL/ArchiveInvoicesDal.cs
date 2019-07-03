using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Data;
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
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.archiveInvoices.Where(arc => arc.draftFlag == draftFlag).ToList();
            }
        }


        public List<string> getArchiveUuidList(bool draftFlag)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.archiveInvoices.Where(arc => arc.draftFlag == draftFlag).Select(arc => arc.uuid).ToList();
            }
        }

        public List<ArchiveInvoices> getArchiveReportList()
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.archiveInvoices.Where(arc => arc.reportFlag == true).ToList();
            }
        }



        public ArchiveInvoices getArchive(string uuid)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.archiveInvoices.Where(arc => arc.uuid == uuid).FirstOrDefault();
            }
        }


        public ArchiveInvoices findArchive(string uuid)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.archiveInvoices.Find(uuid);
            }
        }


        public void addArchive(ArchiveInvoices archive)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.archiveInvoices.Add(archive);

                databaseContext.SaveChanges();
            }
        }


        public void addArchiveFromEArchiveAndSaveContentOnDisk(EARCHIVEINV[] archiveArr)
        {
            ArchiveInvoices archive;

            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                foreach (var arc in archiveArr)
                {
                     archive = new ArchiveInvoices();

                    //bu row unıque degerı dbye daha once eklenmemısse
                    if (databaseContext.archiveInvoices.Find(archive.uuid) == null)
                    {
                        archive.ID = arc.HEADER.INVOICE_ID;
                        archive.uuid = arc.HEADER.UUID;
                        archive.totalAmount = Convert.ToDecimal(arc.HEADER.PAYABLE_AMOUNT);
                        archive.issueDate = Convert.ToDateTime(arc.HEADER.ISSUE_DATE);
                        archive.profileid = arc.HEADER.PROFILE_ID;
                        archive.invoiceType = arc.HEADER.INVOICE_TYPE;
                        archive.sendingType = arc.HEADER.SENDING_TYPE;
                        archive.eArchiveType = arc.HEADER.EARCHIVE_TYPE;
                        archive.senderName = arc.HEADER.SENDER_NAME;
                        archive.senderVkn = arc.HEADER.SENDER_IDENTIFIER;
                        archive.receiverVkn = arc.HEADER.CUSTOMER_IDENTIFIER;
                        archive.status = arc.HEADER.STATUS;
                        archive.statusCode = arc.HEADER.STATUS_CODE;
                        archive.currencyCode = arc.HEADER.CURRENCY_CODE;

                        archive.folderPath = FolderControl.inboxFolderArchive + archive.uuid + "." + nameof(EI.DocumentType.XML);
                        archive.content = Encoding.UTF8.GetString(Compress.UncompressFile(arc.CONTENT.Value));
                        FolderControl.writeFileOnDiskWithString(archive.content, archive.folderPath);

                        databaseContext.archiveInvoices.Add(archive);
                    }
                }
                databaseContext.SaveChanges();
            }
        }



        public void deleteArchive(string uuid)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.archiveInvoices.Remove(findArchive(uuid));

                databaseContext.SaveChanges();
            }
        }


        public void updateArchiveStateNote(string uuid, string newStateNote)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                var archive = databaseContext.archiveInvoices.Find(uuid);
                archive.stateNote = newStateNote;

                databaseContext.SaveChanges();
            }
        }


        public int updateArchiveIdStateNoteDraftFlag(string uuid, string newId, string newStateNote, bool draftFlag)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                var archive = databaseContext.archiveInvoices.Find(uuid);
                archive.ID = newId;
                archive.stateNote = newStateNote;
                archive.draftFlag = draftFlag;

               return databaseContext.SaveChanges();
            }
        }


        public void updateArchiveStatus(EARCHIVE_INVOICE archive)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                ArchiveInvoices archiveOnDb = databaseContext.archiveInvoices.Where(arc => arc.uuid == archive.HEADER.UUID).FirstOrDefault();

                archiveOnDb.status = archive.HEADER.STATUS_DESC;
                if (archive.HEADER.REPORT_ID != 0)
                {
                    archiveOnDb.reportFlag = true;
                }
                archiveOnDb.mailStatus = archive.HEADER.EMAIL_STATUS_DESC;

                databaseContext.SaveChanges();
            }
        }



        public void insertArchiveOnDbFromUbl(InvoiceType invoiceUbl, string xmlPath, bool sendMailWhenReporting)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                ArchiveInvoices createdArchive = new ArchiveInvoices();

                createdArchive.ID = invoiceUbl.ID.Value;
                createdArchive.uuid = invoiceUbl.UUID.Value;
                createdArchive.totalAmount = invoiceUbl.LegalMonetaryTotal.PayableAmount.Value;
                createdArchive.draftFlag = true;
                createdArchive.issueDate = invoiceUbl.IssueDate.Value;
                createdArchive.profileid = invoiceUbl.ProfileID.Value;
                createdArchive.invoiceType = invoiceUbl.InvoiceTypeCode.Value;
                if (invoiceUbl.AdditionalDocumentReference.Length == 3)  //ınternet ıse 2.ındexdekı addDocRef vardır
                {
                    createdArchive.eArchiveType = invoiceUbl.AdditionalDocumentReference[2].DocumentTypeCode.Value;
                }
                else
                {
                    createdArchive.eArchiveType = nameof(EI.ArchiveType.NORMAL);
                }
                createdArchive.sendingType = invoiceUbl.AdditionalDocumentReference[1].DocumentType.Value;
                createdArchive.senderName = invoiceUbl.AccountingSupplierParty.Party.PartyName.Name.Value;
                createdArchive.senderVkn = invoiceUbl.AccountingSupplierParty.Party.PartyIdentification.First().ID.Value;  //sıfırıncı ındexde tc ya da vkn tutuluyor         
                createdArchive.receiverVkn = invoiceUbl.AccountingCustomerParty.Party.PartyIdentification.First().ID.Value;
                createdArchive.stateNote = nameof(EI.StateNote.CREATED);
                createdArchive.status = "";
                createdArchive.statusCode = "";
                if (sendMailWhenReporting) //mail gonder secılı ıse
                {
                    createdArchive.receiverMail = invoiceUbl.AccountingCustomerParty.Party.Contact.ElectronicMail.Value;
                }
                createdArchive.content = File.ReadAllText(xmlPath, Encoding.UTF8);
                createdArchive.folderPath = xmlPath;

                databaseContext.archiveInvoices.Add(createdArchive);

                databaseContext.SaveChanges();
            }
        }



    }
}
