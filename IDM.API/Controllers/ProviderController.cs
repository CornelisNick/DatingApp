using System.Threading.Tasks;
using IDM.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IDM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProviderController: ControllerBase
    {
        private readonly IIDMRepository _repo;
        private readonly IConfiguration _config;

        public ProviderController(IIDMRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get() {
            var issuers = await _repo.Providers.GetAllProviders();
            return Ok(issuers);
        }
    }
}