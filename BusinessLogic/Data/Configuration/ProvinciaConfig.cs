using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class ProvinciaConfig : IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> builder)
        {
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(25);
            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(5);
            builder.Property(p => p.Estado).HasDefaultValue<bool>(true);
            builder.HasOne(p => p.Region).WithMany().HasForeignKey(p => p.RegionId);
        }
    }
}