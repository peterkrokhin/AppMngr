using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace AppMngr.Application
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepo _users;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepo users, IMapper mapper)
        {
            _users = users;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _users.GetByIdIncludeRoleAsync(query.Id);

            if (user == null)
            {
                throw new UserNotFoundException($"User c Id={query.Id} не найден.");
            }
            
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}