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

public class DosarService : IDosarService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;

    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    public DosarService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<DosarDTO>> GetDosar(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new DosarProjectionSpec(id), cancellationToken); 

        return (ServiceResponse<DosarDTO>)(result != null ?
            ServiceResponse.ForSuccess(result) :
            ServiceResponse.FromError(CommonErrors.DosarNotFound)); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<DosarDTO>>> GetUserDosar(Guid id, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination, new DosarProjectionSpec(id,id), cancellationToken);

        return ServiceResponse.ForSuccess(result);
    }

    public async Task<ServiceResponse> AddDosar(Guid Id, DosarAddDTO dosar, UserDTO requestingUser, CancellationToken cancellationToken = default)
    {
        
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Solicitant) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can add!", ErrorCodes.CannotAdd));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can create dosar!", ErrorCodes.CannotAdd));
        }

        var solicitant = _repository.GetAsync(new SolicitantiSpec(Id),cancellationToken).Result;

        if (solicitant == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "The Solicitant not exist!", ErrorCodes.CannotAdd));
        }
 
        await _repository.AddAsync(new Dosar
        {
            IdSolicitant =solicitant.Id,
            DataDosar = dosar.DataDosar,
            CnpSolicitant=dosar.CnpSolicitant,
            DeLa=dosar.DeLa,
            PanaLa=dosar.PanaLa,
            Stare=dosar.Stare,
            UserId = requestingUser.Id
        }, cancellationToken); // A new entity is created and persisted in the database.
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteDosar(Guid id, UserDTO requestingUser, CancellationToken cancellationToken = default)
    {
        if(requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Solicitant can delete dosar!", ErrorCodes.CannotDelete));

        }
        if (requestingUser.Role != UserRoleEnum.Solicitant) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Solicitant can delete dosar!", ErrorCodes.CannotDelete));
        }
        await _repository.DeleteAsync<Dosar>(id, cancellationToken); // Delete the entity.
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateDosar(DosarUpdateDTO dosar, UserDTO requestingUser, CancellationToken cancellationToken = default)
    {
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Solicitant can update dosar!", ErrorCodes.CannotAdd));
        }
        if (requestingUser.Role != UserRoleEnum.Solicitant) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can update orders!", ErrorCodes.CannotUpdate));
        }

        var entity = await _repository.GetAsync(new DosarSpec(dosar.Id), cancellationToken);

        if (entity != null) // Verify if the user is not found, you cannot update an non-existing entity.
        {

            entity.DataDosar = dosar.DataDosar;
            entity.DeLa = dosar.DeLa;
            entity.PanaLa = dosar.PanaLa;

            await _repository.UpdateAsync(entity, cancellationToken); // Update the entity and persist the changes.
        }

        return ServiceResponse.ForSuccess();
    }

}
