using System;
using System.Collections.Generic;

namespace AppMngr.Application
{
    public class FileFieldDTO
    {
        public int Id { get; set; }
        public byte[] Value { get; set; }
        public int AppTypeId { get; set; }

        
    }
}
