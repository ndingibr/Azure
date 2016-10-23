using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;

namespace Azure.Data
{
    public interface ITableStorage
    {
        CloudTableClient CreateCloudTableClient(string storageConnectionString,
            string tableName);
        CloudTable Createtable(CloudTableClient cloudTableClient, string tableName);
        void AddEntity(CloudTable table, CustomerEntity customer);
        void AddEntries(CloudTable table, List<CustomerEntity> customers);
    }
}