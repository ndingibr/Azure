using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Azure.Data
{
    public class BlogStorage : IBlogtorage
    {
        public CloudBlobContainer CreateContainer(string storageConnectionString,
            string containerName)
        {
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(storageConnectionString);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            container.CreateIfNotExists();

            container.SetPermissions(
                new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            return container;
        }

        public void ListItemsInContainter(CloudBlobContainer container)
        {
            //find out the return types of tthis list
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;

                    Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);

                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    CloudPageBlob pageBlob = (CloudPageBlob)item;

                    Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri);

                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory directory = (CloudBlobDirectory)item;

                    Console.WriteLine("Directory: {0}", directory.Uri);
                }
            }
        }
        public void UploadBlogInContainer(CloudBlockBlob blockBlob, string path)
        {
            blockBlob.FetchAttributes();
            blockBlob.Properties.ContentType = "image/png";
            blockBlob.Metadata.Add("Source", "Mike Wood");
            blockBlob.SetProperties();


            using (var fileStream = System.IO.File.OpenRead(path))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }

        public void DownloadBlogInContainer(CloudBlockBlob blockBlob, string path)
        {

            using (var fileStream = System.IO.File.OpenWrite(path))
            {
                blockBlob.DownloadToStream(fileStream);
            }
        }

        public void DeleteBlog(CloudBlockBlob blockBlob)
        {

            blockBlob.Delete();
        }

        async public static Task ListBlobsSegmentedInFlatListing(CloudBlobContainer container)
        {

            Console.WriteLine("List blobs in pages:");

            int i = 0;
            BlobContinuationToken continuationToken = null;
            BlobResultSegment resultSegment = null;

            do
            {

                resultSegment = await container.ListBlobsSegmentedAsync("", true, BlobListingDetails.All, 10, continuationToken, null, null);
                if (resultSegment.Results.Any()) { Console.WriteLine("Page {0}:", ++i); }
                foreach (var blobItem in resultSegment.Results)
                {
                    Console.WriteLine("\t{0}", blobItem.StorageUri.PrimaryUri);
                }
                Console.WriteLine();


                continuationToken = resultSegment.ContinuationToken;
            }
            while (continuationToken != null);
        }
        public void WritingToAppendBlob(CloudBlobContainer container)
        {

            container.CreateIfNotExists();
            CloudAppendBlob appendBlob = container.GetAppendBlobReference("append-blob.log");
            appendBlob.CreateOrReplace();

            int numBlocks = 10;

            Random rnd = new Random();
            byte[] bytes = new byte[numBlocks];
            rnd.NextBytes(bytes);

            for (int i = 0; i < numBlocks; i++)
            {
                appendBlob.AppendText(String.Format("Timestamp: {0:u} \tLog Entry: {1}{2}",
                    DateTime.UtcNow, bytes[i], Environment.NewLine));
            }

        }

        public void DeleteBlog(CloudBlobContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
