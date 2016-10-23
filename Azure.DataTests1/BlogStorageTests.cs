using Azure.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure.DataTests
{
    [TestClass]
    public class BlogStorageTests
    {
        static string storageConnectionString = Shared.ConfigSettings.StorageConnectionString;
        static string containerName = "containername";

        [TestMethod]
        public void Can_Create_Containter()
        {
            var azureStorage = new BlogStorage();
            var container = azureStorage.CreateContainer
                (storageConnectionString, containerName);
            Assert.IsNotNull(container);
            Assert.AreEqual(typeof(CloudBlobContainer), container.GetType());

        }

        [TestMethod]
        public void Can_Upload_Blog()
        {
            var azureStorage = new BlogStorage();
            string pathToReadFile = @"C:\Users\briann\Pictures\imagesJS0BZ3V6.jpg";
            string blogName = "blogname";

            var container = azureStorage.CreateContainer(storageConnectionString, containerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blogName);

            azureStorage.UploadBlogInContainer(blockBlob, pathToReadFile);

        }

        [TestMethod]
        public void Can_Download_Blog()
        {
            var azureStorage = new BlogStorage();
            string pathToReadFile = @"C:\Users\briann\Pictures\Me_Today1.jpg";
            string blogName = "blogname";

            var container = azureStorage.CreateContainer(storageConnectionString, containerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blogName);

            azureStorage.DownloadBlogInContainer(blockBlob, pathToReadFile);

        }
    }
}
