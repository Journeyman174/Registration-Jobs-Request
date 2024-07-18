using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;


namespace MobyLabWebProgramming.Core.Entities
{
    public class Olm : BaseEntity
    {
        public DateTime DataOlm { get; set; }
        public DateTime DataOlmStart { get; set; }
        public DateTime DataOlmSfarsit { get; set; }
        public string Agent { get; set; } = string.Empty;
        public string CuiFirma { get; set; } = default!;
        public Guid IdCor { get; set; }
        public string AdresaLocMunca { get; set; } = default!;
        public int NrLocMunca { get; set; } = 0;
        public OlmStareEnum Stare { get; set; } =default!;
        // proprietati de navigare
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public Cor Cor { get; set; } = default!;
        public ICollection<Repartitie> RepartitiiO { get; set; }= default!;
    }
}
