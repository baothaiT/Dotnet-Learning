using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CS01_StartBrowser;

public class Program
{
    public static void Main(string[] args)
    {

        ChromeOptions chromeOptions = new ChromeOptions();
        IWebDriver webDriver = new ChromeDriver(chromeOptions);
        webDriver.Navigate().GoToUrl("https://example.com/");
        Console.WriteLine("Hello, World!");
    }
}

