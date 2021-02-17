using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AppMngr.Application;
using AppMngr.Core;

namespace AppMngr.Web
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        IConfiguration Configuration { get; set; }
        IUserRepo Users { get; set; }
        private JwtConfiguration _jwtConfiguration;

        public TokenController(IConfiguration configuration, IUserRepo users)
        {  
            Users = users;
            Configuration = configuration;
            _jwtConfiguration = new JwtConfiguration(configuration);
        }

        /// <summary>Получение токена</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "name": "UserName", // Имя пользователя, not null, required
        ///        "pwd": "UserPwd"    // Пароль пользователя, not null, required
        ///     }
        ///
        ///     Администратор по умолчанию:
        ///     {
        ///        "name": "default_admin",
        ///        "pwd": "default_pwd"
        ///     }
        ///
        ///     Клиент по умолчанию:
        ///     {
        ///        "name": "default_client",
        ///        "pwd": "default_pwd"
        ///     }  
        /// </remarks>
        // POST api/token  
        [HttpPost]
        public async Task<IActionResult> Token(AuthUser authUser)
        {
            var user = await GetUserByNameAndPwd(authUser);

            ClaimsIdentity identity = GetIdentity(user);

            return Ok(new {token = CreateEncodedJwt(identity), name = identity.Name});
        }
 
        private ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        private string CreateEncodedJwt(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
                
            // Получаем JWT
            var jwt = new JwtSecurityToken(
                issuer: _jwtConfiguration.Issuer,
                audience: _jwtConfiguration.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(_jwtConfiguration.LifeTime),
                signingCredentials: CreateSigningCredentials());
                
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(CreateSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
        }

        private SymmetricSecurityKey CreateSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key));
        }

        private async Task<User> GetUserByNameAndPwd(AuthUser authUser)
        {
            string pwdHash = Utils.GetHashOrEmpty(authUser.Pwd);
            
            User user = await Users.GetByNameAndPwdHash(authUser.Name, pwdHash);
            
            if (user == null)
                throw new Exception("Invalid user name or password");

            return user;
        } 
    }
}