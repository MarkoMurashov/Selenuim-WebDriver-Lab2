using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestLab2Murashov.pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        public IWebElement IsUserAdmin => driver.FindElement(By.XPath("//li[contains(.,'admin')]"));

        public bool ErrorMessage => driver.FindElement(By.Id("error-message")).Displayed;


        public HomePage(IWebDriver driver) => this.driver = driver;

        public AddPage GoToAddPatient()
        {
            driver.FindElement(By.XPath("//a[@href='/openmrs/registrationapp/registerPatient.page?appId=referenceapplication.registrationapp.registerPatient']"))
                .Click();

            return new AddPage(driver);
        }

        public FindPage GoToFindPatient()
        {
            driver.FindElement(By.XPath("//a[@href='/openmrs/coreapps/findpatient/findPatient.page?app=coreapps.findPatient']"))
                .Click();

            return new FindPage(driver);
        }
    }
}
