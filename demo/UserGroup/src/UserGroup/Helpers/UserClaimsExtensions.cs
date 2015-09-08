using System;
using System.Security.Claims;

namespace UserGroup.Helpers
{
    public static class UserClaimsExtensions
    {
        public static string GetName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException("principal");
            return principal.FindFirstValue(ClaimTypes.GivenName);
        }
    }
}