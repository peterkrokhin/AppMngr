using System.Threading.Tasks;
using System.Collections.Generic;
using AppMngr.Core;

namespace AppMngr.Application
{
    public interface IAppRepo : IGenericRepo<App>
    {
        Task<IEnumerable<AppDTO>> GetAllDTOAsync();
        Task<AppDTO> GetDTOByIdAsync(int id);
    }
}