namespace IdnesTestBySelenium.StepsDefinitions
{    
    [Binding]
    public class UserLoginStepDefinitions
    {
        Methods methods = new Methods();

        string idnesUserEmail = "ttestidnes@gmail.com";
        string idnesUserPassword = "Idnes1dnes";

        [Given(@"User go to login page")]
        public void GivenUserGoToLoginPage()
        {           
                methods.GetIdnesLoginPage();
        }

        [Given(@"User set right e-mail")]
        public void GivenUserSetRightE_Mail()
        {
            methods.InputTextByName("email", idnesUserEmail);            
        }

        [Given(@"User click on Continue button")]
        public void GivenUserClickOnContinueButton()
        {
            methods.ClickOnElementById("fLogin");            
        }

        [Given(@"User set right password")]
        public void GivenUserSetRightPassword()
        {
            methods.InputTextByName("pass", idnesUserPassword);            
        }

        [When(@"User click on Login button")]
        public void WhenUserClickOnLoginButton()
        {
            methods.ClickOnElementById("fLoginPass");            
        }

        [Then(@"User is loged to account")]
        public void ThenUserIsLogedToAccount()
        {
            methods.WaitForVisibleElementById(10, "fLogout");            
        }

        [TestCleanup]
        public void Cleanup() 
        {
            methods.TestCleanup();
        }
    }
}
