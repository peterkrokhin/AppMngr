using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace AppMngr.Application
{
    public class GetAppTypeByIdHandler : IRequestHandler<GetAppTypeByIdQuery, AppTypeDto>
    {
        private readonly IAppTypeRepo _appTypes;
        private readonly IMapper _mapper;

        public GetAppTypeByIdHandler(IAppTypeRepo appTypes, IMapper mapper)
        {
            _appTypes = appTypes;
            _mapper = mapper;
        }

        public async Task<AppTypeDto> Handle(GetAppTypeByIdQuery query, CancellationToken cancellationToken)
        {
            var appType = await _appTypes.GetByIdAsync(query.Id);

            if (appType == null)
            {
                throw new AppTypeNotFoundException($"Тип заявки c Id={query.Id} не найден.");
            }
            
            var appTypeDto = _mapper.Map<AppTypeDto>(appType);
            return appTypeDto;
        }
    }
}