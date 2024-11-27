
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace C002_OKX.Services;

public class OkxApiClient
{
    private static readonly string BaseUrl = "https://www.okx.com";
    private readonly string ApiKey;
    private readonly string SecretKey;
    private readonly string Passphrase;

    public OkxApiClient(string apiKey, string secretKey, string passphrase)
    {
        ApiKey = apiKey;
        SecretKey = secretKey;
        Passphrase = passphrase;
    }

    private string GenerateSignature(string timestamp, string method, string requestPath, string body = "")
    {
        string preHash = timestamp + method + requestPath + body;
        byte[] secretKeyBytes = Encoding.UTF8.GetBytes(SecretKey);
        using (HMACSHA256 hmac = new HMACSHA256(secretKeyBytes))
        {
            byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(preHash));
            return Convert.ToBase64String(hashBytes);
        }
    }

    private async Task<string> SendRequestAsync(string method, string endpoint, string body = "")
    {
        using (HttpClient client = new HttpClient())
        {
            // string timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            string timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            string signature = GenerateSignature(timestamp, method, endpoint, body);

            // Add required headers
            client.DefaultRequestHeaders.Add("OK-ACCESS-KEY", ApiKey);
            client.DefaultRequestHeaders.Add("OK-ACCESS-SIGN", signature);
            client.DefaultRequestHeaders.Add("OK-ACCESS-TIMESTAMP", timestamp);
            client.DefaultRequestHeaders.Add("OK-ACCESS-PASSPHRASE", Passphrase);
            

            HttpResponseMessage response;

            if (method == "GET")
            {
                response = await client.GetAsync(BaseUrl + endpoint);
            }
            else if (method == "POST")
            {
                HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
                response = await client.PostAsync(BaseUrl + endpoint, content);
            }
            else
            {
                throw new InvalidOperationException("Unsupported HTTP method");
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

    public async Task<dynamic> GetAccountBalanceAsync()
    {
        string endpoint = "/api/v5/account/balance";
        string response = await SendRequestAsync("GET", endpoint);
        return JsonConvert.DeserializeObject(response);
    }

    public async Task<dynamic> GetSpotOrderHistoryAsync(string ordType, string instType, string begin = "", string end = "")
{
    // Construct query parameters
    string queryParams = $"?ordType={ordType}&instType={instType}";

    if(!string.IsNullOrEmpty(begin))
    {
        queryParams += $"&begin={begin}";
    }
    if(!string.IsNullOrEmpty(end))
    {
        queryParams += $"&end={end}";
    }

    // Combine endpoint and query parameters
    string endpoint = $"/api/v5/trade/orders-history-archive{queryParams}";

    // Send the GET request
    string response = await SendRequestAsync("GET", endpoint);

    // Deserialize and return the response
    return JsonConvert.DeserializeObject(response);
}
}