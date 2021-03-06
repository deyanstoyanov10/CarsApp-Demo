namespace CarsApp.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : ApiController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(nameof(Test))]
        public ActionResult Test()
        {
            return Ok("Initial Test");
        }

        [HttpGet(nameof(Test1))]
        public ActionResult Test1()
        {
            return Ok("Initial Test");
        }
    }
}
