using System;

namespace AppMngr.Application
{
    public class TimeFieldDto
    {
        public int Id { get; set; }
        public DateTime Value { get; set; }
        public int AppTypeId { get; set; }
    }
}
