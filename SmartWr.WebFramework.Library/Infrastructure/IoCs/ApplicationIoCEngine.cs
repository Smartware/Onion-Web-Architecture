using Autofac;
using SmartWr.WebFramework.Library.Infrastructure.IoCs.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.Infrastructure.IoCs
{
    public class ApplicationIoCEngine : IEngine
    {
        #region Fields

        private IContainerManager _containerManager;

        #endregion
        public ApplicationIoCEngine()
        {
            ContainerBuilder builder = new ContainerBuilder();
            _containerManager = new AutoFacContainerManager(builder.Build());
        }

        public IContainerManager ContainerManager
        {
            get { return _containerManager; }
        }

        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }

        public T[] ResolveAll<T>()
        {
            return ContainerManager.ResolveAll<T>();
        }
    }
}
