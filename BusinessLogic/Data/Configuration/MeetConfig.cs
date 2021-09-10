using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration
{
    public class MeetConfig : IEntityTypeConfiguration<Meet>
    {
        public void Configure(EntityTypeBuilder<Meet> builder)
        {
            builder.Property(m => m.Nombre).IsRequired().HasMaxLength(15);
            builder.Property(m => m.Codigo).IsRequired().HasMaxLength(3);
        }
    }
}