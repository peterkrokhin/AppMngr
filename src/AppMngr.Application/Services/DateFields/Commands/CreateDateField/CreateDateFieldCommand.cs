using System;
using MediatR;

namespace AppMngr.Application
{
    public class CreateDateFieldCommand : IRequest<DateFieldDto>
    {
        public DateTime Value { get; set; }
        public int AppTypeId { get; set; }
    }
}