using AppMngr.Application;
using AppMngr.Core;

namespace AppMngr.Infrastructure
{
    public class TimeFieldRepo : GenericRepo<TimeField>, ITimeFieldRepo
    {
        public TimeFieldRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}