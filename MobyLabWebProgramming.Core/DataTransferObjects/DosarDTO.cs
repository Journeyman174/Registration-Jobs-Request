using MobyLabWebProgramming.Core.Enums;
namespace MobyLabWebProgramming.Core.DataTransferObjects;

/// <summary>
/// This DTO is used to transfer information about a user within the application and to client application.
/// Note that it doesn't contain a password property and that is why you should use DTO rather than entities to use only the data that you need or protect sensible information.
/// </summary>
public class DosarDTO
{
    public string NrDosar { get; set; } = default!;
    public Guid IdSolicitant { get; set; } = default!;
    public DateTime DataDosar { get; set; }
    public string? CnpSolicitant { get; set; }
    public DateTime DeLa { get; set; }
    public DateTime PanaLa { get; set; }
    public DosarStareEnum Stare { get; set; } = default!;
}
