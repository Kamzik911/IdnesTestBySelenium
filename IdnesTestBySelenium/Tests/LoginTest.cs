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
        public void UserLogin_Success()
        {               
            methods.InputTextByName(definedElements.loginEmailField, loginsData.idnesUserEmail);
            methods.ClickOnElementById(definedElements.loginContinueToPassword);
            methods.InputTextByName(definedElements.loginPasswordField, loginsData.idnesUserPassword);
            methods.ClickOnElementById(definedElements.loginContinueToLogin);
            methods.WaitForVisibleElementById(10, definedElements.logoutButton);
        }

        [TestMethod]
        public void UserLogin_InputWrongEmail()
        {
            methods.InputTextByName(definedElements.loginEmailField, loginsData.idnesWrongUserEmail);
            methods.ClickOnElementById(definedElements.loginContinueToPassword);
            methods.WaitForVisibleElementById(10, definedElements.loginRegistryButtonNameById);
        }

        [TestCleanup]
        public void CleanupLoginTests() 
        {
            methods.TestCleanup();
        }
    }
}
