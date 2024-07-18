using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfiguration
{
    public class OlmConfiguration
: IEntityTypeConfiguration<Olm>
    {
        public void Configure(EntityTypeBuilder<Olm> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(e => e.Cor)
                .WithMany(e => e.Oferte)
                .HasForeignKey(e =>e.IdCor)
                .HasPrincipalKey(s => s.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);



            builder.Property(e => e.DataOlmStart)
                 .IsRequired();
            builder.Property(e => e.DataOlmSfarsit)
                 .IsRequired();
            builder.Property(e => e.CuiFirma)
                 .IsRequired();
        }
    }
}
