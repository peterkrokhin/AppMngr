using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AppMngr.Application;

namespace AppMngr.Web
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {  
            _mediator = mediator;
        }

        /// <summary>Вернуть всех пользователей (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var query = new GetAllUsersQuery();
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Вернуть пользователя по Id (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UserDto>> GetUser(int userId)
        {
            var query = new GetUserByIdQuery(userId);
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Добавить пользователя (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserCommand command)
        {
            var user = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetUser), 
                new {userId = user.Id}, 
                user);
        }
    }
}