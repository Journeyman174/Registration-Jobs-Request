using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface ISolicitantService
{
    /// <summary>
    /// GetItem will provide the information about an Item given its Id.
    /// </summary>
    public Task<ServiceResponse<SolicitantiDTO>> GetSolicitant(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// GetItems returns page with items information from the database.
    /// </summary>
    public Task<ServiceResponse<PagedResponse<SolicitantiDTO>>> GetSolicitanti(PaginationSearchQueryParams pagination, UserDTO requestingUser, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// AddItem adds an item and verifies if requesting user has permissions to add one.
    /// </summary>
    public Task<ServiceResponse> AddSolicitant(SolicitantiAddDTO solicitant, UserDTO requestingUser, CancellationToken cancellationToken = default);
    /// <summary>
    /// UpdateItem updates an Item and verifies if requesting item has permissions to update
    /// </summary>
    public Task<ServiceResponse> UpdateSolicitant(SolicitantiUpdateDTO solicitant, UserDTO requestingUser, CancellationToken cancellationToken = default);
    /// <summary>
    /// DeleteItem deletes an Item and verifies if requesting user has permissions to delete it, if the item is his own then that should be allowed.
    /// </summary>
    public Task<ServiceResponse> DeleteSolicitant(Guid id, UserDTO requestingUser, CancellationToken cancellationToken = default);

    public Task<ServiceResponse<int>> GetSolicitantiCount(CancellationToken cancellationToken = default);
}
