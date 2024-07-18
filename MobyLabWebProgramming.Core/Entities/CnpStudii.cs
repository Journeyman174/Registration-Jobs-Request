using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Entities
{
    public class CnpStudii : BaseEntity
    {
        public Guid IdSolicitant { get; set; } 
        public string CnpSolicitant { get; set; } = default!;
        public Guid IdStudii { get; set; }
        // proprietati de navigare
        public  Solicitanti Solicitanti { get; set; } = default!;
        public Studii Studii { get; set; } = default!;
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

    }
}
