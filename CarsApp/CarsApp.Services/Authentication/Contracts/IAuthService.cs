namespace CarsApp.Services.Authentication.Contracts
{
    using Data.Models;

    using System.Threading.Tasks;

    using static Models.Authentication.AuthenticationRecords;

    public interface IAuthService
    {
        Task<AppUser> Register(RegisterUserInputModel registerInput);

        Task<AppUserOutputModel> Login(LoginUserInputModel loginInput);
    }
}
