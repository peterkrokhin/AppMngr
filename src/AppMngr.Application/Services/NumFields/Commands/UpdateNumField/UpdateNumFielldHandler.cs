using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AppMngr.Application
{
    public class UpdateNumFieldHandler : AsyncRequestHandler<UpdateNumFieldCommand>
    {
        private readonly IAppTypeRepo _appTypes;
        private readonly INumFieldRepo _numFields;
        private readonly IUOW _uow;

        public UpdateNumFieldHandler(IAppTypeRepo appTypes, INumFieldRepo numFields, IUOW uow)
        {
            _appTypes = appTypes;
            _numFields = numFields;
            _uow = uow;
        }

        protected override async Task Handle(UpdateNumFieldCommand command, CancellationToken cancellationToken)
        {
            var numField = await _numFields.GetByIdAsync(command.Id);
            if (numField == null)
            {
                throw new NumFieldNotFoundException($"Поле типа число с Id={command.Id} не найдено.");
            }

            if (command.Value != null)
            {
                numField.Value = command.Value.Value;
            }

            if (command.AppTypeId != null)
            {
                var app = await _appTypes.GetByIdAsync(command.AppTypeId.Value);
                if (app == null)
                {
                    throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
                }
                numField.AppTypeId = command.AppTypeId.Value;
            }

            _numFields.Update(numField);
            await _uow.SaveChangesAsync();
        }
    }
}