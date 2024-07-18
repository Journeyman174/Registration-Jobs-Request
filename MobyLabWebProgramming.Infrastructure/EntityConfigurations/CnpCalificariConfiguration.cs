using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;
namespace MobyLabWebProgramming.Infrastructure.EntityConfiguration
{
    public class CnpCalificariConfiguration : IEntityTypeConfiguration<CnpCalificari>
    {
        public void Configure(EntityTypeBuilder<CnpCalificari> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Cor)
                .WithMany(e => e.Lucratori)
                .HasForeignKey(e => e.IdCor)
                 .HasPrincipalKey(s => s.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Solicitanti)
                .WithMany(e => e.Calificari)
                .HasForeignKey(e => e.IdSolicitant)
                .HasPrincipalKey(e => e.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.IdCor)
                 .IsRequired();
        }
    }
}
