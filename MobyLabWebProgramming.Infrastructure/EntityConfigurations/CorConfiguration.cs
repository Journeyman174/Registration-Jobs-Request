using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfiguration
{
    public class CorConfiguration
: IEntityTypeConfiguration<Cor>
    {
        public void Configure(EntityTypeBuilder<Cor> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(m => m.Lucratori)
               .WithOne(e => e.Cor)
               .HasForeignKey(e => e.IdCor)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.Oferte)
               .WithOne(e => e.Cor)
               .HasForeignKey(e => e.IdCor)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.CodCor)
                 .IsRequired();
            builder.Property(e => e.Meserie)
                 .IsRequired();


        }
    }
}
