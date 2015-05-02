using Vilicus.Dal.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;

namespace Vilicus.Dal
{
    public class TicketContext : DbContext
    {

        public TicketContext() : base("TicketContext")
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
        }
    }

    internal static class MissingDllHack
    {
        private static SqlProviderServices instance = SqlProviderServices.Instance;
    }
}