﻿using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications;

/// <summary>
/// This is a simple specification to filter the user entities from the database via the constructors.
/// Note that this is a sealed class, meaning it cannot be further derived.
/// </summary>
public sealed class CnpCalificariSpec : BaseSpec<CnpCalificariSpec, CnpCalificari>
{
    public CnpCalificariSpec(Guid id) : base(id)
    {
    }

    public CnpCalificariSpec(Guid id, Guid Userid)
    {
        if (id == Userid)
        {

        }
        Query.Where(e => e.UserId == Userid);
    }

    public CnpCalificariSpec(Guid id, Guid IdSolicitant, Guid IdCor)
    {
        if (id == IdSolicitant)
        {

        }
        Query.Where(e => e.IdSolicitant == IdSolicitant && e.IdCor == IdCor);
    }
}