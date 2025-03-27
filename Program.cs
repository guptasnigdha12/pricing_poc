using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting Azure Pricing Job...");

        var service = new PricingService();
        var queries = QueryBuilder.GenerateQueries();

        var tasks = queries.Select(async query =>
        {
            var pricingData = await service.FetchPricingDataAsync(query.Value); // API call
            string jsonData = JsonSerializer.Serialize(pricingData, new JsonSerializerOptions { WriteIndented = true });
            await FileHelper.SaveJsonToBlobAsync(query.Key, jsonData); // Save structured data
        });

        await Task.WhenAll(tasks); // Run API calls in parallel

        Console.WriteLine($"Job completed. Total API calls made: {PricingService.GetApiCallCount()}");
    }
}
