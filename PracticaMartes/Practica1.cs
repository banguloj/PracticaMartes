using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Tweeter
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheTweeterTest()
        {
            driver.Navigate().GoToUrl("https://twitter.com/login/error?redirect_after_login=%2Ftweeter%3Flang%3Des");
            driver.FindElement(By.XPath("(//input[@name='session[username_or_email]'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@name='session[username_or_email]'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@name='session[username_or_email]'])[2]")).SendKeys("banguloj@gmail.com");
            driver.FindElement(By.XPath("(//input[@name='session[password]'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@name='session[password]'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@name='session[password]'])[2]")).SendKeys("B4ngul0j");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.Id("user-dropdown-toggle")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Click();
            driver.Close();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
