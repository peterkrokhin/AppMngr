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
    public class TimeFieldsController : ControllerBase
    {
        private IMediator _mediator; 

        public TimeFieldsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Вернуть поле с типом время по id (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet("{timeFieldId}")]
        public async Task<ActionResult<IEnumerable<TimeFieldDto>>> GetTimeField(int timeFieldId)
        {
            var query = new GetTimeFieldByIdQuery(timeFieldId);
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Добавить новое поле с типом время (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpPost]
        public async Task<ActionResult<TimeFieldDto>> CreateApp(CreateTimeFieldCommand command)
        {
            var timeField = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetTimeField),
                new {timeFieldId = timeField.Id},
                timeField);
        }

        /// <summary>Измененить поле с типом время (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpPatch("{timeFieldId:int:min(1)}")]
        public async Task<ActionResult> PatchTimeField(int timeFieldId, UpdateTimeFieldCommand command)
        {
            command.Id = timeFieldId;

            await _mediator.Send(command);
            return NoContent();
        }
    }
}