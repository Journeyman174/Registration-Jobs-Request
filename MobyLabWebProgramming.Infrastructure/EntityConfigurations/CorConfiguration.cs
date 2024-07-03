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
            builder.HasOne(s =>s.CnpCalificari);

            builder.Property(e => e.CodCor)
                 .IsRequired();
            builder.Property(e => e.Meserie)
                 .IsRequired();


        }
    }
}
