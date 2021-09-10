using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class ComunidadConfig : IEntityTypeConfiguration<Comunidad>
    {
        public void Configure(EntityTypeBuilder<Comunidad> builder)
        {
            builder.Property(c => c.Comunidad_Id).IsRequired().HasMaxLength(7);
            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(50);
        }
    }
}