using System.Collections.Generic;
using MediatR;

namespace AppMngr.Application
{
    public class GetAllAppTypesQuery : IRequest<IEnumerable<AppTypeDto>>
    {
    }
}