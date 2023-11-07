using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public class BBCSportsPage
    {
        private IWebDriver driver;
        public BBCSportsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void SportsPage()
        {
            IWebElement sportsearch = driver.FindElement(By.ClassName("orb-nav-sport"));
            sportsearch.Click();          
        }

        public List<IWebElement> GetSportsDetails()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.XPath("//div//ul[@role='list']//a[@href='/sport']")));
            return new List<IWebElement>(driver.FindElements(By.XPath("//div//ul[@role='list']//li//a[contains(@href,'/sport/')]")));
        }

    }
}
