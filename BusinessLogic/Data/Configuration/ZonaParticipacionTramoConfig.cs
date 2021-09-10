using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class ZonaParticipacionTramoConfig : IEntityTypeConfiguration<ZonaParticipacionTramo>
    {
        public void Configure(EntityTypeBuilder<ZonaParticipacionTramo> builder)
        {
            builder.Property(z => z.OrdenTramo).IsRequired();
            builder.Property(z => z.FinTramo).HasColumnType("decimal").HasPrecision(8,2).IsRequired();
            builder.Property(z => z.participacion).HasColumnType("decimal").HasPrecision(8,2).IsRequired();
            builder.HasOne(z => z.ZonaParticipacion).WithMany().HasForeignKey(z => z.ZonaParticipacionId);
        }
    }
}