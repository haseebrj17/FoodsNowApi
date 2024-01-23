using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FoodsNow.Services.BlobStorage.Interfaces;

namespace FoodsNow.Services.BlobStorage.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobStorageService(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<string> UploadFileAsync(string containerName, string folderPath, Stream fileStream, string fileName)
        {
            var blobClient = GetBlobClient(containerName, Path.Combine(folderPath, fileName));
            await blobClient.UploadAsync(fileStream, overwrite: true);
            return blobClient.Uri.ToString();
        }

        public async Task DeleteFileAsync(string containerName, string folderPath, string fileName)
        {
            var blobClient = GetBlobClient(containerName, Path.Combine(folderPath, fileName));
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task UpdateFileAsync(string containerName, string folderPath, Stream fileStream, string fileName)
        {
            await UploadFileAsync(containerName, folderPath, fileStream, fileName);
        }

        public async Task<Stream> DownloadFileAsync(string containerName, string folderPath, string fileName)
        {
            var blobClient = GetBlobClient(containerName, Path.Combine(folderPath, fileName));
            BlobDownloadInfo download = await blobClient.DownloadAsync();
            return download.Content;
        }

        public async Task<IEnumerable<string>> ListFilesAsync(string containerName, string folderPath)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobs = new List<string>();
            await foreach (var blobItem in containerClient.GetBlobsAsync(prefix: folderPath))
            {
                blobs.Add(blobItem.Name);
            }
            return blobs;
        }

        public async Task<Stream> GetBlobAsync(string containerName, string blobName)
        {
            var blobClient = GetBlobClient(containerName, blobName);
            BlobDownloadInfo download = await blobClient.DownloadAsync();
            return download.Content;
        }

        private BlobClient GetBlobClient(string containerName, string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return containerClient.GetBlobClient(blobName);
        }
    }
}
