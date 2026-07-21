using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.MODEL.Data;
using izibiz.MODEL.Entities;
using izibiz.SERVICES.serviceSmm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.DAL
{
    public class SmmDal
    {



        public SelfEmploymentReceipts findSmmWithUuid(string uuid)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.selfEmployments.Find(uuid);
            }
        }


        public List<SelfEmploymentReceipts> getSmmWithDraft(bool isDraft)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.selfEmployments.Where(smm => smm.isDraft == isDraft).ToList();
            }
        }




        public int addSmmToDbAndSaveContentOnDisk(SMM[] smmArr)
        {
            SelfEmploymentReceipts selfEmployment;

            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                foreach (var smm in smmArr)
                {
                    selfEmployment = new SelfEmploymentReceipts();

                    selfEmployment.smmID = smm.ID;
                    selfEmployment.uuid = smm.UUID;
                    selfEmployment.customerTitle =smm.HEADER.CUSTOMER.NAME;
                    selfEmployment.customerID = smm.HEADER.CUSTOMER.IDENTIFIER;
                    selfEmployment.profileID = smm.HEADER.PROFILE_ID.ToString();
                    selfEmployment.status = smm.HEADER.STATUS;
                    selfEmployment.statusCode = smm.HEADER.STATUS_CODE;
                    selfEmployment.statusDesc = smm.HEADER.STATUS_DESCRIPTION;
                    selfEmployment.cDate = smm.HEADER.CDATE;
                    selfEmployment.issueDate = smm.HEADER.ISSUE_DATE;
                    selfEmployment.email = smm.HEADER.EMAIL != null ? smm.HEADER.EMAIL.First() : null;
                    selfEmployment.emailStatusCode = smm.HEADER.EMAIL_STATUS_CODE;
                    selfEmployment.folderPath = FolderControl.smmFolderPath + smm.ID + "." + nameof(EI.DocumentType.XML);

                    FolderControl.writeFileOnDiskWithString(Encoding.UTF8.GetString(Compress.UncompressFile(smm.CONTENT.Value)), selfEmployment.folderPath);

                    databaseContext.selfEmployments.Add(selfEmployment);
                }
                return databaseContext.SaveChanges();
            }
        }







    }
}
