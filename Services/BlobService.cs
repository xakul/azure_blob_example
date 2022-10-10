using System.Collections;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureBlobExample.Helper;
using AzureBlobExample.Interfaces;

namespace AzureBlobExample.Services;

public class BlobService : IBlobService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }
    
    // First container name is given
    // parameter should be a name in container
    public async Task<BlobDownloadInfo> GetBlobAsync(string name)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("test");
        var blobClient = containerClient.GetBlobClient(name);
        var blobDownloadInfo = await blobClient.DownloadAsync();

        return blobDownloadInfo;
    }
    
    public async Task<IEnumerable> GetAllBlobs()
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("test");
        var items = new List<string>();

        await foreach (var blobItem in containerClient.GetBlobsAsync())
        {
            items.Add(blobItem.Name);
        }
        
        return items;
    }

    public async Task UploadFile(string filePath, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("test");
        var blobClient = containerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(filePath, new BlobHttpHeaders { ContentType = filePath.GetContentType() });
    }
    
}