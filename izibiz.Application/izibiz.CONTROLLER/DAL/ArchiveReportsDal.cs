using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.DAL
{
    public class ArchiveReportsDal
    {

        public List<ArchiveReports> getReportList()
        {
            return Singl.databaseContextGet.archiveReports.ToList();
        }


        public void addReport(ArchiveReports report)
        {
            Singl.databaseContextGet.archiveReports.Add(report);
        }


    }
}
