using MediatR;

namespace AppMngr.Application
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Name { get; set; }
        public string Pwd { get; set; }
        public int RoleId { get; set; }
    }
}