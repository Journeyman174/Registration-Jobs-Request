using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfiguration
{
    public class DosarRepartitiiConfiguration :
IEntityTypeConfiguration<DosarRepartitii>
    {
        public void Configure(EntityTypeBuilder<DosarRepartitii> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(e => e.IdDosar)
                 .IsRequired();
            builder.Property(e => e.IdRepartitie)
                 .IsRequired();
        }

    }
}
