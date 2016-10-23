using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Linq;


namespace Azure.Data
{
    public class TableStorage : ITableStorage
    {
        public CloudTableClient CreateCloudTableClient(string storageConnectionString,
            string tableName)
        {
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(storageConnectionString);

            return storageAccount.CreateCloudTableClient();
        }

        public CloudTable Createtable(CloudTableClient cloudTableClient, string tableName)
        {
            CloudTable table = cloudTableClient.GetTableReference(tableName);
            table.CreateIfNotExists();
            return table;
        }

        public List<CustomerEntity> GetAllEntries(CloudTable table, TableQuery<CustomerEntity> query)
        {
            return table.ExecuteQuery(query).ToList();

        }

        public List<CustomerEntity> GetaRangeEntities(CloudTable table, TableQuery<CustomerEntity> rangeQuery)
        {
            return table.ExecuteQuery(rangeQuery).ToList();

        }

        public TableResult GetEntity(CloudTable table, TableOperation retrieveOperation)
        {
            return table.Execute(retrieveOperation);

        }



        public void AddEntity(CloudTable table, CustomerEntity customer)
        {

            TableOperation insertOperation = TableOperation.Insert(customer);
            table.Execute(insertOperation);
        }

        public void AddEntries(CloudTable table, List<CustomerEntity> customers)
        {

            TableBatchOperation batchOperation = new TableBatchOperation();
            foreach (var customer in customers)
            {

                CustomerEntity entity = new CustomerEntity()
                {

                    PartitionKey = customer.PartitionKey,
                    RowKey = customer.RowKey,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                };

                batchOperation.Insert(entity);
            }

            table.ExecuteBatch(batchOperation);
        }

        public void UpdateEntity(CloudTable table, CustomerEntity customer)
        {


        }

        public void DeleleEntity(CloudTable table, CustomerEntity customer)
        {

        }

    }
}
