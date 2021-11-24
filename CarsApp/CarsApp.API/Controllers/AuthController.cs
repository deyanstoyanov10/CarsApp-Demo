namespace CarsApp.API.Controllers
{
    using Services.Authentication.Contracts;

    using Microsoft.AspNetCore.Mvc;

    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;
    }
}
