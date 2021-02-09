using AppMngr.Application;
using AppMngr.Core;

namespace AppMngr.Infrastructure
{
    public class StatusRepo : GenericRepo<Status>, IStatusRepo
    {
        public StatusRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}