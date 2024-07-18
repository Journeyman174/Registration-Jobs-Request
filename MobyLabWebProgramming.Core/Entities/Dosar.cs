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
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

        public ICollection<DosarRepartitii> RepartitiiDr { get; set; } = default!;
        public Solicitanti Solicitanti { get; set; } = default!;

    }
}
