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
public sealed class RepartitieProjectionSpec : BaseSpec<RepartitieProjectionSpec, Repartitie, RepartitiiDTO>
{
    /// <summary>
    /// This is the projection/mapping expression to be used by the base class to get UserDTO object from the database.
    /// </summary>
    protected override Expression<Func<Repartitie, RepartitiiDTO>> Spec => e => new()
    {
        Id = e.Id,
        DataRepartitie=e.DataRepartitie,
        CNP=e.CNP,
        IdOlm=e.IdOlm,
        Rezultat=e.Rezultat,

        UserId = e.UserId
    };

    public RepartitieProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public RepartitieProjectionSpec(Guid id) : base(id)
    {
    }

    public RepartitieProjectionSpec(Guid id,Guid UserId)
    {
        if (id == UserId)
        {

        }
        Query.Where(e => e.UserId == UserId);
    }

    public RepartitieProjectionSpec(string? search)
    {
        search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

        if (search == null)
        {
            return;
        }

        var searchExpr = $"%{search.Replace(" ", "%")}%";

        Query.Where(e => EF.Functions.ILike(e.CNP, searchExpr)); // This is an example on who database specific expressions can be used via C# expressions.
                                                                                           // Note that this will be translated to the database something like "where user.Name ilike '%str%'".
    }
}
