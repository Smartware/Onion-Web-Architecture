using SmartWr.WebFramework.Library.Infrastructure.Factory;
using SmartWr.WebFramework.Library.Infrastructure.Identity;
using SmartWr.WebFramework.Library.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.MiddleServices.DataAccess
{
    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>,
        IDatabaseInitializer<ApplicationDbContext>
    {
        public override void InitializeDatabase(ApplicationDbContext context)
        {
            base.InitializeDatabase(context);
            InitializeIdentityForEF(context);
        }

        public void InitializeIdentityForEF(ApplicationDbContext db)
        {
            const string name = "admin@smartware.com.ng";
            const string password = "microsoft_";
            string[] roleNames = new String[] { "ADMIN", "STAFF", "CUSTOMER" };
            var applicationRoleManager = IdentityFactory.CreateRoleManager(db);
            var applicationUserManager = IdentityFactory.CreateUserManager(db);

            //Create Role Admin if it does not exist
            Array.ForEach(roleNames, r =>
            {

                if (!applicationRoleManager.RoleExistsAsync(r).Result)
                {
                    applicationRoleManager.CreateAsync(new ApplicationIdentityRole { Name = r });
                }

            });

            var user = applicationUserManager.FindByNameAsync(name).Result;
            if (user == null)
            {
                user = new ApplicationIdentityUser { UserName = name, Email = name };
                applicationUserManager.CreateAsync(user, password);
                applicationUserManager.SetLockoutEnabledAsync(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            if (!applicationRoleManager.RoleExistsAsync(roleNames[0]).Result &&
                !applicationUserManager.IsInRoleAsync(user.Id, roleNames[0]).Result)
            {
                applicationUserManager.AddToRoleAsync(user.Id, roleNames[0]);
            }

            if (!applicationRoleManager.RoleExistsAsync(roleNames[1]).Result &&
                !applicationUserManager.IsInRoleAsync(user.Id, roleNames[1]).Result)
            {
                applicationUserManager.AddToRoleAsync(user.Id, roleNames[1]);
            }

            //context.SaveChanges();
        }
        public class DebugLogger : ILogger
        {
            public void Log(string message)
            {

            }

            public void Log(Exception ex)
            {

            }
        }

    }
}
