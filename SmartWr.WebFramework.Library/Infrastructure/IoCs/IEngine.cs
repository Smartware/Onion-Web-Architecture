using SmartWr.WebFramework.Library.Infrastructure.IoCs.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.Infrastructure.IoCs
{
    public interface IEngine
    {
        IContainerManager ContainerManager { get; }

        T Resolve<T>() where T : class;

        object Resolve(Type type);

        T[] ResolveAll<T>();
    }
}
