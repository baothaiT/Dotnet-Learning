using System;
using Polly;
using Polly.Contrib.WaitAndRetry;

namespace C004_Polly.Policies;

public static class RetryPolicyProvider
{
    public static IAsyncPolicy<HttpResponseMessage> CreateHttpRetryPolicy(int retryCount = 5, int medianFirstDelaySeconds = 2)
    {
        IEnumerable<TimeSpan> delay = Backoff.DecorrelatedJitterBackoffV2(
            medianFirstRetryDelay: TimeSpan.FromSeconds(medianFirstDelaySeconds),
            retryCount: retryCount
        );

        return Policy
            .Handle<HttpRequestException>()
            // .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .OrResult<HttpResponseMessage>(r => r.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable
                || r.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            .WaitAndRetryAsync(delay, onRetry: (outcome, timespan, retryAttempt, context) =>
            {
                Console.WriteLine($"Retry {retryAttempt} after {timespan.TotalSeconds:n1}s due to: {outcome.Exception?.Message ?? outcome.Result.StatusCode.ToString()}");
            });
    }
}
