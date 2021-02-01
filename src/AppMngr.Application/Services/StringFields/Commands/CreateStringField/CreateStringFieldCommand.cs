using MediatR;

namespace AppMngr.Application
{
    public class CreateStringFieldCommand : IRequest<StringFieldDto>
    {
        public string Value { get; set; }
        public int AppTypeId { get; set; }
    }
}