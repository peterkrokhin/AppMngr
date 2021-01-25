using System;

namespace AppMngr.Application
{
    public class AppDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AppTypeId { get; set; }
        public int StatusId { get; set; }
    }
}
