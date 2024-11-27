using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

public class ProxyChecker
{
    private readonly string _proxyAddress;
    private readonly string _proxyPort;
    private readonly string _proxyUsername;
    private readonly string _proxyPassword;

    public ProxyChecker(string proxyAddress, string proxyPort, string proxyUsername = null, string proxyPassword = null)
    {
        _proxyAddress = proxyAddress;
        _proxyPort = proxyPort;
        _proxyUsername = proxyUsername;
        _proxyPassword = proxyPassword;
    }
}

// Example usage
public class Program
{
    public static void Main()
    {
        var proxyChecker = new ProxyChecker(
            proxyAddress: "hndc39.proxyno1.com",
            proxyPort: "11066",
            proxyUsername: "admin",  // Optional
            proxyPassword: "111111"   // Optional
        );

        //hndc39.proxyno1.com:11066:admin:111111
        ChromeOptions chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--proxy-server=http://admin:111111@hndc39.proxyno1.com:11066");
        ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);
        chromeDriver.Quit();
    }
}