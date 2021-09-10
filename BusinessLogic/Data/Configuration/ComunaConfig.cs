using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class ComunaConfig : IEntityTypeConfiguration<Comuna>
    {
        public void Configure(EntityTypeBuilder<Comuna> builder)
        {
            builder.Property(c => c.Codigo).IsRequired().HasMaxLength(5);
            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Estado).HasDefaultValue<bool>(true);
            builder.HasOne(c => c.Provincia).WithMany().HasForeignKey(c => c.ProvinciaId);
        }
    }
}