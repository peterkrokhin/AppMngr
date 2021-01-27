using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AppMngr.Application
{
    public class UpdateStatusHandler : AsyncRequestHandler<UpdateStatusCommand>
    {
        private readonly IAppTypeRepo _appTypes;
        private readonly IStatusRepo _statuses;
        private readonly IUOW _uow;

        public UpdateStatusHandler(IAppTypeRepo appTypes, IStatusRepo statuses, IUOW uow)
        {
            _appTypes = appTypes;
            _statuses = statuses;
            _uow = uow;
        }

        protected override async Task Handle(UpdateStatusCommand command, CancellationToken cancellationToken)
        {
            var status = await _statuses.GetByIdAsync(command.Id);
            if (status == null)
            {
                throw new StatusNotFoundException($"Статус с Id={command.Id} не найден."); 
            }

            if (command.Value != null)
            {
                status.Value = command.Value;
            }

            if (command.AppTypeId != null)
            {
                var app = await _appTypes.GetByIdAsync(command.AppTypeId.Value);
                if (app == null)
                {
                    throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
                }
                status.AppTypeId = command.AppTypeId.Value;
            }

            _statuses.Update(status);
            await _uow.SaveChangesAsync();
        }
    }
}