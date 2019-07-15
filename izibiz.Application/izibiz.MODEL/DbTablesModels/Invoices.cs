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

    [Table(Name = nameof(EI.Invoice.Invoices))]
    public class Invoices
    {

        [Column(Name = nameof(EI.Invoice.ID), DbType = "NVARCHAR")]
        public string ID { get; set; }



        [Column(Name = nameof(EI.Invoice.direction), DbType = "VARCHAR")]
        public string direction { get; set; }



        [Column(Name = nameof(EI.Invoice.draftFlag), DbType = "VARCHAR")]
        public string draftFlag { get; set; }


        [Column(Name = nameof(EI.Invoice.draftFlagDesc), DbType = "VARCHAR")]
        public string draftFlagDesc { get; set; }


        [Column(Name = nameof(EI.Invoice.cDate), DbType = "NUMERIC")]
        public DateTime cDate { get; set; }



        [Column(Name = nameof(EI.Invoice.issueDate), DbType = "NUMERIC")]
        public DateTime issueDate { get; set; }


        [Column(Name = nameof(EI.Invoice.profileId), DbType = "NVARCHAR")]
        public string profileId { get; set; }


        [Column(Name = nameof(EI.Invoice.invoiceType), DbType = "NVARCHAR")]
        public string invoiceType { get; set; }


        [Column(Name = nameof(EI.Invoice.suplier), DbType = "NVARCHAR")]
        public string suplier { get; set; }


        [Column(Name = nameof(EI.Invoice.senderVkn), DbType = "VARCHAR")]
        public string senderVkn { get; set; }


        [Column(Name = nameof(EI.Invoice.receiverVkn), DbType = "VARCHAR")]
        public string receiverVkn { get; set; }



        [Column(Name = nameof(EI.Invoice.uuid), IsDbGenerated = true, IsPrimaryKey = true, DbType = "NVARCHAR")]
        [Key]
        public string uuid { get; set; }



        [Column(Name = nameof(EI.Invoice.envelopeIdentifier), DbType = "NVARCHAR")]
        public string envelopeIdentifier { get; set; }

        [Column(Name = nameof(EI.Invoice.stateNote), DbType = "NVARCHAR")]
        public string stateNote { get; set; }

        [Column(Name = nameof(EI.Invoice.status), DbType = "NVARCHAR")]
        public string status { get; set; }


        [Column(Name = nameof(EI.Invoice.statusDesc), DbType = "NVARCHAR")]
        public string statusDesc { get; set; }


        [Column(Name = nameof(EI.Invoice.gibStatusCode), DbType = "INTEGER")]
        public int gibStatusCode { get; set; }


        [Column(Name = nameof(EI.Invoice.gibStatusDescription), DbType = "NVARCHAR")]
        public string gibStatusDescription { get; set; }


        [Column(Name = nameof(EI.Invoice.senderAlias), DbType = "NVARCHAR")]
        public string senderAlias { get; set; }


        [Column(Name = nameof(EI.Invoice.receiverAlias), DbType = "NVARCHAR")]
        public string receiverAlias { get; set; }




        [Column(Name = nameof(EI.Invoice.folderPath), DbType = "NVARCHAR")]
        public string folderPath { get; set; }
    }





}











