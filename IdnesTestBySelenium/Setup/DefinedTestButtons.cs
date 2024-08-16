namespace IdnesTestBySelenium.Setup
{    
    class DefinedTestButtons
    {
        //Denny/AllowAllCookies buttons
        public string cookiesAdvancedSettings = "Podrobné nastavení";
        public string allCookiesDennyButton = "button[class='didomi-components-button didomi-button didomi-button-standard standard-button']";
        public string allCookiesDennyText = "#noconsent";

        //LoginTest buttons
        public string loginEmailField = "email";
        public string loginContinueToPassword = "fLogin";
        public string loginPasswordField = "pass";
        public string loginContinueToLogin = "fLoginPass";
        public string logoutButton= "fLogout";
    }
}
