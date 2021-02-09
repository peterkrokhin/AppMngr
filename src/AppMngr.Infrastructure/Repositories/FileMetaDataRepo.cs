using AppMngr.Application;
using AppMngr.Core;

namespace AppMngr.Infrastructure
{
    public class FileMetaDataRepo : GenericRepo<FileMetaData>, IFileMetaDataRepo
    {
        public FileMetaDataRepo(IAppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}