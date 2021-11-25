namespace CarsApp.Data.Configuration
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder
                .HasKey(k => k.Id);

            builder
                .HasMany(c => c.Cars)
                .WithOne(m => m.Model)
                .HasForeignKey(m => m.ModelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
