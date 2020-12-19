using AppMngr.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AppMngr.Application;

namespace AppMngr.Infrastructure
{
    public class AppRepo : GenericRepo<App>, IAppRepo
    {
        public AppRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<AppDTO>> GetAllDTOAsync()
        {
            return await DbSet
                .Select(a => new AppDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    AppTypeId = a.AppTypeId,
                    StatusId = a.StatusId
                })
                .ToListAsync();
        }

        public async Task<AppDTO> GetDTOByIdAsync(int id)
        {
            return await DbSet
                .Where(a => a.Id == id)
                .Select(a => new AppDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    AppTypeId = a.AppTypeId,
                    StatusId = a.StatusId
                })
                .FirstOrDefaultAsync();
        }
    }
}