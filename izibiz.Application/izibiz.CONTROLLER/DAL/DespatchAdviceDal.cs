using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.MODEL.Data;
using izibiz.MODEL.DbTablesModels;
using izibiz.SERVICES.serviceDespatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UblDespatchAdvice;

namespace izibiz.CONTROLLER.DAL
{


    public class DespatchAdviceDal
    {


        public int addDespatchFromServiceAndSaveContentOnDisk(DESPATCHADVICE[] despatchArr, string direction)
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
                    despatchAdvice.folderPath = FolderControl.createDespatchDocPath(despatch.ID, direction,nameof(EI.DocumentType.XML));
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
                return dbContext.despatchAdvices.Where(despatch => despatch.direction == direction).OrderByDescending(despatch => despatch.cDate).ToList();
            }
        }



        public DespatchAdvices getDespatch(string uuid, string direction)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                return dbContext.despatchAdvices.Where(despatch => despatch.direction == direction && despatch.uuid == uuid).FirstOrDefault();
            }
        }




        public int addDespatchStatusFromService(DESPATCHADVICEHEADER[] despatchHeaderArr, string direction)
        {
            DespatchAdvices despatchAdvice;

            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                foreach (var despatchHeader in despatchHeaderArr)
                {
                    if (despatchHeader.DIRECTION.Equals(direction))  //bir uuid ye ait iki direction  olabilir ... iki status degerı donebılır
                    {
                        despatchAdvice = databaseContext.despatchAdvices.Where(despatch => despatch.direction == direction
                && despatch.uuid == despatchHeader.UUID).FirstOrDefault();

                        despatchAdvice.status = despatchHeader.STATUS;
                        despatchAdvice.statusCode = despatchHeader.STATUS_CODE;
                        despatchAdvice.gibStatusCode = despatchHeader.GIB_STATUS_CODE;
                        despatchAdvice.gibStatusDescription = despatchHeader.GIB_STATUS_DESCRIPTION;

                    }
                }
                return databaseContext.SaveChanges();
            }
        }





        public int updateDespatchIdCdateStatusGibCodeStateNoteFolderPath(string uuid, string direction,
     string newId, DateTime newCdate, string newStatus, int newGibStatusCode, string newStateNote, string newFolderPath)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                DespatchAdvices despatchAdvice = dbContext.despatchAdvices.Where(despatch => despatch.direction == direction
            && despatch.uuid == uuid).First();

                despatchAdvice.ID = newId;
                despatchAdvice.cDate = newCdate;
                despatchAdvice.status = newStatus;
                despatchAdvice.gibStatusCode = newGibStatusCode;
                despatchAdvice.stateNote = newStateNote;
                despatchAdvice.folderPath = newFolderPath;

                return dbContext.SaveChanges();
            }
        }

        public int updateDespatchIdDirectionFolderPathStateNote(string uuid, string direction, string newId, string newDirection, string newFolderPath, string newStateNote)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                DespatchAdvices despatchAdvice = dbContext.despatchAdvices.Where(despatch => despatch.direction == direction
            && despatch.uuid == uuid).First();

                despatchAdvice.ID = newId;
                despatchAdvice.direction = newDirection;
                despatchAdvice.folderPath = newFolderPath;
                despatchAdvice.stateNote = newStateNote;

                return dbContext.SaveChanges();
            }
        }



        public List<DespatchAdvices> getDespatchListOnFilter(string direction, DateTime startTime, DateTime finishTime)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                return dbContext.despatchAdvices.Where(despatch => despatch.direction == direction
            && despatch.cDate <= finishTime
            && despatch.cDate >= startTime).OrderByDescending(inv => inv.cDate).ToList();
            }

        }

        


        public int insertDespatchOnDbFromUbl(DespatchAdviceType despatchUbl, string xmlPath)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                DespatchAdvices createdDespatch = new DespatchAdvices();

                createdDespatch.ID = despatchUbl.ID.Value;
                createdDespatch.uuid = despatchUbl.UUID.Value;
                createdDespatch.direction = EI.Direction.DRAFT.ToString();
                createdDespatch.draftFlag = true; //biz olusturduk servısten cekmedıgımız ıcın true
                createdDespatch.issueDate = despatchUbl.IssueDate.Value;
                createdDespatch.profileId = despatchUbl.ProfileID.Value;
                createdDespatch.senderVkn = despatchUbl.DespatchSupplierParty.Party.PartyIdentification.First().ID.Value;  //sıfırıncı ındexde tc ya da vkn tutuluyor         
                createdDespatch.receiverVkn = despatchUbl.DeliveryCustomerParty.Party.PartyIdentification.First().ID.Value;
                createdDespatch.cDate = despatchUbl.IssueDate.Value;
                createdDespatch.envelopeIdentifier = "";
                createdDespatch.stateNote = nameof(EI.StateNote.CREATED);              
                createdDespatch.status = "";
                createdDespatch.gibStatusCode = 0;
                createdDespatch.gibStatusDescription = "";
                createdDespatch.statusCode = "";
                createdDespatch.folderPath = xmlPath;
                createdDespatch.typeCode = "";
                createdDespatch.shipmentDate = despatchUbl.Shipment.Delivery.Despatch.ActualDespatchDate.Value;
                createdDespatch.shipmentTime = despatchUbl.Shipment.Delivery.Despatch.ActualDespatchTime.Value.ToString();


                databaseContext.despatchAdvices.Add(createdDespatch);

             return   databaseContext.SaveChanges();
            }
        }








    }
}
