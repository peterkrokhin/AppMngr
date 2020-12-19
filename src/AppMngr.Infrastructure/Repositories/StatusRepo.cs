using AppMngr.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AppMngr.Application;

namespace AppMngr.Infrastructure
{
    public class StatusRepo : GenericRepo<Status>, IStatusRepo
    {
        public StatusRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<Status>> GetAllByAppTypeIdAsync(int appTypeId)
        {
            return await DbSet.Where(r => r.AppTypeId == appTypeId).ToListAsync();
        }

    }
}