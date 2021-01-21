using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppMngr.Core;

namespace AppMngr.Infrastructure
{
    public interface IAppDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<App> Apps { get; set; }
        DbSet<AppType> AppTypes { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<StringField> StringFields { get; set; }
        DbSet<NumField> NumFields { get; set; }
        DbSet<DateField> DateFields { get; set; }
        DbSet<TimeField> TimeFields { get; set; }
        DbSet<FileField> FileFields { get; set; }

        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync();
    }
}
