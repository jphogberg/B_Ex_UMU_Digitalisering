using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace B_Ex_UMU_Digitalisering.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<IdentityRole> Roles { get; } = new List<IdentityRole>();

        public virtual ICollection<ApplicationUserClaim> Claims { get; } = new List<ApplicationUserClaim>();
    }

    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
