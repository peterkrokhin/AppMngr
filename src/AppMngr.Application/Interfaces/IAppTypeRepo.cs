using System.Threading.Tasks;
using System.Collections.Generic;
using AppMngr.Core;

namespace AppMngr.Application
{
    public interface IAppTypeRepo : IGenericRepo<AppType>
    {
        Task<IEnumerable<AppTypeDTO>> GetAllDTOAsync();
        Task<AppTypeDTO> GetDTOByIdAsync(int id);
    }
}