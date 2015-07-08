using Vilicus.Dal.Models;
using Vilicus.Dal.Interfaces;

namespace Vilicus.Dal.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(VilicusContext context) : base(context)
        {
        }

    }
}
