using System;

namespace SimpleLogging
{
    public static class SimpleLoggerFactory
    {
        private static readonly Lazy<ISimpleLogger> _simpleLogger;

        static SimpleLoggerFactory()
        {
            _simpleLogger = new Lazy<ISimpleLogger>(() => new SimpleNLogger(), false);
        }

        public static ISimpleLogger Create()
        {
            return _simpleLogger.Value;
        }
    }
}