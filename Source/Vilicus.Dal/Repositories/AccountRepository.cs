using Vilicus.Dal.Models;
using Vilicus.Dal.Interfaces;
using System.Linq;

namespace Vilicus.Dal.Repositories
{
    public class AccountRepository : BaseRepository<User>, IAccountRepository
    {
        VilicusContext context = null;

        public AccountRepository(VilicusContext context)
            : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// Check a user's login credentials
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string email, string password)
        {
            // Check database for user with email and password combo, and make sure they are active
            return context.User.Any(o => o.Email.Equals(email) && o.Password.Equals(password) && o.IsActive);
        }

        /// <summary>
        /// Check if an email address has been taken already
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsEmailTaken(string email)
        {
            return context.User.Any(o => o.Email.Equals(email));
        }

    }
}
