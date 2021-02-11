using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MediatR;
using AppMngr.Application;
using System.IO;
using System;
using System.Linq;

namespace AppMngr.Web
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IMediator _mediator; 
        private readonly IConfiguration _configuration;

        public FilesController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        /// <summary>Получить файл по id (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetFile(int fileId)
        {
            var query = new GetFileMetaDataByIdQuery(fileId);
            var fileMetaData = await _mediator.Send(query);

            string fileName = $"file_{fileMetaData.Id}";
            string filePath = _configuration["FileStorage:Path"];
            // string withoutExtensionFileName = filePath + fileName;

            string[] files = Directory.GetFiles(filePath, fileName + ".*");
            string fullFileName = files.FirstOrDefault();

            if (fullFileName == null)
            {
                throw new Exception($"Файл с Id={fileId} не найден");
            }

            var memoryStream = new MemoryStream();

            using (var fileStream = new FileStream(fullFileName, FileMode.Open))
            {
                await fileStream.CopyToAsync(memoryStream);
            }

            memoryStream.Position = 0;
            return File(memoryStream, GetContentType(fullFileName), fullFileName);
        }

        /// <summary>Получить метаданные файла по id (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet("fileMetaData/{fileId}")]
        public async Task<ActionResult<FileMetaDataDto>> GetFileMetaData(int fileId)
        {
            var query = new GetFileMetaDataByIdQuery(fileId);
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Добавить новый файл на сервер (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpPost]
        public async Task<ActionResult> AddFile(IFormFile file, [FromForm] int appTypeId)
        {
            if (file == null)
            {
                throw new Exception("Ошибка получения файла.");
            }

            var command = new CreateFileMetaDataCommand(appTypeId);

            var fileMetaData = await _mediator.Send(command);

            string fileName = $"file_{fileMetaData.Id}";

            string extension = Path.GetExtension(file.FileName).ToLower();
            string[] permittedExtensions = _configuration["FileStorage:PermittedExtensions"].Split(" ");

            if (!permittedExtensions.Contains(extension))
            {
                throw new Exception("Недопустимое расширейние файла.");
            }

            if (file.Length >= long.Parse(_configuration["FileStorage:FileSizeLimit"]))
            {
                throw new Exception("Недопустимый размер файла.");
            }

            string filePath = _configuration["FileStorage:Path"];
            string fullFileName = filePath + fileName + extension;

            using (var fileStream = new FileStream(fullFileName, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return CreatedAtAction(
                nameof(GetFileMetaData),
                new {fileId = fileMetaData.Id},
                fileMetaData);
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLower();
            return types[ext];
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