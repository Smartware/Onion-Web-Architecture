using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SmartWr.WebFramework.Library.Infrastructure.IoCs;
using SmartWr.WebFramework.Library.MiddleServices.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.MiddleServices.Factory
{
    public class DbContextFactory
    {
        public static IEntitiesContext CreateApplicationDbContext(IdentityFactoryOptions<IEntitiesContext> options
          , IOwinContext context)
        {
            return (IEntitiesContext)EngineContext.Current.Resolve<IEntitiesContext>();
        }
    }
}
