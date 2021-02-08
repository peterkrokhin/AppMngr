using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AppMngr.Application
{
    public class UpdateTimeFieldHandler : AsyncRequestHandler<UpdateTimeFieldCommand>
    {
        private readonly IAppTypeRepo _appTypes;
        private readonly ITimeFieldRepo _timeFields;
        private readonly IUOW _uow;

        public UpdateTimeFieldHandler(IAppTypeRepo appTypes, ITimeFieldRepo timeFields, IUOW uow)
        {
            _appTypes = appTypes;
            _timeFields = timeFields;
            _uow = uow;
        }

        protected override async Task Handle(UpdateTimeFieldCommand command, CancellationToken cancellationToken)
        {
            var timeField = await _timeFields.GetByIdAsync(command.Id);
            if (timeField == null)
            {
                throw new TimeFieldNotFoundException($"Поле типа время с Id={command.Id} не найдено.");
            }

            if (command.Value != null)
            {
                timeField.Value = command.Value.Value;
            }

            if (command.AppTypeId != null)
            {
                var app = await _appTypes.GetByIdAsync(command.AppTypeId.Value);
                if (app == null)
                {
                    throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
                }
                timeField.AppTypeId = command.AppTypeId.Value;
            }

            _timeFields.Update(timeField);
            await _uow.SaveChangesAsync();
        }
    }
}