using MobyLabWebProgramming.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MobyLabWebProgramming.Infrastructure.EntityConfiguration
{
    public class RepartitieCofiguration : IEntityTypeConfiguration<Repartitie>
    {
        public void Configure(EntityTypeBuilder<Repartitie> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();
            builder.HasKey(m => m.Id);
        }
    }
}
