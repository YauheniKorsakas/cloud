using Azure.Storage.Blobs;
using Azure.Identity;

namespace Cloud.Source.BlobInteraction
{
    public class BlobService
    {
        /// <summary>
        /// Gets access to storage account and its containers
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public BlobServiceClient GetBlobServiceClient(string accountName) {
            var client = new BlobServiceClient(
                new Uri($"https://{accountName}.blob.core.windows.net"),
                new DefaultAzureCredential());

            return client;
        }

        /// <summary>
        /// Gets access to container client that allows to CRD containers and blobs within it.
        /// </summary>
        /// <param name="blobServiceClient"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public BlobContainerClient GetBlobContainerClient(BlobServiceClient blobServiceClient, string containerName) {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            return containerClient;
        }

        /// <summary>
        /// To get container client if we work only with single one.
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="containerName"></param>
        /// <param name="clientOptions"></param>
        /// <returns></returns>
        public BlobContainerClient GetBlobContainerClient(string accountName, string containerName, BlobClientOptions clientOptions) {
            var client = new BlobContainerClient(
                new Uri($"https://{accountName}.blob.core.windows.net/{containerName}"),
                new DefaultAzureCredential(),
                clientOptions);

            return client;
        }

        public BlobClient GetBlobClient(BlobServiceClient client, string containerName, string blobName) {
            var blobClient = client.GetBlobContainerClient(containerName).GetBlobClient(blobName);
            
            return blobClient;
        }
    }
}
