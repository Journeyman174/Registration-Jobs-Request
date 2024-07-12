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

public class CorService : ICorService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;

    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    public CorService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<CorDTO>> GetCor(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new CorProjectionSpec(id), cancellationToken); // Get a user using a specification on the repository.

        return (ServiceResponse<CorDTO>)(result != null ?
            ServiceResponse.ForSuccess(result) :
            ServiceResponse.FromError(CommonErrors.CorNotFound)); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<CorDTO>>> GetCoruri(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination, new CorProjectionSpec(pagination.Search), cancellationToken); // Use the specification and pagination API to get only some entities from the database.

        return ServiceResponse.ForSuccess(result);
    }

    
    public async Task<ServiceResponse> AddCor(CorAddDTO cor, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add Cor!", ErrorCodes.CannotAdd));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add Cor!", ErrorCodes.CannotAdd));
        }
        
        await _repository.AddAsync(new Cor
        {
            CodCor = cor.CodCor,
            Meserie = cor.Meserie,
            UserId = requestingUser.Id
        }, cancellationToken); // A new entity is created and persisted in the database.

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateCor(CorUpdateDTO cor, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add Cor!", ErrorCodes.CannotUpdate));
        }

        var entity = await _repository.GetAsync(new CorSpec(cor.Id), cancellationToken); 

        if (entity != null) // Verify if the user is not found, you cannot update an non-existing entity.
        {
            entity.CodCor = cor.CodCor ?? entity.CodCor;
            entity.Meserie = cor.Meserie ?? entity.Meserie;
            
            await _repository.UpdateAsync(entity, cancellationToken); // Update the entity and persist the changes.
        }

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteCor(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin) // Verify who can add user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add Cor!", ErrorCodes.CannotDelete));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Client can delete theCor!", ErrorCodes.CannotDelete));
        }
        var entity = await _repository.GetAsync(new StudiiSpec(id), cancellationToken);
        if (entity !=null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can delete Cor!", ErrorCodes.CannotDelete));
        }
        await _repository.DeleteAsync<Cor>(id, cancellationToken); // Delete the entity.

        return ServiceResponse.ForSuccess();
    }


}
