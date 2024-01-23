using MediatR;
using Microsoft.AspNetCore.Mvc;
using Core.Security.Extensions;

namespace API.Controllers;

public class BaseController : ControllerBase
{
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    private IMediator? _mediator;

    //protected string? getIpAddress()
    //{
    //    string ipAddress = Request
    //        .Headers
    //        .ContainsKey("X-Forwarded-For") ? Request
    //        .Headers["X-Forwarded-For"]
    //        .ToString() : HttpContext
    //        .Connection
    //        .RemoteIpAddress?
    //        .MapToIPv4()
    //        .ToString()
    //        ??
    //        throw new InvalidOperationException("IP address cannot be retrieved from request.");
    //    return ipAddress;
    //}
    protected string? getIpAddress()
    {
        try
        {
            string ipAddress = Request
                .Headers
                .ContainsKey("X-Forwarded-For") ? Request
                .Headers["X-Forwarded-For"]
                .ToString() : HttpContext
                .Connection
                .RemoteIpAddress?
                .MapToIPv4()
                .ToString();

            if (string.IsNullOrEmpty(ipAddress)) throw new InvalidOperationException("IP address cannot be retrieved from the request headers or connection.");

            return ipAddress;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while retrieving the IP address: " + ex.Message);
        }
    }

    protected string? getIpAddressCanNull()
    {
        string ipAddress = Request
            .Headers
            .ContainsKey("X-Forwarded-For") ? Request
            .Headers["X-Forwarded-For"]
            .ToString() : HttpContext
            .Connection
            .RemoteIpAddress?
            .MapToIPv4()
            .ToString()
            ??
            throw new InvalidOperationException("IP address cannot be retrieved from request.");
        return ipAddress;
    }

    protected Guid getUserIdFromRequest() => HttpContext.User.GetUserId();
    //protected Guid? getUserIdFromRequestCanNull() => HttpContext.User.GetUserIdCanNull();
}

