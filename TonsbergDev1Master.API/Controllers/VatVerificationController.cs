using Microsoft.AspNetCore.Mvc;
using TonsbergDev1Master.Core.Interfaces;

namespace TonsbergDev1Master.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VatVerificationController : ControllerBase
    {
        private readonly ILogger<VatVerificationController> _logger;
        public IVatVerificationService _vatVerificationService { get; }

        public VatVerificationController(
            IVatVerificationService vatVerificationService, 
            ILogger<VatVerificationController> logger
        )
        {
            _vatVerificationService = vatVerificationService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string countryCode, [FromQuery] string vatId)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
            {
                return BadRequest($"{nameof(countryCode)} cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(vatId))
            {
                return BadRequest($"{nameof(vatId)} cannot be empty");
            }

            var verificationStatus = await _vatVerificationService.GetVatVerificationStatusAsync(countryCode, vatId);

            return Ok(new { verificationStatus = verificationStatus.ToString() });
        }
    }
}
