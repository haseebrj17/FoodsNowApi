using System.IO;
using System.Threading.Tasks;

namespace FoodsNow.Services.BlobStorage.Interfaces
{
    public interface IBlobStorageService
    {
        Task<string> UploadFileAsync(string containerName, string folderPath, Stream fileStream, string fileName);

        Task DeleteFileAsync(string containerName, string folderPath, string fileName);

        Task UpdateFileAsync(string containerName, string folderPath, Stream fileStream, string fileName);

        Task<Stream> DownloadFileAsync(string containerName, string folderPath, string fileName);

        Task<IEnumerable<string>> ListFilesAsync(string containerName, string folderPath);

        Task<Stream> GetBlobAsync(string containerName, string blobName);
    }
}
