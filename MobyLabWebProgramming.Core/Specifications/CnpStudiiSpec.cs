using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications;

/// <summary>
/// This is a simple specification to filter the user entities from the database via the constructors.
/// Note that this is a sealed class, meaning it cannot be further derived.
/// </summary>
public sealed class CnpStudiiSpec : BaseSpec<CnpStudiiSpec, CnpStudii>
{
    public CnpStudiiSpec(Guid id) : base(id)
    {
    }

    public CnpStudiiSpec(Guid id,Guid Userid)
    {
        if (id == Userid)
        {

        }
        Query.Where(e => e.UserId == Userid);
    }

    public CnpStudiiSpec(Guid id, Guid IdSolicitant, Guid IdStudii)
    {
        if (id == IdSolicitant)
        {

        }
        Query.Where(e => e.IdSolicitant == IdSolicitant && e.IdStudii == IdStudii);
    }

}