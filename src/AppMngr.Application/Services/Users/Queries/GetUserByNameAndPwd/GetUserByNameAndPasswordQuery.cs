using MediatR;

namespace AppMngr.Application
{
    public class GetUserByNameAndPasswordQuery : IRequest<UserDto>
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public string GetPasswordHash()
        {
            return Utils.GetHashOrEmpty(Password);
        } 
    }
}