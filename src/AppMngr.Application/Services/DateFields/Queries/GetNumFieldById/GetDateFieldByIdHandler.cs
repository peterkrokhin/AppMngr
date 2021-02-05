using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace AppMngr.Application
{
    public class GetDateFieldByIdHandler : IRequestHandler<GetDateFieldByIdQuery, DateFieldDto>
    {
        private readonly IDateFieldRepo _dateFields;
        private readonly IMapper _mapper;

        public GetDateFieldByIdHandler(IDateFieldRepo dateFields, IMapper mapper)
        {
            _dateFields = dateFields;
            _mapper = mapper;
        }

        public async Task<DateFieldDto> Handle(GetDateFieldByIdQuery query, CancellationToken cancellationToken)
        {
            var dateField = await _dateFields.GetByIdAsync(query.Id);

            if (dateField == null)
            {
                throw new DateFieldNotFoundException($"Поле типа дата с Id={query.Id} не найдено.");
            }
            
            var dateFieldDto = _mapper.Map<DateFieldDto>(dateField);
            return dateFieldDto;
        }
    }
}