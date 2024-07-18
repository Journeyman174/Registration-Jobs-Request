using MobyLabWebProgramming.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MobyLabWebProgramming.Infrastructure.EntityConfiguration
{
    public class Configuration : IEntityTypeConfiguration<Solicitanti>
    {
        public void Configure(EntityTypeBuilder<Solicitanti> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasAlternateKey(m => m.CnpSolicitant);
            builder.HasMany(m => m.Dosare)
                .WithOne(e => e.Solicitanti)
                .HasForeignKey(e => e.Id)

                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.Pregatire)
                .WithOne(e => e.Solicitanti)
                .HasForeignKey(e => e.IdSolicitant)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.Calificari)
                .WithOne(e => e.Solicitanti)
                .HasForeignKey(e => e.IdSolicitant)

                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.Nume)
                .IsRequired();

            builder.Property(m => m.Prenume)
                .IsRequired();
            builder.Property(m => m.Adresa)
                .IsRequired();
        }
    }
}
