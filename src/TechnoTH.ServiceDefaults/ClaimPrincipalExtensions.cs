using System.Security.Claims;

namespace TechnoTH.ServiceDefaults;

public static class ClaimPrincipalExtensions
{
    public static string? GetUserId(this ClaimsPrincipal principal)
        => principal.FindFirst("sub")?.Value;

    public static string? GetUserName(this ClaimsPrincipal principal)
        => principal.FindFirst(x => x.Type == ClaimTypes.Name)?.Value;
}
