using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AppMngr.Application
{
    public class UpdateAppStatusHandler : AsyncRequestHandler<UpdateAppStatusCommand>
    {
        private readonly IAppRepo _apps;
        private readonly IStatusRepo _statuses;
        private readonly IUOW _uow;

        public UpdateAppStatusHandler(IAppRepo apps, IStatusRepo statuses, IUOW uow)
        {
            _apps = apps;
            _statuses = statuses;
            _uow = uow;
        }

        protected override async Task Handle(UpdateAppStatusCommand command, CancellationToken cancellationToken)
        {
            var app = await _apps.GetByIdAsync(command.AppId);
            if (app == null)
            {
                throw new AppNotFoundException($"Заявка с Id={command.AppId} не найдена.");
            }

            var status = await _statuses.GetByIdAsync(command.StatusId);
            if (status == null)
            {
                throw new StatusNotFoundException($"Статус с Id={command.StatusId} не найден."); 
            }

            app.StatusId = command.StatusId;
            _apps.Update(app);

            await _uow.SaveChangesAsync();
        }
    }
}