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
            catch (Exception ex)
            {
                throw new Exception($"Maximize window doesn't initialize{ex.Message}");
            }
        }

        public void GetIdnesLoginPage()
        {
            if (idnesLoginPage != null)
            {
                webDriver.Navigate().GoToUrl(idnesLoginPage);
            }
            else
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
                throw new Exception($"Page doesn't exist");
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
                throw new Exception("Element doesn't exist");
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

        public void WaitForVisibleElementByXPath(int waitForSeconds, string xPathElement)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitForSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPathElement)));
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

        public void ClickOnElementByLinkText(string linkTextElement)
        {
            if (linkTextElement != null)
            {
                WaitForVisibleElementByLinkText(10, linkTextElement);
                webDriver.FindElement(By.LinkText(linkTextElement)).Click();
            }
            else
            {
                throw new Exception("Element doesn't exist");
            }
        }

        public void VerifyWebPageTextByCss(string cssElement)
        {
            if (cssElement != null)
            {
                WaitForVisibleElementByCss(10, cssElement);
                webDriver.FindElement(By.CssSelector(cssElement));
            }
            else
            {
                throw new ElementNotVisibleException("Text not Found");
            }
        }

        public void VerifyWebPageTextByLinkText (string linkTextName)
        {
            if (linkTextName != null)
            {
                WaitForVisibleElementByLinkText(10, linkTextName);
                webDriver.FindElement(By.LinkText(linkTextName));
            }
            else
            {
                throw new ElementNotVisibleException("Text not Found");
            }
        }

        public void VerifyWebPageTextByName(string nameName)
        {
            if (nameName != null)
            {
                WaitForVisibleElementByName(10, nameName);
                webDriver.FindElement(By.Name(nameName));
            }
            else
            {
                throw new ElementNotVisibleException("Text not Found");
            }
        }

        public void VerifyVisibilityWebPageTextByXPath(string cssElement, string xPathSearchText)
        {
            if (xPathSearchText != null)
            {
                WaitForVisibleElementByCss(10, cssElement);
                webDriver.FindElement(By.XPath($"//*[text()='{xPathSearchText}']"));
            }
            else
            {
                throw new ElementNotVisibleException("Text not Found");
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
                throw new ElementNotVisibleException("The button name doesn't match with expected name");
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
