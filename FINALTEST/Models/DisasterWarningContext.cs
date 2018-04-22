using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FINALTEST.Models
{
    public class DisasterWarningContext : DbContext
    {
        public DisasterWarningContext() : base("DbContextString")
        {

        }

        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Warning> Warnings { get; set; }
        public DbSet<SentWarning> SentWarnings { get; set; }
        public DbSet<TobeSend> TobeSends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}