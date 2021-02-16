using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AppMngr.Application;

namespace AppMngr.Web
{
    public interface IFileSavingService
    {
        Task<FileMetaDataDto> AddFile(IFormFile file, int appTypeId);
    }
}