using FuncLab2.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncLab2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculateWeightController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CalculateWeight([FromQuery]double targetWeight, [FromQuery]double barbellWeight) 
        {
            if (targetWeight < barbellWeight)
            {
                return BadRequest("Искомый вес не может быть меньше веса грифа");
            }
            double diskWeight = (targetWeight - barbellWeight) / 2;
            Console.WriteLine(diskWeight.ToString());
            return Ok(diskWeight);
        }
    }
}
