using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Data;
using izibiz.MODEL.DbModels;
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
            return Singl.databaseContextGet.invoiceIdSerials.Where(serial => serial.serialName == serialName).First();
        }

        public void updateLastAddedInvIdSeri(string invNewId)
        {
            string seriName = invNewId.Remove(3);
            string year = invNewId.Substring(3, 4);
            string seriNo = invNewId.Substring(invNewId.Length - 9);


            InvoiceIdSerials invoiceIdSerial = Singl.databaseContextGet.invoiceIdSerials.Where(serial => serial.serialName == seriName).First();
            invoiceIdSerial.serialName = seriName;
            invoiceIdSerial.year = year;
            invoiceIdSerial.seriNo = seriNo;

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
