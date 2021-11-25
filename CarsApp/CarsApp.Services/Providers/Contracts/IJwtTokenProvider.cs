namespace CarsApp.Services.Providers.Contracts
{
    using CarsApp.Data.Models;

    using System.Collections.Generic;

    public interface IJwtTokenProvider
    {
        string GenerateToken(AppUser user, IEnumerable<string> roles = null);
    }
}
