using System;
using MediatR;

namespace AppMngr.Application
{
    public class UpdateDateFieldCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime? Value { get; set; }
        public int? AppTypeId { get; set; }
    }
}