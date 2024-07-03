using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfiguration
{
    public class CnpStudiiConfiguration : IEntityTypeConfiguration<CnpStudii>
    {
        public void Configure(EntityTypeBuilder<CnpStudii> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(e => e.Studii)
                .WithOne(e => e.CnpStudii)
                .HasForeignKey<Studii>(e => e.Id);
            builder.Property(e => e.CnpSolicitant)
                 .IsRequired();
            builder.Property(e => e.IdStudii)
                 .IsRequired();


        }
    }
}
