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
    public class NumFieldsController : ControllerBase
    {
        private IMediator _mediator; 

        public NumFieldsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Вернуть числовое поле по id (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet("{numFieldId}")]
        public async Task<ActionResult<IEnumerable<NumFieldDto>>> GetNumField(int numFieldId)
        {
            var query = new GetNumFieldByIdQuery(numFieldId);
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Добавить новое числовое поле (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpPost]
        public async Task<ActionResult<NumFieldDto>> CreateApp(CreateNumFieldCommand command)
        {
            var numField = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetNumField),
                new {numFieldId = numField.Id},
                numField);
        }

        /// <summary>Измененить числовое поле (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpPatch("{numFieldId:int:min(1)}")]
        public async Task<ActionResult> PatchNumField(int numFieldId, UpdateNumFieldCommand command)
        {
            command.Id = numFieldId;

            await _mediator.Send(command);
            return NoContent();
        }
    }
}