using Microsoft.AspNet.Identity;
using SmartWr.WebFramework.Library.Infrastructure.Identity.Manager;
using SmartWr.WebFramework.Library.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.MiddleServices.Models.Auth
{
    public class AppUser : BaseEntity
    {
        public AppUser()
        {
            Claims = new List<ApplicationUserClaim>();
            Roles = new List<ApplicationUserRole>();
            Logins = new List<ApplicationUserLogin>();
        }

       
        public virtual int AccessFailedCount { get; set; }
        public virtual ICollection<ApplicationUserClaim> Claims { get; private set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual new int Id { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; private set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual ICollection<ApplicationUserRole> Roles { get; private set; }
        public virtual string SecurityStamp { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual string UserName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Country { get; set; }

        public override List<ValidationError> Validate()
        {
            return new List<ValidationError>();
        }
    }
}
