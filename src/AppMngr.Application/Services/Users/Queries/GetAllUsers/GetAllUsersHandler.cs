using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using AppMngr.Core;

namespace AppMngr.Application
{
    class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepo _users;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUserRepo users, IMapper mapper)
        {
            _users = users;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            var users = await _users.GetAllAsync();
            var usersDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
            return usersDto;
        }
    }
}