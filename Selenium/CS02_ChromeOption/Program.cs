using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CS02_ChromeOption;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS02_ChromeOption!");
        string path = Directory.GetCurrentDirectory();

        string extensionPath = Path.Combine(path, "ProxyAuthExtension");
        if (!Directory.Exists(extensionPath))
        {
            Console.WriteLine("Extension folder not found");
            return;
        }


        ChromeOptions chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument($"user-data-dir={path + "\\ChromeProfile\\Profile1"}");
        #region Proxy

        string ip = "198.23.239.134";
        string port = "6540";
        string user = "qxibizrx";
        string password = "ximfqfs33pyv";
        string url = $"{ip}:{port}";

        Proxy proxy = new Proxy();
        proxy.Kind = ProxyKind.Manual;
        proxy.IsAutoDetect = false;
        proxy.SslProxy = url;
        proxy.SocksProxy = url;
        proxy.SocksVersion = 5;
        proxy.SocksUserName = user;
        proxy.SocksPassword = password;
        chromeOptions.Proxy = proxy;

        chromeOptions.AddArguments($"--proxy-server=sock5://{user}:{password}@{ip}:{port}");
        chromeOptions.AddArgument("ignore-certificate-errors");
        

        // Add proxy settings (SOCKS5)
        
        // chromeOptions.AddArgument($"--proxy-server=http://{ip}:{port}");
        // chromeOptions.AddArgument($"--load-extension={extensionPath}");

        // Add the ProxyAuthExtension to bypass the login prompt
        // chromeOptions.AddExtension(extensionPath);
        
        #endregion
        IWebDriver webDriver = new ChromeDriver(chromeOptions);

        try
        {
            webDriver.Navigate().GoToUrl("https://www.whatismyip.com/");
        }   
        catch (System.Exception)
        {
            
            webDriver.Quit();
        }
        
        
    }
}
