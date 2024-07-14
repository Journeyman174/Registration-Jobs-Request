using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

/// <summary>
/// This DTO is used to transfer information about a user within the application and to client application.
/// Note that it doesn't contain a password property and that is why you should use DTO rather than entities to use only the data that you need or protect sensible information.
/// </summary>
public class RepartitiiAddDTO
{
    public string? CNP { get; set; }
    public DateTime DataRepartitie { get; set; }
    public Guid IdOlm { get; set; }
    public RezultatRepartitieEnum Rezultat { get; set; } = default!;
    public Guid UserId { get; set; }
}
