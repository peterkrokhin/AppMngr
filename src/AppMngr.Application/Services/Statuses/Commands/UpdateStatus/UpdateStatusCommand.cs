using MediatR;

namespace AppMngr.Application
{
    public class UpdateStatusCommand : IRequest
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int? AppTypeId { get; set; }
    }
}