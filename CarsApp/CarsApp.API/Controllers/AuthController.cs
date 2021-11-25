namespace CarsApp.API.Controllers
{
    using CarsApp.Data.Models;
    using CarsApp.Common.Exceptions;
    using Infrastructure.Extensions;
    using Services.Authentication.Contracts;

    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;
    using System.Security.Authentication;

    using static Models.Authentication.AuthenticationRecords;

    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<AppUserOutputModel>> Register(RegisterUserInputModel registerInput)
        {
            AppUser appUser;

            try
            {
                appUser = await _authService.Register(registerInput);
            }
            catch (EmailAlreadyExistingException ex)
            {
                return BadRequest(ex.Message.ToErrorApiResponse<AppUserOutputModel>("Register"));
            }
            catch (UsernameAlreadyExistingException ex)
            {
                return BadRequest(ex.Message.ToErrorApiResponse<AppUserOutputModel>("Register"));
            }
            catch (InvalidCredentialException ex)
            {
                return BadRequest(ex.Message.ToErrorApiResponse<AppUserOutputModel>("Register"));
            }

            return await Login(new LoginUserInputModel(appUser.UserName, registerInput.password));
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<AppUserOutputModel>> Login(LoginUserInputModel loginInput)
        {
            AppUserOutputModel userOutputModel;

            try
            {
                userOutputModel = await _authService.Login(loginInput);
            }
            catch (InvalidCredentialException ex)
            {
                return BadRequest(ex.Message.ToErrorApiResponse<AppUserOutputModel>("Login"));
            }

            return userOutputModel;
        }
    }
}
