namespace CarsApp.Handlers.RegistrationValidation
{
    using Data.Models;
    using CarsApp.Common;

    using Microsoft.AspNetCore.Identity;

    using static Models.Authentication.AuthenticationRecords;

    public class EmailValidationHandler : Handler<RegisterUserInputModel, AppUser>
    {
        private const string EMAIL_ALREADY_EXIST_MESSAGE = "Email already exists.";

        private readonly UserManager<AppUser> _userManager;

        public EmailValidationHandler(UserManager<AppUser> userManager) => _userManager = userManager;

        public override async Task<Result<AppUser>> Execute(RegisterUserInputModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.email);

            return user is not null ? EMAIL_ALREADY_EXIST_MESSAGE : await base.Execute(model);
        }
    }
}
