using AppMngr.Application;
using AppMngr.Core;

namespace AppMngr.Infrastructure
{
    public class AppTypeRepo : GenericRepo<AppType>, IAppTypeRepo
    {
        public AppTypeRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}