using System.Threading.Tasks;
using System.Collections.Generic;
using AppMngr.Core;

namespace AppMngr.Application
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<User> GetByNameAndPwdHash(string name, string pwdHash);
        Task<User> GetByIdIncludeRoleAsync(int id);
        Task<IEnumerable<User>> GetAllIncludeRoleAsync();
    }
}