using System;
using System.Net.Http;
using System.Threading.Tasks;
using C004_Polly.Http.Client;
using C004_Polly.Policies;

namespace C004_Polly;
class Program
{
    static async Task Main()
    {
        var httpClient = new HttpClient();
        var retryPolicy = RetryPolicyProvider.CreateHttpRetryPolicy();

        var httpService = new HttpService(httpClient, retryPolicy);

        try
        {
            Console.WriteLine("Sending request...");
            var response = await httpService.GetAsync("https://httpbin.org/status/500"); // Simulate failure
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Request succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Request ultimately failed: {ex.Message}");
        }
    }
}
