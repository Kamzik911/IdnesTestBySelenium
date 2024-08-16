namespace IdnesTestBySelenium.Setup
{
    public class SelectWebDriver
    {
        private IWebDriver? webDriver;
        ChromeOptions chromeOptions = new ChromeOptions();
        

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