using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IDM.API.DTOs;
using IDM.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IDM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class AuthController: ControllerBase
    {
        private readonly IIDMRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IIDMRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto) 
        {
            var userFromRepo = await _repo.Users.Login(userForLoginDto.Username, userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            // Create an authentication token

            var claims = new[] {
                new Claim(ClaimTypes.PrimarySid, userFromRepo.IssuerId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512);
            
            var tokenDescriptor = new SecurityTokenDescriptor() {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token), user = userForLoginDto.Username});
        }
    }
}