using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using PSL.TechnicalTest.ApplicationUnderTest.Pages;
using NUnit.Framework;


namespace PSL.TechnicalTest.Steps
{
    [Binding]
    public class BBCSportsSteps
    {
        public BBCSportsPage bbcSportsPage;
        public IWebDriver driver;
        public List<IWebElement> sportsDetails;

        public BBCSportsSteps(IWebDriver driver)
        {
            this.driver = driver;
            bbcSportsPage = new BBCSportsPage(driver);            
        }


        [When(@"I navigate to the the sports page")]
        public void WhenINavigateToTheTheSportsPage()
        {
            bbcSportsPage.SportsPage();
            
        }
        [Then(@"I should see the sports details")]
        public void ThenIShouldSeeTheSportsDetails()
        {
            sportsDetails = bbcSportsPage.GetSportsDetails();
            if (sportsDetails.Count > 0)
            {
                Console.WriteLine($"Sports details are displayed)");
                Assert.IsTrue(true, "Sports details are displayed");
            }
            else
            {
                Console.WriteLine($"Sports details are displayed");
                Assert.Fail($"Sports details are displayed)");
            }
        }

    }
}
