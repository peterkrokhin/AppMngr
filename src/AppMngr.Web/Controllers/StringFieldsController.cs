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
    public class StringFieldsController : ControllerBase
    {
        private IMediator _mediator; 

        public StringFieldsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Вернуть строковое поле по id (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet("{stringFieldId}")]
        public async Task<ActionResult<IEnumerable<StringFieldDto>>> GetStringField(int stringFieldId)
        {
            var query = new GetStringFieldByIdQuery(stringFieldId);
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Добавить новое строковое поле (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpPost]
        public async Task<ActionResult<StringFieldDto>> CreateApp(CreateStringFieldCommand command)
        {
            var stringField = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetStringField),
                new {stringFieldId = stringField.Id},
                stringField);
        }

        /// <summary>Измененить строковое поле (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpPatch("{stringFieldId:int:min(1)}")]
        public async Task<ActionResult> PatchStringField(int stringFieldId, UpdateStringFieldCommand command)
        {
            command.Id = stringFieldId;

            await _mediator.Send(command);
            return NoContent();
        }
    }
}