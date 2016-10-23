using Azure.Data;
using Microsoft.WindowsAzure.Storage.Blob;
using NUnit.Framework;

namespace Azure.Tests
{
    [TestFixture]
    public class BlogStorageTests
    {

        private readonly IAzureStorage _azureStorage;
        public BlogStorageTests(IAzureStorage iAzureStorage)
        {
            this._azureStorage = iAzureStorage;
        }
        [Test]
        public void Can_Create_Containter()
        {

            string storageConnectionString = Azure.Shared.ConfigSettings.StorageConnectionString;
            string containerName = "containerName";

            var container = _azureStorage.CreateContainer
                (storageConnectionString, containerName);
            Assert.IsNotNull(container);
            Assert.AreEqual(typeof(CloudBlobContainer), container.GetType());




        }
    }
}
