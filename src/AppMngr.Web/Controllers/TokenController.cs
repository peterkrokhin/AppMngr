using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using AppMngr.Application;
using Microsoft.Extensions.Logging;
using System.Text.Json;

using AppMngr.Core;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Text;


namespace AppMngr.Web
{
    [ApiController]
    [Route("api/")]
    public class TokenController : Controller
    {
        IConfiguration Configuration { get; set; }
        IUserRepo Users { get; set; }

        public TokenController(IConfiguration configuration, IUserRepo users)
        {  
            Users = users;
            Configuration = configuration;
        }

        // POST api/token  
        [HttpPost("token")]
        public async Task<IActionResult> Token(JsonDocument doc)
        {
            JsonElement root = doc.RootElement;
            string name = root.GetProperty("name").GetString();
            string pwd = root.GetProperty("pwd").GetString();

            ClaimsIdentity identity;
            try
            {
                identity = await TryGetIdentityAsync(name, pwd);
            }
            catch
            {
                return BadRequest("Invalid user name or password");
            }
            
            var now = DateTime.UtcNow;
            
            // Получаем JWT
            var jwt = new JwtSecurityToken(
                    issuer: Configuration["JWT:Issuer"],
                    audience: Configuration["JWT:Audience"],
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(double.Parse(Configuration["JWT:LifeTime"]))),
                    signingCredentials: 
                        new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])), SecurityAlgorithms.HmacSha256));
            
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
 
            return Ok(new {token = encodedJwt, name = identity.Name});
        }
 
        private async Task<ClaimsIdentity> TryGetIdentityAsync(string name, string pwd)
        {
            string pwdHash = Utils.GetHashOrEmpty(pwd);
            
            User user = await Users.GetByNameAndPwdHash(name, pwdHash);
            
            if (user == null)
                throw new Exception("Invalid user name or password");
            
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
            
        }

    }
}