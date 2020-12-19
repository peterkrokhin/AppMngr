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

        // GET api/users
        [Authorize(Roles="admin")]
        [HttpGet("users")]
        public async Task<IActionResult> Get() =>
            Ok(await Users.GetAllDTOAsync());

        // POST api/users
        [Authorize(Roles="admin")]
        [HttpPost("users")]
        public async Task<IActionResult> Post(JsonDocument doc)
        {
            await CommandAggregator.AddUserAsync(doc);
            return Ok(await Users.GetAllDTOAsync());
        }

    }
}