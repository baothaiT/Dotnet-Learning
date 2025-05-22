# C004_Polly

## Pacakages
dotnet add package Polly
dotnet add package Polly.Contrib.WaitAndRetry

## Folder Structure (Clean Architecture Style)

/src
  /MyWebApi
    /Controllers
      WeatherController.cs

    /Http
      /Clients
        IHttpService.cs
        HttpService.cs

      /Policies
        RetryPolicyProvider.cs

    /Services
      WeatherService.cs

    Program.cs
    Startup.cs (or configure in Program.cs for .NET 6+)

  /MyWebApi.Domain
    /Interfaces
      IHttpService.cs

  /MyWebApi.Tests
    (Unit/integration tests here)
