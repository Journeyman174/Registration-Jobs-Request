namespace MobyLabWebProgramming.Core.Entities
{
    public class DosarRepartitii : BaseEntity
    {

        public Guid IdDosar { get; set; } = default!;
        public Guid IdRepartitie { get; set; } = default!;
        // proprietati de navigare
        public Dosar Dosar { get; set; } = default!;
        public ICollection<Repartitie> Repartitii { get; set; } = default!;
    }
}


