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
    public class DateFieldsController : ControllerBase
    {
        private IMediator _mediator; 

        public DateFieldsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Вернуть поле с типом дата по id (admin)</summary>
        [Authorize(Roles="admin")]
        [HttpGet("{dateFieldId}")]
        public async Task<ActionResult<IEnumerable<DateFieldDto>>> GetDateField(int dateFieldId)
        {
            var query = new GetDateFieldByIdQuery(dateFieldId);
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Добавить новое поле с типом дата (admin)</summary>
        [Authorize(Roles="admin")]
        [HttpPost]
        public async Task<ActionResult<DateFieldDto>> CreateApp(CreateDateFieldCommand command)
        {
            var dateField = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetDateField),
                new {dateFieldId = dateField.Id},
                dateField);
        }

        /// <summary>Измененить поле с типом дата (admin)</summary>
        [Authorize(Roles="admin")]
        [HttpPatch("{dateFieldId:int:min(1)}")]
        public async Task<ActionResult> PatchDateField(int dateFieldId, UpdateDateFieldCommand command)
        {
            command.Id = dateFieldId;

            await _mediator.Send(command);
            return NoContent();
        }
    }
}