using OpenQA.Selenium.Firefox;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace freedompay_qa_multi
{
    class Program
    {
        public static IWebDriver driver;

        static void Main(string[] args)
        {
            openBrowser();
            loginToFreedomPayEnterprise();

            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("")));
            waitForElementPresent(".//*[@id='bodyContainer']/div[1]/div/div[2]/ul[1]/li[8]/a");
            driver.FindElement(By.XPath(".//*[@id='bodyContainer']/div[1]/div/div[2]/ul[1]/li[8]/a")).Click();

           // wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("")));
            waitForElementPresent(".//*[@id='bodyContainer']/div[1]/div/div[2]/ul[1]/li[8]/ul/li[3]");
            driver.FindElement(By.XPath(".//*[@id='bodyContainer']/div[1]/div/div[2]/ul[1]/li[8]/ul/li[3]")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".fa.fp-component-icon.fa-lg.fa-caret-right.fp-component-icon-active")));
            driver.FindElement(By.CssSelector(".fa.fp-component-icon.fa-lg.fa-caret-right.fp-component-icon-active")).Click();
          
            // wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='divNavTree']/div[2]/div/div/div[2]/div[2]/div/div[1]/span[1]")));
            waitForElementPresent(".//*[@id='divNavTree']/div[2]/div/div/div[2]/div[2]/div/div[1]/span[1]");
            driver.FindElement(By.XPath(".//*[@id='divNavTree']/div[2]/div/div/div[2]/div[2]/div/div[1]/span[1]")).Click();

            waitForElementPresent(".//*[@id='divNavTree']/div[2]/div/div/div[2]/div[2]/div/div[2]/div[4]/div/div[1]/span[1]");
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='divNavTree']/div[2]/div/div/div[2]/div[2]/div/div[2]/div[4]/div/div[1]/span[1]")));
            string bmw = driver.FindElements(By.XPath(".//*[@id='divNavTree']/div[2]/div/div/div[2]/div[2]/div/div[2]/div[*]")).ToString();
            Console.WriteLine(bmw);
            quitBrowsers();


        }
        public static void waitForElementPresent(String elementPath) {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 1, 15));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(elementPath)));
        }
        public static void openBrowser()
        {
            FirefoxProfileManager profile = new FirefoxProfileManager();
            FirefoxProfile myprofile = profile.GetProfile("freedom");
            driver = new FirefoxDriver();
            //  RemoteWebDriver driver = new FirefoxDriver(myprofile);
        }

        public static void quitBrowsers()
        {
            driver.Quit();
        }
        public static void loginToFreedomPayEnterprise()
        {
            driver.Navigate().GoToUrl("http://enterprise.uat.freedompay.com/EnterpriseAdmin");
            Console.WriteLine("Browser Opened");
            driver.FindElement(By.Id("EnterpriseCode")).SendKeys("FPE001");
            driver.FindElement(By.Id("UserName")).SendKeys("QaFpAdmin");
            driver.FindElement(By.Id("Password")).SendKeys("Qatester#1");
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
        }
    }
}
