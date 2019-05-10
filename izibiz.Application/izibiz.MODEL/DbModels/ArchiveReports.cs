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

namespace izibiz.MODEL.DbModels
{
    public class ArchiveReports
    {

        [Column(Name = nameof(EI.ArchiveReports.reportNo), IsDbGenerated = true, IsPrimaryKey = true, DbType = "NVARCHAR")]
        [Key]
        public string reportNo { get; set; }


        [Column(Name = nameof(EI.ArchiveReports.ID), DbType = "NUMERIC")]
        public int ID { get; set; }


        [Column(Name = nameof(EI.ArchiveReports.status), DbType = "NVARCHAR")]
        public string status { get; set; }


        [Column(Name = nameof(EI.ArchiveReports.periodStart), DbType = "DATE")]
        public DateTime periodStart { get; set; }


        [Column(Name = nameof(EI.ArchiveReports.periodEnd), DbType = "DATE")]
        public DateTime periodEnd { get; set; }


        [Column(Name = nameof(EI.ArchiveReports.chapter), DbType = "NUMERIC")]
        public int chapter { get; set; }


        [Column(Name = nameof(EI.ArchiveReports.chapterStart), DbType = "DATE")]
        public DateTime chapterStart { get; set; }


        [Column(Name = nameof(EI.ArchiveReports.chapterEnd), DbType = "DATE")]
        public DateTime chapterEnd { get; set; }


        [Column(Name = nameof(EI.ArchiveReports.archiveInvCount), DbType = "NUMERIC")]
        public int archiveInvCount { get; set; }

    


        [Column(Name = nameof(EI.ArchiveReports.gibSendDate), DbType = "DATETIME")]
        public DateTime gibSendDate { get; set; }


        [Column(Name = nameof(EI.ArchiveReports.gibConfirmationDate), DbType = "DATETIME")]
        public DateTime gibConfirmationDate { get; set; }


        [Column(Name = nameof(EI.ArchiveReports.description), DbType = "NVARCHAR")]
        public string description { get; set; }

    }
}
