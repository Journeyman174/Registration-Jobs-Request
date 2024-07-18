using MobyLabWebProgramming.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MobyLabWebProgramming.Infrastructure.EntityConfiguration
{
    public class RepartitieCofiguration : IEntityTypeConfiguration<Repartitie>
    {
        public void Configure(EntityTypeBuilder<Repartitie> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();
            builder.HasKey(m => m.Id);

            builder.HasMany(m => m.DosareDr)
               .WithOne(e => e.Repartitie)
               .HasForeignKey(e => e.IdRepartitie)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Olm)
               .WithMany(e => e.RepartitiiO)
               .HasForeignKey(e => e.IdOlm)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
