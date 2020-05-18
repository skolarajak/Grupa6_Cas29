using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Cas29
{
    class SeleniumTests
    {
        IWebDriver driver;
        WebDriverWait wait;

        [Test]
        [Category("Kategorija"), Category("Kat.2")]
        [Ignore("Ignored")]
        public void TestKreirajNovogKorisnika()
        {
            Navigate("http://test.qa.rs");

            IWebElement linkCreate = wait.Until(EC.ElementIsVisible(By.LinkText("Kreiraj novog korisnika")));
            if (linkCreate.Displayed && linkCreate.Enabled)
            {
                linkCreate.Click();
            }

            IWebElement inputName = wait.Until(EC.ElementIsVisible(By.Name("ime")));
            if (inputName.Displayed && inputName.Enabled)
            {
                inputName.SendKeys("Pera");
            }

            IWebElement inputLastName = driver.FindElement(By.Name("prezime"));
            if (inputLastName.Displayed && inputLastName.Enabled)
            {
                inputLastName.SendKeys("Peric");
            }

            IWebElement inputUserName = driver.FindElement(By.Name("korisnicko"));
            if (inputUserName.Displayed && inputUserName.Enabled)
            {
                inputUserName.SendKeys("pperic");
            }

            IWebElement inputEmail = driver.FindElement(By.Name("email"));
            if (inputEmail.Displayed && inputEmail.Enabled)
            {
                inputEmail.SendKeys("pperic@email.commm");
            }

            IWebElement inputPhone = driver.FindElement(By.Name("telefon"));
            if (inputPhone.Displayed && inputPhone.Enabled)
            {
                inputPhone.SendKeys("012/345-6789");
            }

            IWebElement inputCountry = driver.FindElement(By.Name("zemlja"));
            if (inputCountry.Displayed && inputCountry.Enabled)
            {
                SelectElement selectCountry = new SelectElement(inputCountry);
                selectCountry.SelectByText("Sweden");
            }

            IWebElement inputCity = wait.Until(EC.ElementIsVisible(By.Name("grad")));
            if (inputCity.Displayed && inputCity.Enabled)
            {
                SelectElement selectCity = new SelectElement(inputCity);
                selectCity.SelectByIndex(1);
            }

            IWebElement inputStreet = driver.FindElement(By.XPath("//div[@id='address']//input"));
            if (inputStreet.Displayed && inputStreet.Enabled)
            {
                inputStreet.SendKeys("Ulica Glavna 45");
            }

            IWebElement inputGender = driver.FindElement(By.Id("pol_m"));
            if (inputGender.Displayed && inputGender.Enabled)
            {
                inputGender.Click();
            }

            IWebElement buttonRegister = driver.FindElement(By.Name("register"));
            if (buttonRegister.Displayed && buttonRegister.Enabled)
            {
                buttonRegister.Click();
            }
        }

        private void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
