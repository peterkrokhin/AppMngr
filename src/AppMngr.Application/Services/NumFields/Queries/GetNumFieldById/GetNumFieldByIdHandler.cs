using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace AppMngr.Application
{
    public class GetNumFieldByIdHandler : IRequestHandler<GetNumFieldByIdQuery, NumFieldDto>
    {
        private readonly INumFieldRepo _numFields;
        private readonly IMapper _mapper;

        public GetNumFieldByIdHandler(INumFieldRepo numFields, IMapper mapper)
        {
            _numFields = numFields;
            _mapper = mapper;
        }

        public async Task<NumFieldDto> Handle(GetNumFieldByIdQuery query, CancellationToken cancellationToken)
        {
            var numField = await _numFields.GetByIdAsync(query.Id);

            if (numField == null)
            {
                throw new NumFieldNotFoundException($"Поле типа число с Id={query.Id} не найдено.");
            }
            
            var numFieldDto = _mapper.Map<NumFieldDto>(numField);
            return numFieldDto;
        }
    }
}