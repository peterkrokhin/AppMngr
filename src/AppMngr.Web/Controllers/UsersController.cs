using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using AppMngr.Application;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using System.Collections.Generic;

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

        /// <summary>Просмотр пользователей (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var query = new GetAllUsersQuery();
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Просмотр пользователя по Id (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UserDto>> GetUser(int userId)
        {
            var query = new GetUserByIdQuery(userId);
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Добавление пользователя (admin)</summary>
        // [Authorize(Roles="admin")]
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(CreateUserCommand command)
        {
            var user = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
        }
    }
}