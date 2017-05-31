using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FinalProject.DAL
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext(): base("name = FinalProject")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<FinalProjectContext>(new DropCreateDatabaseIfModelChanges<FinalProjectContext>());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}