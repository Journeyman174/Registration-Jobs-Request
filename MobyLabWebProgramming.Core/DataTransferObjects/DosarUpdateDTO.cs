namespace MobyLabWebProgramming.Core.DataTransferObjects;

/// <summary>
/// This DTO is used to update a user, the properties besides the id are nullable to indicate that they may not be updated if they are null.
/// </summary>
public record DosarUpdateDTO
(
    Guid Id,
    string NrDosar,
    DateTime DataDosar,
    string? CnpSolicitant,
    DateTime DeLa,
    DateTime PanaLa
);