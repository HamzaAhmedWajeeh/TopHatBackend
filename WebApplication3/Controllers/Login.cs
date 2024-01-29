using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Top_Hat_App.Models;

namespace Top_Hat_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Login : ControllerBase
    {
        private readonly TopHatContext _dbContext;
        IConfiguration _configuration;

        public Login(TopHatContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpPost("PostUserLoginDetails")]
       
        public async Task<IActionResult> PostLoginDetails(User _userData)
        {
            if (_userData != null)
            {
                var resultLoginCheck = _dbContext.Users
                    .Where(e => e.Email == _userData.Email && e.Password == _userData.Password)
                    .FirstOrDefault();
                if (resultLoginCheck == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {
                    

                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", resultLoginCheck.Id.ToString()),
                        new Claim("DisplayName", resultLoginCheck.Firstname),
                        new Claim("lastname", resultLoginCheck.Lastname),
                        new Claim("Email", resultLoginCheck.Email),
                        new Claim(ClaimTypes.Role, "User")
                    };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn);


                    _userData.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok("User Login Success");
                }
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }

        [HttpPost("PostAdminLoginDetails")]

        public async Task<IActionResult> PostAdminLoginDetails(Admin _userData)
        {
            if (_userData != null)
            {
                var resultLoginCheck = _dbContext.Admins
                    .Where(e => e.Email == _userData.Email && e.Password == _userData.Password)
                    .FirstOrDefault();
                if (resultLoginCheck == null)
                {
                    return BadRequest("Invalid Credentials");
                }
                else
                {


                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("AdminId", resultLoginCheck.Id.ToString()),
                        new Claim("Useranme", resultLoginCheck.Username),                       
                        new Claim("Email", resultLoginCheck.Email),
                        new Claim(ClaimTypes.Role, "Admin")
                    };


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn);


                    _userData.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok("Admin Login Success");
                }
            }
            else
            {
                return BadRequest("No Data Posted");
            }
        }


    }
}
