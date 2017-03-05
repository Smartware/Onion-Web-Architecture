using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using SmartWr.WebFramework.Library.Infrastructure.Identity;
using SmartWr.WebFramework.Library.Infrastructure.Identity.Manager;
using SmartWr.WebFramework.Library.MiddleServices.DataAccess;
using SmartWr.WebFramework.Library.MiddleServices.Interfaces.Auth;
using System;
using System.Data.Entity;
namespace SmartWr.WebFramework.Library.Infrastructure.Factory
{
    public class IdentityFactory
    {
        public static IApplicationSignInManager CreateApplicationSignInManager(
          IdentityFactoryOptions<IApplicationSignInManager> options
          , IOwinContext context)
        {
            var dbContext = (DbContext)context.Get<IEntitiesContext>();
            var manager = CreateManager(dbContext);
            return new ApplicationSignInManager(new ApplicationUserManager(manager, context.Authentication), context.Authentication);
        }

        public static IApplicationUserManager CreateApplicationUserManager(
            IdentityFactoryOptions<IApplicationUserManager> options
            , IOwinContext context)
        {
            var dbContext = (DbContext)context.Get<IEntitiesContext>();
            var manager = CreateManager(dbContext);
            return new ApplicationUserManager(manager, context.Authentication);
        }

        public static IApplicationRoleManager CreateApplicationRoleManager(
          IdentityFactoryOptions<IApplicationRoleManager> options, IOwinContext context)
        {
            var dbContext = (DbContext)context.Get<IEntitiesContext>();
            var roleManager = new RoleManager<ApplicationIdentityRole, Int32>(new RoleStore<ApplicationIdentityRole, Int32,
                ApplicationIdentityUserRole>(dbContext));
            return new ApplicationRoleManager(roleManager);
        }

        public static UserManager<ApplicationIdentityUser, Int32> CreateUserManager(DbContext context)
        {
            var manager = new UserManager<ApplicationIdentityUser, Int32>(new UserStore<ApplicationIdentityUser, ApplicationIdentityRole, Int32, ApplicationIdentityUserLogin, ApplicationIdentityUserRole, ApplicationIdentityUserClaim>(context));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationIdentityUser, Int32>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationIdentityUser, Int32>
            {
                MessageFormat = "Your security code is: {0}"
            });

            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationIdentityUser, Int32>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();

            var provider = new DpapiDataProtectionProvider("Wizitup");

            manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationIdentityUser, Int32>(
                provider.Create("ASP.NET Identity"));

            return manager;
        }

        public static RoleManager<ApplicationIdentityRole, Int32> CreateRoleManager(DbContext context)
        {
            return new RoleManager<ApplicationIdentityRole, Int32>(new RoleStore<ApplicationIdentityRole, Int32, ApplicationIdentityUserRole>(context));
        }


        private static UserManager<ApplicationIdentityUser, int> CreateManager(DbContext dbContext)
        {
            var manager = new UserManager<ApplicationIdentityUser, Int32>(new UserStore<ApplicationIdentityUser, ApplicationIdentityRole, Int32
                    , ApplicationIdentityUserLogin, ApplicationIdentityUserRole
                    , ApplicationIdentityUserClaim>(dbContext));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationIdentityUser, Int32>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false,
            };

            // Configure user lockout defaults
            // manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationIdentityUser, Int32>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationIdentityUser, Int32>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is: {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            //var dataProtectionProvider = options.DataProtectionProvider;
            var provider = new DpapiDataProtectionProvider("SmartWrApp");

            manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationIdentityUser, Int32>(
                provider.Create("EmailConfirmation"));
            //provider.Create("ASP.NET Identity"));
            return manager;
        }
    }
}
