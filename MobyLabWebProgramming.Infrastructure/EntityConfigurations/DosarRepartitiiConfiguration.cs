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

            builder.HasOne(e => e.Repartitie)
                .WithMany(e => e.DosareDr)
                .HasForeignKey(e => e.IdRepartitie)
                 .HasPrincipalKey(s => s.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Dosar)
                .WithMany(e => e.RepartitiiDr)
                .HasForeignKey(e => e.IdDosar)
                .HasPrincipalKey(e => e.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
