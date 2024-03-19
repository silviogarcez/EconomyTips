using EconomyTips.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EconomyTips.Calculation.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
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
