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
using izibiz.COMMON.Language;



namespace izibiz.MODEL.Model
{

    [Table(Name = "IncomingInvoices")]
    public class IncomingInvoices
    {
      

        [Column(Name = izibiz.COMMON.Language., DbType = "NVARCHAR")]
        public string ID { get; set; }


        [Column(Name = "uuid", IsDbGenerated = true, IsPrimaryKey = true, DbType = "NVARCHAR")]
        [Key]
        public string Uuid { get; set; }


        [Column(Name = "issueDate", DbType = "NUMERIC")]
        public DateTime issueDate { get; set; }


        [Column(Name = "profileid", DbType = "NVARCHAR")]
        public string profileid { get; set; }


        [Column(Name = "type", DbType = "NVARCHAR")]
        public string type { get; set; }


        [Column(Name = "suplier", DbType = "NVARCHAR")]
        public string suplier { get; set; }


        [Column(Name = "sender", DbType = "NVARCHAR")]
        public string sender { get; set; }


        [Column(Name = "cDate", DbType = "NUMERIC")]
        public DateTime cDate { get; set; }


        [Column(Name = "envelopeIdentifier", DbType = "NVARCHAR")]
        public string envelopeIdentifier { get; set; }


        [Column(Name = "status", DbType = "NVARCHAR")]
        public string status { get; set; }


        [Column(Name = "statusDesc", DbType = "NVARCHAR")]
        public string statusDesc { get; set; }


        [Column(Name = "gibStatusCode", DbType = "INTEGER")]
        public int gibStatusCode { get; set; }


        [Column(Name = "gibStatusDescription", DbType = "NVARCHAR")]
        public string gibStatusDescription { get; set; }


        [Column(Name = "fromm2", DbType = "NVARCHAR")]
        public string fromm { get; set; }


        [Column(Name = "too", DbType = "NVARCHAR")]
        public string too { get; set; }





    }



}
