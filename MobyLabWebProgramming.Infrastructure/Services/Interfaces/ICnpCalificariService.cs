using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface ICnpCalificariService
{
    /// <summary>
    /// get entity by its id
    /// </summary>
    public Task<ServiceResponse<CnpCalificariDTO>> GetCnpCalificari(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// get entity list from their users id
    /// </summary>
    public Task<ServiceResponse<PagedResponse<CnpCalificariDTO>>> GetUserCnpCalificari(Guid id, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    /// <summary>
    /// Creates factura from cart
    /// </summary>
    public Task<ServiceResponse> CreateCnpCalificari(Guid IdSolicitant,Guid IdCor,UserDTO requestingUser, CancellationToken cancellationToken = default);
    /// <summary>
    /// cancels order
    /// </summary>
    public Task<ServiceResponse> CancelCnpCalificari(Guid id, UserDTO requestingUser, CancellationToken cancellationToken = default);
 

}
