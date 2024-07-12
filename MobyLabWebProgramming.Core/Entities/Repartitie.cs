using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;


namespace MobyLabWebProgramming.Core.Entities
{
    public class Repartitie : BaseEntity
    {
        public string? CNP { get; set; }
        public DateTime DataRepartitie { get; set; }
        public Guid IdOlm { get; set; }
        public RezultatRepartitieEnum Rezultat { get; set; } = default!;
        // proprietati de navigare
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public Guid IdDosar { get; set; }
        public Dosar DosarR { get; set; } = default!;
        public Olm RepartitiiOlm { get; set; } = default!;
    }
 }
