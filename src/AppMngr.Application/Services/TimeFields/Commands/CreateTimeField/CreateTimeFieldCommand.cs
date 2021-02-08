using System;
using MediatR;

namespace AppMngr.Application
{
    public class CreateTimeFieldCommand : IRequest<TimeFieldDto>
    {
        public DateTime Value { get; set; }
        public int AppTypeId { get; set; }
    }
}