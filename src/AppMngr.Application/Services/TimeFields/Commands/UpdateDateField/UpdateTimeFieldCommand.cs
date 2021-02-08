using System;
using MediatR;

namespace AppMngr.Application
{
    public class UpdateTimeFieldCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime? Value { get; set; }
        public int? AppTypeId { get; set; }
    }
}