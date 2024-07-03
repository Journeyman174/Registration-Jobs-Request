using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;


namespace MobyLabWebProgramming.Core.Entities
{
    public class Dosar : BaseEntity
    {
        public Guid IdSolicitant { get; set; } = default!;
        public DateTime DataDosar { get; set; }
        public string? CnpSolicitant { get; set; }
        public DateTime DeLa { get; set; }
        public DateTime PanaLa { get; set; }
        public DosarStareEnum Stare { get; set; } = default!;
        // proprietati de navigare
        public ICollection<DosarRepartitii> Repartitii { get; set; } = default!;
        public Solicitanti Solicitanti { get; set; } = default!;

    }
}
