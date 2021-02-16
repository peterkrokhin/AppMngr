using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MediatR;
using AppMngr.Application;

namespace AppMngr.Web
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFileGettingService _fileGettingService;
        private readonly IFileSavingService _fileSavingService;


        public FilesController(IMediator mediator, IFileGettingService fileGettingService, IFileSavingService fileSavingService)
        {
            _mediator = mediator;
            _fileGettingService = fileGettingService;
            _fileSavingService = fileSavingService;
        }

        /// <summary>Получить файл по id (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetFile(int fileId)
        {
            var fileContent = await _fileGettingService.GetFile(fileId);
            return File(fileContent.MemoryStream, fileContent.ContentType, fileContent.FullName);
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
            var fileMetaData = await _fileSavingService.AddFile(file, appTypeId);

            return CreatedAtAction(
                nameof(GetFileMetaData),
                new {fileId = fileMetaData.Id},
                fileMetaData);
        }
    }
}