using System.Linq.Expressions;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Specifications;

/// <summary>
/// This is a specification to filter the user entities and map it to and UserDTO object via the constructors.
/// Note how the constructors call the base class's constructors. Also, this is a sealed class, meaning it cannot be further derived.
/// </summary>
public sealed class DosarProjectionSpec : BaseSpec<DosarProjectionSpec, Dosar, DosarDTO>
{
    /// <summary>
    /// This is the projection/mapping expression to be used by the base class to get UserDTO object from the database.
    /// </summary>
    protected override Expression<Func<Dosar, DosarDTO>> Spec => e => new()
    {
           IdSolicitant=e.IdSolicitant,
    DataDosar=e.DataDosar,
    CnpSolicitant=e.CnpSolicitant,
    DeLa=e.DeLa,
    PanaLa=e.PanaLa,
    Stare =e.Stare
     };

    public DosarProjectionSpec(bool orderByCreatedAt = true) : base(orderByCreatedAt)
    {
    }

    public DosarProjectionSpec(Guid id) : base(id)
    {
    }

    public DosarProjectionSpec(Guid id,Guid IdSolicitant)
    {
        if (id == IdSolicitant)
        {

        }
        Query.Where(e => e.IdSolicitant == IdSolicitant);
    }

}
