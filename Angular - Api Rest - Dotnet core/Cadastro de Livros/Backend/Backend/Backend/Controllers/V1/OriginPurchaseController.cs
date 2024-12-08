using Core.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginPurchaseController : ControllerBase
    {
        private readonly IOriginPurchaseRepository _originPurchaRepository;
        private readonly ILogger<OriginPurchaseController> _logger;

        public OriginPurchaseController(ILogger<OriginPurchaseController> logger, IOriginPurchaseRepository originPurchaRepository)
        {
            _originPurchaRepository = originPurchaRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OriginPurchase>>> GetAsync()
        {
            return Ok(await _originPurchaRepository.GetAsync());
        }

        [HttpGet("{originPurchaseId:int}")]
        public ActionResult<OriginPurchase> Get(int originPurchaseId)
        {
            var originPurchas = _originPurchaRepository.Get(originPurchaseId);

            if (originPurchas == null)
            {
                return NoContent();
            }

            return Ok(originPurchas);
        }

        [HttpPost]
        public async Task<ActionResult<OriginPurchase>> PostAsync(OriginPurchase originPurchase)
        {
            return Created("", await _originPurchaRepository.AddAsync(originPurchase));
        }

        [HttpPut("{originPurchaseId:int}")]
        public async Task<ActionResult<OriginPurchase>> PutAsync(int originPurchaseId, OriginPurchase originPurchase)
        {
            if (originPurchase == null || originPurchaseId != originPurchase.OriginPurchaseId)
            {
                return BadRequest("Id de atualização do objecto não confere.");
            }

            return Ok(await _originPurchaRepository.UpdateAsync(originPurchase));
        }

        [HttpDelete("{originPurchaseId:int}")]
        public async Task<ActionResult> DeleteAsync(int originPurchaseId)
        {
            await _originPurchaRepository.RemoveAsync(originPurchaseId);
            return Ok();
        }
    }
}
