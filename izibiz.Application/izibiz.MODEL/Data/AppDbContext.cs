using izibiz.MODEL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.MODEL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Invoice> sentInvoices { get; set; }

        public DbSet<Invoice> incomingInvoices { get; set; }

        public DbSet<Invoice> draftInvoices { get; set; }


       
    }
}
