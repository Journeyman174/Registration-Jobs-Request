using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface ICnpStudiiService
{
    /// <summary>
    /// get entity by its id
    /// </summary>
    public Task<ServiceResponse<CnpStudiiDTO>> GetCnpStudii(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// get entity list from their users id
    /// </summary>
    public Task<ServiceResponse<PagedResponse<CnpStudiiDTO>>> GetUserCnpStudii(Guid id, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    /// <summary>
    /// Creates factura from cart
    /// </summary>
    public Task<ServiceResponse> CreateCnpStudii(Guid IdSolicitant,Guid IdStudii,UserDTO requestingUser, CancellationToken cancellationToken = default);
    /// <summary>
    /// cancels order
    /// </summary>
    public Task<ServiceResponse> CancelCnpStudii(Guid id, UserDTO requestingUser, CancellationToken cancellationToken = default);
 

}
