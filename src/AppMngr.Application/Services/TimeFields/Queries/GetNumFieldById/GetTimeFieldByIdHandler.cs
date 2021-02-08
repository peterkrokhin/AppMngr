using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace AppMngr.Application
{
    public class GetTimeFieldByIdHandler : IRequestHandler<GetTimeFieldByIdQuery, TimeFieldDto>
    {
        private readonly ITimeFieldRepo _timeFields;
        private readonly IMapper _mapper;

        public GetTimeFieldByIdHandler(ITimeFieldRepo timeFields, IMapper mapper)
        {
            _timeFields = timeFields;
            _mapper = mapper;
        }

        public async Task<TimeFieldDto> Handle(GetTimeFieldByIdQuery query, CancellationToken cancellationToken)
        {
            var timeField = await _timeFields.GetByIdAsync(query.Id);

            if (timeField == null)
            {
                throw new TimeFieldNotFoundException($"Поле типа время с Id={query.Id} не найдено.");
            }
            
            var timeFieldDto = _mapper.Map<TimeFieldDto>(timeField);
            return timeFieldDto;
        }
    }
}