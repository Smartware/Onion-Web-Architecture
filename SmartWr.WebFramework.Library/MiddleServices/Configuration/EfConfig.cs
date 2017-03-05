using SmartWr.WebFramework.Library.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.MiddleServices.Configuration
{
    public class EfConfig
    {
        public static void ConfigureEf(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationIdentityUser>()
                 .Property(e => e.Id)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ApplicationIdentityRole>()
                .Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ApplicationIdentityUserClaim>()
                 .Property(e => e.Id)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
