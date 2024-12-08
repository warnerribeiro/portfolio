namespace Web.Api.Controllers.V1
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Web.Api.ApplicationService;
    using Web.Api.Contracts;

    /// <summary>
    /// Controladora de login
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationServiceUser;

        public LoginController(IApplicationServiceUser applicationServiceUser)
        {
            _applicationServiceUser = applicationServiceUser;
        }

        /// <summary>
        /// Realiza o login no sistema
        /// </summary>
        /// <param name="contratoSolicitacaoLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<dynamic> login(ContractReturnLogin contractReturnLogin)
        {
            return Ok(_applicationServiceUser.Login(contractReturnLogin.User, contractReturnLogin.Password));
        }
    }
}