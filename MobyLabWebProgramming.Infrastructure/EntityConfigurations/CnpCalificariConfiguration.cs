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
                .WithOne(e => e.CnpCalificari)
                .HasForeignKey<Cor>(e => e.Id)
                .IsRequired();
            builder.Property(e => e.IdCor)
                 .IsRequired();
        }
    }
}
