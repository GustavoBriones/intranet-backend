using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class RegionConfig : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(r => r.Nombre).IsRequired().HasMaxLength(25);
            builder.Property(r => r.Codigo).IsRequired().HasMaxLength(5);
            builder.Property(r => r.Estado).HasDefaultValue<bool>(true);
        }
    }
}