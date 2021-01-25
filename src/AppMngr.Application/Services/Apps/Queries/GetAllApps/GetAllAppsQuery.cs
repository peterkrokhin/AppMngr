using System.Collections.Generic;
using MediatR;

namespace AppMngr.Application
{
    public class GetAllAppsQuery : IRequest<IEnumerable<AppDto>>
    {
    }
}