using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages
{
    public class BBCWeatherPage
    {
        private IWebDriver driver;
        public BBCWeatherPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void WeatherSearch(string searchText)
        {
            IWebElement weathersearch = driver.FindElement(By.ClassName("orb-nav-weather"));
            weathersearch.Click();
            Thread.Sleep(10);
            IWebElement weathersearchInput = driver.FindElement(By.Id("ls-c-search__input-label"));
            weathersearchInput.Click();
            weathersearchInput.SendKeys(searchText);
            weathersearchInput.SendKeys(Keys.Return);
        }

        public List<IWebElement> GetWeatherReport()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.Id("daylink-0")));
            return new List<IWebElement>(driver.FindElements(By.XPath("//div[@class='wr-day-carousel__viewport wr-js-day-carousel-scroll']//div[@class='wr-day-carousel__scrollable']//ol//li")));
        }
    }
}
