using MediatR;

namespace AppMngr.Application
{
    public class UpdateAppStatusCommand : IRequest
    {
        public int AppId { get; set; }
        public int StatusId { get; set; }
    }
}