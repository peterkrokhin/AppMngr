using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using AppMngr.Application;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

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

        /// <summary>Просмотр заявок (admin, client)</summary>
        // GET api/apps
        [Authorize(Roles="admin, client")]
        [HttpGet("apps")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var apps = await Apps.GetAllDTOAsync();
                return Ok(apps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Изменение статуса заявки (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "statusId": 1   // Id нового статуса, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "statusId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="appId">Id заявки</param>
        /// <param name="doc"></param>
        // PATCH api/apps/{id}/status
        [Authorize(Roles="admin")]
        [HttpPatch("apps/{appId:int}/status")]
        public async Task<IActionResult> PatchStatus(int appId, JsonDocument doc)
        {
            try
            {
                await CommandAggregator.ChangeStatusInAppAsync(appId, doc);

                var app = await Apps.GetDTOByIdAsync(appId);
                return Ok(app);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Добавление новой заявки (client)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "name": "AppName",   // Имя заявки, not null, required
        ///        "appTypeId": 1,      // Id типа заявки, not null, required
        ///        "statusId": 1        // Id статуса, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "name": "Заявка 1",
        ///        "appTypeId": 1,
        ///        "statusId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        // POST api/apps
        [Authorize(Roles="client")]
        [HttpPost("apps")]
        public async Task<IActionResult> Post(JsonDocument doc)
        {
            try
            {
                await CommandAggregator.AddAppAsync(doc);

                var apps = await Apps.GetAllDTOAsync();
                return Ok(apps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}