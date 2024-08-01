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
public sealed class CnpStudiiProjectionSpec : BaseSpec<CnpStudiiProjectionSpec, CnpStudii, CnpStudiiDTO>
{
    /// <summary>
    /// This is the projection/mapping expression to be used by the base class to get UserDTO object from the database.
    /// </summary>
    protected override Expression<Func<CnpStudii, CnpStudiiDTO>> Spec => e => new()
    {
        Id = e.Id,
        IdSolicitant = e.IdSolicitant,
        IdStudii = e.IdStudii,
        CnpSolicitant = e.CnpSolicitant,

    };

    public CnpStudiiProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public CnpStudiiProjectionSpec(Guid id) : base(id)
    {
    }

    public CnpStudiiProjectionSpec(Guid id,Guid UserId)
    {
        if (id == UserId)
        {

        }
        Query.Where(e => e.UserId == UserId);
    }
    public CnpStudiiProjectionSpec(Guid idSolicitant, bool state)
    {
        if (state == true)
        {

        }
        Query.Where(e => e.IdSolicitant == idSolicitant);
    }

}
