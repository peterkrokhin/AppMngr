using System.Threading.Tasks;
using System.Collections.Generic;
using AppMngr.Core;

namespace AppMngr.Application
{
    public interface IStatusRepo : IGenericRepo<Status>
    {
        Task<IEnumerable<Status>> GetAllByAppTypeIdAsync(int requestTypeId);
    }  
}