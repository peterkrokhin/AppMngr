using MediatR;

namespace AppMngr.Application
{
    public class UpdateNumFieldCommand : IRequest
    {
        public int Id { get; set; }
        public double? Value { get; set; }
        public int? AppTypeId { get; set; }
    }
}