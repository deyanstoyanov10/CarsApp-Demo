namespace CarsApp.Services.Authentication.Contracts
{
    using CarsApp.Data.Models;

    using System.Collections.Generic;

    public interface ITokenGeneratorService
    {
        string GenerateToken(AppUser user, IEnumerable<string> roles = null);
    }
}
