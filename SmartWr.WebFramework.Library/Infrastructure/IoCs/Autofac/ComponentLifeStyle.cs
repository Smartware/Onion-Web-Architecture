using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.Infrastructure.IoCs.Autofac
{
    public enum ComponentLifeStyle
    {
        Singleton = 0,
        Transient = 1,
        LifetimeScope = 2
    }
}
