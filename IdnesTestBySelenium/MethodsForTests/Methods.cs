


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

        public void GetIdnesLoginPage()
        {
            try
            {
                webDriver.Navigate().GoToUrl(idnesLoginPage);
            }
            catch (Exception ex)
            {
                throw new Exception($"Page doesn't exist: {ex.Message}");
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

        public void WaitForVisibleElementByLinkText(int waitForSeconds, string ltElement)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitForSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(ltElement)));
            }
            catch
            {
                throw new Exception($"Element doesn't exist");
            }
        }
        public void WaitForVisibleElementByName(int waitForSeconds, string nameElement)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitForSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name(nameElement)));
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

        public void InputTextByName(string nameElement, string inputTextToField)
        {
            try
            {
                WaitForVisibleElementByName(10, nameElement);
                webDriver.FindElement(By.Name(nameElement)).SendKeys(inputTextToField);
            }
            catch (Exception ex)
            {
                throw new Exception($"Element not found: {ex.Message}");
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

        public void VerifyButtonNameByLinkText(string txtElement)
        {            
            try
            {                
                WaitForVisibleElementByLinkText(10, txtElement);
                IWebElement button = webDriver.FindElement(By.LinkText(txtElement));     
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Přihlásit", button.Text,"The button name isn't as expected");
            }
            catch
            {
                throw new ElementNotVisibleException($"The button name doesn't match with expected name");
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
