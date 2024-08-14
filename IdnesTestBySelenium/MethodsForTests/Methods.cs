namespace IdnesTestBySelenium.MethodsForTests
{
    public class Methods
    {
        IWebDriver webDriver = new SelectWebDriver("Chrome").GetDriver();

        string idnesMainPage = "https://idnes.cz";
        string idnesLoginPage = "https://ucet.idnes.cz/prihlasit";
        
        public void MaximizeWindow()
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
            if (idnesLoginPage != null)
            {
                webDriver.Navigate().GoToUrl(idnesLoginPage);
            }
            else if (string.IsNullOrEmpty(idnesLoginPage))
            {
                throw new Exception("Page doesn't exist");
            }
        }

        public void GetIdnesMainPage()
        {
            if (idnesMainPage != null)
            {
                webDriver.Navigate().GoToUrl(idnesMainPage);
            }
            else
            {
                throw new Exception("Page doesn't exist");
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
            if (cssElement != null)
            {
                WaitForVisibleElementByCss(10, cssElement);
                webDriver.FindElement(By.CssSelector(cssElement)).Click();
            }
            else
            {
                throw new Exception("Element doesn't exist");
            }
        }

        public void ClickOnElementById(string idElement)
        {
            if (idElement != null)
            {
                WaitForVisibleElementById(10, idElement);
                webDriver.FindElement(By.Id(idElement)).Click();
            }
            else
            {
                throw new Exception("Element doesn't exist");
            }
        }

        public void VerifyButtonNameByLinkText(string txtElement, string nameOfElement)
        {
            if (txtElement == nameOfElement)
            {
                WaitForVisibleElementByLinkText(10, txtElement);
                webDriver.FindElement(By.LinkText(txtElement));
            }
            else
            {
                throw new ElementNotVisibleException($"The button name doesn't match with expected name");
            }
        }

        public void VerifyButtonNameByCss(string cssElement, string expectedButtonName, string actualButtonName)
        {            
            if (expectedButtonName == actualButtonName)
            {
                WaitForVisibleElementByCss(10, cssElement);
                webDriver.FindElement(By.CssSelector(cssElement));
            }
            else
            {
                throw new ElementNotVisibleException("The button name doesn't match!");
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
