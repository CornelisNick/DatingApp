using System.Collections.Generic;
using System.Threading.Tasks;
using IDM.API.Models;

namespace IDM.API.Repositories
{
    public interface IIssuerRepository
    {
         Task<IEnumerable<Issuer>> GetAllIssuers();
    }
}