using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MediatR;
using AppMngr.Application;

namespace AppMngr.Web
{
    public class FileGettingService : IFileGettingService
    {
        private readonly FileStorageConfiguration _fileStorageConfiguration;
        private readonly IMediator _mediator;

        public FileGettingService(IConfiguration configuration, IMediator mediator)
        {
            _fileStorageConfiguration = new FileStorageConfiguration(configuration);
            _mediator = mediator;
        }

        public async Task<FileContent> GetFile(int fileId)
        {
            var query = new GetFileMetaDataByIdQuery(fileId);
            var fileMetaData = await _mediator.Send(query);

            var fileName = GenerateFileNameFromFileMetaData(fileMetaData);
            var fullFileName = GetFullFileName(fileMetaData);
            var memoryStream = await GetMemoryStream(fullFileName);

            var contentType = GetContentType(fullFileName);

            var fileContent = new FileContent(memoryStream, contentType, fileName);
            
            return fileContent;
        }

        private string GenerateFileNameFromFileMetaData(FileMetaDataDto fileMetaData)
        {
            return _fileStorageConfiguration.FileNamePrefix + fileMetaData.Id;
        }

        private string GetFullFileName(FileMetaDataDto fileMetaData)
        {
            string directoryName = _fileStorageConfiguration.Path;
            string fileName = GenerateFileNameFromFileMetaData(fileMetaData);

            string[] fullFileNamesInDirectory = Directory.GetFiles(directoryName, fileName + ".*");
            string fullFileName = fullFileNamesInDirectory.FirstOrDefault();

            if (fullFileName == null)
            {
                throw new FileNotFoundException($"Файл с Id={fileMetaData.Id} не найден");
            }

            return fullFileName;
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var extension = Path.GetExtension(path).ToLower();
            return types[extension];
        }

        private async Task<MemoryStream> GetMemoryStream(string fileName)
        {
            var memoryStream = new MemoryStream();

            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                await fileStream.CopyToAsync(memoryStream);
            }

            memoryStream.Position = 0;

            return memoryStream;
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".jpg", "image/jpeg"}
            };  
        }
    }
}