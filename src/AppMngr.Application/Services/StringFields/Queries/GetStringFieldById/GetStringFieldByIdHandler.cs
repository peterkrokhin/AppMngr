using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace AppMngr.Application
{
    public class GetStringFieldByIdHandler : IRequestHandler<GetStringFieldByIdQuery, StringFieldDto>
    {
        private readonly IStringFieldRepo _stringFields;
        private readonly IMapper _mapper;

        public GetStringFieldByIdHandler(IStringFieldRepo stringFields, IMapper mapper)
        {
            _stringFields = stringFields;
            _mapper = mapper;
        }

        public async Task<StringFieldDto> Handle(GetStringFieldByIdQuery query, CancellationToken cancellationToken)
        {
            var stringField = await _stringFields.GetByIdAsync(query.Id);

            if (stringField == null)
            {
                throw new StringFieldNotFoundException($"Поле типа string с Id={query.Id} не найдено.");
            }
            
            var stringFieldDto = _mapper.Map<StringFieldDto>(stringField);
            return stringFieldDto;
        }
    }
}