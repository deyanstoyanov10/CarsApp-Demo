namespace CarsApp.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    //[Authorize]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
