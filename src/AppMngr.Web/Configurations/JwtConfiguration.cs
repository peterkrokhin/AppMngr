using System;
using Microsoft.Extensions.Configuration;

namespace AppMngr.Web
{
    public class JwtConfiguration
    {
        public string Issuer { get; private set; }
        public string Audience { get; private set; }
        public TimeSpan LifeTime { get; private set; }
        public string Key { get; private set; }

        public JwtConfiguration(IConfiguration configuration)
        {
            Issuer = configuration["JWT:Issuer"];
            Audience = configuration["JWT:Audience"];
            LifeTime = TimeSpan.FromMinutes(double.Parse(configuration["JWT:LifeTime"]));
            Key = (configuration["JWT:Key"]);
        }
    }
}