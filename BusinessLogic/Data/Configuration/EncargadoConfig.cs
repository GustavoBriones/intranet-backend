using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class EncargadoConfig : IEntityTypeConfiguration<Encargado>
    {
        public void Configure(EntityTypeBuilder<Encargado> builder)
        {
            builder.Property(e => e.Rut).IsRequired();
            builder.Property(e => e.Dv).IsRequired().HasMaxLength(1);
            builder.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ApellidoPaterno).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ApellidoMaterno).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Direccion).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Telefono).IsRequired();
            builder.Property(e => e.Estado).HasDefaultValue<bool>(true);
            builder.HasOne(e => e.EncargadoTipo).WithMany().HasForeignKey(e => e.EncargadoTipoId);
        }
    }
}