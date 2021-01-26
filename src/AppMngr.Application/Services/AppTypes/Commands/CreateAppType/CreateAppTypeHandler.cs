using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class CreateAppTypeHandler : IRequestHandler<CreateAppTypeCommand, AppTypeDto>
    {
        private readonly IAppTypeRepo _appTypes;
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public CreateAppTypeHandler(IAppTypeRepo appTypes, IUOW uow, IMapper mapper)
        {
            _appTypes = appTypes;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<AppTypeDto> Handle(CreateAppTypeCommand command, CancellationToken cancellationToken)
        {
            AppType appType = new AppType()
            {
                Name = command.Name,
            };

            await _appTypes.AddAsync(appType);
            await _uow.SaveChangesAsync();

            var appTypeDto = _mapper.Map<AppTypeDto>(appType);

            return appTypeDto;
        }
    }
}