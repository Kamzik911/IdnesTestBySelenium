namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class DennyAllCookies
    {
        Methods methods = new Methods();

        string cookiesAdvancedSettings = "Podrobné nastavení";
        string allCookiesDennyButton = "button[class='didomi-components-button didomi-button didomi-button-standard standard-button']";
        string dennyAllCookiesTextElement = "#noconsent";

        [TestMethod]
        public void DennyAllCookies_ShouldPass()
        {
            methods.GetIdnesMainPage();
            methods.ClickOnElementByLinkText(cookiesAdvancedSettings);
            methods.ClickOnElementByCss(allCookiesDennyButton);
            methods.VerifyVisibilityWebPageTextByXPath(dennyAllCookiesTextElement, "Vážený čtenáři, v podrobném nastavení, které jste zvolil, bychom nedostali potřebné souhlasy k cílení reklamy nutné pro další financování našich novin.");
        }

        [TestMethod]
        public void AllowAllCookies_ShouldPass()
        {
            methods.GetIdnesMainPage();
            methods.ClickOnElementByCss("a[class='btn-cons contentwall_ok']");
        }
        
        [TestCleanup]
        public void TestCleanup() 
        {
            methods.TestCleanup();
        }
    }
}
