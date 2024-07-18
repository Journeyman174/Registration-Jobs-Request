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

public class CnpStudiiService : ICnpStudiiService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;

    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    public CnpStudiiService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<CnpStudiiDTO>> GetCnpStudii(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new CnpStudiiProjectionSpec(id), cancellationToken); 

        return (ServiceResponse<CnpStudiiDTO>)(result != null ?
            ServiceResponse.ForSuccess(result) :
            ServiceResponse.FromError(CommonErrors.CnpStudiiNotFound)); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<CnpStudiiDTO>>> GetUserCnpStudii(Guid id, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination, new CnpStudiiProjectionSpec(id,id), cancellationToken);

        return ServiceResponse.ForSuccess(result);
    }

    public async Task<ServiceResponse> CreateCnpStudii(Guid IdSolicitant,Guid IdStudii, UserDTO requestingUser, CancellationToken cancellationToken = default)
    {
        
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Solicitant) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can invoice!", ErrorCodes.CannotAdd));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the solicitant can create invoice!", ErrorCodes.CannotAdd));
        }

        var sol = _repository.GetAsync(new SolicitantiSpec(IdSolicitant),cancellationToken).Result;
        if (sol == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "Solicitant nu exista!", ErrorCodes.CannotAdd));
        }
        var Studii = _repository.GetAsync(new StudiiSpec(IdStudii), cancellationToken).Result;
        if (Studii == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "Studii nu exista!", ErrorCodes.CannotAdd));
        }
        await _repository.AddAsync(new CnpStudii
        {
            IdSolicitant = sol.Id,
            CnpSolicitant = sol.CnpSolicitant,
            IdStudii = Studii.Id,
            UserId = requestingUser.Id
        }, cancellationToken); // A new entity is created and persisted in the database.
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> CancelCnpStudii(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Solicitant) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can sterge!", ErrorCodes.CannotDelete));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Solicitant can delete!", ErrorCodes.CannotDelete));
        }
        var entity = await _repository.GetAsync(new CnpStudiiSpec(id), cancellationToken);
        if (entity != null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Solicitant can delete !", ErrorCodes.CannotDelete));
        }
        await _repository.DeleteAsync<CnpStudii>(id, cancellationToken); // Delete the entity.

        return ServiceResponse.ForSuccess();
    }

}
