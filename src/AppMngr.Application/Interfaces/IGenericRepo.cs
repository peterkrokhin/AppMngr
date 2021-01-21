using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace AppMngr.Application
{
    public interface IGenericRepo<T> : IDisposable where T : class 
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void Update(T entity);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
    }
}