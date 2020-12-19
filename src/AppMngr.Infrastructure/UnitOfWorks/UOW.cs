using System;
using AppMngr.Application;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace AppMngr.Infrastructure
{
    public class UOW : IUOW
    {
        private IAppDbContext DbContext { get; set; }
        public IAppTypeRepo AppTypes { get; set; }
        public IStringFieldRepo StringFields { get; set; }
        public INumFieldRepo NumFields { get; set; }
        public IDateFieldRepo DateFields { get; set; }
        public ITimeFieldRepo TimeFields { get; set; }
        public IFileFieldRepo FileFields { get; set; }
        public IStatusRepo Statuses { get; set; }
        public IAppRepo Apps { get; set; }
        public IRoleRepo Roles { get; set; }
        public IUserRepo Users { get; set; }

        public UOW(IAppDbContext appDbContext)
        {
            DbContext = appDbContext;
            AppTypes = new AppTypeRepo(appDbContext);
            StringFields = new StringFieldRepo(appDbContext);
            NumFields = new NumFieldRepo(appDbContext);
            DateFields = new DateFieldRepo(appDbContext);
            TimeFields = new TimeFieldRepo(appDbContext);
            FileFields = new FileFieldRepo(appDbContext);
            Statuses = new StatusRepo(appDbContext);
            Apps = new AppRepo(appDbContext);
            Roles = new RoleRepo(appDbContext);
            Users = new UserRepo(appDbContext);
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if(disposed)
                return;

            if(disposing)
            {
                DbContext?.Dispose();
                AppTypes?.Dispose();
                StringFields?.Dispose();
                NumFields?.Dispose();
                DateFields?.Dispose();
                TimeFields?.Dispose();
                FileFields?.Dispose();
                Statuses?.Dispose();
                Roles?.Dispose();
                Users?.Dispose();
                // Console.WriteLine($"object {this.ToString()} Dispose"); // Проверка работы Dispose()
            }

            disposed = true;
        }
 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

