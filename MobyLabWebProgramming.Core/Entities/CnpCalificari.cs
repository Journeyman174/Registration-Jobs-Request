using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Entities
{
    public class CnpCalificari :BaseEntity
    {
        public Guid IdSolicitant { get; set; }
        public string CnpSolicitant { get; set; } = default!;
        public Guid IdCor { get; set; } = default!;
        // proprietati de navigare
        public Solicitanti Solicitanti { get; set; } = default!;
        public Cor Cor { get; set; } = default!;
    }
}