using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Entities
{
    public class Studii : BaseEntity 
    {
        public string DenStudii { get; set; } = default!;
        // proprietati de navigare
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public ICollection<CnpStudii> Persoane { get; set; }= default!;
    }
}
