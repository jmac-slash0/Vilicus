using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;
using Vilicus.Dal.Models;

namespace Vilicus.Dal
{
    public class VilicusContext : DbContext
    {

        public VilicusContext() : base("VilicusContext")
        {
        }

        public DbSet<Tag> Tag { get; set; }
        public DbSet<TicketTagMapping> TicketTagMapping { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Datetime2 is the recommended type for dates and times in SQL Server 2008 onwards.
            // EF will always map.Net DateTimes to the SQL Server datetime type, so we want to 
            // tell it to always map DateTime to DateTime2 instead at a global level.
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }

    internal static class MissingDllHack
    {
        private static SqlProviderServices instance = SqlProviderServices.Instance;
    }
}