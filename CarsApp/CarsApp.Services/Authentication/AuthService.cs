namespace CarsApp.Services.Authentication
{
    using Data.Models;
    using Common.Exceptions;
    using Authentication.Contracts;

    using Microsoft.AspNetCore.Identity;

    using System.Threading.Tasks;
    using System.Security.Authentication;

    using static Models.Authentication.AuthenticationRecords;

    public class AuthService : IAuthService
    {
        private const string USERNAME_ALREADY_EXIST_MESSAGE = "Username already exists.";
        private const string EMAIL_ALREADY_EXIST_MESSAGE = "Email already exists.";
        private const string INVALID_CREDENTIALS_MESSAGE = "Invalid credentials.";

        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenGeneratorService _tokenGenerator;

        public AuthService(
            UserManager<AppUser> userManager,
            ITokenGeneratorService tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AppUser> Register(RegisterUserInputModel registerInput)
        {
            var appUserCheckEmail = await _userManager.FindByEmailAsync(registerInput.email);

            if (appUserCheckEmail is not null)
            {
                throw new EmailAlreadyExistingException(EMAIL_ALREADY_EXIST_MESSAGE);
            }

            var appUserUsernameCheck = await _userManager.FindByNameAsync(registerInput.username);

            if (appUserUsernameCheck is not null)
            {
                throw new UsernameAlreadyExistingException(USERNAME_ALREADY_EXIST_MESSAGE);
            }

            var appUser = new AppUser
            {
                Email = registerInput.email,
                UserName = registerInput.username,
            };

            var identityResult = await _userManager.CreateAsync(appUser, registerInput.password);

            if (!identityResult.Succeeded)
            {
                throw new InvalidCredentialException(INVALID_CREDENTIALS_MESSAGE);
            }

            return appUser;
        }

        public async Task<AppUserOutputModel> Login(LoginUserInputModel loginInput)
        {
            var appUser = await _userManager.FindByNameAsync(loginInput.username);

            if (appUser == null)
            {
                throw new InvalidCredentialException(INVALID_CREDENTIALS_MESSAGE);
            }
            
            var passwordValid = await _userManager.CheckPasswordAsync(appUser, loginInput.password);
            if (!passwordValid)
            {
                throw new InvalidCredentialException(INVALID_CREDENTIALS_MESSAGE);
            }

            var roles = await _userManager.GetRolesAsync(appUser);

            var token = _tokenGenerator.GenerateToken(appUser, roles);

            return new AppUserOutputModel(token);
        }
    }
}