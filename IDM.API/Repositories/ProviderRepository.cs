using System.Collections.Generic;
using System.Threading.Tasks;
using IDM.API.Models;

namespace IDM.API.Repositories
{
    public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(IDMDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Provider>> GetAllProviders()
        {
            return await this.GetAllAsync();
        }
    }
}