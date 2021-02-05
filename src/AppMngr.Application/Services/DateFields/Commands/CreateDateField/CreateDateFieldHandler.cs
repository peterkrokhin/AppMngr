using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class CreateDateFieldHandler : IRequestHandler<CreateDateFieldCommand, DateFieldDto>
    {
        private IAppTypeRepo _appTypes;
        private IDateFieldRepo _dateFields;
        private IUOW _uow;
        private IMapper _mapper;
        
        public CreateDateFieldHandler(IAppTypeRepo appTypes, IDateFieldRepo dateFields, IUOW uow, IMapper mapper)
        {
            _appTypes = appTypes;
            _dateFields = dateFields;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<DateFieldDto> Handle(CreateDateFieldCommand command, CancellationToken cancellationToken)
        {
            var appType = await _appTypes.GetByIdAsync(command.AppTypeId);
            if (appType == null)
            {
                throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
            }

            var dateField = new DateField()
            {
                Value = command.Value,
                AppTypeId = command.AppTypeId
            };

            await _dateFields.AddAsync(dateField);
            await _uow.SaveChangesAsync();

            var dateFieldDto = _mapper.Map<DateFieldDto>(dateField);
            return dateFieldDto;
        }
    }
}