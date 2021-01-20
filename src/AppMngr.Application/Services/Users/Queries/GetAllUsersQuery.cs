using System.Collections.Generic;
using MediatR;

namespace AppMngr.Application
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDTO>>
    {

    }
}