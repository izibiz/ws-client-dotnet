using izibiz.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.MODEL.Entities
{

    [Table(Name = nameof(EI.SelfEmploymentReceipt.SelfEmploymentReceipts))]
    public class SelfEmploymentReceipts
    {

        [Column(Name = nameof(EI.SelfEmploymentReceipt.uuid), IsDbGenerated = true, IsPrimaryKey = true, DbType = "NVARCHAR")]
        [Key]
        public string uuid { get; set; }


        [Column(Name = nameof(EI.SelfEmploymentReceipt.smmID), DbType = "NVARCHAR")]
        public string smmID { get; set; }



        [Column(Name = nameof(EI.SelfEmploymentReceipt.isDraft), DbType = "BOOLEAN")]
        public bool isDraft { get; set; }



        [Column(Name = nameof(EI.SelfEmploymentReceipt.customerTitle), DbType = "VARCHAR")]
        public string customerTitle { get; set; }


        [Column(Name = nameof(EI.SelfEmploymentReceipt.customerID), DbType = "VARCHAR")]
        public string customerID { get; set; }



        [Column(Name = nameof(EI.SelfEmploymentReceipt.profileID), DbType = "NVARCHAR")]
        public string profileID { get; set; }



        [Column(Name = nameof(EI.SelfEmploymentReceipt.status), DbType = "NVARCHAR")]
        public string status { get; set; }



        [Column(Name = nameof(EI.SelfEmploymentReceipt.statusCode), DbType = "INTEGER")]
        public int statusCode { get; set; }



        [Column(Name = nameof(EI.SelfEmploymentReceipt.statusDesc), DbType = "NVARCHAR")]
        public string statusDesc { get; set; }



        [Column(Name = nameof(EI.SelfEmploymentReceipt.CDate), DbType = "DATETIME")]
        public DateTime cDate { get; set; }


        [Column(Name = nameof(EI.SelfEmploymentReceipt.issueDate), DbType = "DATETIME")]
        public DateTime issueDate { get; set; }



        [Column(Name = nameof(EI.SelfEmploymentReceipt.email), DbType = "NVARCHAR")]
        public string email { get; set; }



        [Column(Name = nameof(EI.SelfEmploymentReceipt.emailStatusCode), DbType = "INTEGER")]
        public int emailStatusCode { get; set; }




        [Column(Name = nameof(EI.Invoice.folderPath), DbType = "NVARCHAR")]
        public string folderPath { get; set; }









    }
}
