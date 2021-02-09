using AppMngr.Application;
using AppMngr.Core;

namespace AppMngr.Infrastructure
{
    public class StringFieldRepo : GenericRepo<StringField>, IStringFieldRepo
    {
        public StringFieldRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}