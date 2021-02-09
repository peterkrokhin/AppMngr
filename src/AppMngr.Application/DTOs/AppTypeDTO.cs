using System.Collections.Generic;

namespace AppMngr.Application
{
    public class AppTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<NumFieldDto> NumFields { get; set; }
        public IEnumerable<StringFieldDto> StringFields { get; set; }
        public IEnumerable<DateFieldDto> DateFields { get; set; }
        public IEnumerable<TimeFieldDto> TimeFields { get; set; }
        public IEnumerable<FileMetaDataDto> FileMetaData { get; set; }
        public IEnumerable<StatusDto> Statuses { get; set; }
    }
}
