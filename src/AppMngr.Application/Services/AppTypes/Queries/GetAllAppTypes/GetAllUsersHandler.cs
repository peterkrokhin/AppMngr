using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using AppMngr.Core;

namespace AppMngr.Application
{
    class GetAllAppTypesHandler : IRequestHandler<GetAllAppTypesQuery, IEnumerable<AppTypeDto>>
    {
        private readonly IAppTypeRepo _appTypes;
        private readonly IMapper _mapper;

        public GetAllAppTypesHandler(IAppTypeRepo appTypes, IMapper mapper)
        {
            _appTypes = appTypes;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AppTypeDto>> Handle(GetAllAppTypesQuery query, CancellationToken cancellationToken)
        {
            var appTypes = await _appTypes.GetAllAsync();
            var appTypesDto = _mapper.Map<IEnumerable<AppType>, IEnumerable<AppTypeDto>>(appTypes);
            return appTypesDto;
        }
    }
}