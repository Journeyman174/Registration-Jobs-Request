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
public sealed class CnpCalificariProjectionSpec : BaseSpec<CnpCalificariProjectionSpec, CnpCalificari, CnpCalificariDTO>
{
    /// <summary>
    /// This is the projection/mapping expression to be used by the base class to get UserDTO object from the database.
    /// </summary>
    protected override Expression<Func<CnpCalificari, CnpCalificariDTO>> Spec => e => new()
    {
        Id = e.Id,
        IdSolicitant = e.IdSolicitant,
        IdCor = e.IdCor,
        CnpSolicitant = e.CnpSolicitant,

    };

    public CnpCalificariProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public CnpCalificariProjectionSpec(Guid id) : base(id)
    {
    }

    public CnpCalificariProjectionSpec(Guid id,Guid UserId)
    {
        if (id == UserId)
        {

        }
        Query.Where(e => e.UserId == UserId);
    }

}
