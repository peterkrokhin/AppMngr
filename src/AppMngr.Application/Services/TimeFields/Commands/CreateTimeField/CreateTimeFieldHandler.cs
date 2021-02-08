using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class CreateTimeFieldHandler : IRequestHandler<CreateTimeFieldCommand, TimeFieldDto>
    {
        private IAppTypeRepo _appTypes;
        private ITimeFieldRepo _timeFields;
        private IUOW _uow;
        private IMapper _mapper;
        
        public CreateTimeFieldHandler(IAppTypeRepo appTypes, ITimeFieldRepo timeFields, IUOW uow, IMapper mapper)
        {
            _appTypes = appTypes;
            _timeFields = timeFields;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<TimeFieldDto> Handle(CreateTimeFieldCommand command, CancellationToken cancellationToken)
        {
            var appType = await _appTypes.GetByIdAsync(command.AppTypeId);
            if (appType == null)
            {
                throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
            }

            var timeField = new TimeField()
            {
                Value = command.Value,
                AppTypeId = command.AppTypeId
            };

            await _timeFields.AddAsync(timeField);
            await _uow.SaveChangesAsync();

            var timeFieldDto = _mapper.Map<TimeFieldDto>(timeField);
            return timeFieldDto;
        }
    }
}