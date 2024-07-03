using MobyLabWebProgramming.Core.Entities;
using System.Runtime.ConstrainedExecution;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Cor : BaseEntity
    {
        public string CodCor { get; set; } = default!; 
        public string Meserie { get; set; } = default!;
        // proprietati de navigare
        public CnpCalificari CnpCalificari { get; set; } = default!;
    }
}
