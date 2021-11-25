namespace CarsApp.Data
{
    using Models;
    using Configuration;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class CarsDbContext : IdentityDbContext<AppUser>
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            : base(options) {}

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new ModelConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
