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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {  
            _mediator = mediator;
        }


        /// <summary>Просмотр пользователей (admin)</summary>
        [Authorize(Roles="admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllUsersResponse>>> GetUsers()
        {
            var query = new GetAllUsersQuery();
            return Ok(await _mediator.Send(query));
        }

        /// <summary>Просмотр пользователя по Id (admin)</summary>
        [Authorize(Roles="admin")]
        [HttpGet("{userId:long}")]
        public async Task<ActionResult<GetUserByIdResponse>> GetUser(long userId)
        {
            var query = new GetUserByIdQuery(userId);
            return Ok(await _mediator.Send(query));
        }


        /// <summary>Добавление пользователя (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "name": "UserName", // Имя пользователя, not null, required
        ///        "pwd": "UserPwd",   // Пароль пользователя, not null, required
        ///        "roleId": 1         // Id роли, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "name": "UserName",
        ///        "pwd": "UserPwd",
        ///        "roleId": 1
        ///     }
        ///
        /// </remarks>
        // POST api/users
        [Authorize(Roles="admin")]
        [HttpPost]
        public async Task<ActionResult<GetUserByIdResponse>> PostUser(CreateUserCommand command)
        {
            var user = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
        }

    }
}