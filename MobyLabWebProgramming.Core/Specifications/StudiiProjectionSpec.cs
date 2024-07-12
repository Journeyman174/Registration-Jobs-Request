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
public sealed class StudiiProjectionSpec : BaseSpec<StudiiProjectionSpec, Studii, StudiiDTO>
{
    /// <summary>
    /// This is the projection/mapping expression to be used by the base class to get UserDTO object from the database.
    /// </summary>
    protected override Expression<Func<Studii, StudiiDTO>> Spec => e => new()
    {
        Id = e.Id,
        DenStudii = e.DenStudii
    };

    public StudiiProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public StudiiProjectionSpec(Guid id) : base(id)
    {
    }



    public StudiiProjectionSpec(string? search)
    {
        search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

        if (search == null)
        {
            return;
        }

        var searchExpr = $"%{search.Replace(" ", "%")}%";

        Query.Where(e => EF.Functions.ILike(e.DenStudii, searchExpr)); // This is an example on who database specific expressions can be used via C# expressions.
                                                                                           // Note that this will be translated to the database something like "where user.Name ilike '%str%'".
    }
}
