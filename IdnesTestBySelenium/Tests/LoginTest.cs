﻿namespace IdnesTestBySelenium.Tests
{
    [TestClass]
    public class LoginTest
    {        
        Methods methods = new Methods();
        string idnesUserEmail = "ttestidnes@gmail.com";
        string idnesUserPasswrod = "Idnes1dnes";

        [SetUp]
        public void SetupLoginTest()
        {
            methods.SetupBeforeTest();
        }

        [TestMethod]
        public void UserLogin_ShouldPass()
        {
            methods.GetIdnesLoginPage();
            methods.InputTextByName("email", idnesUserEmail);
            methods.ClickOnElementById("fLogin");
            methods.InputTextByName("pass", idnesUserPasswrod);
        }

        [TestCleanup]
        public void CleanupLoginTests() 
        {
            methods.TestCleanup();
        }
    }
}
