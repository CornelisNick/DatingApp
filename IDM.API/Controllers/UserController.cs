using System.Security.Claims;
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
    public class UserController: ControllerBase
    {
        private readonly IIDMRepository _repo;
        private readonly IConfiguration _config;

        public UserController(IIDMRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get() {

            var issuerId = User.FindFirst(ClaimTypes.PrimarySid).Value;

            var users = await _repo.Users.GetAllUsers(issuerId);

            return Ok(users);
        }        
    }
}