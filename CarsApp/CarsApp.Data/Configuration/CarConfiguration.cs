namespace CarsApp.Data.Configuration
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasOne(u => u.AppUser)
                .WithMany(c => c.Cars)
                .HasForeignKey(u => u.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(i => i.Images)
                .WithOne(c => c.Car)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
