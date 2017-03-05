using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SmartWr.WebFramework.Library.MiddleServices.Interfaces.Auth;
using SmartWr.WebFramework.Library.MiddleServices.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.Infrastructure.Identity.Manager
{
    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationIdentityUser, Int32>, IApplicationSignInManager
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager.UserManager , authenticationManager)
        {
        }

        public override Task SignInAsync(ApplicationIdentityUser user, bool isPersistent, bool rememberBrowser)
        {
            return base.SignInAsync(user, isPersistent, rememberBrowser);
        }

        public  override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationIdentityUser user)
        {
            return  user.GenerateUserIdentityAsync(new ApplicationUserManager(UserManager, AuthenticationManager));
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
