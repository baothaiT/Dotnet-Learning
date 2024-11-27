
using CS002_AppSettingService.Services.Interfaces;

namespace CS002_AppSettingService.Services;
public class AppSettingsService : IAppSettingsService
{
    private readonly IConfiguration _configuration;

    public AppSettingsService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetSetting(string key)
    {
        // Use the configuration to fetch the value by key
        var value = _configuration[key];

        if (string.IsNullOrEmpty(value))
        {
            throw new KeyNotFoundException($"The key '{key}' was not found in appsettings.");
        }

        return value;
    }
}