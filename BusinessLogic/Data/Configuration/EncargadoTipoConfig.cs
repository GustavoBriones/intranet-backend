using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class EmcargadoTipoConfig : IEntityTypeConfiguration<EncargadoTipo>
    {
        public void Configure(EntityTypeBuilder<EncargadoTipo> builder)
        {
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(15);
            builder.Property(e => e.Estado).HasDefaultValue<bool>(true);
        }
    }
}