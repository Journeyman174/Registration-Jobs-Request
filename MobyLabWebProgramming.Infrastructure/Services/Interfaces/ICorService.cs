using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface ICorService
{
    /// <summary>
    /// GetAddress will provide the information about an Address given its user Id.
    /// </summary>
    public Task<ServiceResponse<CorDTO>> GetCor(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// GetCor returns page with Studii information from the database.
    /// </summary>
    public Task<ServiceResponse<PagedResponse<CorDTO>>> GetCoruri(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// AddStudii adds an studii and verifies if requesting user has permissions to add one.
    /// If the requesting addr is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> AddCor(CorAddDTO cor, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    /// <summary>
    /// UpdateStudii updates an studii and verifies if requesting user has permissions to update
    /// If the requesting studii is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> UpdateCor(CorUpdateDTO cor, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    /// <summary>
    /// DeleteStudii deletes an addr and verifies if requesting user has permissions to delete it, if the addr is his own then that should be allowed.
    /// If the requesting studii is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> DeleteCor(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
}
