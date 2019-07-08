using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using izibiz.COMMON;

namespace izibiz.MODEL.DbTablesModels
{
    public class ArchiveReports
    {

        [Column(Name = nameof(EI.ArchiveReports.reportNo), IsDbGenerated = true, IsPrimaryKey = true, DbType = "NVARCHAR")]
        [Key]
        public string reportNo { get; set; }


       
        [Column(Name = nameof(EI.ArchiveReports.status), DbType = "NVARCHAR")]
        public string status { get; set; }

        

    }
}
