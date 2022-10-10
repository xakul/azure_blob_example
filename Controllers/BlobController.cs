using System.Collections;
using Azure.Storage.Blobs.Models;
using AzureBlobExample.Interfaces;
using AzureBlobExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureBlobExample.Controllers;

[ApiController]
[Route("[controller]")]
public class BlobController : ControllerBase
{
    private readonly IBlobService _blobService;

    public BlobController(IBlobService blobService)
    {
        _blobService = blobService;
    }
    
    [HttpGet("get-blob-by-name")]
    public async Task<ActionResult<BlobDownloadInfo>> GetBlobByName(string name)
    {
        var blobResponse = await _blobService.GetBlobAsync(name);
        return StatusCode(StatusCodes.Status200OK, blobResponse);
    }
    [HttpGet("get-all-blob")]
    public async Task<ActionResult<IEnumerable>> GetAllBlob()
    {
        var blobResponse = await _blobService.GetAllBlobs();
        return StatusCode(StatusCodes.Status200OK, blobResponse);
    }
    
    [HttpPost("upload-file-local")]
    public async Task UploadLocalFile(UploadFileModel uploadFile)
    {
        await _blobService.UploadFile(uploadFile.FilePath, uploadFile.FileName);
    }
}