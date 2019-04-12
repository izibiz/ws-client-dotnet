using izibiz.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.MODEL.Model
{
    [Table(Name = "DraftCreatedInv")]
    public class DraftCreatedInv
    {

        [Column(Name = nameof(EI.InvClmName.ID), DbType = "NVARCHAR")]
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



        [Column(Name = nameof(EI.InvClmName.fromm), DbType = "NVARCHAR")]
        public string fromm { get; set; }


        [Column(Name = nameof(EI.InvClmName.too), DbType = "NVARCHAR")]
        public string too { get; set; }


        [Column(Name = nameof(EI.InvClmName.content), DbType = "NVARCHAR")]
        public string content { get; set; }


 
    }

}
