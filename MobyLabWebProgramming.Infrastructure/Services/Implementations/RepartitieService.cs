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

public class RepartitieService : IRepartitieService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;

    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    public RepartitieService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<RepartitiiDTO>> GetRepartitie(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new RepartitieProjectionSpec(id), cancellationToken); // Get a user using a specification on the repository.

        return (ServiceResponse<RepartitiiDTO>)(result != null ?
            ServiceResponse.ForSuccess(result) :
            ServiceResponse.FromError(CommonErrors.RepartitieNotFound)); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<RepartitiiDTO>>> GetRepartitii(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination, new RepartitieProjectionSpec(pagination.Search), cancellationToken); // Use the specification and pagination API to get only some entities from the database.

        return ServiceResponse.ForSuccess(result);
    }

    
    public async Task<ServiceResponse> AddRepartitie(RepartitiiAddDTO repartitie, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Client) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the client can add Repartitie!", ErrorCodes.CannotAdd));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the client can add Addreses to self!", ErrorCodes.CannotAdd));
        }
        
        await _repository.AddAsync(new Repartitie
        {
            CNP = repartitie.CNP,
            DataRepartitie=repartitie.DataRepartitie,
            IdOlm=repartitie.IdOlm,
            Rezultat=repartitie.Rezultat,
            UserId = requestingUser.Id
        }, cancellationToken); // A new entity is created and persisted in the database.

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateRepartitie(RepartitiiUpdateDTO repartitie, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Client )// Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Client update the address!", ErrorCodes.CannotUpdate));
        }

        var entity = await _repository.GetAsync(new RepartitieSpec(repartitie.Id), cancellationToken); 

        if (entity != null) // Verify if the user is not found, you cannot update an non-existing entity.
        {
            entity.CNP = repartitie.CNP ?? entity.CNP;
            entity.DataRepartitie = repartitie.DataRepartitie;
            entity.IdOlm = repartitie.IdOlm;
            entity.Rezultat = repartitie.Rezultat ?? entity.Rezultat;
            
            await _repository.UpdateAsync(entity, cancellationToken); // Update the entity and persist the changes.
        }

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteRepartitie(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Client && requestingUser.Role !=UserRoleEnum.Admin) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Client can delete repartitie!", ErrorCodes.CannotDelete));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Client can delete repartitie!", ErrorCodes.CannotDelete));
        }
        var entity = await _repository.GetAsync(new RepartitieSpec(id), cancellationToken);
        if (entity !=null && entity.UserId != requestingUser.Id)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Client can delete Repartitie!", ErrorCodes.CannotDelete));
        }
        await _repository.DeleteAsync<Repartitie>(id, cancellationToken); // Delete the entity.

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse<PagedResponse<RepartitiiDTO>>> GetRepartitieFromUser(PaginationSearchQueryParams pagination, Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination,new RepartitieProjectionSpec(id,id), cancellationToken); // Get a user using a specification on the repository.

        return ServiceResponse.ForSuccess(result);
    }
}
