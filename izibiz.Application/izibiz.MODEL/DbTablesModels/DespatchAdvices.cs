using izibiz.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.MODEL.DbTablesModels
{


    [Table(Name = nameof(EI.Despatch.DespatchAdvices))]
    public  class DespatchAdvices
    {

        [Column(Name = nameof(EI.Despatch.ID), DbType = "NVARCHAR")]
        public string ID { get; set; }



        [Column(Name = nameof(EI.Despatch.direction), DbType = "VARCHAR")]
        public string direction { get; set; }


        [Column(Name = nameof(EI.Despatch.draftFlag), DbType = "BOOLEAN")]
        public bool draftFlag { get; set; }


        [Column(Name = nameof(EI.Despatch.cDate), DbType = "NUMERIC")]
        public DateTime cDate { get; set; }




        [Column(Name = nameof(EI.Despatch.issueDate), DbType = "NUMERIC")]
        public DateTime issueDate { get; set; }



        [Column(Name = nameof(EI.Despatch.issueTime), DbType = "STRING")]
        public string issueTime { get; set; }


        [Column(Name = nameof(EI.Despatch.senderVkn), DbType = "VARCHAR")]
        public string senderVkn { get; set; }


        [Column(Name = nameof(EI.Despatch.receiverVkn), DbType = "VARCHAR")]
        public string receiverVkn { get; set; }


        [Column(Name = nameof(EI.Despatch.shipmentDate), DbType = "NUMERIC")]
        public DateTime shipmentDate { get; set; }



        [Column(Name = nameof(EI.Despatch.shipmentTime), DbType = "STRING")]
        public string shipmentTime { get; set; }




        [Column(Name = nameof(EI.Despatch.profileId), DbType = "NVARCHAR")]
        public string profileId { get; set; }



        [Column(Name = nameof(EI.Despatch.typeCode), DbType = "NVARCHAR")]
        public string typeCode { get; set; }



        [Column(Name = nameof(EI.Despatch.uuid), IsDbGenerated = true, IsPrimaryKey = true, DbType = "NVARCHAR")]
        [Key]
        public string uuid { get; set; }



        [Column(Name = nameof(EI.Despatch.envelopeIdentifier), DbType = "NVARCHAR")]
        public string envelopeIdentifier { get; set; }




        [Column(Name = nameof(EI.Despatch.stateNote), DbType = "NVARCHAR")]
        public string stateNote { get; set; }



        [Column(Name = nameof(EI.Despatch.status), DbType = "NVARCHAR")]
        public string status { get; set; }



        [Column(Name = nameof(EI.Despatch.statusCode), DbType = "NVARCHAR")]
        public string statusCode { get; set; }




        [Column(Name = nameof(EI.Despatch.gibStatusCode), DbType = "INTEGER")]
        public int gibStatusCode { get; set; }




        [Column(Name = nameof(EI.Despatch.gibStatusDescription), DbType = "NVARCHAR")]
        public string gibStatusDescription { get; set; }



        [Column(Name = nameof(EI.Despatch.folderPath), DbType = "NVARCHAR")]
        public string folderPath { get; set; }

    }
}
