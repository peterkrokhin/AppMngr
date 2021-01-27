using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace AppMngr.Application
{
    public class GetStatusByIdHandler : IRequestHandler<GetStatusByIdQuery, StatusDto>
    {
        private readonly IStatusRepo _statuses;
        private readonly IMapper _mapper;

        public GetStatusByIdHandler(IStatusRepo statuses, IMapper mapper)
        {
            _statuses = statuses;
            _mapper = mapper;
        }

        public async Task<StatusDto> Handle(GetStatusByIdQuery query, CancellationToken cancellationToken)
        {
            var status = await _statuses.GetByIdAsync(query.Id);

            if (status == null)
            {
                throw new StatusNotFoundException($"Статус с Id={query.Id} не найдена.");
            }
            
            var statusDto = _mapper.Map<StatusDto>(status);
            return statusDto;
        }
    }
}