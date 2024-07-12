using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications;

/// <summary>
/// This is a simple specification to filter the user entities from the database via the constructors.
/// Note that this is a sealed class, meaning it cannot be further derived.
/// </summary>
public sealed class StudiiSpec : BaseSpec<StudiiSpec, Studii>
{
    public StudiiSpec(Guid id) : base(id)
    {
    }

    public StudiiSpec(string studii)
    {
        Query.Where(e => e.DenStudii == studii);
    }
}