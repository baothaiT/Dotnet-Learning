using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace selenium_proxies;

class Program
{
    static void Main(string[] args)
    {

        string httpHost = "103.177.108.235";
        int httpPort = 6789;
        string username = "xwci1j2w";
        string password = "xWcI1j2w";
        string extensionPath = "E:/Learn/Development/Automation/Selenium-Dotnet/learn/Selenium-Learning/src/CS03_Selenium_Proxies/extension/proxy2";

        // Check if necessary files are present
        if (!IsValidExtensionFolder(extensionPath))
        {
            Console.WriteLine("Extension folder is missing required files: manifest.json or background.js");
            return;
        }
        IWebDriver driver = InitializeChromeWithExtension(extensionPath);
        try
        {

            var originalWindow = driver.CurrentWindowHandle;
            Console.WriteLine("Current ", originalWindow);

            string settingJs = $"saveProxyHttpSettings('{httpHost}', '{httpPort}', '{username}', '{password}');";

            // Combine into the final script with event listener
            string script = $@"document.addEventListener('DOMContentLoaded', function() {{
                {settingJs}
                httpProxy(); // Ensure httpProxy() is defined in the same scope
            }});";

            // Execute the script to add the event listener
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script);
            // Switch to the new tab
            Thread.Sleep(2000);

            driver.SwitchTo().Window(driver.WindowHandles[1]);
            // // Close the new tab
            driver.Close();

            // // Switch back to the original tab
            driver.SwitchTo().Window(driver.WindowHandles[0]);


            Thread.Sleep(2000);

            // driver.Navigate().GoToUrl($"https://ident.me");
            //driver.navigate().to("http://<username>:<password>@your.website.com/basic_auth");
            driver.Navigate().GoToUrl($"https://username:password@ident.me/basic_auth");

        }
        catch (System.Exception)
        {
            throw;
        }
        finally
        {
            Thread.Sleep(5000);
            driver.Quit();
        }
    }

    public static bool IsValidExtensionFolder(string folderPath)
    {
        string manifestPath = Path.Combine(folderPath, "manifest.json");
        string backgroundPath = Path.Combine(folderPath, "background.js");

        return File.Exists(manifestPath) && File.Exists(backgroundPath);
    }

    public static IWebDriver InitializeChromeWithExtension(string extensionPath)
    {
        ChromeOptions options = new ChromeOptions();
        // Load the extension with proxy settings
        options.AddArgument("user-data-dir=E:/Learn/Development/Automation/Selenium-Dotnet/learn/Selenium-Learning/src/CS03_Selenium_Proxies/profile");
        options.AddArgument("profile-directory=Profile 3"); // Replace with the specific profile
        options.AddArguments("--load-extension=" + extensionPath);
        // Start ChromeDriver with the extension loaded
        return new ChromeDriver(options);
    }
}