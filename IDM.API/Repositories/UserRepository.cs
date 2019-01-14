using System.Collections.Generic;
using System.Threading.Tasks;
using IDM.API.Helpers;
using IDM.API.Models;

namespace IDM.API.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDMDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUsers(string issuerId)
        {
            return await this.FindAllAsync(q => q.IssuerId == issuerId);
        }

        public async Task<User> GetByName(string username)
        {
            var user = await this.FindAsync(q => q.Username == username);

            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await this.FindAsync(q => q.Username == username);

            if (user == null)
                return null;

            if (!Hashing.VerifyPasswordHash(password,user.PasswordHash, user.PasswordSalt))
                return null;

            return user;           
        }
    }
}