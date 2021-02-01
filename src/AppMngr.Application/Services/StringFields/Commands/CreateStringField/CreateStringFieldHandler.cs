using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class CreateStringFieldHandler : IRequestHandler<CreateStringFieldCommand, StringFieldDto>
    {
        private IAppTypeRepo _appTypes;
        private IStringFieldRepo _stringFields;
        private IUOW _uow;
        private IMapper _mapper;
        
        public CreateStringFieldHandler(IAppTypeRepo appTypes, IStringFieldRepo stringFields, IUOW uow, IMapper mapper)
        {
            _appTypes = appTypes;
            _stringFields = stringFields;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<StringFieldDto> Handle(CreateStringFieldCommand command, CancellationToken cancellationToken)
        {
            var appType = await _appTypes.GetByIdAsync(command.AppTypeId);
            if (appType == null)
            {
                throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
            }

            var stringField = new StringField()
            {
                Value = command.Value,
                AppTypeId = command.AppTypeId
            };

            await _stringFields.AddAsync(stringField);
            await _uow.SaveChangesAsync();

            var stringFieldDto = _mapper.Map<StringFieldDto>(stringField);
            return stringFieldDto;
        }
    }
}