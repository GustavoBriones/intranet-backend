using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class AsociacionConfig : IEntityTypeConfiguration<Asociacion>
    {
        public void Configure(EntityTypeBuilder<Asociacion> builder)
        {
            builder.Property(a => a.Asociacion_Id).IsRequired().HasMaxLength(3);
            builder.Property(a => a.Nombre).IsRequired().HasMaxLength(50);
        }
    }
}