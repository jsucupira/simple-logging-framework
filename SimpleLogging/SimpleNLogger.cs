using System;
using NLog;

namespace SimpleLogging
{
    internal class SimpleNLogger : ISimpleLogger
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public void LogError(string message, string requestUrl)
        {
            LogError(null, message, requestUrl, null, null);
        }

        public void LogError(Exception ex, string message)
        {
            LogError(ex, message, null, null, null);
        }

        public void LogError(Exception ex, string message, string requestUrl)
        {
            LogError(ex, message, requestUrl, null, null);
        }

        public void LogError(Exception ex, string message, string requestUrl, string requestIP, string urlReferrer)
        {
            InternalLog(LogLevel.Error, ex, message, requestUrl, requestIP, urlReferrer);
        }

        public void LogError(string message, string requestUrl, string requestIP, string urlReferrer)
        {
            LogError(null, message, requestUrl, requestIP, urlReferrer);
        }

        public void LogError(string message)
        {
            LogError(null, message, null, null, null);
        }

        public void LogTrace(string message, string requestUrl, string requestIP, string urlReferrer)
        {
            InternalLog(LogLevel.Trace, null, message, requestUrl, requestIP, urlReferrer);
        }

        public void LogTrace(string message)
        {
            LogTrace(message, null, null, null);
        }

        public void LogTrace(string message, string requestUrl)
        {
            LogTrace(message, requestUrl, null, null);
        }

        public void LogInfo(string message)
        {
            LogInfo(message, null, null, null);
        }

        public void LogInfo(string message, string requestUrl)
        {
            LogInfo(message, requestUrl, null, null);
        }

        public void LogInfo(string message, string requestUrl, string requestIP, string urlReferrer)
        {
            InternalLog(LogLevel.Info, null, message, requestUrl, requestIP, urlReferrer);
        }

        public void LogWarning(string message)
        {
            LogWarning(message, null, null, null);
        }

        public void LogWarning(string message, string requestUrl)
        {
            LogWarning(message, requestUrl, null, null);
        }

        public void LogWarning(string message, string requestUrl, string requestIP, string urlReferrer)
        {
            InternalLog(LogLevel.Warn, null, message, requestUrl, requestIP, urlReferrer);
        }

        private static void InternalLog(LogLevel logLevel, Exception ex, string message, string requestUrl, string requestIP, string urlReferrer)
        {
            if (_logger == null)
                throw new ApplicationException("NLog configuration has not been setup. Please make sure if you configure it before using it.");

            LogEventInfo info = new LogEventInfo();
            info.Properties.Add(CustomProperties.REQUEST_URL, requestUrl);
            info.Properties.Add(CustomProperties.IP_ADDRESS, requestIP);
            info.Properties.Add(CustomProperties.URL_REFERRER, urlReferrer);

            if (ex != null)
                _logger.Log(logLevel, ex, message, info);
            else
                _logger.Log(logLevel, message, info);
        }
    }
}