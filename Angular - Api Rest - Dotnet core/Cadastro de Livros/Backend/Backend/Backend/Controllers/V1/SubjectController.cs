using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ILogger<SubjectController> _logger;

        public SubjectController(ILogger<SubjectController> logger, ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAsync()
        {
            return Ok(await _subjectRepository.GetAsync());
        }

        [HttpGet("{subjectId:int}")]
        public ActionResult<Subject> Get(int subjectId)
        {
            var subject = _subjectRepository.Get(subjectId);

            if (subject == null)
            {
                return NoContent();
            }

            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> PostAsync(Subject subject)
        {
            if (subject == null)
            {
                return BadRequest();
            }

            return Created("", await _subjectRepository.AddAsync(subject));
        }

        [HttpPut("{subjectId:int}")]
        public async Task<ActionResult<Subject>> PutAsync(int subjectId, Subject subject)
        {
            if (subject == null || subjectId != subject.SubjectId) 
            {
                return BadRequest("Id de atualização do objecto não confere.");
            }
            
            return Ok(await _subjectRepository.UpdateAsync(subject));
        }

        [HttpDelete("{subjectId:int}")]
        public async Task<ActionResult> DeleteAsync(int subjectId)
        {
            await _subjectRepository.RemoveAsync(subjectId);
            return Ok();
        }
    }
}
