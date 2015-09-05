using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace NLog.AzureExtensions
{
    public class LogEntry : TableEntity
    {
        public LogEntry(string partition)
        {
            PartitionKey = partition;
            RowKey = string.Format("{0}", Guid.NewGuid());
        }

        public string Exception { get; set; }
        public string ExceptionData { get; set; }
        public string Level { get; set; }
        public string Machine { get; set; }
        public string Message { get; set; }
        public string RequestIP { get; set; }
        public string RequestUrl { get; set; }
        public string ReferralUrl { get; set; }
    }
}