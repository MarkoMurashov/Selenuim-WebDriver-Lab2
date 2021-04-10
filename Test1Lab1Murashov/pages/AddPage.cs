using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TestLab2Murashov.Models;

namespace TestLab2Murashov.pages
{
    public class AddPage
    {
        private readonly IWebDriver driver;

        #region UI Elements

        private IWebElement GivenNameArea => driver.FindElement(By.Name("givenName"));
        private IWebElement MiddleNameArea => driver.FindElement(By.Name("middleName"));
        private IWebElement FamilyNameArea => driver.FindElement(By.Name("familyName"));
        private IWebElement NameTab => driver.FindElement(By.XPath("//span[contains(.,'Name')]"));
        private IWebElement GenderTab => driver.FindElement(By.Id("genderLabel"));
        private IWebElement BirthdayTab => driver.FindElement(By.Id("birthdateLabel"));
        private IWebElement AddressTab => driver.FindElement(By.XPath("//span[contains(.,'Address')]"));
        private IWebElement PhoneNumberTab => driver.FindElement(By.XPath("//span[contains(.,'Phone Number')]"));
        private IWebElement RelativesTab => driver.FindElement(By.XPath("//span[contains(.,'Relatives')]"));
        private IWebElement ConfirmTab => driver.FindElement(By.Id("confirmation_label"));
        private IWebElement GenderList => driver.FindElement(By.Id("gender-field"));
        private IWebElement DayArea => driver.FindElement(By.Name("birthdateDay"));
        private IWebElement MonthsList => driver.FindElement(By.Name("birthdateMonth"));
        private IWebElement YearArea => driver.FindElement(By.Name("birthdateYear"));
        private IWebElement AdressArea => driver.FindElement(By.Id("address1"));
        private IWebElement PhoneNumberArea => driver.FindElement(By.Name("phoneNumber"));
        private IWebElement ConfirmButton => driver.FindElement(By.Id("submit"));

        private bool Error
        {
            get
            {
                try
                {
                   return driver.FindElement(By.ClassName("field-error")).Displayed;
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion

        public AddPage(IWebDriver driver) => this.driver = driver;

        public PatientPage AddPatient(Patient patient, out bool error)
        {
            error = false;
            try
            {

                GivenNameArea.SendKeys(patient.GivenName);
                MiddleNameArea.SendKeys(patient.MiddleName);
                FamilyNameArea.SendKeys(patient.FamilyName);

                GenderTab.Click();
                var genders = new SelectElement(GenderList);
                genders.SelectByValue(patient.Gender);

                BirthdayTab.Click();
                DayArea.SendKeys(patient.Day);
                var months = new SelectElement(MonthsList);
                months.SelectByValue(patient.Month);
                YearArea.SendKeys(patient.Year);

                AddressTab.Click();
                AdressArea.SendKeys(patient.Address);

                PhoneNumberTab.Click();
                PhoneNumberArea.SendKeys(patient.Phone);

                ConfirmTab.Click();
                ConfirmButton.Click();
            }
            catch
            {
                error = true;
                //driver.FindElement(By.XPath("//span[@class='field-error' and not(contains(@style,'display: none')) and @style]")).Displayed;
            }
            

            return new PatientPage(driver);
        }

    }
}
