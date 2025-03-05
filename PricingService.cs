using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

public class PricingService
{
    private static int _apiCallCount = 0; // Tracks API calls
    private readonly HttpClient _httpClient = new();

    public async Task<List<object>> FetchPricingDataAsync(string query)
    {
        List<object> allResults = new();
        string url = $"{AppSettings.ApiBaseUrl}?{query}";

        try
        {
            while (!string.IsNullOrEmpty(url))
            {
                Interlocked.Increment(ref _apiCallCount); // Increment API call count
                Console.WriteLine($"API Call {_apiCallCount}: {url}");

                var response = await _httpClient.GetFromJsonAsync<JsonDocument>(url);
                if (response is null) break;

                var prices = response.RootElement.GetProperty("Items").EnumerateArray();
                foreach (var price in prices)
                {
                    allResults.Add(price);
                }

                url = response.RootElement.TryGetProperty("NextPageLink", out var nextPage)
                    ? nextPage.GetString()
                    : null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data for query {query}: {ex.Message}");
        }

        return allResults;
    }
    public static int GetApiCallCount()
    {
        return _apiCallCount;  // Return the total number of API calls made
    }

}
