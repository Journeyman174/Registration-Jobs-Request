using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Extensions;
using MobyLabWebProgramming.Infrastructure.Services.Implementations;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Backend.Controllers;

/// <summary>
/// This is a controller example for CRUD operations on users.
/// </summary>
[ApiController] // This attribute specifies for the framework to add functionality to the controller such as binding multipart/form-data.
[Route("api/[controller]/[action]")] // The Route attribute prefixes the routes/url paths with template provides as a string, the keywords between [] are used to automatically take the controller and method name.
public class CnpStudiiController : AuthorizedController // Here we use the AuthorizedController as the base class because it derives ControllerBase and also has useful methods to retrieve user information.
{
    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    /// 
    protected readonly ICnpStudiiService _cnpStudiiService;
    public CnpStudiiController(IUserService userService, ICnpStudiiService cnpStudiiService) : base(userService) // Also, you may pass constructor parameters to a base class constructor and call as specific constructor from the base class.
    {
        _cnpStudiiService = cnpStudiiService;
    }

    /// <summary>
    /// This method implements the Read operation (R from CRUD) on a user. 
    /// </summary>
    [Authorize] // You need to use this attribute to protect the route access, it will return a Forbidden status code if the JWT is not present or invalid, and also it will decode the JWT token.
    [HttpGet("{id:guid}")] // This attribute will make the controller respond to a HTTP GET request on the route /api/User/GetById/<some_guid>.
    public async Task<ActionResult<RequestResponse<CnpStudiiDTO>>> GetById([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
    {
        var currentUser = await GetCurrentUser();

        return currentUser.Result != null ? 
            this.FromServiceResponse(await _cnpStudiiService.GetCnpStudii(id)) : 
            this.ErrorMessageResult<CnpStudiiDTO>(currentUser.Error);
    }

    /// <summary>
    /// This method implements the Read operation (R from CRUD) on page of users.
    /// Generally, if you need to get multiple values from the database use pagination if there are many entries.
    /// It will improve performance and reduce resource consumption for both client and server.
    /// </summary>
    [Authorize]
    [HttpGet] // This attribute will make the controller respond to a HTTP GET request on the route /api/User/GetPage.
    public async Task<ActionResult<RequestResponse<PagedResponse<CnpStudiiDTO>>>> GetFromUserId([FromQuery] PaginationSearchQueryParams pagination)                                                                                                                // the PaginationSearchQueryParams properties to the object in the method parameter.
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null ?
            this.FromServiceResponse(await _cnpStudiiService.GetUserCnpStudii(currentUser.Result.Id,pagination)) :
            this.ErrorMessageResult<PagedResponse<CnpStudiiDTO>>(currentUser.Error);
    }

    /// <summary>
    /// This method implements the Create operation (C from CRUD) of a user. 
    /// </summary>
    [Authorize]
    [HttpPost] // This attribute will make the controller respond to a HTTP POST request on the route /api/User/Add.
    public async Task<ActionResult<RequestResponse>> Create([FromBody] CnpStudiiAddDTO aux)
    {
        var currentUser = await GetCurrentUser();
       

        return currentUser.Result != null ?
            this.FromServiceResponse(await _cnpStudiiService.CreateCnpStudii(aux.IdSolicitant,aux.IdStudii,currentUser.Result)) :
            this.ErrorMessageResult(currentUser.Error);
    }



    /// <summary>
    /// This method implements the Delete operation (D from CRUD) on a user.
    /// Note that in the HTTP RFC you cannot have a body for DELETE operations.
    /// </summary>
    [Authorize]
    [HttpDelete("{id:guid}")] // This attribute will make the controller respond to a HTTP DELETE request on the route /api/User/Delete/<some_guid>.
    public async Task<ActionResult<RequestResponse>> Cancel([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
    {
        var currentUser = await GetCurrentUser();

        return currentUser.Result != null ?
            this.FromServiceResponse(await _cnpStudiiService.CancelCnpStudii(id, currentUser.Result)) :
            this.ErrorMessageResult(currentUser.Error);
    }
}
