using System.Threading.Tasks;

namespace AppMngr.Web
{
    public interface IFileGettingService
    {
        Task<FileContent> GetFileContent(int fileId);
    }
}