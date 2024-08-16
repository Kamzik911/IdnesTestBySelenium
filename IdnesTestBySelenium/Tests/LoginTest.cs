namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class LoginTest
    {        
        Methods methods = new Methods();
        DefinedLoginsData loginsData = new DefinedLoginsData();
        DefinedTestButtons definedTestButtons = new DefinedTestButtons();

        [TestInitialize]
        public void SetupLoginTests()
        {

            methods.GetIdnesLoginPage();            
        }

        [TestMethod]
        public void UserLogin_ShouldPass()
        {               
            methods.InputTextByName(definedTestButtons.loginEmailField, loginsData.idnesUserEmail);
            methods.ClickOnElementById(definedTestButtons.loginContinueToPassword);
            methods.InputTextByName(definedTestButtons.loginPasswordField, loginsData.idnesUserPassword);
            methods.ClickOnElementById(definedTestButtons.loginContinueToLogin);
            methods.WaitForVisibleElementById(10, definedTestButtons.logoutButton);
        }

        [TestCleanup]
        public void CleanupLoginTests() 
        {
            methods.TestCleanup();
        }
    }
}
