using MediatR;

namespace AppMngr.Application
{
    public class CreateAppTypeCommand : IRequest<AppTypeDto>
    {
        public string Name { get; set; }
    }
}