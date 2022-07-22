using Microsoft.AspNetCore.Identity;

namespace NBATeams.Data.Models
{
    public class AppRole : IdentityRole<int>
    {
        public IEnumerable<AppUserRole> UserRoles { get; set; }
    }
}
