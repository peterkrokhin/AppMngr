using System;

namespace AppMngr.Core
{
    public class App
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AppTypeId { get; set; }
        public AppType AppType { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
