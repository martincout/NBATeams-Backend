using Microsoft.AspNetCore.Identity;

namespace NBATeams.Data.Models
{
    public class AppUser : IdentityUser<int>
    {
        public List<CustomTeam> CustomTeams { get; set; } = new List<CustomTeam>();
        public IEnumerable<AppUserRole> UserRoles { get; set; }
    }
}