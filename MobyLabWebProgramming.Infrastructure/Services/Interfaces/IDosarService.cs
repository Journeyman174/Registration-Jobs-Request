using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IDosarService
{
    /// <summary>
    /// get entity by its id
    /// </summary>
    public Task<ServiceResponse<DosarDTO>> GetDosar(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// get entity list from their solicitanti id
    /// </summary>
    public Task<ServiceResponse<PagedResponse<DosarDTO>>> GetUserDosar(Guid id, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    /// <summary>
    /// Creates dosar from solicitanti
    /// </summary>
    public Task<ServiceResponse> AddDosar(Guid Id, DosarAddDTO dosar, UserDTO requestingUser, CancellationToken cancellationToken = default);
    /// <summary>
    /// delete dosar
    /// </summary>
    public Task<ServiceResponse> DeleteDosar(Guid id, UserDTO requestingUser, CancellationToken cancellationToken = default);
    /// <summary>
    /// update
    /// </summary>
    public Task<ServiceResponse> UpdateDosar(DosarUpdateDTO upd, UserDTO requestingUser, CancellationToken cancellationToken = default);

}
