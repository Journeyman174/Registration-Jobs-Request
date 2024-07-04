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
public sealed class SolicitantiProjectionSpec : BaseSpec<SolicitantiProjectionSpec, Solicitanti, SolicitantiDTO>
{
    /// <summary>
    /// This is the projection/mapping expression to be used by the base class to get UserDTO object from the database.
    /// </summary>
    protected override Expression<Func<Solicitanti, SolicitantiDTO>> Spec => e => new()
    {
        DataInregistare = e.DataInregistare,
        CnpSolicitant = e.CnpSolicitant,
        Nume = e.Nume,
        Prenume = e.Prenume,
        Adresa = e.Adresa,
        UserId = e.Id
    };

    public SolicitantiProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public SolicitantiProjectionSpec(Guid id) : base(id)
    {
    }

    public SolicitantiProjectionSpec(Guid id,Guid UserId)
    {
        if (id == UserId)
        {

        }
        Query.Where(e => e.UserId == UserId);
    }

    public SolicitantiProjectionSpec(string? search,UserDTO user)
    {
        search = !string.IsNullOrWhiteSpace(search) ? search.Trim() : null;

        if (search == null)
        {
            return;
        }
        if (search == "IsMine")
        {
            Query.Where(e => e.UserId == user.Id);
        }
        else
        {
            var searchExpr = $"%{search.Replace(" ", "%")}%";

            Query.Where(e => EF.Functions.ILike(e.Nume, searchExpr)); // This is an example on who database specific expressions can be used via C# expressions.
        }                                                                                 // Note that this will be translated to the database something like "where user.Name ilike '%str%'".
    }
}
