﻿namespace IdnesTestBySelenium.Setup
{
    public class SelectWebDriver
    {
        private IWebDriver? webDriver;

        public SelectWebDriver(string selectWebDriver)
        {
            if (selectWebDriver == "Chrome")
            {
                webDriver = new ChromeDriver();
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

        public void RemoveChromeExtensions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--disable-extensions");
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