using Microsoft.AspNetCore.Mvc;
using SumProject.Dto;


namespace SumProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SumController : ControllerBase
    {     

        private readonly ILogger<SumController> _logger;

        public SumController(ILogger<SumController> logger)
        {
            _logger = logger;
        }

        

        [HttpGet()]
        public ActionResult<SumResult> GetSum([FromQuery] string a, string b)
        {
            try
            {
                long nA;
                long nB;
                bool isNumericA = long.TryParse(a, out nA);
                bool isNumericB = long.TryParse(b, out nB);
                if(!(isNumericA && isNumericB))
                {
                    return StatusCode(500, "Dados não númerico!");
                }
                var result = new SumResult { Result = nA +nB };
                return result;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
