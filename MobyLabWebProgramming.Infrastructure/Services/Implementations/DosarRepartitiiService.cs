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

public class DosarRepartitiiService : IDosarRepartitiiService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;

    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    public DosarRepartitiiService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<DosarRepartitiiDTO>> GetDosarRepartitii(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new DosarRepartitiiProjectionSpec(id), cancellationToken); 
       return (ServiceResponse<DosarRepartitiiDTO>)(result != null ?
           ServiceResponse.ForSuccess(result) :
            ServiceResponse.FromError(CommonErrors.DosarRepartitiiNotFound)); // Pack the result or error into a ServiceResponse.

    }

    public async Task<ServiceResponse<PagedResponse<DosarRepartitiiDTO>>> GetUserDosarRepartitii(Guid id, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination, new DosarRepartitiiProjectionSpec(id,id), cancellationToken);

        return ServiceResponse.ForSuccess(result);
    }

    public async Task<ServiceResponse> CreateDosarRepartitii(Guid IdDosar,Guid IdRepartitie, UserDTO requestingUser, CancellationToken cancellationToken = default)
    {
        
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Solicitant) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can invoice!", ErrorCodes.CannotAdd));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can create invoice!", ErrorCodes.CannotAdd));
        }

        var dos = _repository.GetAsync(new DosarSpec(IdDosar),cancellationToken).Result;
        if (dos == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "Solicitant nu exista!", ErrorCodes.CannotAdd));
        }
        var rep = _repository.GetAsync(new RepartitieSpec(IdRepartitie), cancellationToken).Result;
        if (rep == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "Cor nu exista!", ErrorCodes.CannotAdd));
        }
        await _repository.AddAsync(new DosarRepartitii
        {
            IdDosar = dos.Id,
            IdRepartitie = rep.Id,
            UserId = requestingUser.Id
        }, cancellationToken); // A new entity is created and persisted in the database.
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> CancelDosarRepartitii(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Solicitant) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can sterge!", ErrorCodes.CannotDelete));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Solicitant can delete!", ErrorCodes.CannotDelete));
        }
        var entity = await _repository.GetAsync(new DosarRepartitiiSpec(id), cancellationToken);
        if (entity != null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Solicitant can delete !", ErrorCodes.CannotDelete));
        }
        await _repository.DeleteAsync<DosarRepartitii>(id, cancellationToken); // Delete the entity.

        return ServiceResponse.ForSuccess();
    }

}
