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

    [Table(Name = nameof(EI.Reconcilation.Reconcilations))]
    public class Reconcilations
    {

        //mutabakatta uuid unique dir o yuzden primary key verdik
        [Key]  
        [Column(Name = nameof(EI.Reconcilation.uuid), IsDbGenerated = true, IsPrimaryKey = true, DbType = "NVARCHAR")]     
        public string uuid { get; set; }



        [Column(Name = nameof(EI.Reconcilation.type), DbType = "NVARCHAR")]
        public string type { get; set; }



        [Column(Name = nameof(EI.Reconcilation.isSend), DbType = "BOOLEAN")]
        public bool isSend { get; set; }



        [Column(Name = nameof(EI.Reconcilation.customerID), DbType = "NVARCHAR")]
        public string customerID { get; set; }



        [Column(Name = nameof(EI.Reconcilation.period), DbType = "NVARCHAR")]
        public string period { get; set; }



        [Column(Name = nameof(EI.Reconcilation.cmDate), DbType = "DATETIME")]
        public DateTime cmDate { get; set; }



        [Column(Name = nameof(EI.Reconcilation.status), DbType = "NVARCHAR")]
        public string status { get; set; }



        [Column(Name = nameof(EI.Reconcilation.statusCode), DbType = "NVARCHAR")]
        public string statusCode { get; set; }



        [Column(Name = nameof(EI.Reconcilation.createDate), DbType = "DATETIME")]
        public DateTime createDate { get; set; }



        [Column(Name = nameof(EI.Reconcilation.email), DbType = "NVARCHAR")]
        public string email { get; set; }



        [Column(Name = nameof(EI.Reconcilation.emailStatusCode), DbType = "NVARCHAR")]
        public string emailStatusCode { get; set; }



        [Column(Name = nameof(EI.Reconcilation.emailStatusDesc), DbType = "NVARCHAR")]
        public string emailStatusDesc { get; set; }



        [Column(Name = nameof(EI.Reconcilation.emailStatusDate), DbType = "DATETIME")]
        public DateTime emailStatusDate { get; set; }



        [Column(Name = nameof(EI.Reconcilation.baDocPiece), DbType = "INTEGER")]
        public int baDocPiece { get; set; }


        [Column(Name = nameof(EI.Reconcilation.bsDocPiece), DbType = "INTEGER")]
        public int bsDocPiece { get; set; }


        [Column(Name = nameof(EI.Reconcilation.baDocAmount), DbType = "DECIMAL")]
        public decimal baDocAmount { get; set; }


        [Column(Name = nameof(EI.Reconcilation.bsDocAmount), DbType = "DECIMAL")]
        public decimal bsDocAmount { get; set; }


        [Column(Name = nameof(EI.Reconcilation.customerTitle), DbType = "NVARCHAR")]
        public string customerTitle { get; set; }



        [Column(Name = nameof(EI.Reconcilation.currentAmount), DbType = "DECIMAL")]
        public decimal currentAmount { get; set; }



        [Column(Name = nameof(EI.Reconcilation.accountType), DbType = "NVARCHAR")]
        public string accountType { get; set; }




    }
}
