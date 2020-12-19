using AppMngr.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AppMngr.Application;

namespace AppMngr.Infrastructure
{
    public class AppTypeRepo : GenericRepo<AppType>, IAppTypeRepo
    {
        public AppTypeRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<AppTypeDTO>> GetAllDTOAsync()
        {
            return await DbSet
                .Select(t => new AppTypeDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    NumFields = t.NumFields
                        .Select(t => new NumFieldDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList(),
                    StringFields = t.StringFields
                        .Select(t => new StringFieldDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList(),
                    DateFields= t.DateFields
                        .Select(t => new DateFieldDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList(),
                    TimeFields = t.TimeFields
                        .Select(t => new TimeFieldDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList(),
                    FileFields = t.FileFields
                        .Select(t => new FileFieldDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList(),
                    Statuses = t.Statuses
                        .Select(t => new StatusDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList(),
                })
                .ToListAsync();
        }
        public async Task<AppTypeDTO> GetDTOByIdAsync(int id)
        {
            return await DbSet
                .Where(t => t.Id == id)
                .Select(t => new AppTypeDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    NumFields = t.NumFields
                        .Select(t => new NumFieldDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList(),
                    StringFields = t.StringFields
                        .Select(t => new StringFieldDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList(),
                    DateFields= t.DateFields
                        .Select(t => new DateFieldDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList(),
                    TimeFields = t.TimeFields
                        .Select(t => new TimeFieldDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList(),
                    FileFields = t.FileFields
                        .Select(t => new FileFieldDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList(),
                    Statuses = t.Statuses
                        .Select(t => new StatusDTO{Id = t.Id, Value = t.Value, AppTypeId = t.AppTypeId}).ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}