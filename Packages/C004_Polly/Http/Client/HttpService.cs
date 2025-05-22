using System;
using Polly;

namespace C004_Polly.Http.Client;

public class HttpService
{
    private readonly HttpClient _httpClient;
    private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy;

    public HttpService(HttpClient httpClient, IAsyncPolicy<HttpResponseMessage> retryPolicy)
    {
        _httpClient = httpClient;
        _retryPolicy = retryPolicy;
    }

    public async Task<HttpResponseMessage> GetAsync(string url)
    {
        return await _retryPolicy.ExecuteAsync(() => _httpClient.GetAsync(url));
    }
}
