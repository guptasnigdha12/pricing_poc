using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public class PricingService
{
    private static int _apiCallCount = 0; // Tracks API calls
    private readonly HttpClient _httpClient = new();
    private const int MaxRetries = 5; // Maximum retry attempts

    public async Task<PricingDataModel> FetchPricingDataAsync(string query)
    {
        List<object> allResults = new();
        string? url = $"{AppSettings.ApiBaseUrl}{AppSettings.ApiVersion}&{query}";
        int retryCount = 0;

        while (!string.IsNullOrEmpty(url))
        {
            bool success = false;

            while (!success && retryCount < MaxRetries)
            {
                try
                {
                    Interlocked.Increment(ref _apiCallCount); // Increment API call count
                    Console.WriteLine($"API Call {_apiCallCount} (Attempt {retryCount + 1}): {url}");

                    var response = await _httpClient.GetFromJsonAsync<JsonDocument>(url);
                    if (response is null) throw new Exception("Received null response.");

                    var prices = response.RootElement.GetProperty("Items").EnumerateArray();
                    foreach (var price in prices)
                    {
                        allResults.Add(price);
                    }

                    url = response.RootElement.TryGetProperty("NextPageLink", out var nextPage)
                        ? nextPage.GetString()
                        : null;

                    success = true; // API call succeeded
                }
                catch (Exception ex)
                {
                    retryCount++;
                    Console.WriteLine($"Error fetching data (Attempt {retryCount}): {ex.Message}");

                    if (retryCount >= MaxRetries)
                    {
                        Console.WriteLine("Max retries reached. Moving to the next query.");
                        return new PricingDataModel
                        {
                            terminalState = "Failed",
                            content = JsonSerializer.Serialize(new { error = "Max retries reached." })
                        };
                    }

                    await Task.Delay(1000 * retryCount); // Exponential backoff
                }
            }
        }

        return new PricingDataModel
        {
            terminalState = "Success",
            content = allResults
        };
    }

    public static int GetApiCallCount() => _apiCallCount;
}
