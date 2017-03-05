using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.Infrastructure.Logging
{
    public class NLogLogger : ILogger
    {
        private static readonly Lazy<NLogLogger> LazyLogger = new Lazy<NLogLogger>(() => new NLogLogger());
        private static readonly Lazy<NLog.Logger> LazyNLogger = new Lazy<NLog.Logger>(NLog.LogManager.GetCurrentClassLogger);

        public static ILogger Instance
        {
            get
            {
                return LazyLogger.Value;
            }
        }

        private NLogLogger()
        {
        }

        public void Log(string message)
        {
            LazyNLogger.Value.Info(message);
        }

        public void Log(Exception ex)
        {
            LazyNLogger.Value.Error(ex);
        }
    }
}
