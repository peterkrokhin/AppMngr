using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AppMngr.Application
{
    class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDTO>>
    {
        public Task<IEnumerable<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}