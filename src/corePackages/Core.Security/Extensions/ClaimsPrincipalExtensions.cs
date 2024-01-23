using System.Security.Claims;

namespace Core.Security.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        List<string>? result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
        return result;
    }

    public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.Role);
    }

    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal == null)
            throw new ArgumentNullException(nameof(claimsPrincipal), "ClaimsPrincipal value can not be null");


        var userIdClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
            throw new InvalidOperationException("NameIdentifier type Id value could not find.");

        return Guid.TryParse(userIdClaim.Value, out var userId)
            ? userId
            : throw new InvalidOperationException("Guid Id value could not be parsed.");


    }    //public static Guid? GetUserIdCanNull(this ClaimsPrincipal claimsPrincipal)
    //{
    //    if (claimsPrincipal == null)
    //        throw new ArgumentNullException(nameof(claimsPrincipal), "ClaimsPrincipal value can not be null");

    //    var userIdClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

    //    //if (userIdClaim == null)
    //    //    throw new InvalidOperationException("NameIdentifier type Id value could not be found.");

    //    return Guid
    //        .TryParse(userIdClaim.Value, out var userId) 
    //        ? userId 
    //        : (Guid?)null;
    //} 


}