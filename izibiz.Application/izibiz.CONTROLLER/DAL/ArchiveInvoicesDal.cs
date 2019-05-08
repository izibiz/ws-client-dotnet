using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbModels;
using izibiz.SERVICES.serviceArchive;
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

        public ArchiveInvoices getArchive(string uuid,string profileId)
        {
            return Singl.databaseContextGet.archiveInvoices.Where(arc => arc.uuid == uuid).FirstOrDefault();
        }


        public void addArchive(ArchiveInvoices archive)
        {
            Singl.databaseContextGet.archiveInvoices.Add(archive);
        }


        public void updateArchiveStatus(EARCHIVE_INVOICE archive )
        {
            ArchiveInvoices archiveOnDb = Singl.databaseContextGet.archiveInvoices.Where(arc => arc.uuid == archive.HEADER.UUID).FirstOrDefault();

            archiveOnDb.status = archive.HEADER.STATUS_DESC;
            archiveOnDb.mailStatus = archive.HEADER.EMAIL_STATUS_DESC;
        }



        public void dbSaveChanges()
        {
            Singl.databaseContextGet.SaveChanges();
        }
    }
}
