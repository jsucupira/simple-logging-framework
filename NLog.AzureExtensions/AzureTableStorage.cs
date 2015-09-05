using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace NLog.AzureExtensions
{
    public class AzureTableUtility
    {
        private readonly CloudStorageAccount _storageAccount;
        private readonly string _tableName;

        public AzureTableUtility(string accountConnectingString, string tableName)
        {
            _tableName = tableName;
            _storageAccount = CloudStorageAccount.Parse(accountConnectingString);
            CreateTable();
        }

        public TableResult AddItemToTable(TableEntity item)
        {
            // Create the table client.
            CloudTableClient tableClient = _storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference(_tableName);

            // Create the TableOperation that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(item);

            // Execute the insert operation.
            return table.Execute(insertOperation);
        }

        private bool CreateTable()
        {
            // Create the table client.
            CloudTableClient tableClient = _storageAccount.CreateCloudTableClient();
            // Create the table if it doesn't exist.
            CloudTable table = tableClient.GetTableReference(_tableName);
            return table.CreateIfNotExists();
        }
    }
}