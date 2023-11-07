using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using PSL.TechnicalTest.ApplicationUnderTest.Pages;
using NUnit.Framework;


namespace PSL.TechnicalTest.Steps
{
    [Binding]
    public class BBCWeatherReportSteps
    {
        public BBCWeatherPage bbcWeatherPage;
        public IWebDriver driver;  
        public List<IWebElement> searchWeatherReport;

        public BBCWeatherReportSteps(IWebDriver driver)
        {
            this.driver = driver;
            bbcWeatherPage = new BBCWeatherPage(driver);
        }
        [When(@"I navigate to the weather page")]
        public void WhenINavigateToTheWeatherPage()
        {
            bbcWeatherPage.WeatherSearch("Chorley");
            searchWeatherReport = bbcWeatherPage.GetWeatherReport();
        }

        [Then(@"I should see the weather details for Chorley")]
        public void ThenIShouldSeeTheWeatherDetailsForChorley()
        {
            if (searchWeatherReport.Count > 0)
            {
                Console.WriteLine($"Weather report in 'Chorley' is displayed)");
                Assert.IsTrue(true, "Weather report in 'Chorley' is displayed");
            }
            else
            {
                Console.WriteLine($"Weather report is not displayed");
                Assert.Fail($"Weather report is not displayed)");
            }
        }
    }
}
