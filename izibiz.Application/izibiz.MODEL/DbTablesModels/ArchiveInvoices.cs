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

    [Table(Name = nameof(EI.Invoice.ArchiveInvoices))]
    public  class ArchiveInvoices
    {


        [Column(Name = nameof(EI.Invoice.ID), DbType = "NVARCHAR")]
        public string ID { get; set; }



        [Column(Name = nameof(EI.Invoice.totalAmount), DbType = "DECIMAL")]
        public decimal totalAmount { get; set; }


        [Column(Name = nameof(EI.Invoice.draftFlag), DbType = "BOOLEAN")]
        public bool draftFlag { get; set; }



        [Column(Name = nameof(EI.Invoice.reportFlag), DbType = "BOOLEAN")]
        public bool reportFlag { get; set; }



        [Column(Name = nameof(EI.Invoice.reportFlagDesc), DbType = "NVARCHAR")]
        public string reportFlagDesc { get; set; }



        [Column(Name = nameof(EI.Invoice.issueDate), DbType = "DATETIME")]
        public DateTime issueDate { get; set; }



        [Column(Name = nameof(EI.Invoice.profileId), DbType = "NVARCHAR")]
        public string profileId { get; set; }


        [Column(Name = nameof(EI.Invoice.invoiceType), DbType = "NVARCHAR")]
        public string invoiceType { get; set; }


        [Column(Name = nameof(EI.Invoice.eArchiveType), DbType = "NVARCHAR")]
        public string eArchiveType { get; set; }


        [Column(Name = nameof(EI.Invoice.sendingType), DbType = "NVARCHAR")]
        public string sendingType { get; set; }


        [Column(Name = nameof(EI.Invoice.senderName), DbType = "NVARCHAR")]
        public string senderName { get; set; }


        [Column(Name = nameof(EI.Invoice.senderVkn), DbType = "VARCHAR")]
        public string senderVkn { get; set; }


        [Column(Name = nameof(EI.Invoice.receiverVkn), DbType = "VARCHAR")]
        public string receiverVkn { get; set; }


  
        [Column(Name = nameof(EI.Invoice.stateNote), DbType = "NVARCHAR")]
        public string stateNote { get; set; }


    
        [Column(Name = nameof(EI.Invoice.status), DbType = "NVARCHAR")]
        public string status { get; set; }



        [Column(Name = nameof(EI.Invoice.statusCode), DbType = "NVARCHAR")]
        public string statusCode { get; set; }



        [Column(Name = nameof(EI.Invoice.uuid), IsDbGenerated = true, IsPrimaryKey = true, DbType = "NVARCHAR")]
        [Key]
        public string uuid { get; set; }



        [Column(Name = nameof(EI.Invoice.mailStatus), DbType = "NVARCHAR")]
        public string mailStatus { get; set; }



        [Column(Name = nameof(EI.Invoice.receiverMail), DbType = "VARCHAR")]
        public string receiverMail { get; set; }


        [Column(Name = nameof(EI.Invoice.currencyCode), DbType = "VARCHAR")]
        public string currencyCode { get; set; }



        [Column(Name = nameof(EI.Invoice.folderPath), DbType = "NVARCHAR")]
        public string folderPath { get; set; }



    }
}
