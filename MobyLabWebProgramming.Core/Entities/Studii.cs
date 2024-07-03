using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Studii : BaseEntity 
    {
        public string DenStudii { get; set; } = default!;
        // proprietati de navigare
        public CnpStudii CnpStudii { get; set; }= default!;
    }
}
