using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class DivisionTipoAsociadoConfig : IEntityTypeConfiguration<DivisionTipoAsociado>
    {
        public void Configure(EntityTypeBuilder<DivisionTipoAsociado> builder)
        {
            builder.Property(d => d.Nombre).IsRequired().HasMaxLength(25);
        }
    }
}