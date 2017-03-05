using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.Infrastructure.IoCs
{
    public class EngineContext
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize()
        {
            if (Singleton<IEngine>.Instance == null)
            {
                Singleton<IEngine>.Instance = new ApplicationIoCEngine();
            }

            return Singleton<IEngine>.Instance;
        }

        /// <summary>Sets the static engine instance to the supplied engine. Use this method to supply your own engine implementation.</summary>
        /// <param name="engine">The engine to use.</param>
        /// <remarks>Only use this method if you know what you're doing.</remarks>
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }


        /// <summary>Gets the singleton Nop engine used to access Nop services.</summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Initialize();
                }
                return Singleton<IEngine>.Instance;
            }
        }
    }
}
