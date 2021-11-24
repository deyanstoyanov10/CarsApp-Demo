namespace CarsApp.Services.Authentication.Contracts
{
    using System.Threading.Tasks;

    using static CarsApp.Models.Authentication.AuthenticationRecords;

    public interface IAuthService
    {
        Task<AppUserOutputModel> Login(LoginUserInputModel loginInput);
    }
}
