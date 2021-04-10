
using OpenQA.Selenium;
using System.Threading;

namespace TestLab2Murashov.pages
{
    public class FindPage
    {
        private readonly IWebDriver driver;

        private IWebElement SearchArea => driver.FindElement(By.Id("patient-search"));
        private IWebElement PatientRecord => driver.FindElement(By.XPath("//td[contains(.,'" + PatientName + "')]"));
        private IWebElement PatientRecordNotExist => driver.FindElement(By.ClassName("dataTables_empty"));


        public static string PatientName { get; set; }

        public FindPage(IWebDriver driver) => this.driver =  driver;

        public bool FindPatient()
        {
            SearchArea.Clear();
            SearchArea.SendKeys(PatientName);

            return PatientRecord.Displayed;
        }

        public bool IsNoResult()
        {
            SearchArea.Clear();
            SearchArea.SendKeys(PatientName);

            Thread.Sleep(2000);

            return PatientRecordNotExist.Displayed;
        }

        public PatientPage GoToPatientRecord()
        {
            PatientRecord.Click();

            return new PatientPage(driver);
        }
    }
}
