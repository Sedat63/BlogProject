using System.Collections.Generic;
using System.Security.Claims;


namespace Entities.Jwt
{
    public static class ClaimExtensions
    {

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }
        public static void AddUsername(this ICollection<Claim> claims, string username)
        {
            claims.Add(new Claim(CustomClaimTypes.Username, username));
        }
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(ClaimTypes.Email, email));
        }
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
        }

    }
}
