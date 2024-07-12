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
                .WithMany(e => e.Persoane)
                .HasPrincipalKey(s => s.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Solicitanti)
                .WithMany(e => e.Pregatire)
                .HasForeignKey(e => e.Id)
                .HasPrincipalKey(e => e.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.CnpSolicitant)
                 .IsRequired();
            builder.Property(e => e.IdStudii)
                 .IsRequired();


        }
    }
}
