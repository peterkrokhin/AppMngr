using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class GetAllAppsHandler : IRequestHandler<GetAllAppsQuery, IEnumerable<AppDto>>
    {
        private readonly IAppRepo _apps;
        private readonly IMapper _mapper;

        public GetAllAppsHandler(IAppRepo apps, IMapper mapper)
        {
            _apps = apps;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppDto>> Handle(GetAllAppsQuery request, CancellationToken cancellationToken)
        {
            var apps = await _apps.GetAllAsync();
            var appsDto = _mapper.Map<IEnumerable<App>, IEnumerable<AppDto>>(apps);
            return appsDto;
        }
    }
}