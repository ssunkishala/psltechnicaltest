using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public  class BBCNewsPage
    {
        private IWebDriver driver;

        public BBCNewsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToBBCNews(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void PerformSearch(string searchText)
        {
            IWebElement search = driver.FindElement(By.XPath("//div[@role='search']"));
            search.Click();
            IWebElement searchInput = driver.FindElement(By.Id("searchInput"));            
            searchInput.Click();
            searchInput.SendKeys(searchText);
            searchInput.SendKeys(Keys.Return);
        }

        public List<IWebElement> GetSearchResults()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElements(By.XPath("//div[@class='ssrcss-rn9nnc-PromoSwitchLayoutAtBreakpoints et5qctl0']")));
           
            return new List<IWebElement>(driver.FindElements(By.XPath("//div[@class='ssrcss-rn9nnc-PromoSwitchLayoutAtBreakpoints et5qctl0']")));
        }    

}
}
