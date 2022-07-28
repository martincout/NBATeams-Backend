using Microsoft.AspNetCore.Identity;

namespace NBATeams.Data.Models
{
    public class AppUser : IdentityUser<int>
    {
        public IEnumerable<AppUserRole> UserRoles { get; set; }
    }
}