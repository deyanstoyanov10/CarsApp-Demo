namespace CarsApp.Services.Authentication
{
    using Data.Models;
    using Common.ServiceResult;
    using Authentication.Contracts;

    using Microsoft.AspNetCore.Identity;

    using System.Threading.Tasks;
    using System.Security.Authentication;

    using static Models.Authentication.AuthenticationRecords;

    public class AuthService : IAuthService
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenGeneratorService _tokenGenerator;

        public AuthService(
            UserManager<AppUser> userManager,
            ITokenGeneratorService tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        //public async Task<AppUser> Register(RegisterUserInputModel registerInput)
        //{
        //    var user = new AppUser
        //    {
        //        Email = registerInput.email,
        //        UserName = registerInput.username,
        //    };

        //    var identityResult = await _userManager.CreateAsync(user, registerInput.password);

        //    var errors = identityResult.Errors.Select(e => e.Description);

        //    return identityResult.Succeeded
        //        ? Result<User>.SuccessWith(user)
        //        : Result<User>.Failure(errors);
        //}

        public async Task<AppUserOutputModel> Login(LoginUserInputModel loginInput)
        {
            var appUser = await _userManager.FindByNameAsync(loginInput.username);

            if (appUser == null)
            {
                throw new InvalidCredentialException(InvalidErrorMessage);
            }

            var passwordValid = await _userManager.CheckPasswordAsync(appUser, loginInput.password);
            if (!passwordValid)
            {
                throw new InvalidCredentialException(InvalidErrorMessage);
            }

            var roles = await _userManager.GetRolesAsync(appUser);

            var token = _tokenGenerator.GenerateToken(appUser, roles);

            return new AppUserOutputModel(token);
        }
    }
}