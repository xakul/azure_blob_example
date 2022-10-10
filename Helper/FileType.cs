using Microsoft.AspNetCore.StaticFiles;

namespace AzureBlobExample.Helper;

public static class FileType
{
    private static readonly FileExtensionContentTypeProvider Provider = new FileExtensionContentTypeProvider();

    public static string GetContentType(this string fileName)
    {
        if (!Provider.TryGetContentType(fileName, out var contentType))
        {
            contentType = "application/octet-stream";
        }

        return contentType;
    }

}