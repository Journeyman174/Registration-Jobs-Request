using MobyLabWebProgramming.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MobyLabWebProgramming.Infrastructure.EntityConfiguration
{
    public class DosarConfiguration : IEntityTypeConfiguration<Dosar>
    {
        public void Configure(EntityTypeBuilder<Dosar> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.CnpSolicitant).IsRequired();
            builder.Property(s => s.DataDosar).IsRequired();
            builder.Property(s => s.DeLa).IsRequired();
            builder.Property(s => s.PanaLa).IsRequired();
            builder.HasMany(e => e.Repartitii)
                .WithOne(e => e.Dosar)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
