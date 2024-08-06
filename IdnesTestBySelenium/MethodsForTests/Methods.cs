using IdnesTestBySelenium.Setup;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;
using System.Xml.Linq;

namespace IdnesTestBySelenium.MethodsForTests
{
    public class Methods
    {
        IWebDriver webDriver = new SelectWebDriver("Chrome").GetDriver();        
        
        string idnesMainPage = "https://idnes.cz";
        string idnesLoginPage = "https://ucet.idnes.cz/prihlasit";

        public void SetupBeforeTest()
        {
            try
            {
                webDriver.Manage().Window.Maximize();
            }
            catch 
            {
                throw new Exception("Maximize window doesn't initialize");
            }
            
        }

        public void GetIdnesMainPage()
        {
            try
            {
                webDriver.Navigate().GoToUrl(idnesMainPage);
            }
            catch (Exception ex)
            {
                throw new Exception($"Page doesn't exist: {ex.Message}");
            }
        }

        public void WaitForVisibleElementByCss(int waitForSeconds, string cssElement)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitForSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssElement)));
            }
            catch
            {
                throw new Exception($"Element doesn't exist");
            }
        }

        public void WaitForVisibleElementById(int waitForSeconds, string IdElement)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitForSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(IdElement)));
            }
            catch
            { 
                throw new Exception("Element doesn't exist");
            }
            
        }

        public void ClickOnElementByCss(string cssElement)
        {
            try
            {
                WaitForVisibleElementByCss(10, cssElement);
                webDriver.FindElement(By.CssSelector(cssElement)).Click();
            }
            catch 
            { 
                throw new Exception("Element doesn't exist");
            }
        }

        public void ClickOnElementById(string idElement)
        {
            try
            {
                WaitForVisibleElementById(10, idElement);
                webDriver.FindElement(By.Id(idElement)).Click();
            }
            catch
            {
                throw new Exception("Element doesn't exist");
            }
        }
        public void KillWebDriverWindowsProcess()
        {
            var chromeDriverProcess = Process.GetProcessesByName("chromedriver");

            foreach (var process in chromeDriverProcess)
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                }
                catch (Exception e)
                {
                    throw new Exception($"Error while killing process: {e.Message}");
                }
            }
        }

        public void TestCleanup()
        {
            if (webDriver != null)
            {
                webDriver.Quit();                
            }
            KillWebDriverWindowsProcess();
        }
    }
}
