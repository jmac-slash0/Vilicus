using Vilicus.Dal.Models;
using Vilicus.Dal.Interfaces;

namespace Vilicus.Dal.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        // Get context private variable from base class: _context

        public MessageRepository(VilicusContext context)
            : base(context)
        {
        }

    }
}
