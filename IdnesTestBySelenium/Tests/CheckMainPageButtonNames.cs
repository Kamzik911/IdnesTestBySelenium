namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class CheckMainPageButtonNames
    {
        private Methods methods = new Methods();     
        private DefinedElements definedElements = new DefinedElements();        

        [TestInitialize]
        public void SetupBeforeTest()
        {               
            methods.MaximizeWindow();            
            methods.GetIdnesMainPage();            
            methods.ClickOnElementByCss(definedElements.allCookiesAllowButton);
        }

        [TestMethod]
        public void MainPageUserLogin_ShouldPass()
        {                      
            methods.VerifyButtonNameByLinkText("Přihlásit", "Přihlásit");
        }

        [TestMethod]
        public void MainPageMenu_ShouldPass()
        {               
            methods.VerifyButtonNameByLinkText("Menu", "Menu");            
        }

        [TestMethod]
        public void MainPageIphRow3Zpravy_ShouldPass()
        {               
            methods.VerifyButtonNameByLinkText("Zprávy", "Zprávy");
        }        

        [TestMethod]
        public void MainPageIphRow3Kraje_ShouldPass()
        {         
            methods.VerifyButtonNameByLinkText("Kraje", "Kraje");
        }

        [TestMethod]
        public void MainPageIphRow3Sport_ShouldPass()
        {
            methods.VerifyButtonNameByLinkText("Sport", "Sport");
        }

        [TestMethod]
        public void MainPageIphRow3Magazines_ShouldPass()
        {
            methods.VerifyButtonNameByLinkText("Magazíny", "Magazíny");
        }

        [TestMethod]
        public void MainPageIphRow3Revues_ShouldPass()
        {
            methods.VerifyButtonNameByLinkText("Revue", "Revue");
        }

        [TestCleanup]
        public void ButtonNamesAfterTestCleanup()
        {
            methods.TestCleanup();
        }
    }
}
