using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfiguration
{
    public class StudiiConfiguration
: IEntityTypeConfiguration<Studii>
    {
        public void Configure(EntityTypeBuilder<Studii> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(e => e.CnpStudii);

            builder.Property(e => e.DenStudii)
                 .IsRequired();
        }
    }
}
