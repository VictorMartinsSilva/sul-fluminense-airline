using System.Linq;
using Microsoft.AspNetCore.Http;

namespace SFA.Site.Extensions
{
    public class CustomAuthorization
    {
        public static bool ValidationUserClaims(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }
}