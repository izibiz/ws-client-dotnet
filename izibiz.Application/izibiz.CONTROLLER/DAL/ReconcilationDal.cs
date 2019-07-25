using izibiz.MODEL.Data;
using izibiz.MODEL.DbTablesModels;
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
              return  databaseContext.reconcilations.Where(rec => rec.type == reconcilationType).ToList();
            }
        }








    }
}
