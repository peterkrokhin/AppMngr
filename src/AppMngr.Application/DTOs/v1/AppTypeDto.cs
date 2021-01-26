using System.Collections.Generic;

namespace AppMngr.Application
{
    public class AppTypeDto
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
