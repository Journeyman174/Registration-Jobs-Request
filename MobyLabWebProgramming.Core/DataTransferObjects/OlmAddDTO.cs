using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

/// <summary>
/// This DTO is used to transfer information about a user within the application and to client application.
/// Note that it doesn't contain a password property and that is why you should use DTO rather than entities to use only the data that you need or protect sensible information.
/// </summary>
public class OlmAddDTO
{
    public DateTime DataOlm { get; set; }
    public DateTime DataOlmStart { get; set; }
    public DateTime DataOlmSfarsit { get; set; }
    public string Agent { get; set; } = string.Empty;
    public string CuiFirma { get; set; } = default!;
    public Guid IdCor { get; set; }
    public string AdresaLocMunca { get; set; } = default!;
    public int NrLocMunca { get; set; } = 0;
    public OlmStareEnum Stare { get; set; } = default!;
}
