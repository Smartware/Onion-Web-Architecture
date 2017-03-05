using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.Infrastructure.Auth
{
    public class CustomAppUser : ClaimsPrincipal
    {
        public CustomAppUser(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        public String Id 
        { 
            get
            {
                var claim = this.FindFirst(ClaimTypes.NameIdentifier);
                return claim != null ? claim.Value : String.Empty;
            }
        }

        public string Name
        {
            get
            {
                var claim = this.FindFirst(ClaimTypes.Name);
                return claim != null ? claim.Value : String.Empty;
            }
        }

        public string Role
        {
            get
            {
                var claim = this.FindFirst(ClaimTypes.Role);
                return claim != null? claim.Value:  String.Empty;
            }
        }
    }
}
