using System;
using System.Collections.Generic;

namespace AppMngr.Core
{
    public class TimeField
    {
        public int Id { get; set; }
        public DateTime Value { get; set; }
        
        public int AppTypeId { get; set; }
        public AppType Type { get; set; }
        
    }
}
