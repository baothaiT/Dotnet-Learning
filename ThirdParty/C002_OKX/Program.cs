

using C002_OKX.Services;
using Newtonsoft.Json;

namespace C002_OKX;

class Program
{
    static async Task Main(string[] args)
    {
        // Your OKX API credentials
        string apiKey = "ee436608-591d-400a-bf5f-f21a74df31d8";
        string secretKey = "FFD6793A773DD8D3A30426F6C34A7547";
        string passphrase = "0VfQFsA3e9gP3Ffd5eYz!";

        DateTime endDateTime = DateTime.Now;
        DateTime startDateTime = endDateTime.AddDays(-1);

        // Convert to UTC first to avoid timezone issues
        DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Convert startDateTime to timestamp in milliseconds
        long startTimestampMillis = (long)(startDateTime.ToUniversalTime() - unixEpoch).TotalMilliseconds;
        long endTimestampMillis = (long)(endDateTime.ToUniversalTime() - unixEpoch).TotalMilliseconds;

        // Create OKX API Client
        OkxApiClient client = new OkxApiClient(apiKey, secretKey, passphrase);
        try
        {
            // Fetch account balance
            // var balance = await client.GetAccountBalanceAsync();
            // Console.WriteLine(JsonConvert.SerializeObject(balance, Formatting.Indented));

            // Fetch historical orders with ordType=limit and instType=SPOT
            var orderHistory = await client.GetSpotOrderHistoryAsync(
                ordType: "limit",        // Order type
                instType: "SPOT",        // Instrument type
                begin: startTimestampMillis.ToString(),
                end: endTimestampMillis.ToString()
            );

            // Print the result
            Console.WriteLine(JsonConvert.SerializeObject(orderHistory, Formatting.Indented));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
    }
}