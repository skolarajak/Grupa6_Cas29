using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Cas29
{
    class SeleniumTests_Cas30
    {
        IWebDriver driver;
        WebDriverWait wait;

        string email = "DDavidovic@jum.mdok";
        string password = "LOzinka2589";
        string username = "DaviDo";

        [Test]
        [Category("SC")]
        public void Registration()
        {
            Navigate("http://shop.qa.rs/");

            IWebElement register = driver.FindElement(By.XPath("//a[@href='/register']"));
            if (register.Displayed && register.Enabled)
            {
                register.Click();
            }
            IWebElement inputName = driver.FindElement(By.Name("ime"));
            if (inputName.Displayed && inputName.Enabled)
            {
                inputName.SendKeys("David");
            }

            IWebElement inputSurname = driver.FindElement(By.Name("prezime"));

            if (inputSurname.Displayed && inputSurname.Enabled)
            {
                inputSurname.SendKeys("Davidovic");
            }

            IWebElement inputEmail = driver.FindElement(By.Name("email"));

            if (inputEmail.Displayed && inputEmail.Enabled)
            {
                inputEmail.SendKeys(email);
            }

            IWebElement inputUserName = driver.FindElement(By.Name("korisnicko"));

            if (inputUserName.Displayed && inputUserName.Enabled)
            {
                inputUserName.SendKeys(username);
            }

            IWebElement inputPassword = driver.FindElement(By.Name("lozinka"));

            if (inputPassword.Displayed && inputPassword.Enabled)
            {
                inputPassword.SendKeys(password);
            }

            IWebElement passwordAgain = driver.FindElement(By.Name("lozinkaOpet"));

            if (passwordAgain.Displayed && passwordAgain.Enabled)
            {
                passwordAgain.SendKeys(password);
            }

            IWebElement registerNew = driver.FindElement(By.Name("register"));

            if (registerNew.Displayed && registerNew.Enabled)
            {
                registerNew.Click();
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
