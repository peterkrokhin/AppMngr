using AppMngr.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using AppMngr.Application;

namespace AppMngr.Infrastructure
{
    public class StringFieldRepo : GenericRepo<StringField>, IStringFieldRepo
    {
        public StringFieldRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}