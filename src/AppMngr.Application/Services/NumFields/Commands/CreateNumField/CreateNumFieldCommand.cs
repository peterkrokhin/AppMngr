using MediatR;

namespace AppMngr.Application
{
    public class CreateNumFieldCommand : IRequest<NumFieldDto>
    {
        public double Value { get; set; }
        public int AppTypeId { get; set; }
    }
}