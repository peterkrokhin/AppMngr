using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using AppMngr.Application;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using MediatR;

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
        [HttpGet("{appId:int}")]
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









        /// <summary>Изменение статуса заявки (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "statusId": 1   // Id нового статуса, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "statusId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="appId">Id заявки</param>
        /// <param name="doc"></param>
        // PATCH api/apps/{id}/status
        [Authorize(Roles="admin")]
        [HttpPatch("apps/{appId:int}/status")]
        public async Task<IActionResult> PatchStatus(int appId, JsonDocument doc)
        {
            try
            {
                await CommandAggregator.ChangeStatusInAppAsync(appId, doc);

                var app = await Apps.GetDTOByIdAsync(appId);
                return Ok(app);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}