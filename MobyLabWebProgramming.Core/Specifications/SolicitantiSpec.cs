using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications;

/// <summary>
/// This is a simple specification to filter the user entities from the database via the constructors.
/// Note that this is a sealed class, meaning it cannot be further derived.
/// </summary>
public sealed class SolicitantiSpec : BaseSpec<SolicitantiSpec, Solicitanti>
{
    public SolicitantiSpec(Guid id) : base(id)
    {
    }

    public SolicitantiSpec(string cnp)
    {
        Query.Where(e => e.CnpSolicitant == cnp);
    }
}