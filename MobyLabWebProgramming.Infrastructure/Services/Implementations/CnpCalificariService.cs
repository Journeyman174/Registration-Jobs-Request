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

public class CnpCalificariService : ICnpCalificariService
{
    private readonly IRepository<WebAppDatabaseContext> _repository;

    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    public CnpCalificariService(IRepository<WebAppDatabaseContext> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<CnpCalificariDTO>> GetCnpCalificari(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _repository.GetAsync(new CnpCalificariProjectionSpec(id), cancellationToken); 

        return (ServiceResponse<CnpCalificariDTO>)(result != null ?
            ServiceResponse.ForSuccess(result) :
            ServiceResponse.FromError(CommonErrors.CnpCalificariNotFound)); // Pack the result or error into a ServiceResponse.
    }

    public async Task<ServiceResponse<PagedResponse<CnpCalificariDTO>>> GetUserCnpCalificari(Guid id, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await _repository.PageAsync(pagination, new CnpCalificariProjectionSpec(id,id), cancellationToken);

        return ServiceResponse.ForSuccess(result);
    }

    public async Task<ServiceResponse> CreateCnpCalificari(Guid IdSolicitant,Guid IdCor, UserDTO requestingUser, CancellationToken cancellationToken = default)
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
        var cor = _repository.GetAsync(new CorSpec(IdCor), cancellationToken).Result;
        if (cor == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "Cor nu exista!", ErrorCodes.CannotAdd));
        }
        await _repository.AddAsync(new CnpCalificari
        {
            IdSolicitant = sol.Id,
            CnpSolicitant = sol.CnpSolicitant,
            IdCor = cor.Id,
            UserId = requestingUser.Id
        }, cancellationToken); // A new entity is created and persisted in the database.
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> CancelCnpCalificari(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default)
    {
        if (requestingUser != null && requestingUser.Role != UserRoleEnum.Solicitant) // Verify who can add the user, you can change this however you se fit.
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the admin can sterge!", ErrorCodes.CannotDelete));
        }
        if (requestingUser == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Solicitant can delete!", ErrorCodes.CannotDelete));
        }
        var entity = await _repository.GetAsync(new CnpCalificariSpec(id), cancellationToken);
        if (entity != null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only the Solicitant can delete !", ErrorCodes.CannotDelete));
        }
        await _repository.DeleteAsync<CnpCalificari>(id, cancellationToken); // Delete the entity.

        return ServiceResponse.ForSuccess();
    }

}
