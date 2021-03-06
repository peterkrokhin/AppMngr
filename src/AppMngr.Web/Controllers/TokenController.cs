using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AppMngr.Application;

namespace AppMngr.Web
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IGetTokenService _getTokenService;

        public TokenController(IMediator mediator, IGetTokenService getTokenService)
        {  
            _mediator = mediator;
            _getTokenService = getTokenService;
        }

        /// <summary>Получение токена</summary>
        /// <remarks>
        /// Пользователи по умолчанию:
        ///
        ///     Администратор по умолчанию:
        ///     {
        ///        "name": "default_admin",
        ///        "pwd": "default_pwd"
        ///     }
        ///
        ///     Клиент по умолчанию:
        ///     {
        ///        "name": "default_client",
        ///        "pwd": "default_pwd"
        ///     }  
        /// </remarks>
        // POST api/token
        [HttpPost]
        public async Task<ActionResult<TokenData>> Token(GetUserByNameAndPasswordQuery query)
        {
            var user = await _mediator.Send(query);

            var tokenData = _getTokenService.GetTokenData(user);

            return Ok(tokenData);
        }
    }
}