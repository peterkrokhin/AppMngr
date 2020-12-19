using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using AppMngr.Application;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AppMngr.Web
{
    [ApiController]
    [Route("api/")]
    public class AppController : Controller
    {
        private IAppRepo Apps { get; set; }
        private ICommandAggregator CommandAggregator { get; set; }

        public AppController(IAppRepo apps, ICommandAggregator commandAggregator)
        {
            Apps = apps;
            CommandAggregator = commandAggregator;
        }

        // GET api/apps
        [HttpGet("apps")]
        public async Task<IActionResult> Get()
        {
            var apps = await Apps.GetAllDTOAsync();
            return Ok(apps);
        }

        // PATCH api/apps/{id}/status
        [HttpPatch("apps/{appId:int}/status")]
        public async Task<IActionResult> PatchStatus(int appId, JsonDocument doc)
        {
            await CommandAggregator.ChangeStatusInAppAsync(appId, doc);

            var app = await Apps.GetDTOByIdAsync(appId);
            return Ok(app);
        }

        // POST api/apps
        [HttpPost("apps")]
        public async Task<IActionResult> Post(JsonDocument doc)
        {
            await CommandAggregator.AddAppAsync(doc);

            var apps = await Apps.GetAllDTOAsync();
            return Ok(apps);
        }

    }
}