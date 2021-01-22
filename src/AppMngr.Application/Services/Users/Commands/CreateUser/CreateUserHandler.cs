using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepo _users;
        private readonly IRoleRepo _roles;
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepo users, IRoleRepo roles, IUOW uow, IMapper mapper)
        {
            _users = users;
            _roles = roles;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var role = await _roles.GetByIdAsync(command.RoleId);
            if (role == null)
            {
                throw new RoleNotFoundException($"Роль с Id={command.RoleId} не найдена.");
            }

            User user = new User()
            {
                Name = command.Name,
                PwdHash = Utils.GetHashOrEmpty(command.Pwd),
                RoleId = command.RoleId
            };

            await _users.AddAsync(user);
            await _uow.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }
    }
}