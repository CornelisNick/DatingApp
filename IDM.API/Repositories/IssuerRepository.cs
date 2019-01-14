using System.Collections.Generic;
using System.Threading.Tasks;
using IDM.API.Models;

namespace IDM.API.Repositories
{
    public class IssuerRepository : GenericRepository<Issuer>, IIssuerRepository
    { 
        public IssuerRepository(IDMDataContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Issuer>> GetAllIssuers()
        {
            return await this.GetAllAsync();
        }
    }
}