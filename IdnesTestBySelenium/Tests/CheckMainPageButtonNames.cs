namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class CheckMainPageButtonNames
    {
        private Methods methods = new Methods();        

        [TestInitialize]
        public void SetupBeforeTest()
        {
            methods.GetIdnesMainPage();
            methods.MaximizeWindow();
        }

        [TestMethod]
        public void MainPageUserLogin_ShouldPass()
        {            
            methods.ClickOnElementById("didomi-notice-learn-more-button");
            methods.ClickOnElementByCss("button[class='didomi-components-button didomi-button didomi-button-standard standard-button']");
            methods.VerifyButtonNameByLinkText("Přihlásit", "Přihlásit");
        }

        [TestMethod]
        public void MainPageMenu_ShouldPass()
        {            
            methods.ClickOnElementById("didomi-notice-learn-more-button");
            methods.ClickOnElementByCss("button[class='didomi-components-button didomi-button didomi-button-standard standard-button']");
            methods.VerifyButtonNameByCss(".ico-menu", "Menu", "Menu");            
        }

        [TestMethod]
        public void MainPageIphRow3Zpravy_ShouldPass()
        {            
            methods.ClickOnElementById("didomi-notice-learn-more-button");
            methods.ClickOnElementByCss("button[class='didomi-components-button didomi-button didomi-button-standard standard-button']");
            methods.VerifyButtonNameByCss(".ico-menu", "Zprávy", "Zprávy");
        }

        [TestMethod]
        public void MainPageIphRow3Kraje_ShouldPass()
        {         
            methods.ClickOnElementById("didomi-notice-learn-more-button");
            methods.ClickOnElementByCss("button[class='didomi-components-button didomi-button didomi-button-standard standard-button']");
            methods.VerifyButtonNameByCss(".ico-menu", "Kraje", "Kraje");
        }

        [TestCleanup]
        public void ButtonNamesAfterTestCleanup()
        {
            methods.TestCleanup();
        }
    }
}
