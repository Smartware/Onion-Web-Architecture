using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.Infrastructure.IoCs.Autofac
{
    public interface IContainerManager
    {
        // void Build();
        void AddControllerFromAssembly(Assembly assembly, ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton);
        void AddComponent(Type service, string key = "", ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton);
        void AddComponent(Type service, Type implementation, string key = "", ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton);
        void AddComponent<TService, TImplementation>(string key = "", ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton);
        void AddComponent<TService>(string key = "", ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton);
        void AddComponentInstance(Type service, object instance, string key = "", ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton);
        void AddComponentInstance<TService>(object instance, string key = "", ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton);
        void AddComponentWithParameters(Type service, Type implementation, System.Collections.Generic.IDictionary<string, string> properties, string key = "", ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton);
        void AddComponentWithParameters<TService, TImplementation>(IDictionary<string, string> properties, string key = "", ComponentLifeStyle lifeStyle = ComponentLifeStyle.Singleton);
        IContainer Container { get; }
        bool IsRegistered(Type serviceType, ILifetimeScope scope = null);
        object Resolve(Type type, ILifetimeScope scope = null);
        T Resolve<T>(string key = "", ILifetimeScope scope = null) where T : class;
        T[] ResolveAll<T>(string key = "", ILifetimeScope scope = null);
        object ResolveOptional(Type serviceType, ILifetimeScope scope = null);
        object ResolveUnregistered(Type type, ILifetimeScope scope = null);
        T ResolveUnregistered<T>(ILifetimeScope scope = null) where T : class;
        ILifetimeScope Scope();
        bool TryResolve(Type serviceType, ILifetimeScope scope, out object instance);
        void UpdateContainer(Action<ContainerBuilder> action);
    }
}
