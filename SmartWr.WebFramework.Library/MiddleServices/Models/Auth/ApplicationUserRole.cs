using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.MiddleServices.Models.Auth
{
    public class ApplicationUserRole
    {
        public virtual int RoleId { get; set; }
        public virtual int UserId { get; set; }
    }
}
