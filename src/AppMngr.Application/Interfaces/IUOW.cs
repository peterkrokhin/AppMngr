using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace AppMngr.Application
{
    public interface IUOW : IDisposable
    {
        IAppTypeRepo AppTypes { get; set; }
        IStringFieldRepo StringFields { get; set; }
        INumFieldRepo NumFields { get; set; }
        IDateFieldRepo DateFields { get; set; }
        ITimeFieldRepo TimeFields { get; set; }
        IFileFieldRepo FileFields { get; set; }
        IStatusRepo Statuses { get; set; }
        IAppRepo Apps { get; set; }
        IRoleRepo Roles { get; set; }
        IUserRepo Users { get; set; }
        Task SaveChangesAsync();
    }
}