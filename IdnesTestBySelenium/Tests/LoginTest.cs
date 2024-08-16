namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class LoginTest
    {        
        Methods methods = new Methods();
        DefinedLoginsData loginsData = new DefinedLoginsData();
        DefinedElements definedElements = new DefinedElements();

        [TestInitialize]
        public void SetupLoginTests()
        {

            methods.GetIdnesLoginPage();            
        }

        [TestMethod]
        public void UserLogin_ShouldPass()
        {               
            methods.InputTextByName(definedElements.loginEmailField, loginsData.idnesUserEmail);
            methods.ClickOnElementById(definedElements.loginContinueToPassword);
            methods.InputTextByName(definedElements.loginPasswordField, loginsData.idnesUserPassword);
            methods.ClickOnElementById(definedElements.loginContinueToLogin);
            methods.WaitForVisibleElementById(10, definedElements.logoutButton);
        }

        [TestCleanup]
        public void CleanupLoginTests() 
        {
            methods.TestCleanup();
        }
    }
}
