using System.Net;
using Ardalis.Specification;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations;

public class SolicitantService : ISolicitantService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;

    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    public SolicitantService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<SolicitantiDTO>> GetSolicitant(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new SolicitantiProjectionSpec(id), cancellationToken); // Get a user using a specification on the repository.

        return (ServiceResponse<SolicitantiDTO>)(result != null ?
            ServiceResponse.ForSuccess(result) :
            ServiceResponse.FromError(CommonErrors.SolicitantNotFound)); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<SolicitantiDTO>>> GetSolicitanti(PaginationSearchQueryParams pagination, UserDTO requestingUser, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination, new SolicitantiProjectionSpec(pagination.Search,requestingUser), cancellationToken); // Use the specification and pagination API to get only some entities from the database.

        return ServiceResponse.ForSuccess(result);
    }
    public async Task<ServiceResponse<SolicitantiDTO>> GetUserSolicitant(UserDTO requestingUser, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new SolicitantiProjectionSpec(requestingUser.Id,true), cancellationToken);

        if (result == null)
        {
        }
        return (ServiceResponse<SolicitantiDTO>)(result != null ?
            ServiceResponse.ForSuccess(result) :
            ServiceResponse.FromError(CommonErrors.SolicitantNotFound)); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<CorDTO>>> GetCors(Guid id, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var Icor = await _repository.PageAsync(pagination, new CnpCalificariProjectionSpec(id,true), cancellationToken);
        var result = new PagedResponse<CorDTO>(Icor.Page, Icor.PageSize, Icor.TotalCount, new List<CorDTO>());
        foreach (var cor in Icor.Data)
        {
            var aux = await _repository.GetAsync(new CorProjectionSpec(cor.IdCor), cancellationToken);
            if (aux != null)
            {
                result.Data.Add(aux);
            }
        }
        return ServiceResponse.ForSuccess(result);
    }

    public async Task<ServiceResponse<PagedResponse<StudiiDTO>>> GetStudiis(Guid id, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var Istudii = await _repository.PageAsync(pagination, new CnpStudiiProjectionSpec(id, true), cancellationToken);
        var result = new PagedResponse<StudiiDTO>(Istudii.Page, Istudii.PageSize, Istudii.TotalCount, new List<StudiiDTO>());
        foreach (var studii in Istudii.Data)
        {
            var aux = await _repository.GetAsync(new StudiiProjectionSpec(studii.IdStudii), cancellationToken);
            if (aux != null)
            {
                result.Data.Add(aux);
            }
        }
        return ServiceResponse.ForSuccess(result);
    }

    public async Task<ServiceResponse> AddCorToSolicitant(Guid id, CorDTO cor, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Solicitant)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can update !", ErrorCodes.CannotUpdate));
        }

        var entity = await _repository.GetAsync(new SolicitantiSpec(id), cancellationToken);
        var meserie = await _repository.GetAsync(new CorSpec(cor.CodCor), cancellationToken);
        if (entity != null && meserie != null )
        {
            await _repository.UpdateAsync(entity, cancellationToken);
            await _repository.UpdateAsync(meserie, cancellationToken);

            var meserie_in_solicitant = await _repository.GetAsync(new CnpCalificariSpec(id, id, meserie.Id), cancellationToken);
            if (meserie_in_solicitant != null)
            {
                 await _repository.UpdateAsync(meserie_in_solicitant, cancellationToken);
            }
            else
            {
                await _repository.AddAsync(new CnpCalificari
                {
                    IdSolicitant = id,
                    IdCor = meserie.Id,
                    CnpSolicitant=entity.CnpSolicitant,
                    UserId=meserie.UserId

                }, cancellationToken);
            }
        }

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> RemoveCorFromSolicitant(Guid id, CorDTO cor, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Solicitant)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can update !", ErrorCodes.CannotUpdate));
        }
        var entity = await _repository.GetAsync(new SolicitantiSpec(id), cancellationToken);
        var meserie = await _repository.GetAsync(new CorSpec(cor.CodCor), cancellationToken);
        if (entity != null && meserie != null )
        {
            await _repository.UpdateAsync(entity, cancellationToken);
            await _repository.UpdateAsync(meserie, cancellationToken);

            var meserie_in_solicitant = await _repository.GetAsync(new CnpCalificariSpec(id, id, meserie.Id), cancellationToken);
            if (meserie_in_solicitant != null)
            {
                     await _repository.DeleteAsync<CnpCalificari>(meserie_in_solicitant.Id, cancellationToken);
            }
        }
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> AddStudiiToSolicitant(Guid id, StudiiDTO studii, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Solicitant)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can update !", ErrorCodes.CannotUpdate));
        }

        var entity = await _repository.GetAsync(new SolicitantiSpec(id), cancellationToken);
        var stud = await _repository.GetAsync(new StudiiSpec(studii.DenStudii), cancellationToken);
        if (entity != null && stud != null)
        {
            await _repository.UpdateAsync(entity, cancellationToken);
            await _repository.UpdateAsync(stud, cancellationToken);

            var studii_in_solicitant = await _repository.GetAsync(new CnpStudiiSpec(id, id, stud.Id), cancellationToken);
            if (studii_in_solicitant != null)
            {
                await _repository.UpdateAsync(studii_in_solicitant, cancellationToken);
            }
            else
            {
                await _repository.AddAsync(new CnpStudii
                {
                    IdSolicitant = id,
                    IdStudii = stud.Id,
                    CnpSolicitant = entity.CnpSolicitant,
                    UserId = stud.UserId
                }, cancellationToken);
            }
        }
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> RemoveStudiiFromSolicitant(Guid id, StudiiDTO studii, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Solicitant)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can update !", ErrorCodes.CannotUpdate));
        }
        var entity = await _repository.GetAsync(new SolicitantiSpec(id), cancellationToken);
        var stud = await _repository.GetAsync(new StudiiSpec(studii.DenStudii), cancellationToken);
        if (entity != null && stud != null)
        {
            await _repository.UpdateAsync(entity, cancellationToken);
            await _repository.UpdateAsync(stud, cancellationToken);

            var studii_in_solicitant = await _repository.GetAsync(new CnpStudiiSpec(id, id, stud.Id), cancellationToken);
            if (studii_in_solicitant != null)
            {
                await _repository.DeleteAsync<CnpStudii>(studii_in_solicitant.Id, cancellationToken);
            }
        }
        return ServiceResponse.ForSuccess();
    }
    public async Task<ServiceResponse> AddSolicitant(SolicitantiAddDTO solicitant, UserDTO requestingUser, CancellationToken cancellationToken = default)
    {
        
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Solicitant && requestingUser.Role != UserRoleEnum.Admin) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Solocitant can add in Solicitanti!", ErrorCodes.CannotAdd));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can add null in Solicitanti!", ErrorCodes.CannotAdd));
        }

        var result = await _repository.GetAsync(new SolicitantiSpec(solicitant.CnpSolicitant), cancellationToken);

        if (result != null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "The Solicitant already exists!", ErrorCodes.UserAlreadyExists));
        }

        await _repository.AddAsync(new Solicitanti
        {
               DataInregistare = solicitant.DataInregistare,
               CnpSolicitant = solicitant.CnpSolicitant,
               Nume = solicitant.Nume,
               Prenume = solicitant.Prenume,
               Adresa = solicitant.Adresa,
               UserId = requestingUser.Id
        }, cancellationToken); // A new entity is created and persisted in the database.

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateSolicitant(SolicitantiUpdateDTO solicitant, UserDTO requestingUser, CancellationToken cancellationToken = default)
    {
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can add in Solicitanti!", ErrorCodes.CannotAdd));
        }
        if (requestingUser.Role != UserRoleEnum.Admin && requestingUser.Role != UserRoleEnum.Solicitant) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant and admin update the Solicitanti!", ErrorCodes.CannotUpdate));
        }

        var entity = await _repository.GetAsync(new SolicitantiSpec(solicitant.Id), cancellationToken); 

        if (entity != null) // Verify if the user is not found, you cannot update an non-existing entity.
        {
            entity.Nume = solicitant.Nume ?? entity.Nume;
            entity.Prenume = solicitant.Prenume ?? entity.Prenume;
            entity.Adresa = solicitant.Adresa ?? entity.Adresa;

            await _repository.UpdateAsync(entity, cancellationToken); // Update the entity and persist the changes.
        }

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteSolicitant(Guid id, UserDTO requestingUser, CancellationToken cancellationToken = default)
    {
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Solicitant can delete !", ErrorCodes.CannotDelete));

        }
        if (requestingUser.Role == UserRoleEnum.Personnel) 
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can delete the item!", ErrorCodes.CannotDelete));
        }
        if (requestingUser.Role == UserRoleEnum.Solicitant || requestingUser.Role == UserRoleEnum.Admin)
        {
            var entity = await _repository.GetAsync(new SolicitantiSpec(id), cancellationToken);
            if (entity != null && entity.UserId != requestingUser.Id)
            {
                return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Producer can delete the item!", ErrorCodes.CannotDelete));
            }
        }
        await _repository.DeleteAsync<Solicitanti>(id, cancellationToken); // Delete the entity.
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse<int>> GetSolicitantiCount(CancellationToken cancellationToken = default) =>
        ServiceResponse.ForSuccess(await _repository.GetCountAsync<User>(cancellationToken)); // Get the count of all user entities in the database.
}
