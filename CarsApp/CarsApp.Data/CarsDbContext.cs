namespace CarsApp.Data
{
    using Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class CarsDbContext : IdentityDbContext<AppUser>
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            : base(options)
        {
        }
    }
}
