using OpenQA.Selenium;
using System.Threading;

namespace TestLab2Murashov.pages
{
    class MainHomePage
    {
        private readonly IWebDriver driver;

        public MainHomePage(IWebDriver driver) => this.driver = driver;

        public HomePage HomePage => new HomePage(driver);

        public void GoToWebsite()
        {
            driver.Navigate().GoToUrl("https://openmrs.org/demo/");
            driver.Manage().Window.Maximize();
        }

        public LoginPage GoToDemoPage()
        {
            var demoButton = driver.FindElement(By.XPath("//a[@href='http://demo.openmrs.org/']"));
            demoButton.Click();

            return new LoginPage(driver);
        }

    }
}
