using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure.Data
{
    public interface IBlogtorage
    {
        CloudBlobContainer CreateContainer(string storageConnectionString,
            string containerName);
        void ListItemsInContainter(CloudBlobContainer container);
        void UploadBlogInContainer(CloudBlockBlob blockBlob, string path);
        void DownloadBlogInContainer(CloudBlockBlob blockBlob, string path);
        void DeleteBlog(CloudBlobContainer container);
        void WritingToAppendBlob(CloudBlobContainer container);
    }
}