using System.Collections;
using Azure.Storage.Blobs.Models;

namespace AzureBlobExample.Interfaces;

public interface IBlobService
{
    Task<BlobDownloadInfo> GetBlobAsync(string name);
    Task<IEnumerable> GetAllBlobs();
    Task UploadFile(string filePath, string fileName);
}