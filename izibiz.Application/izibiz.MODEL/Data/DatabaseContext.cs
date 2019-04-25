using izibiz.MODEL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace izibiz.MODEL.Data
{
    public class DatabaseContext : DbContext
    {


        public DatabaseContext() :         
            base(new SQLiteConnection()
            {
                //datasourcede projenızın yer aldıgı dızını yazınız
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = "C:\\Users\\gamze.sahin\\Desktop\\ws-client-dotnet-son\\izibiz.Application\\izibiz.MODEL\\Db\\izibiz-Entegrasyon.s3db", ForeignKeys = true }.ConnectionString
            }, true)
        {
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Invoices> Invoices { get; set; }

        public DbSet<InvoiceIdSerials> InvoiceIdSerials { get; set; }

    }
}
