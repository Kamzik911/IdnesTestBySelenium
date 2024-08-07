namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class CheckButtonNames
    {
        Methods methods = new Methods();        

        [TestMethod]
        public void VerifyButtonName_ShouldPass()
        {
            methods.GetIdnesMainPage();
            methods.ClickOnElementById("didomi-notice-learn-more-button");
            methods.ClickOnElementByCss("button[class='didomi-components-button didomi-button didomi-button-standard standard-button']");
            methods.VerifyButtonNameByLinkText("Přihlásit");
        }

        [TestCleanup]
        public void ButtonNamesAfterTestCleanup()
        {
            methods.TestCleanup();
        }
    }
}
