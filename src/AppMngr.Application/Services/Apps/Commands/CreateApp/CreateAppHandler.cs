using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class CreateAppHandler : IRequestHandler<CreateAppCommand, AppDto>
    {
        private IAppRepo _apps;
        private IAppTypeRepo _appTypes;
        private IStatusRepo _statuses;
        private IUOW _uow;
        private IMapper _mapper;
        

        public CreateAppHandler(IAppRepo apps, IAppTypeRepo appTypes, IStatusRepo statuses, IUOW uow, IMapper mapper)
        {
            _apps = apps;
            _appTypes = appTypes;
            _statuses = statuses;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<AppDto> Handle(CreateAppCommand command, CancellationToken cancellationToken)
        {
            var appType = await _appTypes.GetByIdAsync(command.AppTypeId);
            if (appType == null)
            {
                throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
            }

            var status = await _statuses.GetByIdAsync(command.StatusId);
            if (status == null)
            {
                throw new StatusNotFoundException($"Статус с Id={command.AppTypeId} не найден.");
            }

            var app = new App()
            {
                Name = command.Name,
                AppTypeId = command.AppTypeId,
                StatusId = command.StatusId
            };

            await _apps.AddAsync(app);
            await _uow.SaveChangesAsync();

            var appDto = _mapper.Map<AppDto>(app);
            return appDto;
        }
    }
}