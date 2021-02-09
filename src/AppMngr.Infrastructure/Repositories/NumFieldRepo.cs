using AppMngr.Application;
using AppMngr.Core;

namespace AppMngr.Infrastructure
{
    public class NumFieldRepo : GenericRepo<NumField>, INumFieldRepo
    {
        public NumFieldRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}