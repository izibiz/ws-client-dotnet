using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.MODEL.Data;
using izibiz.MODEL.DbModels;
using izibiz.SERVICES.serviceDespatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.DAL
{


    public class DespatchAdviceDal
    {


        public int addDespatchFromDespatchAdviceAndSaveContentOnDisk(DESPATCHADVICE[] despatchArr,string direction)
        {
            DespatchAdvices despatchAdvice;

            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                foreach (var despatch in despatchArr)
                {
                    despatchAdvice = new DespatchAdvices();

                    despatchAdvice.ID = despatch.ID;
                    despatchAdvice.uuid = despatch.UUID;
                    despatchAdvice.direction = direction;
                    despatchAdvice.issueDate = Convert.ToDateTime(despatch.DESPATCHADVICEHEADER.ISSUE_DATE);
                    despatchAdvice.profileId = despatch.DESPATCHADVICEHEADER.PROFILEID;
                    despatchAdvice.senderVkn = despatch.DESPATCHADVICEHEADER.SENDER.VKN;
                    despatchAdvice.cDate = despatch.DESPATCHADVICEHEADER.CDATE;
                    despatchAdvice.envelopeIdentifier = despatch.DESPATCHADVICEHEADER.ENVELOPE_IDENTIFIER;
                    despatchAdvice.status = despatch.DESPATCHADVICEHEADER.STATUS;
                    despatchAdvice.gibStatusCode = despatch.DESPATCHADVICEHEADER.GIB_STATUS_CODE;
                    despatchAdvice.gibStatusDescription = despatch.DESPATCHADVICEHEADER.GIB_STATUS_DESCRIPTION;
                    despatchAdvice.folderPath = FolderControl.inboxFolderArchive + despatchAdvice.uuid + "." + nameof(EI.DocumentType.XML);
                    despatchAdvice.issueTime = despatch.DESPATCHADVICEHEADER.ISSUE_TIME;
                    despatchAdvice.shipmentDate = despatch.DESPATCHADVICEHEADER.ACTUAL_SHIPMENT_DATE;
                    despatchAdvice.shipmentTime = despatch.DESPATCHADVICEHEADER.ACTUAL_SHIPMENT_TIME;
                    despatchAdvice.typeCode = despatch.DESPATCHADVICEHEADER.TYPE_CODE;
                    despatchAdvice.statusCode = despatch.DESPATCHADVICEHEADER.STATUS_CODE;

                    FolderControl.writeFileOnDiskWithString(Encoding.UTF8.GetString(Compress.UncompressFile(despatch.CONTENT.Value)), despatchAdvice.folderPath);

                    databaseContext.despatchAdvices.Add(despatchAdvice);

                }
                return databaseContext.SaveChanges();
            }
        }



        public List<DespatchAdvices> getDespatchList(string direction)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                return dbContext.despatchAdvices.Where(despatch => despatch.direction == direction).ToList();
            }
        }





    }
}
