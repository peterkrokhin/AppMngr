using Microsoft.IdentityModel.Tokens;
using System.Text;
 
namespace AppMngr.Web
{
    public class AuthOptions
    {
        public const string ISSUER = "AppMngrAuthServer"; // издатель токена
        public const string AUDIENCE = "AppMngrAuthClient"; // потребитель токена
        const string KEY = "kdjfjoiwerslf219308uitje";   // ключ шифра
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}