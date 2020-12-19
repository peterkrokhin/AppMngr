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
    public class AppTypeController : Controller
    {
        private IAppTypeRepo AppTypes { get; set; }
        private ICommandAggregator CommandAggregator { get; set; }

        public AppTypeController(IAppTypeRepo appTypes, ICommandAggregator commandAggregator)
        {
            AppTypes = appTypes;
            CommandAggregator = commandAggregator;
        }

        // GET api/types
        [Authorize(Roles="admin")]
        [HttpGet("types")]
        public async Task<IActionResult> Get()
        {
            var appTypes = await AppTypes.GetAllDTOAsync();
            return Ok(appTypes);
        }

        // POST api/types
        [Authorize(Roles="admin")]
        [HttpPost("types")]
        public async Task<IActionResult> Post([FromBody] JsonDocument doc)
        {
            await CommandAggregator.AddAppTypeAsync(doc);

            var appTypes = await AppTypes.GetAllDTOAsync();
            return Ok(appTypes);
        }

        // POST api/types/{id}/stringfield
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/stringfield")]
        public async Task<IActionResult> PostStringField(int appTypeId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.AddStringFieldInAppTypeAsync(appTypeId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }

        // POST api/types/{id}/numfield
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/numfield")]
        public async Task<IActionResult> PostNumField(int appTypeId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.AddNumFieldInAppTypeAsync(appTypeId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }
        
        // POST api/types/{id}/datefield
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/datefield")]
        public async Task<IActionResult> PostDateField(int appTypeId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.AddDateFieldInAppTypeAsync(appTypeId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }

        // POST api/types/{id}/timefield
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/timefield")]
        public async Task<IActionResult> PostTimeField(int appTypeId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.AddTimeFieldInAppTypeAsync(appTypeId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }

        // POST api/types/{id}/filefield
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/filefield")]
        public async Task<IActionResult> PostFileField(int appTypeId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.AddFileFieldInAppTypeAsync(appTypeId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }

        // POST api/types/{id}/status
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/status")]
        public async Task<IActionResult> PostStatus(int appTypeId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.AddStatusInAppTypeAsync(appTypeId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }

        // PATCH api/types/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}")]
        public async Task<IActionResult> PatchAppType(int appTypeId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.ChangeAppTypeAsync(appTypeId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }

        // PATCH api/types/{id}/stringfield/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/stringfield/{stringFieldId:int}")]
        public async Task<IActionResult> PatchStringField(int appTypeId, int stringFieldId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.ChangeStringFieldInAppTypeAsync(appTypeId, stringFieldId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }

        // PATCH api/types/{id}/numfield/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/numfield/{numFieldId:int}")]
        public async Task<IActionResult> PatchNumField(int appTypeId, int numFieldId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.ChangeNumFieldInAppTypeAsync(appTypeId, numFieldId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }

        // PATCH api/types/{id}/datefield/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/datefield/{dateFieldId:int}")]
        public async Task<IActionResult> PatchDateField(int appTypeId, int dateFieldId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.ChangeDateFieldInAppTypeAsync(appTypeId, dateFieldId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }

        // PATCH api/types/{id}/timefield/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/timefield/{timeFieldId:int}")]
        public async Task<IActionResult> PatchTimeField(int appTypeId, int timeFieldId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.ChangeTimeFieldInAppTypeAsync(appTypeId, timeFieldId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }

        // PATCH api/types/{id}/filefield/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/filefield/{fileFieldId:int}")]
        public async Task<IActionResult> PatchFileField(int appTypeId, int fileFieldId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.ChangeFileFieldInAppTypeAsync(appTypeId, fileFieldId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }

        // PATCH api/types/{id}/status/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/status/{statusId:int}")]
        public async Task<IActionResult> PatchStatus(int appTypeId, int statusId, [FromBody] JsonDocument doc)
        {
            await CommandAggregator.ChangeStatusInAppTypeAsync(appTypeId, statusId, doc);

            var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
            return Ok(appType);
        }


    }
}