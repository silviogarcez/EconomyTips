using EconomyTips.Calculation.Controllers.Base;
using EconomyTips.Calculation.Services.Abstractions.Interfaces;
using EconomyTips.Domain;
using EconomyTips.Domain.Abstractions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EconomyTips.Calculation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CdbController(ILogger<CdbController> logger, ICdbService cdbService) : BaseController
    {

        private readonly ILogger<CdbController> _logger = logger;
        private readonly ICdbService cdbService = cdbService;

        [HttpPost(Name = "GetCdb")]
        public IActionResult GetCdb([FromBody] Cdb cdb123)
        {
            IActionResult ret;
            _logger.LogInformation("Started Method Get");
            ret = base.HttpReturn<ICdb>(cdbService.GetCalculation(cdb123));
            _logger.LogInformation("Ended Method Get");

            return ret;
        }
    }
}
