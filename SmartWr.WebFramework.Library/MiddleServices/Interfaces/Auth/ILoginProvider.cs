using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.MiddleServices.Interfaces.Auth
{
    public interface ILoginProvider
    {
        bool ValidateCredentials(string userName, string password, out ClaimsIdentity identity);
    }
}
