using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AppMngr.Core;
using AppMngr.Application;

namespace AppMngr.Infrastructure
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<App> Apps { get; set; }
        public DbSet<AppType> AppTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<StringField> StringFields { get; set; }
        public DbSet<NumField> NumFields { get; set; }
        public DbSet<DateField> DateFields { get; set; }
        public DbSet<TimeField> TimeFields { get; set; }
        public DbSet<FileMetaData> FileMetaData { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Методы Set<T>(), SaveChangesAsync() берем из базового класса
        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
