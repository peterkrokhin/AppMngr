using MediatR;

namespace AppMngr.Application
{
    public class CreateStatusCommand : IRequest<StatusDto>
    {
        public string Value { get; set; }
        public int AppTypeId { get; set; }
    }
}