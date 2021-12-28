using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using EncapsulationApi.DDD.ApplicationServices;

namespace EncapsulationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DomainModelController : ControllerBase
    {
        private readonly ILogger<DomainModelController> _logger;
        private readonly IDomainModelApplicationService _domainModelApplicationService;

        public DomainModelController(
            IDomainModelApplicationService domainModelApplicationService, 
            ILogger<DomainModelController> logger)
        {
            _domainModelApplicationService = domainModelApplicationService;
            _logger = logger;
        }

        [HttpPut("draft")]
        public async Task<ActionResult> PutAsync()
        {
            await _domainModelApplicationService.SubmitDraft();
            return Ok();
        }
    }
}
