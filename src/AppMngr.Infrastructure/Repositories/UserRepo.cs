using AppMngr.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AppMngr.Application;

namespace AppMngr.Infrastructure
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<User> GetByNameAndPwdHash(string name, string pwdHash)
        {
            return await DbSet
                .Include(u => u.Role)
                .Where(u => u.Name == name & u.PwdHash == pwdHash)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserDTO>> GetAllDTOAsync()
        {
            return await DbSet
                .Select(u => new UserDTO{
                    Id = u.Id,
                    Name = u.Name,
                    Role = u.Role,
                })
                .ToListAsync();
        }
    }
}