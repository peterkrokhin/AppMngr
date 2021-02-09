using System;
using System.Threading.Tasks;

namespace AppMngr.Application
{
    public interface IUOW : IDisposable
    {
        Task SaveChangesAsync();
    }
}