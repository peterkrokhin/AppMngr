using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AppMngr.Application
{
    public class UpdateDateFieldHandler : AsyncRequestHandler<UpdateDateFieldCommand>
    {
        private readonly IAppTypeRepo _appTypes;
        private readonly IDateFieldRepo _dateFields;
        private readonly IUOW _uow;

        public UpdateDateFieldHandler(IAppTypeRepo appTypes, IDateFieldRepo dateFields, IUOW uow)
        {
            _appTypes = appTypes;
            _dateFields = dateFields;
            _uow = uow;
        }

        protected override async Task Handle(UpdateDateFieldCommand command, CancellationToken cancellationToken)
        {
            var dateField = await _dateFields.GetByIdAsync(command.Id);
            if (dateField == null)
            {
                throw new DateFieldNotFoundException($"Поле типа дата с Id={command.Id} не найдено.");
            }

            if (command.Value != null)
            {
                dateField.Value = command.Value.Value;
            }

            if (command.AppTypeId != null)
            {
                var app = await _appTypes.GetByIdAsync(command.AppTypeId.Value);
                if (app == null)
                {
                    throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
                }
                dateField.AppTypeId = command.AppTypeId.Value;
            }

            _dateFields.Update(dateField);
            await _uow.SaveChangesAsync();
        }
    }
}