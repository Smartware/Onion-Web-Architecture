using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartWr.WebFramework.Library.Infrastructure.Identity.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SmartWr.WebFramework.Library.MiddleServices.Extensions;

namespace SmartWr.WebFramework.Library.Infrastructure.Identity
{
    public class ApplicationIdentityUser :
        IdentityUser<int, ApplicationIdentityUserLogin, ApplicationIdentityUserRole, ApplicationIdentityUserClaim>
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this.ToAppUser(), DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }


    public class ApplicationIdentityRole : IdentityRole<int, ApplicationIdentityUserRole>
    {
        public ApplicationIdentityRole()
        {
        }

        public ApplicationIdentityRole(string name)
        {
            Name = name;
        }
    }

    public class ApplicationIdentityUserRole : IdentityUserRole<int>
    {
    }

    public class ApplicationIdentityUserClaim : IdentityUserClaim<int>
    {
    }

    public class ApplicationIdentityUserLogin : IdentityUserLogin<int>
    {
    }
}
