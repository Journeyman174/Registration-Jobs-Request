﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Extensions;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Backend.Controllers;

/// <summary>
/// This is a controller example for CRUD operations on users.
/// </summary>
[ApiController] // This attribute specifies for the framework to add functionality to the controller such as binding multipart/form-data.
[Route("api/[controller]/[action]")] // The Route attribute prefixes the routes/url paths with template provides as a string, the keywords between [] are used to automatically take the controller and method name.
public class SolicitantiController : AuthorizedController // Here we use the AuthorizedController as the base class because it derives ControllerBase and also has useful methods to retrieve user information.
{
    /// <summary>
    /// Inject the required services through the constructor.
    /// </summary>
    /// 
    protected readonly ISolicitantService _solicitantService;
    public SolicitantiController(IUserService userService, ISolicitantService solicitantService) : base(userService) // Also, you may pass constructor parameters to a base class constructor and call as specific constructor from the base class.
    {
        _solicitantService = solicitantService;
    }

    /// <summary>
    /// This method implements the Read operation (R from CRUD) on a user. 
    /// </summary>
    [Authorize] // You need to use this attribute to protect the route access, it will return a Forbidden status code if the JWT is not present or invalid, and also it will decode the JWT token.
    [HttpGet("{id:guid}")] // This attribute will make the controller respond to a HTTP GET request on the route /api/User/GetById/<some_guid>.
    public async Task<ActionResult<RequestResponse<SolicitantiDTO>>> GetById([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
    {
        var currentUser = await GetCurrentUser();

        return currentUser.Result != null ? 
            this.FromServiceResponse(await _solicitantService.GetSolicitant(id)) : 
            this.ErrorMessageResult<SolicitantiDTO>(currentUser.Error);
    }
    /// <summary>
    /// This method implements the Read operation (R from CRUD) on page of users.
    /// Generally, if you need to get multiple values from the database use pagination if there are many entries.
    /// It will improve performance and reduce resource consumption for both client and server.
    /// </summary>
    [Authorize]
    [HttpGet] // This attribute will make the controller respond to a HTTP GET request on the route /api/User/GetPage.
    public async Task<ActionResult<RequestResponse<PagedResponse<SolicitantiDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination) // The FromQuery attribute will bind the parameters matching the names of
                                                                                                                                                // the PaginationSearchQueryParams properties to the object in the method parameter.
    {
        var currentUser = await GetCurrentUser();

        return currentUser.Result != null ?
            this.FromServiceResponse(await _solicitantService.GetSolicitanti(pagination, currentUser.Result)) :
            this.ErrorMessageResult<PagedResponse<SolicitantiDTO>>(currentUser.Error);
    }

    /// <summary>
    /// This method implements the Read operation (R from CRUD) on a user. 
    /// </summary>
    [Authorize] // You need to use this attribute to protect the route access, it will return a Forbidden status code if the JWT is not present or invalid, and also it will decode the JWT token.
    [HttpGet("{id:guid}")] // This attribute will make the controller respond to a HTTP GET request on the route /api/User/GetById/<some_guid>.
    public async Task<ActionResult<RequestResponse<SolicitantiDTO>>> GetByUserId([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
    {
        var currentUser = await GetCurrentUser();

        return currentUser.Result != null ?
            this.FromServiceResponse(await _solicitantService.GetUserSolicitant(currentUser.Result)) :
            this.ErrorMessageResult<SolicitantiDTO>(currentUser.Error);
    }


    /// <summary>
    /// This method implements the Read operation (R from CRUD) on page of users.
    /// Generally, if you need to get multiple values from the database use pagination if there are many entries.
    /// It will improve performance and reduce resource consumption for both client and server.
    /// </summary>
    [Authorize]
    [HttpGet] // This attribute will make the controller respond to a HTTP GET request on the route /api/User/GetPage.
    public async Task<ActionResult<RequestResponse<PagedResponse<CorDTO>>>> GetPageCor([FromQuery] PaginationSearchQueryParams pagination)                                                                                                                // the PaginationSearchQueryParams properties to the object in the method parameter.
    {
        var currentUser = await GetCurrentUser();
        if (currentUser.Result == null)
        {
            return this.ErrorMessageResult<PagedResponse<CorDTO>>(currentUser.Error);
        }
        var solicitant = await _solicitantService.GetUserSolicitant(currentUser.Result);
        return solicitant.Result!= null ?
            this.FromServiceResponse(await _solicitantService.GetCors(solicitant.Result.Id, pagination)) :
            this.ErrorMessageResult<PagedResponse<CorDTO>>(solicitant.Error);
    }
    [Authorize]
    [HttpGet] // This attribute will make the controller respond to a HTTP GET request on the route /api/User/GetPage.
    public async Task<ActionResult<RequestResponse<PagedResponse<StudiiDTO>>>> GetPageStudii([FromQuery] PaginationSearchQueryParams pagination)                                                                                                                // the PaginationSearchQueryParams properties to the object in the method parameter.
    {
        var currentUser = await GetCurrentUser();
        if (currentUser.Result == null)
        {
            return this.ErrorMessageResult<PagedResponse<StudiiDTO>>(currentUser.Error);
        }
        var solicitant = await _solicitantService.GetUserSolicitant(currentUser.Result);
        return solicitant.Result != null ?
            this.FromServiceResponse(await _solicitantService.GetStudiis(solicitant.Result.Id, pagination)) :
            this.ErrorMessageResult<PagedResponse<StudiiDTO>>(solicitant.Error);
    }

    /// <summary>
    /// This method implements the Create operation (C from CRUD) of a user. 
    /// </summary>
    [Authorize]
    [HttpPost] // This attribute will make the controller respond to a HTTP POST request on the route /api/User/Add.
    public async Task<ActionResult<RequestResponse>> Add([FromBody] SolicitantiAddDTO solicitant)
    {
        var currentUser = await GetCurrentUser();
       

        return currentUser.Result != null ?
            this.FromServiceResponse(await _solicitantService.AddSolicitant(solicitant, currentUser.Result)) :
            this.ErrorMessageResult(currentUser.Error);
    }
    /// <summary>
    /// This method implements the Update operation (U from CRUD) on a user. 
    /// </summary>
    [Authorize]
    [HttpPut] // This attribute will make the controller respond to a HTTP PUT request on the route /api/User/Update.
    public async Task<ActionResult<RequestResponse>> AddCorToSolicitant([FromBody] CorDTO meserie) // The FromBody attribute indicates that the parameter is deserialized from the JSON body.
    {
        var currentUser = await GetCurrentUser();
        if (currentUser.Result == null)
        {
            return this.ErrorMessageResult(currentUser.Error);
        }
        var sol = await _solicitantService.GetUserSolicitant(currentUser.Result);
        return sol.Result != null ?
            this.FromServiceResponse(await _solicitantService.AddCorToSolicitant(sol.Result.Id, meserie, currentUser.Result)) :
            this.ErrorMessageResult(sol.Error);
    }

    /// <summary>
    /// This method implements the Update operation (U from CRUD) on a user. 
    /// </summary>
    [Authorize]
    [HttpPut] // This attribute will make the controller respond to a HTTP PUT request on the route /api/User/Update.
    public async Task<ActionResult<RequestResponse>> RemoveCorFromSolicitant([FromBody] CorDTO meserie) // The FromBody attribute indicates that the parameter is deserialized from the JSON body.
    {
        var currentUser = await GetCurrentUser();
        if (currentUser.Result == null)
        {
            return this.ErrorMessageResult(currentUser.Error);
        }
        var sol = await _solicitantService.GetUserSolicitant(currentUser.Result);
        return sol.Result != null ?
            this.FromServiceResponse(await _solicitantService.RemoveCorFromSolicitant(sol.Result.Id, meserie, currentUser.Result)) :
            this.ErrorMessageResult(sol.Error);
    }
    [Authorize]
    [HttpPut] // This attribute will make the controller respond to a HTTP PUT request on the route /api/User/Update.
    public async Task<ActionResult<RequestResponse>> AddStudiiToSolicitant([FromBody] StudiiDTO studii) // The FromBody attribute indicates that the parameter is deserialized from the JSON body.
    {
        var currentUser = await GetCurrentUser();
        if (currentUser.Result == null)
        {
            return this.ErrorMessageResult(currentUser.Error);
        }
        var sol = await _solicitantService.GetUserSolicitant(currentUser.Result);
        return sol.Result != null ?
            this.FromServiceResponse(await _solicitantService.AddStudiiToSolicitant(sol.Result.Id, studii, currentUser.Result)) :
            this.ErrorMessageResult(sol.Error);
    }

    /// <summary>
    /// This method implements the Update operation (U from CRUD) on a user. 
    /// </summary>
    [Authorize]
    [HttpPut] // This attribute will make the controller respond to a HTTP PUT request on the route /api/User/Update.
    public async Task<ActionResult<RequestResponse>> RemoveStudiiFromSolicitant([FromBody] StudiiDTO studii) // The FromBody attribute indicates that the parameter is deserialized from the JSON body.
    {
        var currentUser = await GetCurrentUser();
        if (currentUser.Result == null)
        {
            return this.ErrorMessageResult(currentUser.Error);
        }
        var sol = await _solicitantService.GetUserSolicitant(currentUser.Result);
        return sol.Result != null ?
            this.FromServiceResponse(await _solicitantService.RemoveStudiiFromSolicitant(sol.Result.Id, studii, currentUser.Result)) :
            this.ErrorMessageResult(sol.Error);
    }
    /// <summary>
    /// This method implements the Update operation (U from CRUD) on a user. 
    /// </summary>
    [Authorize]
    [HttpPut] // This attribute will make the controller respond to a HTTP PUT request on the route /api/User/Update.
    public async Task<ActionResult<RequestResponse>> Update([FromBody] SolicitantiUpdateDTO solicitant) // The FromBody attribute indicates that the parameter is deserialized from the JSON body.
    {
        var currentUser = await GetCurrentUser();

        return currentUser.Result != null ?
            this.FromServiceResponse(await _solicitantService.UpdateSolicitant(solicitant, currentUser.Result)) :
            this.ErrorMessageResult(currentUser.Error);
    }

    /// <summary>
    /// This method implements the Delete operation (D from CRUD) on a user.
    /// Note that in the HTTP RFC you cannot have a body for DELETE operations.
    /// </summary>
    [Authorize]
    [HttpDelete("{id:guid}")] // This attribute will make the controller respond to a HTTP DELETE request on the route /api/User/Delete/<some_guid>.
    public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id) // The FromRoute attribute will bind the id from the route to this parameter.
    {
        var currentUser = await GetCurrentUser();

        return currentUser.Result != null ?
            this.FromServiceResponse(await _solicitantService.DeleteSolicitant(id, currentUser.Result)) :
            this.ErrorMessageResult(currentUser.Error);
    }
}
