using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AppMngr.Application;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace AppMngr.Web
{
    public class GetTokenService : IGetTokenService
    {
        private readonly JwtConfiguration _jwtConfiguration;
        private UserDto _user;
        
        public GetTokenService(IConfiguration configuration)
        {
            _jwtConfiguration = new JwtConfiguration(configuration);
        }

        public TokenData GetTokenData(UserDto user)
        {
            _user = user;

            ClaimsIdentity identity = GetIdentity();
            
            var token = CreateEncodedJwt(identity);

            var tokenData = new TokenData(token, identity.Name);

            return tokenData;
        }

        private ClaimsIdentity GetIdentity()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, _user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, _user.Role.Name),
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
    }
}