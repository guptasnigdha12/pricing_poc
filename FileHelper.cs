using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

public class FileHelper
{
    private static readonly BlobContainerClient _blobContainerClient;

    static FileHelper()
    {
        // Define your managed identity's Client ID (User-Assigned Managed Identity)
        //var managedIdentityClientId = "5464b679-7cff-4d9f-90ed-878618edb430"; // Replace with your MI's Client ID

        // Use Managed Identity with specific Client ID
        var credential = new DefaultAzureCredential();
        // Construct Blob Service Client using Managed Identity
        var blobServiceClient = new BlobServiceClient(new Uri("https://guptasnigdhatest.blob.core.windows.net"), credential);

        // Get reference to the container
        _blobContainerClient = blobServiceClient.GetBlobContainerClient(AppSettings.ContainerName);

        // Ensure the container exists (no public access required)
        _blobContainerClient.CreateIfNotExists(PublicAccessType.None);
    }

    public static async Task SaveJsonToBlobAsync(string fileName, string jsonData)
    {
        try
        {
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData));
            await blobClient.UploadAsync(stream, overwrite: true);

            Console.WriteLine($"✅ File '{fileName}' successfully uploaded to Blob Storage.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error uploading to Blob: {ex.Message}");
        }
    }
}
