using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace TestLab2Murashov.pages
{
    class LoginPage
    {
        private readonly IWebDriver driver;

        private IWebElement usernameTextbox => driver.FindElement(By.Id("username"));
        private IWebElement pwdTextBox => driver.FindElement(By.Id("password"));
        private IWebElement regDeskbBtn => driver.FindElement(By.Id("Registration Desk"));
        private IWebElement loginBtn => driver.FindElement(By.Id("loginButton"));

        public LoginPage(IWebDriver driver) => this.driver = driver;

        public void Login(string logName, string pwd)
        {
            usernameTextbox.SendKeys(logName);
            pwdTextBox.SendKeys(pwd);

            regDeskbBtn.Click();
            loginBtn.Click();
        }
    }
}
