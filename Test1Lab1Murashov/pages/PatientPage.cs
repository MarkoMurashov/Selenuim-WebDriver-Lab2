using OpenQA.Selenium;

namespace TestLab2Murashov.pages
{
    public class PatientPage
    {
        private readonly IWebDriver driver;

        #region UI Elements

        private string Id => driver.FindElement(By.XPath("//*[@id='content']/div[6]/div[2]/span")).Text;
        private IWebElement DeletePatientButton => driver.FindElement(By.XPath("//*[@id='org.openmrs.module.coreapps.deletePatient']/div/div[2]"));
        private IWebElement ReasonArea => driver.FindElement(By.Id("delete-reason"));
        private IWebElement ConfirmDeletingButton => driver.FindElement(By.XPath("//*[@id='delete-patient-creation-dialog']/div[2]/button[1]"));
        private IWebElement HomeButton => driver.FindElement(By.XPath("//*[@id='breadcrumbs']/li[1]/a/i"));

        #endregion

        public PatientPage(IWebDriver driver) => this.driver = driver;

        public FindPage DeletePatient(string reason)
        {
            DeletePatientButton.Click();
            ReasonArea.SendKeys(reason);
            ConfirmDeletingButton.Click();

            return new FindPage(driver);
        }

        public HomePage GoToHomePage()
        {
            HomeButton.Click();

            return new HomePage(driver);
        }
    }
}
