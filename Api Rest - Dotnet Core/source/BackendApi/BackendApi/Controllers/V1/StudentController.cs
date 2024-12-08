namespace Web.Api.Controllers.V1
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Api.ApplicationService;
    using Web.Api.Contracts;

    /// <summary>
    /// Controladora de Alunos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IApplicationServiceStudent _applicationServiceStudent;

        public StudentController(IApplicationServiceStudent applicationServiceStudent)
        {
            _applicationServiceStudent = applicationServiceStudent;
        }

        [HttpDelete("{studentId:int}")]
        public ActionResult Delete(int studentId)
        {
            _applicationServiceStudent.Delete(studentId);

            return Ok();
        }

        [HttpGet("{studentId:int}")]
        public ActionResult<ContractReturnStudent> Get(int studentId)
        {
            return Ok(_applicationServiceStudent.Get(studentId));
        }

        /// <summary>
        /// Retorna todos os alunos
        /// </summary>
        /// <returns>Retorna uma lista de alunos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractReturnStudent>>> GetAsync()
        {
            return Ok(await _applicationServiceStudent.GetAsync());
        }

        [HttpGet("{name}/{segment}/{accountable}")]
        public async Task<ActionResult<IEnumerable<ContractReturnStudent>>> GetAsync(string name, string segment, string accountable)
        {
            return Ok(await _applicationServiceStudent.GetAsync(name, segment, accountable));
        }

        [HttpPost]
        public ActionResult<ContractReturnStudent> Post(ContractReturnStudent contractReturnStudent)
        {
            var message = Validations(contractReturnStudent);

            if (!string.IsNullOrEmpty(message))
                return BadRequest(message);

            return Created("", _applicationServiceStudent.Insert(contractReturnStudent));
        }

        [HttpPut("{studentId:int}")]
        public ActionResult<ContractReturnStudent> Put(int studentId, ContractReturnStudent contractReturnStudent)
        {
            if (studentId != contractReturnStudent.Id)
                return BadRequest("Numero de identificação de aluno não confere!");

            var message = Validations(contractReturnStudent);

            if (!string.IsNullOrEmpty(message))
                BadRequest(message);

            return Ok(_applicationServiceStudent.Edit(contractReturnStudent));
        }

        private string Validations(ContractReturnStudent contractReturnStudent)
        {
            if (contractReturnStudent.Segment != Commom.Segment.fundamental
                && contractReturnStudent.Segment != Commom.Segment.infantile)
                return "Segmento não suportado!";

            if (contractReturnStudent.Segment == Commom.Segment.fundamental &&
                string.IsNullOrEmpty(contractReturnStudent.Email))
                return "Campo de e-mail obrigatorio para alunos do fundamental";

            return null;
        }
    }
}