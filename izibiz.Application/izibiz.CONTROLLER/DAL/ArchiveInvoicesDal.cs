using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.DAL
{
    public class ArchiveInvoicesDal
    {

        public List<ArchiveInvoices> getInvoiceList(bool isDraft)
        {
            return Singl.databaseContextGet.archiveInvoices.Where(arc =>arc.draftFlag==isDraft).ToList();
        }



    }
}
