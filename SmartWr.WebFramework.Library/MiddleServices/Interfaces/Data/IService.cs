using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.MiddleServices.Interfaces.Data
{
    public interface IService : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
