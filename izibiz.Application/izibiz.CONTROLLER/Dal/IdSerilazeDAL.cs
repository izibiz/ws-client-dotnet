using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.Dal
{
    public class IdSerilazeDAL
    {

        public InvoiceIdSerials getLastAddedSeri(string serialName)
        {
            return Singl.databaseContextGet.InvoiceIdSerials.Where(serial => serial.serialName == serialName).First();
        }

        public void updateLastAddedInvIdSeri(string invNewId)
        {
            string seriName = invNewId.Remove(3);
            string year = invNewId.Substring(3, 4);
            string seriNo = invNewId.Substring(invNewId.Length - 9);


            InvoiceIdSerials invoiceIdSerial = Singl.databaseContextGet.InvoiceIdSerials.Where(serial => serial.serialName == seriName).First();
            invoiceIdSerial.serialName = seriName;
            invoiceIdSerial.year = year;
            invoiceIdSerial.seriNo =seriNo;

        }

        public List<string> getSeriNames()
        {
            return Singl.databaseContextGet.InvoiceIdSerials.Select(idSerial => idSerial.serialName).ToList();
        }


    }
}
