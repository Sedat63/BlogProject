using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Entities.Jwt
{
    public static class ClaimPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimPrincipal,string claimType)
        {
            var result = claimPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
        public static List<string> ClaimRoles(this ClaimsPrincipal claimPrincipal, string claimType)
        {
            var result = claimPrincipal?.Claims(ClaimTypes.Role);
            return result;
        }
    }
}
