using AppMngr.Application;
using AppMngr.Core;

namespace AppMngr.Infrastructure
{
    public class DateFieldRepo : GenericRepo<DateField>, IDateFieldRepo
    {
        public DateFieldRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}