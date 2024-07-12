using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IStudiiService
{
    /// <summary>
    /// GetAddress will provide the information about an Address given its user Id.
    /// </summary>
    public Task<ServiceResponse<StudiiDTO>> GetStudii(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// GetStudii returns page with Studii information from the database.
    /// </summary>
    public Task<ServiceResponse<PagedResponse<StudiiDTO>>> GetStudiile(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// AddCor adds an studii and verifies if requesting user has permissions to add one.
    /// If the requesting addr is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> AddStudii(StudiiAddDTO studii, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    /// <summary>
    /// UpdateCor updates an studii and verifies if requesting user has permissions to update
    /// If the requesting studii is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> UpdateStudii(StudiiUpdateDTO Studii, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
    /// <summary>
    /// DeleteCor deletes an cor and verifies if requesting user has permissions to delete it, if the addr is his own then that should be allowed.
    /// If the requesting studii is null then no verification is performed as it indicates that the application.
    /// </summary>
    public Task<ServiceResponse> DeleteStudii(Guid id, UserDTO? requestingUser = default, CancellationToken cancellationToken = default);
}
