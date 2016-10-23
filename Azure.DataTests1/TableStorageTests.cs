
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using Azure.Data;

namespace Azure.DataTests
{
    [TestClass]
    public class TableStorageTests
    {
        private static readonly string StorageConnectionString =
            Shared.ConfigSettings.StorageConnectionString;

        private static string _tableName = "tableName";

        [TestMethod]
        public void Can_Create_TableClient()
        {
            var tableStorage = new TableStorage();
            var tableClient = tableStorage.CreateCloudTableClient
                (StorageConnectionString, _tableName);
            Assert.IsNotNull(tableClient);
            Assert.AreEqual(typeof (CloudTableClient), tableClient.GetType());
        }

        [TestMethod]
        public void Can_Create_Table()
        {
            var tableStorage = new TableStorage();
            var tableClient = tableStorage.CreateCloudTableClient
                (StorageConnectionString, _tableName);
            var table = tableStorage.Createtable(tableClient, _tableName);
            Assert.IsNotNull(table);
            Assert.AreEqual(typeof (CloudTableClient), tableClient.GetType());
        }

        [TestMethod]
        public void Can_Add_Entity()
        {
            var tableStorage = new TableStorage();
            var tableClient = tableStorage.CreateCloudTableClient
                (StorageConnectionString, _tableName);
            var table = tableStorage.Createtable(tableClient, _tableName);

            CustomerEntity customer = new CustomerEntity("Harp", "Walter");
            customer.Email = "Walter@contoso.com";
            customer.PhoneNumber = "425-555-0101";

            tableStorage.AddEntity(table, customer);
        }

        [TestMethod]
        public void Can_Get_All_Entries()
        {
            var tableStorage = new TableStorage();
            var tableClient = tableStorage.CreateCloudTableClient
                (StorageConnectionString, _tableName);
            var table = tableStorage.Createtable(tableClient, _tableName);

            var query =
                new TableQuery<CustomerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey",
                    QueryComparisons.Equal, "Smith"));

            var result = tableStorage.GetAllEntries(table, query);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Can_Get_Range_Entries()
        {
            var tableStorage = new TableStorage();
            var tableClient = tableStorage.CreateCloudTableClient
                (StorageConnectionString, _tableName);
            var table = tableStorage.Createtable(tableClient, _tableName);

            TableQuery<CustomerEntity> rangeQuery = new TableQuery<CustomerEntity>().Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Smith"),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, "E")));

            var result = tableStorage.GetAllEntries(table, rangeQuery);

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Can_a_Single_Entity()
        {
            var tableStorage = new TableStorage();
            var tableClient = tableStorage.CreateCloudTableClient
                (StorageConnectionString, _tableName);
            var table = tableStorage.Createtable(tableClient, _tableName);

            TableOperation retrieveOperation = TableOperation.Retrieve<CustomerEntity>("Smith", "Ben");

            var result = tableStorage.GetEntity(table, retrieveOperation);

            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(TableResult), result.GetType());
        }

        [TestMethod]
        public void Can_Add_Entities()
        {
            var tableStorage = new TableStorage();
            var tableClient = tableStorage.CreateCloudTableClient
                (StorageConnectionString, _tableName);
            var table = tableStorage.Createtable(tableClient, _tableName);

            var customers = new List<CustomerEntity>();
            customers.Add(new CustomerEntity("Smith", "Ben")
            {
                Email = "ndingibr@gmail.com",
                PhoneNumber = "0630912872"
            });
            customers.Add(new CustomerEntity("Smith", "Ben2")
            {
                Email = "ndingibr@gmail.com",
                PhoneNumber = "0630912872"
            });
            customers.Add(new CustomerEntity("Smith", "Ben3")
            {
                Email = "ndingibr@gmail.com",
                PhoneNumber = "0630912872"
            });
            customers.Add(new CustomerEntity("Smith", "Ben4")
            {
                Email = "ndingibr@gmail.com",
                PhoneNumber = "0630912872"
            });

            tableStorage.AddEntries(table, customers);
        }
    }
}
