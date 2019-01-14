using System.Collections.Generic;
using System.Threading.Tasks;
using IDM.API.Models;

namespace IDM.API.Repositories
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> GetAllUsers(string providerId);

         Task<User> GetByName(string username);

         Task<User> Login(string username, string password);
    }
}