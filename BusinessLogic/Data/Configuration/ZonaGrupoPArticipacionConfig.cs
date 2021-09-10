using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class ZonaGrupoParticipacionConfig : IEntityTypeConfiguration<ZonaGrupoParticipacion>
    {
        public void Configure(EntityTypeBuilder<ZonaGrupoParticipacion> builder)
        {
            builder.Property(z => z.Descripcion).IsRequired().HasMaxLength(50);
            builder.Property(z => z.Glosa).IsRequired().HasMaxLength(5);
        }
    }
}