namespace CarsApp.Infrastructure.Extensions
{
    using Data;
    using Data.Seeder;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using System.Collections.Generic;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
            => app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Source Control API");
                    options.RoutePrefix = string.Empty;
                });

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<CarsDbContext>();

            dbContext.Database.Migrate();
        }

        public static void SeedDatabase(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<CarsDbContext>();

            List<ISeeder> seeders = new List<ISeeder>()
            {
                new BrandSeeder(dbContext)
            };

            foreach (var seeder in seeders)
            {
                seeder.Seed();
            }
        }
    }
}
