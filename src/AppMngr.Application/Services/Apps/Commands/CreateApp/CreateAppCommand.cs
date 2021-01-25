using MediatR;

namespace AppMngr.Application
{
    public class CreateAppCommand : IRequest<AppDto>
    {
        public string Name { get; set; }
        public int AppTypeId { get; set; }
        public int StatusId { get; set; }
    }
}