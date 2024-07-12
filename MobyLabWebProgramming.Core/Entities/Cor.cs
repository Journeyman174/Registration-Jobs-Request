using MobyLabWebProgramming.Core.Entities;
using System.Runtime.ConstrainedExecution;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Cor : BaseEntity
    {
        public string CodCor { get; set; } = default!; 
        public string Meserie { get; set; } = default!;
        // proprietati de navigare
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public ICollection<CnpCalificari> Lucratori { get; set; } = default!;
    }
}
