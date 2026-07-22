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




        public int addCreditNoteToDbAndSaveContentOnDisk(CREDITNOTE[] creditNoteArr)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                foreach (var creditNotes in creditNoteArr)
                {
                    // Aynı uuid daha önce kaydedilmişse (ör. servis tarafında tekrar okunmuşsa)
                    // yeniden Add etmek PRIMARY KEY çakışmasına (DbUpdateException) sebep oluyordu.
                    // Varsa güncelle, yoksa ekle.
                    CreditNotes CreditNote = databaseContext.creditNotes.Find(creditNotes.UUID);
                    bool isNew = CreditNote == null;
                    if (isNew)
                    {
                        CreditNote = new CreditNotes();
                        CreditNote.uuid = creditNotes.UUID;
                    }

                    CreditNote.CreditNoteID = creditNotes.ID;
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
                    // Servis "taslak/gönderilmemiş" belgeler için STATUS_DESCRIPTION alanında "TASLAK" döner;
                    // isDraft'ı sabit bir değer yerine gerçek statüden türetiyoruz.
                    CreditNote.isDraft = creditNotes.HEADER.STATUS_DESCRIPTION == "TASLAK"
                        ? nameof(EI.ActiveOrPasive.Y)
                        : nameof(EI.ActiveOrPasive.N);
                    CreditNote.folderPath = FolderControl.CreditNoteFolderPath + CreditNote.CreditNoteID + "." + nameof(EI.DocumentType.XML);

                    FolderControl.writeFileOnDiskWithString(Encoding.UTF8.GetString(Compress.UncompressFile(creditNotes.CONTENT.Value)), CreditNote.folderPath);

                    if (isNew)
                    {
                        databaseContext.creditNotes.Add(CreditNote);
                    }
                }

                databaseContext.SaveChanges();
                return creditNoteArr.Length;
            }

        }
    








    }
}
