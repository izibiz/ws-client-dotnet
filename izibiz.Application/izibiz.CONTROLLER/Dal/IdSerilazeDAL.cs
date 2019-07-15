using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Data;
using izibiz.MODEL.DbTablesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.DAL
{
    public class IdSerilazeDal
    {

        DatabaseContext dataBaseContext = new DatabaseContext();

        public InvoiceIdSerials getLastAddedSeri(string serialName)
        {
            using(DatabaseContext databaseContext=new DatabaseContext())
            {
                return databaseContext.invoiceIdSerials.Where(serial => serial.serialName == serialName).First();
            }
        }




        public void updateLastAddedInvIdSeri(string invNewId)
        {
            using (DatabaseContext databaseContext=new DatabaseContext())
            {
                string seriName = invNewId.Remove(3);
                string year = invNewId.Substring(3, 4);
                string seriNo = invNewId.Substring(invNewId.Length - 9);

                InvoiceIdSerials invoiceIdSerial = databaseContext.invoiceIdSerials.Where(serial => serial.serialName == seriName).First();
                invoiceIdSerial.serialName = seriName;
                invoiceIdSerial.year = year;
                invoiceIdSerial.seriNo = seriNo;

                databaseContext.SaveChanges();
            }
        }

        public List<string> getSeriNames()
        {
            return dataBaseContext.invoiceIdSerials.Select(idSerial => idSerial.serialName).ToList();
        }


        public void addSeriName(string seriName)
        {
         /*   foreach (var seri in getSeriNames())
            {
                if (seri == seriName)
                {
                    return false;
                }
            }*/
            InvoiceIdSerials idSerials = new InvoiceIdSerials();
            idSerials.serialName = seriName;
            dataBaseContext.invoiceIdSerials.Add(idSerials);
        }

        public void dbSaveChanges()
        {
            dataBaseContext.SaveChanges();
        }
    }
}
