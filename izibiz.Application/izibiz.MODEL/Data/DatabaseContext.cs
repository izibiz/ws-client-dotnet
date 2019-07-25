using izibiz.MODEL.DbTablesModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace izibiz.MODEL.Data
{
    public class DatabaseContext : DbContext
    {

        private static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;


        public DatabaseContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = projectDirectory + @"\izibiz.MODEL\Db\izibiz-Entegrasyon.s3db", ForeignKeys = true }.ConnectionString
            }, true)
        {
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Invoices> invoices { get; set; }

        public DbSet<ArchiveInvoices> archiveInvoices { get; set; }

        public DbSet<ArchiveReports> archiveReports { get; set; }

        public DbSet<DespatchAdvices> despatchAdvices { get; set; }

        public DbSet<Reconcilations> reconcilations { get; set; }

        public DbSet<InvoiceIdSerials> invoiceIdSerials { get; set; }

        public DbSet<UserInformation> userInformations { get; set; }

        public DbSet<GibUsers> gibUsers { get; set; }
    }
}
