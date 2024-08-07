namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class DennyAllCookies
    {
        Methods methods = new Methods();        

        [SetUp]
        public void SetupBeforeTests()
        {
            methods.SetupBeforeTest();
        }

        [TestMethod]
        public void DennyAllCookies_ShouldPass()
        {
            methods.GetIdnesMainPage();
            methods.ClickOnElementById("didomi-notice-learn-more-button");
            methods.ClickOnElementByCss("button[class='didomi-components-button didomi-button didomi-button-standard standard-button']");            
        }

        [TestMethod]
        public void AllowAllCookies_ShouldPass()
        {
            methods.GetIdnesMainPage();
            methods.ClickOnElementById("didomi-notice-agree-button");            
        }
        
        [TestCleanup]
        public void TestCleanup() 
        {
            methods.TestCleanup();
        }
    }
}
