using System.Collections.Generic;
using System.Threading.Tasks;
using IDM.API.Models;

namespace IDM.API.Repositories
{
    public interface IProviderRepository
    {
         Task<IEnumerable<Provider>> GetAllProviders();
    }
}