using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IDosarRepartitiiService
{
    /// <summary>
    /// get entity by its id
    /// </summary>
    public Task<ServiceResponse<DosarRepartitiiDTO>> GetDosarRepartitii(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// get entity list from their users id
    /// </summary>
    public Task<ServiceResponse<PagedResponse<DosarRepartitiiDTO>>> GetUserDosarRepartitii(Guid id, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    /// <summary>
    /// Creates factura from cart
    /// </summary>
    public Task<ServiceResponse> CreateDosarRepartitii(Guid IdDosar,Guid IdRepartitie,UserDTO requestingUser, CancellationToken cancellationToken = default);
    /// <summary>
    /// cancels order
    /// </summary>
    public Task<ServiceResponse> CancelDosarRepartitii(Guid id, UserDTO requestingUser, CancellationToken cancellationToken = default);
 

}
