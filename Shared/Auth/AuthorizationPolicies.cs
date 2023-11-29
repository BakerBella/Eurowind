using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Shared.Auth;

public class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("MustBeUser", a => a.RequireAuthenticatedUser().RequireClaim("Role", "User"));
        });
    }
}