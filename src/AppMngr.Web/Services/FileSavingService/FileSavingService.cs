using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MediatR;
using AppMngr.Application;

namespace AppMngr.Web
{
    public class FileSavingService : IFileSavingService
    {
        private readonly FileStorageSettings _fileStorageSettings;
        private readonly IMediator _mediator;
        private IFormFile _file;
        private string _extension;
     
        public FileSavingService(IConfiguration configuration, IMediator mediator)
        {
            _fileStorageSettings = new FileStorageSettings(configuration);
            _mediator = mediator;
        }

        public async Task<FileMetaDataDto> AddFile(IFormFile file, int appTypeId)
        {
            SetFile(file);

            CheckFileIsNotNull();
            CheckFileExtension();
            CheckFileLength();

            var newFileMetaData = await _mediator.Send(new CreateFileMetaDataCommand(appTypeId));

            await SaveFileWithId(newFileMetaData.Id);

            return newFileMetaData;
        }

        public void SetFile(IFormFile file)
        {
            _file = file;
            _extension = Path.GetExtension(file.FileName).ToLower();
        }

        private void CheckFileIsNotNull()
        {
            if (_file == null)
            {
                throw new FileUploadException("Ошибка получения файла.");
            }
        }

        private void CheckFileExtension()
        {
            if (!_fileStorageSettings.PermittedExtensions.Contains(_extension))
            {
                throw new FileExtensionException("Недопустимое расширейние файла.");
            }
        }

        private void CheckFileLength()
        {
            if (_file.Length >= _fileStorageSettings.FileSizeLimit)
            {
                throw new FileLengthException("Недопустимый размер файла.");
            }
        }

        private async Task SaveFileWithId(int fileId)
        {
            string fileName = GenerateFileName(fileId);

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                await _file.CopyToAsync(fileStream);
            }
        }

        private string GenerateFileName(int fileId)
        {
            return _fileStorageSettings.Path + _fileStorageSettings.FileNamePrefix + $"{fileId}" + _extension;
        }
    }
}