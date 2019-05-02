using izibiz.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.MODEL.DbModels
{
    [Table(Name = nameof(EI.GibUser.GibUsers))]
    public class GibUsers
    {

        [Key]
        [Column(Name =nameof(EI.GibUser.aliasPk), DbType = "VARCHAR")]
        public string aliasPk { get; set; }


        [Column(Name = nameof(EI.GibUser.identifier), DbType = "VARCHAR")]
        public string identifier { get; set; }



        [Column(Name = nameof(EI.GibUser.title), DbType = "VARCHAR")]
        public string title { get; set; }

    }
}
