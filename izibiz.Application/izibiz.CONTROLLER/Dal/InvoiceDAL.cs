using izibiz.COMMON;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.Dal
{
    public class InvoiceDAL
    {

        public List<Invoices> getFaultyInvoices()
        {
            return Singl.databaseContextGet.Invoices.Where(x => x.invType == nameof(EI.InvType.OUT)
            && x.status.Contains(nameof(EI.StatusType.LOAD))
            && x.status.Contains(nameof(EI.SubStatusType.FAILED))).ToList();
        }

  


    }
}
