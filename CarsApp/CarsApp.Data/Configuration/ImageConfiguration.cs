namespace CarsApp.Data.Configuration
{
    using Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .HasKey(k => k.Id);
        }
    }
}
