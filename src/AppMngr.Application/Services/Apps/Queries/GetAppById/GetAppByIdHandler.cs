using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace AppMngr.Application
{
    public class GetAppByIdHandler : IRequestHandler<GetAppByIdQuery, AppDto>
    {
        private readonly IAppRepo _apps;
        private readonly IMapper _mapper;

        public GetAppByIdHandler(IAppRepo apps, IMapper mapper)
        {
            _apps = apps;
            _mapper = mapper;
        }

        public async Task<AppDto> Handle(GetAppByIdQuery query, CancellationToken cancellationToken)
        {
            var app = await _apps.GetByIdAsync(query.Id);

            if (app == null)
            {
                throw new AppNotFoundException($"Заявка с Id={query.Id} не найдена.");
            }
            
            var appDto = _mapper.Map<AppDto>(app);
            return appDto;
        }
    }
}