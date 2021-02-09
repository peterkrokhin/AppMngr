using System;
using System.Threading.Tasks;
using AppMngr.Application;

namespace AppMngr.Infrastructure
{
    public class UOW : IUOW
    {
        private IAppDbContext DbContext { get; set; }
 
        public UOW(IAppDbContext appDbContext)
        {
            DbContext = appDbContext;
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