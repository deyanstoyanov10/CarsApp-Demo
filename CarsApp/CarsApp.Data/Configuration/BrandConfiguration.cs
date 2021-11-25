namespace CarsApp.Data.Configuration
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasMany(m => m.Models)
                .WithOne(b => b.Brand)
                .HasForeignKey(b => b.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
