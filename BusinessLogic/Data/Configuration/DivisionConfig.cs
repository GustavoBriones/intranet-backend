using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class DivisionConfig : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.Property(d => d.Division_Id).IsRequired().HasMaxLength(11);
            builder.Property(d => d.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Nombre_BI).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Estado).HasDefaultValue<bool>(true);
            builder.Property(d => d.FechaCreacion).IsRequired();
            builder.Property(d => d.Direccion).IsRequired().HasMaxLength(150);
            builder.HasOne(d => d.Comuna).WithMany().HasForeignKey(d => d.ComunaId);
            builder.HasOne(d => d.Comunidad).WithMany().HasForeignKey(d => d.ComunidadId);
            builder.HasOne(d => d.DivisionCategoria).WithMany().HasForeignKey(d => d.DivisionCategoriaId);
            builder.HasOne(d => d.DivisionTipoAsociado).WithMany().HasForeignKey(d => d.DivisionTipoAsociadoId);
            builder.HasOne(d => d.Encargado).WithMany().HasForeignKey(d => d.EncargadoId);
            builder.HasOne(d => d.ZonaParticipacion).WithMany().HasForeignKey(d => d.ZonaPArticipacionId);
        }
    }
}