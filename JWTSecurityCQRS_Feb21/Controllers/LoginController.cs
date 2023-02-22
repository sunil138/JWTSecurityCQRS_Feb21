using JWTSecurityCQRS_Feb21.DataAccess;
using JWTSecurityCQRS_Feb21.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims; 
using System.Text;

namespace JWTSecurityWithCQRS_Feb20.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //Interface Object
        private IUser _user;
        private IConfiguration _configuration;
        public LoginController(IUser user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("PostLoginDetails")]
        public async Task<IActionResult> LoginDetails(Tuser tblUser)
        {
            //checking whether the data entered by me and data present in the database is correct or not.
            if (tblUser != null)
            {
                var LoginCheck = _user.GetUsers()
                    .Where(a => a.UserId == tblUser.UserId && a.Password == tblUser.Password)
                    .FirstOrDefault();
                if (LoginCheck != null)
                {
                    var Token = GetToken(LoginCheck);
                    return Ok(Token);
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }

        //Getting the Token from getToken() Method with help of issuer,audience,claims,signing credentials
        private string GetToken(Tuser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, user.Role)

            };

            var tokens = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
             
            return new JwtSecurityTokenHandler().WriteToken(tokens);
        }

    }
}
