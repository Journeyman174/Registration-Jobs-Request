﻿namespace MobyLabWebProgramming.Core.DataTransferObjects;

/// <summary>
/// This DTO is used to transfer information about a user within the application and to client application.
/// Note that it doesn't contain a password property and that is why you should use DTO rather than entities to use only the data that you need or protect sensible information.
/// </summary>
public class CnpCalificariDTO
{
    public Guid Id { get; set; }
    public Guid IdSolicitant { get; set; }
    public string CnpSolicitant { get; set; } = default!;
    public Guid IdCor { get; set; } = default!;

}
