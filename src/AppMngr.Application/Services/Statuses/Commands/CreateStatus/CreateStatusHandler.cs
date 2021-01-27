using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class CreateStatusHandler : IRequestHandler<CreateStatusCommand, StatusDto>
    {
        private IAppTypeRepo _appTypes;
        private IStatusRepo _statuses;
        private IUOW _uow;
        private IMapper _mapper;
        
        public CreateStatusHandler(IAppTypeRepo appTypes, IStatusRepo statuses, IUOW uow, IMapper mapper)
        {
            _appTypes = appTypes;
            _statuses = statuses;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<StatusDto> Handle(CreateStatusCommand command, CancellationToken cancellationToken)
        {
            var appType = await _appTypes.GetByIdAsync(command.AppTypeId);
            if (appType == null)
            {
                throw new AppTypeNotFoundException($"Тип заявки с Id={command.AppTypeId} не найден.");
            }

            var status = new Status()
            {
                Value = command.Value,
                AppTypeId = command.AppTypeId
            };

            await _statuses.AddAsync(status);
            await _uow.SaveChangesAsync();

            var statusDto = _mapper.Map<StatusDto>(status);
            return statusDto;
        }
    }
}