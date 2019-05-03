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

        public List<ArchiveInvoices> getArchiveReportList( )
        {
            return Singl.databaseContextGet.archiveInvoices.Where(arc =>arc.reportFlag== true).ToList();
        }

        public void addArchive(ArchiveInvoices archive)
        {
            Singl.databaseContextGet.archiveInvoices.Add(archive);
        }


        public void dbSaveChanges()
        {
            Singl.databaseContextGet.SaveChanges();
        }
    }
}
