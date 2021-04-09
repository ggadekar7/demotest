using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeController : ControllerBase
    {
        [Route("IsThisAPrimeNumber")]
        [HttpPost]
        public async Task<IActionResult> CheckPrime([FromBody] ModelCls number)
        {
            Service service = new Service(); 
            bool result = service.isPrime(number);
            if (result == false)
                return this.BadRequest();
            return Ok(result);
        }
    }
}
