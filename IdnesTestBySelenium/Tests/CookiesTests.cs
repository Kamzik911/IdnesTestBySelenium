namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class CookiesTests
    {
        Methods methods = new Methods();
        DefinedElements definedElements = new DefinedElements();

        [TestInitialize]
        public void SetupCookiesTests()
        {
            methods.MaximizeWindow();
            methods.GetIdnesMainPage();            
        }

        [TestMethod]        
        public void DennyAllCookies_ShouldPass()
        {            
            methods.ClickOnElementByLinkText(definedElements.cookiesAdvancedSettings);
            methods.ClickOnElementByCss(definedElements.allCookiesDennyButton);
            methods.VerifyVisibilityWebPageTextByXPath(definedElements.allCookiesDennyText, definedElements.allCookiesAssesmentText);
        }

        [TestMethod]
        public void AllowAllCookies_ShouldPass()
        {          
            methods.ClickOnElementByCss(definedElements.allCookiesAllowButton);
        }
        
        [TestCleanup]
        public void TestCleanup() 
        {
            methods.TestCleanup();
        }
    }
}
