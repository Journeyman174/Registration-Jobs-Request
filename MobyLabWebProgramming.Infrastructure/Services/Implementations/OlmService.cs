using System.Net;
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

public class OlmService : IOlmService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;

    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    public OlmService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<OlmDTO>> GetOlm(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new OlmProjectionSpec(id), cancellationToken); // Get a user using a specification on the repository.

        return (ServiceResponse<OlmDTO>)(result != null ? 
            ServiceResponse<OlmDTO>.ForSuccess(result) : 
            ServiceResponse<OlmDTO>.FromError(CommonErrors.OlmNotFound)); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<OlmDTO>>> GetOferte(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination, new OlmProjectionSpec(pagination.Search), cancellationToken); // Use the specification and pagination API to get only some entities from the database.

        return ServiceResponse<PagedResponse<OlmDTO>>.ForSuccess(result);
    }

    
    public async Task<ServiceResponse> AddOlm(OlmAddDTO olm, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the client can add Oferte de Locuri de munca!", ErrorCodes.CannotAdd));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the client can add Oferte de Locuri de munca!", ErrorCodes.CannotAdd));
        }
        
        await _repository.AddAsync(new Olm
        {
            DataOlm = olm.DataOlm,
            DataOlmStart = olm.DataOlmStart,
            DataOlmSfarsit = olm.DataOlmSfarsit,
            Agent = olm.Agent,
            CuiFirma = olm.CuiFirma,
            IdCor = olm.IdCor,
            AdresaLocMunca = olm.AdresaLocMunca,
            NrLocMunca= olm.NrLocMunca,
            Stare=olm.Stare,

            UserId = requestingUser.Id
        }, cancellationToken); // A new entity is created and persisted in the database.

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateOlm(OlmUpdateDTO olm, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin ) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Client update Oferte de Locuri de munca!", ErrorCodes.CannotUpdate));
        }

        var entity = await _repository.GetAsync(new OlmSpec(olm.Id), cancellationToken); 

        if (entity != null) // Verify if the user is not found, you cannot update an non-existing entity.
        {
            entity.DataOlm = olm.DataOlm;
            entity.DataOlmSfarsit = olm.DataOlmSfarsit;
            entity.DataOlmStart = olm.DataOlmStart;
            entity.Agent = olm.Agent ?? entity.Agent;
            entity.CuiFirma = olm.CuiFirma ?? entity.CuiFirma;
            entity.AdresaLocMunca = olm.AdresaLocMunca ?? entity.AdresaLocMunca;
            entity.NrLocMunca = olm.NrLocMunca;
             
            await _repository.UpdateAsync(entity, cancellationToken); // Update the entity and persist the changes.
        }

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteOlm(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin ) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Client can delete Oferte de Locuri de munca!", ErrorCodes.CannotDelete));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Client can delete the address!", ErrorCodes.CannotDelete));
        }
        var entity = await _repository.GetAsync(new OlmSpec(id), cancellationToken);
        if (entity !=null && entity.UserId != requestingUser.Id)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Client can delete Oferte de Locuri de munca!", ErrorCodes.CannotDelete));
        }
        await _repository.DeleteAsync<Olm>(id, cancellationToken); // Delete the entity.

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse<PagedResponse<OlmDTO>>> GetOlmFromUser(PaginationSearchQueryParams pagination, Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination,new OlmProjectionSpec(id,id), cancellationToken); // Get a user using a specification on the repository.

        return ServiceResponse<PagedResponse<OlmDTO>>.ForSuccess(result);
    }
}
