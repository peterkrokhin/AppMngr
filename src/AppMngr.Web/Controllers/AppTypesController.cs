using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AppMngr.Application;

namespace AppMngr.Web
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class AppTypesController : ControllerBase
    {
        private IMediator _mediator;

        public AppTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Вернуть все типы заявок (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppTypeDto>>> GetAppTypes()
        {
            var query = new GetAllAppTypesQuery();
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Вернуть тип заявки по Id (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet("{appTypeId:int:min(1)}")]
        public async Task<ActionResult<AppTypeDto>> GetAppType(int appTypeId)
        {
            var query = new GetAppTypeByIdQuery(appTypeId);
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Добавить новый тип заявки (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpPost]
        public async Task<ActionResult<AppTypeDto>> CreateAppType(CreateAppTypeCommand command)
        {
            var appType = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetAppType),
                new {appTypeId = appType.Id},
                appType);
        }
    }
}