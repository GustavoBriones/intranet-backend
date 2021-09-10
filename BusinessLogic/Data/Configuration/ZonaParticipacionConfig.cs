using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class ZonaParticipacionConfig : IEntityTypeConfiguration<ZonaParticipacion>
    {
        public void Configure(EntityTypeBuilder<ZonaParticipacion> builder)
        {
            builder.Property(z => z.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(z => z.PorcGtoExplotacion).IsRequired().HasColumnType("decimal").HasPrecision(8,2);
            builder.Property(z => z.PorcVenta).IsRequired().HasColumnType("decimal").HasPrecision(8,2);
            builder.Property(z => z.PorcUnico).IsRequired().HasColumnType("decimal").HasPrecision(8,2);
            builder.HasOne(z => z.ZonaGrupoParticipacion).WithMany().HasForeignKey(z => z.ZonaGrupoParticipacionId);
        }
    }
}