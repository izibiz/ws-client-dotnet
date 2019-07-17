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
using System.ComponentModel.DataAnnotations;

namespace izibiz.MODEL.DbTablesModels
{

    [Table(Name = nameof(EI.UserInformation.UserInformation))]
    public class UserInformation
    {

        [Key]
        [Column(Name = nameof(EI.UserInformation.vknTckn), IsDbGenerated = true, IsPrimaryKey = true, DbType = "NVARCHAR")]      
        public string vknTckn { get; set; }


        [Column(Name = nameof(EI.UserInformation.firstName), DbType = "VARCHAR")]
        public string firstName { get; set; }



        [Column(Name = nameof(EI.UserInformation.familyName), DbType = "VARCHAR")]
        public string familyName { get; set; }



        [Column(Name = nameof(EI.UserInformation.partyName), DbType = "NVARCHAR")]
        public string partyName { get; set; }


        [Column(Name = nameof(EI.UserInformation.mail), DbType = "NVARCHAR")]
        public string mail { get; set; }


        [Column(Name = nameof(EI.UserInformation.phone), DbType = "NVARCHAR")]
        public string phone { get; set; }


        [Column(Name = nameof(EI.UserInformation.fax), DbType = "VARCHAR")]
        public string fax { get; set; }


        [Column(Name = nameof(EI.UserInformation.webUri), DbType = "VARCHAR")]
        public string webUri { get; set; }



        [Column(Name = nameof(EI.UserInformation.sicilNo), DbType = "NVARCHAR")]
        public string sicilNo { get; set; }



        [Column(Name = nameof(EI.UserInformation.taxScheme), DbType = "NVARCHAR")]
        public string taxScheme { get; set; }



        [Column(Name = nameof(EI.UserInformation.country), DbType = "NVARCHAR")]
        public string country { get; set; }


        [Column(Name = nameof(EI.UserInformation.cityName), DbType = "NVARCHAR")]
        public string cityName { get; set; }


        [Column(Name = nameof(EI.UserInformation.citySubdivisionName), DbType = "NVARCHAR")]
        public string citySubdivisionName { get; set; }


        [Column(Name = nameof(EI.UserInformation.streetName), DbType = "NVARCHAR")]
        public string streetName { get; set; }


        [Column(Name = nameof(EI.UserInformation.buldingName), DbType = "NVARCHAR")]
        public string buldingName { get; set; }


        [Column(Name = nameof(EI.UserInformation.buldingNumber), DbType = "NVARCHAR")]
        public string buldingNumber { get; set; }


        [Column(Name = nameof(EI.UserInformation.postalZone), DbType = "NVARCHAR")]
        public string postalZone { get; set; }


        [Column(Name = nameof(EI.UserInformation.aliasGb), DbType = "NVARCHAR")]
        public string aliasGb { get; set; }



    }
}
