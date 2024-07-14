using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

/// <summary>
/// This is a specification to filter the user entities and map it to and UserDTO object via the constructors.
/// Note how the constructors call the base class's constructors. Also, this is a sealed class, meaning it cannot be further derived.
/// </summary>
public sealed class OlmProjectionSpec : BaseSpec<OlmProjectionSpec, Olm, OlmDTO>
{
    /// <summary>
    /// This is the projection/mapping expression to be used by the base class to get UserDTO object from the database.
    /// </summary>
    protected override Expression<Func<Olm, OlmDTO>> Spec => e => new()
    {
        DataOlm =e.DataOlm,
        DataOlmStart=e.DataOlmStart,
        DataOlmSfarsit=e.DataOlmSfarsit,
        Agent=e.Agent,
        CuiFirma=e.CuiFirma,
        IdCor=e.IdCor,
        AdresaLocMunca=e.AdresaLocMunca,
        NrLocMunca=e.NrLocMunca
    };

    public OlmProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public OlmProjectionSpec(Guid id) : base(id)
    {
    }

    public OlmProjectionSpec(Guid id,Guid UserId)
    {
        if (id == UserId)
        {

        }
        Query.Where(e => e.UserId == UserId);
    }

    public OlmProjectionSpec(string? search)
    {
        search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

        if (search == null)
        {
            return;
        }

        var searchExpr = $"%{search.Replace(" ", "%")}%";

        Query.Where(e => EF.Functions.ILike(e.CuiFirma, searchExpr)); // This is an example on who database specific expressions can be used via C# expressions.
                                                                                           // Note that this will be translated to the database something like "where user.Name ilike '%str%'".
    }
}
