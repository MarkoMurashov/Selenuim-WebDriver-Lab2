using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TestLab2Murashov.Models;
using TestLab2Murashov.pages;

namespace Test1Lab1Murashov
{
    public class Tests
    {
        public const string LOGNAME = "admin";
        public const string PASSWORD = "Admin123";

        private IWebDriver driver;

        private HomePage Login(string login, string pass)
        {
            var mainHomePage = new MainHomePage(driver);
            mainHomePage.GoToWebsite();
            var loginPage = mainHomePage.GoToDemoPage();

            Thread.Sleep(2000);

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            Thread.Sleep(2000);

            loginPage.Login(login, pass);

            return mainHomePage.HomePage;
        }

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestLogin()
        {
            Assert.AreEqual(LOGNAME, Login(LOGNAME, PASSWORD).IsUserAdmin.Text);
        }

        [Test]
        public void TestAddUser()
        {
            var homePage = Login(LOGNAME, PASSWORD);
            var addPage = homePage.GoToAddPatient();

            var patient = new Patient();
            patient.GivenName = "Mark";
            patient.MiddleName = string.Empty;
            patient.FamilyName = "Murashov";
            patient.Gender = "M";
            patient.Day = "11";
            patient.Month = "5";
            patient.Year = "2000";
            patient.Address = "Dnipro";
            patient.Phone = "1234567890";

            var patientPage =  addPage.AddPatient(patient, out bool error);

            Thread.Sleep(2000);

            patientPage.GoToHomePage();


            FindPage.PatientName = "Mark Murashov";
            var findPage = homePage.GoToFindPatient();

            Assert.IsTrue(findPage.FindPatient());
        }

        [Test]
        public void TestDeleteUser()
        {
            var homePage = Login(LOGNAME, PASSWORD);

            FindPage.PatientName = "Mark Murashov";
            var findPage = homePage.GoToFindPatient();
            findPage.FindPatient();

            var patientPage = findPage.GoToPatientRecord();
            findPage = patientPage.DeletePatient("ABC");

            Thread.Sleep(5000);

            Assert.IsTrue(findPage.IsNoResult());
        }

        [Test]
        public void TestInvalidLogin()
        {
            Assert.IsTrue(Login("wrong", PASSWORD).ErrorMessage);
        }

        [Test]
        public void TestInvalidNameAdd()
        {
            var homePage = Login(LOGNAME, PASSWORD);
            var addPage = homePage.GoToAddPatient();

            var patient = new Patient();
            patient.GivenName = "Mark";

            addPage.AddPatient(patient, out bool error);
            Assert.IsTrue(error);
        }

        [Test]
        public void TestInvalidGenderAdd()
        {
            var homePage = Login(LOGNAME, PASSWORD);
            var addPage = homePage.GoToAddPatient();

            var patient = new Patient();
            patient.GivenName = "Mark";
            patient.MiddleName = string.Empty;
            patient.FamilyName = "Murashov";
            patient.Gender = "MF";

            addPage.AddPatient(patient, out bool error);

            Assert.IsTrue(error);
        }

        [Test]
        public void TestInvalidDateAdd()
        {
            var homePage = Login(LOGNAME, PASSWORD);
            var addPage = homePage.GoToAddPatient();

            var patient = new Patient();
            patient.GivenName = "Mark";
            patient.MiddleName = string.Empty;
            patient.FamilyName = "Murashov";
            patient.Gender = "M";
            patient.Day = "assdf";
            patient.Month = "5";
            patient.Year = "2000";

            addPage.AddPatient(patient, out bool error);

            Assert.IsTrue(error);
        }

        [Test]
        public void TestInvalidAddressAdd()
        {
            var homePage = Login(LOGNAME, PASSWORD);
            var addPage = homePage.GoToAddPatient();

            var patient = new Patient();
            patient.GivenName = "Mark";
            patient.MiddleName = 
            patient.FamilyName = "Murashov";
            patient.Gender = "M";
            patient.Day = "11";
            patient.Month = "5";
            patient.Year = "2000";
            patient.Address = string.Empty; 

            addPage.AddPatient(patient, out bool error);

            Assert.IsTrue(error);
        }

    }
}