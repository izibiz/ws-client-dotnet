using izibiz.COMMON;
using izibiz.MODEL.Data;
using izibiz.MODEL.DbTablesModels;
using izibiz.SERVICES.serviceReconcilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.DAL
{
    public class ReconcilationDal
    {

        public int addReconcilation(Reconcilations reconcilation)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                databaseContext.reconcilations.Add(reconcilation);

                return databaseContext.SaveChanges();
            }
        }



        public List<Reconcilations> getReconcilationsWithType(string reconcilationType)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.reconcilations.Where(rec => rec.type == reconcilationType).ToList();
            }
        }



        public Boolean updateReconcilationIsSend(List<string> uuidArr, bool isSend)
        {
            bool succes = true;

            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                foreach (string uuid in uuidArr)
                {
                    Reconcilations reconcilation = databaseContext.reconcilations.Find(uuid);
                    if (reconcilation != null)
                    {
                        reconcilation.isSend = isSend;

                        if (databaseContext.SaveChanges() != 1)
                        {
                            succes = false;
                        }
                    }
                    else
                    {
                        succes = false;
                    }
                }
                return succes;
            }
        }



        public Reconcilations FindReconcilationWithUuid(string uuid)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.reconcilations.Find(uuid);
            }
        }


        public Boolean updateStatusReconcilation(RECONCILIATION_STATUSRECONCILIATION[][] statusList)
        {
            bool succes = true;

            using (DatabaseContext databaseContext = new DatabaseContext())
            {

                foreach (var status in statusList)
                {
                    foreach (var state in status)
                    {

                        Reconcilations reconcilation = databaseContext.reconcilations.Find(state.UUID);
                        if (reconcilation != null)
                        {
                            reconcilation.status = state.STATUS;
                            reconcilation.statusCode = state.STATUS_CODE;
                            reconcilation.createDate = state.CREATE_DATE;

                            if (databaseContext.SaveChanges() != 1)
                            {
                                succes = false;
                            }
                        }
                        else
                        {
                            succes = false;
                        }
                    }
                }
                return succes;
            }
        }



    }
}
