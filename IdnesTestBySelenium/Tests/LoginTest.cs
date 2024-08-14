namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class LoginTest
    {        
        Methods methods = new Methods();
        string idnesUserEmail = "ttestidnes@gmail.com";
        string idnesUserPassword = "Idnes1dnes";

        [TestMethod]
        public void UserLogin_ShouldPass()
        {            
            methods.GetIdnesLoginPage();
            methods.InputTextByName("email", idnesUserEmail);
            methods.ClickOnElementById("fLogin");
            methods.InputTextByName("pass", idnesUserPassword);
            methods.ClickOnElementById("fLoginPass");
            methods.WaitForVisibleElementById(10, "fLogout");
        }

        [TestCleanup]
        public void CleanupLoginTests() 
        {
            methods.TestCleanup();
        }
    }
}
