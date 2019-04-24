using izibiz.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.MODEL.Models
{


    [Table(Name = "InvoiceIdSerials")]
    public class InvoiceIdSerials
    {

        [Key]
        [Column(Name = "serialName", IsDbGenerated = true, IsPrimaryKey = true, DbType = "VARCHAR")]
        public string serialName { get; set; }

      
        [Column(Name = "year",  DbType = "VARCHAR")]
        public string year { get; set; }



        [Column(Name = "seriNo", DbType = "VARCHAR")]
        public string seriNo { get; set; }

    }
}