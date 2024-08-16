namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class DennyAllCookies
    {
        Methods methods = new Methods();
        DefinedTestButtons definedTestButtons = new DefinedTestButtons();

        [TestInitialize]
        public void SetupCookiesTests()
        {
            methods.GetIdnesMainPage();
            methods.MaximizeWindow();
        }

        [TestMethod]        
        public void DennyAllCookies_ShouldPass()
        {            
            methods.ClickOnElementByLinkText(definedTestButtons.cookiesAdvancedSettings);
            methods.ClickOnElementByCss(definedTestButtons.allCookiesDennyButton);
            methods.VerifyVisibilityWebPageTextByXPath(definedTestButtons.allCookiesDennyText, "Vážený čtenáři, v podrobném nastavení, které jste zvolil, bychom nedostali potřebné souhlasy k cílení reklamy nutné pro další financování našich novin.");
        }

        [TestMethod]
        public void AllowAllCookies_ShouldPass()
        {          
            methods.ClickOnElementByCss("a[class='btn-cons contentwall_ok']");
        }
        
        [TestCleanup]
        public void TestCleanup() 
        {
            methods.TestCleanup();
        }
    }
}
