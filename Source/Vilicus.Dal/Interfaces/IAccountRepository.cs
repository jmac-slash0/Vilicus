using Vilicus.Dal.Models;

namespace Vilicus.Dal.Interfaces
{
    public interface IAccountRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Check a user's login credentials
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Login(string email, string password);

        /// <summary>
        /// Check if an email address has been taken already
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool IsEmailTaken(string email);
    }
}
