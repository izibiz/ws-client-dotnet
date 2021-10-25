using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.MODEL.Data;
using izibiz.MODEL.Entities;
using izibiz.SERVICES.serviceCreditNote;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.DAL
{
    public class CreditNotesDal
    {



        public CreditNotes findCreditNoteWithUuid(string uuid)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.creditNotes.Find(uuid);
            }
        }


        public List<CreditNotes> getCreditNoteWithDraft(bool isDraft)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.creditNotes.Where(CreditNotes => isDraft ? CreditNotes.isDraft == "Y" : CreditNotes.isDraft == "N").ToList();
            }
        }




        public int addCreditNoteToDbAndSaveContentOnDisk(CREDITNOTE[] creditNoteArr, string isDraft)
        {
            CreditNotes CreditNote;

            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                foreach (var creditNotes in creditNoteArr)
                {
                    CreditNote = new CreditNotes();
                    CreditNote.CreditNoteID = creditNotes.ID;
                    CreditNote.uuid = creditNotes.UUID;
                    CreditNote.customerTitle = creditNotes.HEADER.CUSTOMER.NAME;
                    CreditNote.customerIdentifier = creditNotes.HEADER.CUSTOMER.IDENTIFIER;
                    CreditNote.profileID = creditNotes.HEADER.PROFILE_ID.ToString();
                    CreditNote.status = creditNotes.HEADER.STATUS;
                    CreditNote.statusCode = creditNotes.HEADER.STATUS_CODE;
                    CreditNote.statusDesc = creditNotes.HEADER.STATUS_DESCRIPTION;
                    CreditNote.cDate = creditNotes.HEADER.CDATE;
                    CreditNote.issueDate = creditNotes.HEADER.ISSUE_DATE;
                    CreditNote.email = creditNotes.HEADER.EMAIL != null ? creditNotes.HEADER.EMAIL.First() : null;
                    CreditNote.emailStatusCode = creditNotes.HEADER.EMAIL_STATUS_CODE;
                    CreditNote.isDraft = isDraft;
                    CreditNote.folderPath = FolderControl.CreditNoteFolderPath + CreditNote.CreditNoteID + "." + nameof(EI.DocumentType.XML);

                    FolderControl.writeFileOnDiskWithString(Encoding.UTF8.GetString(Compress.UncompressFile(creditNotes.CONTENT.Value)), CreditNote.folderPath);

                    databaseContext.creditNotes.Add(CreditNote);


                }
              
                    return databaseContext.SaveChanges();
  
            }

        }
    








    }
}
