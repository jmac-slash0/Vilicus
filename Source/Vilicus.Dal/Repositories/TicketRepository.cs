using Vilicus.Dal.Models;
using Vilicus.Dal.Interfaces;

namespace Vilicus.Dal.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        // Get context private variable from base class: _context

        public TicketRepository(TicketContext context) : base(context)
        {
        }

    }
}
