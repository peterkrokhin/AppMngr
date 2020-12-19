using System;
using System.Collections.Generic;
using AppMngr.Core;

namespace AppMngr.Application
{
    public class AppTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<NumFieldDTO> NumFields { get; set; }
        public IEnumerable<StringFieldDTO> StringFields { get; set; }
        public IEnumerable<DateFieldDTO> DateFields { get; set; }
        public IEnumerable<TimeFieldDTO> TimeFields { get; set; }
        public IEnumerable<FileFieldDTO> FileFields { get; set; }
        public IEnumerable<StatusDTO> Statuses { get; set; }
        
    }
}
