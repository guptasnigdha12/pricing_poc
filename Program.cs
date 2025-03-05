using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting Azure Pricing Job...");        

        var service = new PricingService();
        var tasks = AppSettings.Skus.Select(async sku =>
        {
            var data = await service.FetchPricingDataAsync(sku.Query);
            string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            await FileHelper.SaveJsonToBlobAsync(sku.Name, jsonData);
        });

        await Task.WhenAll(tasks); // Run API calls in parallel

        Console.WriteLine($"Job completed. Total API calls made: {PricingService.GetApiCallCount()}");
    }
}
