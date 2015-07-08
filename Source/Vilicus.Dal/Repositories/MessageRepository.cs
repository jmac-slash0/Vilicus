using Vilicus.Dal.Models;
using Vilicus.Dal.Interfaces;

namespace Vilicus.Dal.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(VilicusContext context)
            : base(context)
        {
        }

    }
}
