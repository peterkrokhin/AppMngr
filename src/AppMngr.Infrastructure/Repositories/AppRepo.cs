using AppMngr.Application;
using AppMngr.Core;

namespace AppMngr.Infrastructure
{
    public class AppRepo : GenericRepo<App>, IAppRepo
    {
        public AppRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}