using EconomyTips.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace EconomyTips.Calculation.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class BaseController : ControllerBase
    {
        public IActionResult HttpReturn<T>(Result<T> result)
        {
            if (result != null && result.Sucess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
