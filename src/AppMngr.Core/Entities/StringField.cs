using System;
using System.Collections.Generic;

namespace AppMngr.Core
{
    public class StringField
    {
        public int Id { get; set; }
        public string Value { get; set; }
        
        public int AppTypeId { get; set; }
        public AppType Type { get; set; }
        
    }
}
