using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace AppMngr.Application
{
    public class GetUserByNameAndPasswordHandler : IRequestHandler<GetUserByNameAndPasswordQuery, UserDto>
    {
        private readonly IUserRepo _users;
        private readonly IMapper _mapper;

        public GetUserByNameAndPasswordHandler(IUserRepo users, IMapper mapper)
        {
            _users = users;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByNameAndPasswordQuery query, CancellationToken cancellationToken)
        {
            var user = await _users.GetByNameAndPasswordHashAsync(query.Name, query.GetPasswordHash());

            if (user == null)
            {
                throw new UserNotFoundException($"User c Name={query.Name} и Password=*** не найден.");
            }

            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}