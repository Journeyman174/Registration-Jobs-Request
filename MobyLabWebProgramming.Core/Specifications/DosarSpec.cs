using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications;

/// <summary>
/// This is a simple specification to filter the user entities from the database via the constructors.
/// Note that this is a sealed class, meaning it cannot be further derived.
/// </summary>
public sealed class DosarSpec : BaseSpec<DosarSpec, Dosar>
{
    public DosarSpec(Guid id) : base(id)
    {
    }

    public DosarSpec(Guid id, Guid IdSolicitant)
    {
        if (id == IdSolicitant)
        {

        }
        Query.Where(e => e.IdSolicitant == IdSolicitant);
    }
}