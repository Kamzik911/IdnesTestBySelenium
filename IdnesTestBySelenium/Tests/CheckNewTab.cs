namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class CheckNewTab
    {
        Methods methods = new Methods();
        DefinedElements definedElements = new DefinedElements();

        [TestInitialize]
        public void SetupBeforeTest()
        {
            methods.MaximizeWindow();
            methods.GetIdnesMainPage();
            methods.ClickOnElementByCss(definedElements.allCookiesAllowButton);
        }

        [TestMethod]
        public void CheckNewsTabVisibility()
        {
            methods.WaitForVisibleElementByCss(10, definedElements.NewsTabElement);
        }

        [TestMethod]
        public void CheckLatestButton()
        {
            methods.VerifyButtonNameByLinkText("Nejnovější", "Nejnovější");
        }

        [TestCleanup]
        public void ButtonNamesAfterTestCleanup()
        {
            methods.TestCleanup();
        }
    }
}
