using AppMngr.Application;

namespace AppMngr.Web
{
    public interface IGetTokenService
    {
        TokenData GetTokenData(UserDto user);
    }
}