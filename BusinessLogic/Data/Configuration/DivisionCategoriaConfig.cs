using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class DivisionCategoriaConfig : IEntityTypeConfiguration<DivisionCategoria>
    {
        public void Configure(EntityTypeBuilder<DivisionCategoria> builder)
        {
            builder.Property(d => d.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Estado).HasDefaultValue<bool>(true);
        }
    }
}