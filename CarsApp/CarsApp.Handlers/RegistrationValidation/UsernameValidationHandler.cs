namespace CarsApp.Handlers.RegistrationValidation
{
    using Common;
    using Data.Models;

    using Microsoft.AspNetCore.Identity;

    using static CarsApp.Models.Authentication.AuthenticationRecords;

    public class UsernameValidationHandler : Handler<RegisterUserInputModel, AppUser>
    {
        private const string USERNAME_ALREADY_EXIST_MESSAGE = "Username already exists.";

        private readonly UserManager<AppUser> _userManager;

        public UsernameValidationHandler(UserManager<AppUser> userManager) => _userManager = userManager;

        public override async Task<Result<AppUser>> Execute(RegisterUserInputModel model)
        {
            var user = await _userManager.FindByNameAsync(model.username);

            return user is not null ? USERNAME_ALREADY_EXIST_MESSAGE : await base.Execute(model);
        }
    }
}
