using System;

namespace SimpleLogging
{
    public interface ISimpleLogger
    {
        void LogError(string message);
        void LogError(string message, string requestUrl);
        void LogError(Exception ex, string message);
        void LogError(Exception ex, string message, string requestUrl);
        void LogError(Exception ex, string message, string requestUrl, string requestIP, string urlReferrer);
        void LogError(string message, string requestUrl, string requestIP, string urlReferrer);
        void LogInfo(string message);
        void LogInfo(string message, string requestUrl);
        void LogInfo(string message, string requestUrl, string requestIP, string urlReferrer);
        void LogTrace(string message);
        void LogTrace(string message, string requestUrl);
        void LogTrace(string message, string requestUrl, string requestIP, string urlReferrer);
        void LogWarning(string message);
        void LogWarning(string message, string requestUrl);
        void LogWarning(string message, string requestUrl, string requestIP, string urlReferrer);
    }
}