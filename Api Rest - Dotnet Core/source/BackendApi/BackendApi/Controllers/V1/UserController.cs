namespace Web.Api.Controllers.V1
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Api.ApplicationService;
    using Web.Api.Contracts;

    /// <summary>
    /// Controladora de usuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IApplicationServiceUser _applicationServiceUser;

        public UserController(IApplicationServiceUser applicationServiceUser)
        {
            _applicationServiceUser = applicationServiceUser;
        }

        [HttpDelete("{userId}")]
        public ActionResult Delete(int userId)
        {
            _applicationServiceUser.Delete(userId);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractReturnUser>>> Get()
        {
            return Ok(await _applicationServiceUser.GetAsync());
        }

        [HttpGet("{userId}")]
        public ActionResult<ContractReturnUser> Get(int userId)
        {
            return Ok(_applicationServiceUser.Get(userId));
        }

        [HttpPost]
        public ActionResult<ContractReturnUser> Post(ContractReturnUser contractReturnUser)
        {
            return Created("", _applicationServiceUser.Insert(contractReturnUser));
        }

        [HttpPut("{userId:int}")]
        public ActionResult<ContractReturnUser> Put(int userId, ContractReturnUser contractReturnUser)
        {
            return Ok(_applicationServiceUser.Edit(contractReturnUser));
        }
    }
}