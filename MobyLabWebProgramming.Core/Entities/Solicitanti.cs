using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Solicitanti : BaseEntity
    {
        public DateTime DataInregistare { get; set; } = default!;
        public string CnpSolicitant { get; set; } = default!; 
        public string Nume { get; set; } = default!;
        public string Prenume { get; set; } = default!;
        public string? Adresa { get; set; } = default!;
        public Guid UserId { get; set; }
        // proprietati de navigare
        public ICollection<Dosar> Dosare { get; set; } = default!;
        public ICollection<CnpStudii> Pregatire { get; set; } = default!;
        public ICollection<CnpCalificari> Calificari { get; set; } = default!;
    }
}
