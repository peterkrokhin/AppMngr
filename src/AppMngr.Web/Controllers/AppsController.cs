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
    public class AppController : ControllerBase
    {
        private IMediator _mediator; 

        public AppController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Вернуть все заявки (admin, client)</summary>
        // [Authorize(Roles="admin, client")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppDto>>> GetApps()
        {
            var query = new GetAllAppsQuery();
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Вернуть заявку по Id (admin, client)</summary>
        // [Authorize(Roles="admin, client")]
        [HttpGet("{appId:int:min(1)}")]
        public async Task<ActionResult<AppDto>> GetApp(int appId)
        {
            var query = new GetAppByIdQuery(appId);
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Добавить новую заявку (client)</summary>
        // [Authorize(Roles="client")]
        [HttpPost]
        public async Task<ActionResult<AppDto>> CreateApp(CreateAppCommand command)
        {
            var app = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetApp),
                new {appId = app.Id},
                app);
        }

        /// <summary>Измененить статус заявки (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpPatch("{appId:int:min(1)}/status")]
        public async Task<ActionResult> PatchStatus(int appId, UpdateAppStatusCommand command)
        {
            command.AppId = appId;

            await _mediator.Send(command);
            return NoContent();
        }
    }
}