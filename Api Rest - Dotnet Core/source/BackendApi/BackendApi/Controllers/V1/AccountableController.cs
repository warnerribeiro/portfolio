namespace Web.Api.Controllers.V1
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Api.ApplicationService;
    using Web.Api.Contracts;

    /// <summary>
    /// Controladora de Responsáveis
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountableController : ControllerBase
    {
        private readonly IApplicationServiceAccountable _applicationServiceAccountable;

        public AccountableController(IApplicationServiceAccountable applicationServiceAccountable)
        {
            _applicationServiceAccountable = applicationServiceAccountable;
        }

        [HttpDelete("{accountableId:int}")]
        public ActionResult Delete(int accountableId)
        {
            _applicationServiceAccountable.Delete(accountableId);

            return Ok();
        }

        [HttpGet("{accountableId:int}")]
        public ActionResult<ContractsReturnAccountable> Get(int accountableId)
        {
            return Ok(_applicationServiceAccountable.Get(accountableId));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractsReturnAccountable>>> GetAsync()
        {
            return Ok(await _applicationServiceAccountable.GetAsync());
        }

        [HttpPost]
        public ActionResult<ContractsReturnAccountable> Post(ContractsReturnAccountable accountable)
        {
            var messageValidation = Validations(accountable);

            if (!string.IsNullOrEmpty(messageValidation))
                return BadRequest(messageValidation);

            return Created("", _applicationServiceAccountable.Insert(accountable));
        }

        [HttpPut("{accountableId:int}")]
        public ActionResult<ContractsReturnAccountable> Put(int accountableId, ContractsReturnAccountable accountable)
        {
            if (accountableId != accountable.Id)
                return BadRequest("Numero de identifcação do responsavel não confere!");

            var messageValidation = Validations(accountable);

            if (!string.IsNullOrEmpty(messageValidation))
                return BadRequest(messageValidation);

            return Ok(_applicationServiceAccountable.Edit(accountable));
        }

        private string Validations(ContractsReturnAccountable contractsReturnAccountable)
        {
            if (string.IsNullOrEmpty(contractsReturnAccountable.Email))
                return "Campo de e-mail obrigatorio para o responsavel";

            return null;
        }
    }
}