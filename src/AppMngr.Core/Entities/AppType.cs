using System;
using System.Collections.Generic;

namespace AppMngr.Core
{
    public class AppType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<NumField> NumFields { get; set; }
        public IEnumerable<StringField> StringFields { get; set; }
        public IEnumerable<DateField> DateFields { get; set; }
        public IEnumerable<TimeField> TimeFields { get; set; }
        public IEnumerable<FileField> FileFields { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<App> Apps { get; set; }

        
    }
}
