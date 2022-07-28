using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Models
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppRole Role { get; set; }
        public AppUser User { get; set; }
    }
}
