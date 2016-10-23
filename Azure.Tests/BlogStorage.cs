using Azure.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure.Tests
{
    [TestClass]
    public class BlogStorage
    {

        private readonly IAzureStorage _azureStorage;
        public BlogStorage(IAzureStorage iAzureStorage)
        {
            this._azureStorage = iAzureStorage;
        }
        [TestMethod]
        public async void Check_Create_Containter()
        {

            string storageConnectionString = Azure.Shared.ConfigSettings.StorageConnectionString;
            string containerName = "containerName";

            CloudBlobContainer container = _azureStorage.CreateContainer
                (storageConnectionString, containerName);




        }
    }
}
