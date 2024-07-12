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

public class StudiiService : IStudiiService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;

    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    public StudiiService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<StudiiDTO>> GetStudii(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new StudiiProjectionSpec(id), cancellationToken); // Get a user using a specification on the repository.

        return (ServiceResponse<StudiiDTO>)(result != null ?
            ServiceResponse.ForSuccess(result) :
            ServiceResponse.FromError(CommonErrors.StudiiNotFound)); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<StudiiDTO>>> GetStudiile(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination, new StudiiProjectionSpec(pagination.Search), cancellationToken); // Use the specification and pagination API to get only some entities from the database.

        return ServiceResponse.ForSuccess(result);
    }

    
    public async Task<ServiceResponse> AddStudii(StudiiAddDTO studii, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add Studii!", ErrorCodes.CannotAdd));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add Studii!", ErrorCodes.CannotAdd));
        }
        
        await _repository.AddAsync(new Studii
        {
            DenStudii = studii.DenStudii,
            UserId = requestingUser.Id
        }, cancellationToken); // A new entity is created and persisted in the database.

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateStudii(StudiiUpdateDTO studii, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add Studii!", ErrorCodes.CannotUpdate));
        }

        var entity = await _repository.GetAsync(new StudiiSpec(studii.Id), cancellationToken); 

        if (entity != null) // Verify if the user is not found, you cannot update an non-existing entity.
        {
            entity.DenStudii = studii.DenStudii ?? entity.DenStudii;
            
            await _repository.UpdateAsync(entity, cancellationToken); // Update the entity and persist the changes.
        }

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteStudii(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Admin) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can add Studii!", ErrorCodes.CannotDelete));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Client can delete the address!", ErrorCodes.CannotDelete));
        }
        var entity = await _repository.GetAsync(new StudiiSpec(id), cancellationToken);
        if (entity !=null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can delete Studii!", ErrorCodes.CannotDelete));
        }
        await _repository.DeleteAsync<Studii>(id, cancellationToken); // Delete the entity.

        return ServiceResponse.ForSuccess();
    }


}
