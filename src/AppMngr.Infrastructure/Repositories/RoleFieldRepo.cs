using AppMngr.Application;
using AppMngr.Core;

namespace AppMngr.Infrastructure
{
    public class RoleRepo : GenericRepo<Role>, IRoleRepo
    {
        public RoleRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}