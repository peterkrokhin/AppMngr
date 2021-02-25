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
    public class StatusesController : ControllerBase
    {
        private IMediator _mediator; 

        public StatusesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Вернуть статус по id (admin)</summary>
        [Authorize(Roles="admin")]
        [HttpGet("{statusId}")]
        public async Task<ActionResult<IEnumerable<StatusDto>>> GetStatus(int statusId)
        {
            var query = new GetStatusByIdQuery(statusId);
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Добавить новый статус (admin)</summary>
        [Authorize(Roles="admin")]
        [HttpPost]
        public async Task<ActionResult<StatusDto>> CreateApp(CreateStatusCommand command)
        {
            var status = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetStatus),
                new {statusId = status.Id},
                status);
        }

        /// <summary>Измененить статус (admin)</summary>
        [Authorize(Roles="admin")]
        [HttpPatch("{statusId:int:min(1)}")]
        public async Task<ActionResult> PatchStatus(int statusId, UpdateStatusCommand command)
        {
            command.Id = statusId;

            await _mediator.Send(command);
            return NoContent();
        }
    }
}