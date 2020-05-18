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
        string korisnicko = "DaviDo";

        /* comment */

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
                inputUserName.SendKeys(korisnicko);
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

        [Test]
        [Category("SC")]
        public void Login()
        {

            Navigate("http://shop.qa.rs/");

            IWebElement signIn = driver.FindElement(By.XPath("//a[@href='/login']"));
            if (signIn.Displayed && signIn.Enabled)
            {
                signIn.Click();
            }
            IWebElement username = driver.FindElement(By.Name("username"));
            if (username.Displayed && username.Enabled)
            {
                username.SendKeys(korisnicko);
            }

            IWebElement inputPassword = driver.FindElement(By.Name("password"));

            if (inputPassword.Displayed && inputPassword.Enabled)
            {
                inputPassword.SendKeys(password);
            }

            IWebElement sigNIn = driver.FindElement(By.Name("login"));
            if (sigNIn.Displayed && sigNIn.Enabled)
            {
                sigNIn.Click();
            }
        }

        [Test]
        [Category("SC")]
        public void CheckCartIsEmpty()
        {
            Login();
            IWebElement signIn = driver.FindElement(By.XPath("//a[@href='/cart']"));
            if (signIn.Displayed && signIn.Enabled)
            {
                signIn.Click();
            }

            IWebElement alert = driver.FindElement(By.XPath("//div[@class='alert alert-warning']"));
            if (alert.Displayed && alert.Enabled)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        [Category("SC")]
        [TestCase("DaviDo", "LOzinka2589")]
        [TestCase("DaviDo", "pogresna sifra")]
        [TestCase("pogresno korisnicko", "LOzinka2589")]
        [TestCase("pogresno korisnicko", "pogresna sifra")]
        public void Login_annotation(string korisnickoIme, string sifra)
        {

            Navigate("http://shop.qa.rs/");

            IWebElement signIn = driver.FindElement(By.XPath("//a[@href='/login']"));
            if (signIn.Displayed && signIn.Enabled)
            {
                signIn.Click();
            }
            IWebElement username = driver.FindElement(By.Name("username"));
            if (username.Displayed && username.Enabled)
            {
                username.SendKeys(korisnickoIme);
            }

            IWebElement inputPassword = driver.FindElement(By.Name("password"));

            if (inputPassword.Displayed && inputPassword.Enabled)
            {
                inputPassword.SendKeys(sifra);
            }

            IWebElement sigNIn = driver.FindElement(By.Name("login"));
            if (sigNIn.Displayed && sigNIn.Enabled)
            {
                sigNIn.Click();
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
