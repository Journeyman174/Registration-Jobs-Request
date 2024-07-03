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
            builder.Property(e => e.DataOlmStart)
                 .IsRequired();
            builder.Property(e => e.DataOlmSfarsit)
                 .IsRequired();
            builder.Property(e => e.CuiFirma)
                 .IsRequired();
        }
    }
}
