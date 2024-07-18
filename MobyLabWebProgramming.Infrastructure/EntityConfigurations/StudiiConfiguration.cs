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
            builder.HasMany(m => m.Persoane)
               .WithOne(e => e.Studii)
               .HasForeignKey(e => e.IdStudii)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
            builder.Property(e => e.DenStudii)
                 .IsRequired();
        }
    }
}
