using Microsoft.AspNetCore.Identity;

namespace NBATeams.Data.Models
{
    public class User : IdentityUser<int>
    {
        public List<CustomTeam> CustomTeams { get; set; } = new List<CustomTeam>();
        public AppRole UserRole { get; set; }
    }
}