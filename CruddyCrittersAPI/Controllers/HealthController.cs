using Microsoft.AspNetCore.Mvc;

namespace CruddyCrittersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        // TODO: this controller will have all services that require healthchecks injected in
        public HealthController()
        {

        }


        /// <summary>
        /// Healthcheck api for monitoring
        /// </summary>
        /// <returns>Action result with string of validation failures</returns>
        [HttpGet()]
        public ActionResult<string> Get()
        {
            return Ok("");
        }
    }
}
