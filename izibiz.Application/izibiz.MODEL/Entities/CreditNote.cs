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

    [Table(Name = nameof(EI.CreditNote.CreditNotes))]
    public class CreditNotes
    {
        [Column(Name = nameof(EI.CreditNote.UUID), IsDbGenerated = true, IsPrimaryKey = true, DbType = "NVARCHAR")]
        [Key]     
        public string uuid { get; set; }
        

        [Column(Name = nameof(EI.CreditNote.CreditNoteID), DbType = "NVARCHAR")]
        public string CreditNoteID { get; set; }
        

        [Column(Name = nameof(EI.CreditNote.isDraft), DbType = "NVARCHAR")]
        public string isDraft { get; set; }

        [Column(Name = nameof(EI.CreditNote.draftDesc), DbType = "NVARCHAR")]
        public string draftDesc { get; set; }

        [Column(Name = nameof(EI.CreditNote.customerTitle), DbType = "VARCHAR")]
        public string customerTitle { get; set; }


        [Column(Name = nameof(EI.CreditNote.customerIdentifier), DbType = "VARCHAR")]
        public string customerIdentifier { get; set; }



        [Column(Name = nameof(EI.CreditNote.profileID), DbType = "NVARCHAR")]
        public string profileID { get; set; }



        [Column(Name = nameof(EI.CreditNote.status), DbType = "NVARCHAR")]
        public string status { get; set; }



        [Column(Name = nameof(EI.CreditNote.statusCode), DbType = "INTEGER")]
        public int statusCode { get; set; }



        [Column(Name = nameof(EI.CreditNote.statusDesc), DbType = "NVARCHAR")]
        public string statusDesc { get; set; }



        [Column(Name = nameof(EI.CreditNote.CDate), DbType = "DATETIME")]
        public DateTime cDate { get; set; }


        [Column(Name = nameof(EI.CreditNote.issueDate), DbType = "DATETIME")]
        public DateTime issueDate { get; set; }



        [Column(Name = nameof(EI.CreditNote.email), DbType = "NVARCHAR")]
        public string email { get; set; }



        [Column(Name = nameof(EI.CreditNote.emailStatusCode), DbType = "INTEGER")]
        public int emailStatusCode { get; set; }




        [Column(Name = nameof(EI.Invoice.folderPath), DbType = "NVARCHAR")]
        public string folderPath { get; set; }
        
        
        
    }
}
