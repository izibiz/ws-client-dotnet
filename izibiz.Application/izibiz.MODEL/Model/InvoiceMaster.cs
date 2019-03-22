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




namespace izibiz.MODEL.Model
{

    [Table(Name = "Invoices")]
    public class Invoices
    {

        [Column(Name =nameof(EI.InvClmName.ID), DbType = "NVARCHAR")]
        public string ID { get; set; }


        [Column(Name = nameof(EI.InvClmName.uuid), IsDbGenerated = true, IsPrimaryKey = true, DbType = "NVARCHAR")]
        [Key]
        public string Uuid { get; set; }


        [Column(Name = nameof(EI.InvClmName.invType), DbType = "VARCHAR")]
        public string invType { get; set; }



        [Column(Name = nameof(EI.InvClmName.issueDate), DbType = "NUMERIC")]
        public DateTime issueDate { get; set; }


        [Column(Name = nameof(EI.InvClmName.profileid), DbType = "NVARCHAR")]
        public string profileid { get; set; }


        [Column(Name = nameof(EI.InvClmName.type), DbType = "NVARCHAR")]
        public string type { get; set; }


        [Column(Name = nameof(EI.InvClmName.suplier), DbType = "NVARCHAR")]
        public string suplier { get; set; }


        [Column(Name = nameof(EI.InvClmName.sender), DbType = "NVARCHAR")]
        public string sender { get; set; }


        [Column(Name = nameof(EI.InvClmName.cDate), DbType = "NUMERIC")]
        public DateTime cDate { get; set; }


        [Column(Name = nameof(EI.InvClmName.envelopeIdentifier), DbType = "NVARCHAR")]
        public string envelopeIdentifier { get; set; }


        [Column(Name = nameof(EI.InvClmName.status), DbType = "NVARCHAR")]
        public string status { get; set; }


        [Column(Name = nameof(EI.InvClmName.statusDesc), DbType = "NVARCHAR")]
        public string statusDesc { get; set; }


        [Column(Name = nameof(EI.InvClmName.gibStatusCode), DbType = "INTEGER")]
        public int gibStatusCode { get; set; }


        [Column(Name = nameof(EI.InvClmName.gibStatusDescription), DbType = "NVARCHAR")]
        public string gibStatusDescription { get; set; }


        [Column(Name = nameof(EI.InvClmName.fromm), DbType = "NVARCHAR")]
        public string fromm { get; set; }


        [Column(Name = nameof(EI.InvClmName.too), DbType = "NVARCHAR")]
        public string too { get; set; } 
    }


}
