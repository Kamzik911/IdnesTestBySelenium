using Microsoft.Testing.Platform.Requests;

namespace IdnesTestBySelenium.Setup
{
    public class SelectWebDriver
    {
        IWebDriver? webDriver;

        ChromeOptions chromeOptions = new ChromeOptions();
        FirefoxOptions firefoxOptions = new FirefoxOptions();
        EdgeOptions edgeOptions = new EdgeOptions();

        public SelectWebDriver(string selectWebDriver)
        {
            if (selectWebDriver == "Chrome")
            {
                chromeOptions.AddArgument("--disable-search-engine-choice-screen");
                webDriver = new ChromeDriver(chromeOptions);                
            }
            else if (selectWebDriver == "Firefox")
            {                
                webDriver = new FirefoxDriver();
            }
            else if (selectWebDriver == "Edge")
            {                
                webDriver = new EdgeDriver();
            }
            else
            {
                throw new ArgumentException("Unsupported webDriver");
            }
        }         

        public IWebDriver GetDriver()
        {
            if (webDriver == null)
            {
                throw new WebDriverException("WebDriver doesn't initialize");
            }
            return webDriver;
        }                
    }
}