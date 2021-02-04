using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class CreateNumFieldHandler : IRequestHandler<CreateNumFieldCommand, NumFieldDto>
    {
        private IAppTypeRepo _appTypes;
        private INumFieldRepo _numFields;
        private IUOW _uow;
        private IMapper _mapper;
        
        public CreateNumFieldHandler(IAppTypeRepo appTypes, INumFieldRepo numFields, IUOW uow, IMapper mapper)
        {
            _appTypes = appTypes;
            _numFields = numFields;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<NumFieldDto> Handle(CreateNumFieldCommand command, CancellationToken cancellationToken)
        {
            var appType = await _appTypes.GetByIdAsync(command.AppTypeId);
            if (appType == null)
            {
                throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
            }

            var numField = new NumField()
            {
                Value = command.Value,
                AppTypeId = command.AppTypeId
            };

            await _numFields.AddAsync(numField);
            await _uow.SaveChangesAsync();

            var numFieldDto = _mapper.Map<NumFieldDto>(numField);
            return numFieldDto;
        }
    }
}