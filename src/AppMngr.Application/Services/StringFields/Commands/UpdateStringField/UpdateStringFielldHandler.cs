using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AppMngr.Application
{
    public class UpdateStringFieldHandler : AsyncRequestHandler<UpdateStringFieldCommand>
    {
        private readonly IAppTypeRepo _appTypes;
        private readonly IStringFieldRepo _stringFields;
        private readonly IUOW _uow;

        public UpdateStringFieldHandler(IAppTypeRepo appTypes, IStringFieldRepo stringFields, IUOW uow)
        {
            _appTypes = appTypes;
            _stringFields = stringFields;
            _uow = uow;
        }

        protected override async Task Handle(UpdateStringFieldCommand command, CancellationToken cancellationToken)
        {
            var stringField = await _stringFields.GetByIdAsync(command.Id);
            if (stringField == null)
            {
                throw new StringFieldNotFoundException($"Поле типа string с Id={command.Id} не найдено."); 
            }

            if (command.Value != null)
            {
                stringField.Value = command.Value;
            }

            if (command.AppTypeId != null)
            {
                var app = await _appTypes.GetByIdAsync(command.AppTypeId.Value);
                if (app == null)
                {
                    throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
                }
                stringField.AppTypeId = command.AppTypeId.Value;
            }

            _stringFields.Update(stringField);
            await _uow.SaveChangesAsync();
        }
    }
}