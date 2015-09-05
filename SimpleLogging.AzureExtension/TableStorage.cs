using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text;
using NLog;
using NLog.Targets;

namespace SimpleLogging.AzureExtension
{
    [Target("TableStorage")]
    public class AzureTableStorageTarget : TargetWithLayout
    {
        private readonly object _syncRoot = new object();
        private AzureTableUtility _tableStorageManager;

        [Required]
        public string ConnectionStringKey { get; set; }

        [Required]
        public string TableName { get; set; }

        private static string GetExceptionDataAsString(Exception exception)
        {
            if (exception != null)
            {
                StringBuilder data = new StringBuilder();
                foreach (DictionaryEntry entry in exception.Data)
                    data.AppendLine(entry.Key + "=" + entry.Value);
                return data.ToString();
            }
            return null;
        }

        protected override void InitializeTarget()
        {
            base.InitializeTarget();
            lock (_syncRoot)
            {
                _tableStorageManager = new AzureTableUtility(ConnectionStringKey, TableName);
            }
        }

        protected override void Write(LogEventInfo logEvent)
        {
            lock (_syncRoot)
            {
                try
                {
                    if (_tableStorageManager != null)
                    {
                        string exceptionString = null;
                        if (logEvent.Exception != null)
                            exceptionString = logEvent.Exception.ToString();

                        LogEntry logEntry = new LogEntry(logEvent.Level.Name)
                        {
                            RequestIP = logEvent.Properties.ContainsKey(CustomProperties.IP_ADDRESS) ? logEvent.Properties[CustomProperties.IP_ADDRESS] as string : null,
                            RequestUrl = logEvent.Properties.ContainsKey(CustomProperties.REQUEST_URL) ? logEvent.Properties[CustomProperties.REQUEST_URL] as string : null,
                            ReferralUrl = logEvent.Properties.ContainsKey(CustomProperties.URL_REFERRER) ? logEvent.Properties[CustomProperties.URL_REFERRER] as string : null,
                            Timestamp = logEvent.TimeStamp,
                            Message = logEvent.FormattedMessage,
                            Level = logEvent.Level.Name,
                            Exception = exceptionString,
                            ExceptionData = GetExceptionDataAsString(logEvent.Exception),
                            Machine = Environment.MachineName
                        };
                        _tableStorageManager.AddItemToTable(logEntry);
                    }
                }
                catch
                {
                }
            }
        }
    }
}