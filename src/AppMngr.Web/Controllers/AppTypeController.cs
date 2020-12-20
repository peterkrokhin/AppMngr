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

        /// <summary>Просмотр типов заявок (admin)</summary>
        // GET api/types
        [Authorize(Roles="admin")]
        [HttpGet("types")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var appTypes = await AppTypes.GetAllDTOAsync();
                return Ok(appTypes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Добавление нового типа заявки (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "name": "AppTypeName"    // Имя типа, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "name": "Тип 1"
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        // POST api/types
        [Authorize(Roles="admin")]
        [HttpPost("types")]
        public async Task<IActionResult> Post([FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.AddAppTypeAsync(doc);

                var appTypes = await AppTypes.GetAllDTOAsync();
                return Ok(appTypes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Добавление к типу заявки динамического поля, тип поля: строка (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": "StringValue"    // Значение поля, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": "Строка 1"
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        // POST api/types/{id}/stringfield
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/stringfield")]
        public async Task<IActionResult> PostStringField(int appTypeId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.AddStringFieldInAppTypeAsync(appTypeId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Добавление к типу заявки динамического поля, тип поля: число double (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": DoubleValue    // Значение поля, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": 7.7
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        // POST api/types/{id}/numfield
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/numfield")]
        public async Task<IActionResult> PostNumField(int appTypeId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.AddNumFieldInAppTypeAsync(appTypeId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        /// <summary>Добавление к типу заявки динамического поля, тип поля: дата, формат: YYYY-MM-DDThh:mm:ss (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": "YYYY-MM-DDThh:mm:ss"    // Значение поля, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": "2020-12-20T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        // POST api/types/{id}/datefield
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/datefield")]
        public async Task<IActionResult> PostDateField(int appTypeId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.AddDateFieldInAppTypeAsync(appTypeId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Добавление к типу заявки динамического поля, тип поля: время, формат: YYYY-MM-DDThh:mm:ss (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": "YYYY-MM-DDThh:mm:ss"    // Значение поля, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": "2020-12-20T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        // POST api/types/{id}/timefield
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/timefield")]
        public async Task<IActionResult> PostTimeField(int appTypeId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.AddTimeFieldInAppTypeAsync(appTypeId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Добавление к типу заявки динамического поля, тип поля: файл, формат: Base64 (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": "Base64Value"    // Значение поля, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": "0J/RgNC40LzQtdGA"
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        // POST api/types/{id}/filefield
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/filefield")]
        public async Task<IActionResult> PostFileField(int appTypeId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.AddFileFieldInAppTypeAsync(appTypeId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Добавление к типу заявки статуса (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": "StringValue"    // Значение статуса, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": "Статус 1"
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        // POST api/types/{id}/status
        [Authorize(Roles="admin")]
        [HttpPost("types/{appTypeId:int}/status")]
        public async Task<IActionResult> PostStatus(int appTypeId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.AddStatusInAppTypeAsync(appTypeId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Изменение типа заявки (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "name": "StringValue"    // Новое имя, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "name": "Тип 2"
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        // PATCH api/types/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}")]
        public async Task<IActionResult> PatchAppType(int appTypeId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.ChangeAppTypeAsync(appTypeId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Изменение в типе заявки поля с типом строка (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": "StringValue"    // Новое значение поля, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": "Строка 2"
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        /// <param name="stringFieldId">Id поля</param>
        // PATCH api/types/{id}/stringfield/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/stringfield/{stringFieldId:int}")]
        public async Task<IActionResult> PatchStringField(int appTypeId, int stringFieldId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.ChangeStringFieldInAppTypeAsync(appTypeId, stringFieldId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Изменение в типе заявки поля с типом число double (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": "DoubleValue"    // Новое значение поля, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": 7.7
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        /// <param name="numFieldId">Id поля</param>
        // PATCH api/types/{id}/numfield/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/numfield/{numFieldId:int}")]
        public async Task<IActionResult> PatchNumField(int appTypeId, int numFieldId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.ChangeNumFieldInAppTypeAsync(appTypeId, numFieldId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Изменение в типе заявки поля с типом дата (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": "YYYY-MM-DDThh:mm:ss"    // Новое значение поля, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": "2020-12-21T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        /// <param name="dateFieldId">Id поля</param>
        // PATCH api/types/{id}/datefield/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/datefield/{dateFieldId:int}")]
        public async Task<IActionResult> PatchDateField(int appTypeId, int dateFieldId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.ChangeDateFieldInAppTypeAsync(appTypeId, dateFieldId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Изменение в типе заявки поля с типом время (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": "YYYY-MM-DDThh:mm:ss"    // Новое значение поля, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": "2020-12-21T01:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        /// <param name="timeFieldId">Id поля</param>
        // PATCH api/types/{id}/timefield/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/timefield/{timeFieldId:int}")]
        public async Task<IActionResult> PatchTimeField(int appTypeId, int timeFieldId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.ChangeTimeFieldInAppTypeAsync(appTypeId, timeFieldId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Изменение в типе заявки поля с типом файл (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": "Base64Value"    // Новое значение поля, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": "0J/RgNC40LzQtdGAMg=="
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        /// <param name="fileFieldId">Id поля</param>
        // PATCH api/types/{id}/filefield/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/filefield/{fileFieldId:int}")]
        public async Task<IActionResult> PatchFileField(int appTypeId, int fileFieldId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.ChangeFileFieldInAppTypeAsync(appTypeId, fileFieldId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>Изменение статуса в типе заявки (admin)</summary>
        /// <remarks>
        /// Описание и примеры запросов:
        ///
        ///     Описание запроса:
        ///     {
        ///        "value": "StringVakue"    // Новое значение поля, not null, required
        ///     }
        ///
        ///     Пример:
        ///     {
        ///        "value": "Статус 2"
        ///     }
        ///
        /// </remarks>
        /// <param name="doc"></param>
        /// <param name="appTypeId">Id типа заяки</param>
        /// <param name="statusId">Id поля</param>
        // PATCH api/types/{id}/status/{id}
        [Authorize(Roles="admin")]
        [HttpPatch("types/{appTypeId:int}/status/{statusId:int}")]
        public async Task<IActionResult> PatchStatus(int appTypeId, int statusId, [FromBody] JsonDocument doc)
        {
            try
            {
                await CommandAggregator.ChangeStatusInAppTypeAsync(appTypeId, statusId, doc);

                var appType = await AppTypes.GetDTOByIdAsync(appTypeId);
                return Ok(appType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}