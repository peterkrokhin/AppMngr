using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using AppMngr.Application;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;


namespace AppMngr.Web
{
    [ApiController]
    [Route("api/")]
    public class UserController : Controller
    {
        IUserRepo Users { get; set; }
        ICommandAggregator CommandAggregator { get; set; }

        public UserController(IUserRepo users, ICommandAggregator commandAggregator)
        {  
            Users = users;
            CommandAggregator = commandAggregator;
        }


        /// <summary>Просмотр пользователей (admin)</summary>
        // GET api/users
        [Authorize(Roles="admin")]
        [HttpGet("users")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await Users.GetAllDTOAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
        [HttpPost("users")]
        public async Task<IActionResult> Post(JsonDocument doc)
        {
            try
            {
                await CommandAggregator.AddUserAsync(doc);
                return Ok(await Users.GetAllDTOAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}