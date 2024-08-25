namespace IdnesTestBySelenium.Setup
{    
    class DefinedElements
    {
        //Denny/AllowAllCookies elements
        public string cookiesAdvancedSettings = "Podrobné nastavení";
        public string allCookiesDennyButton = "button[class='didomi-components-button didomi-button didomi-button-standard standard-button']";
        public string allCookiesDennyText = "#noconsent";
        public string allCookiesAllowButton = "a[class='btn-cons contentwall_ok']";
        public string allCookiesAssesmentText = "Vážený čtenáři, v podrobném nastavení, které jste zvolil, bychom nedostali potřebné souhlasy k cílení reklamy nutné pro další financování našich novin.";

        //LoginTest elements
        public string loginEmailField = "email";
        public string loginContinueToPassword = "fLogin";
        public string loginPasswordField = "pass";
        public string loginContinueToLogin = "fLoginPass";
        public string logoutButton= "fLogout";
        public string inputWrongEmail = "Registrujte se a využívejte všech možností webu iDNES naplno";
        public string inputWrongEmailAssertText = "p[id='benefit-preview']";
        public string loginRegistryButtonNameById = "fCreate";

        //CheckMainPageButtonNames elements

    }
}
