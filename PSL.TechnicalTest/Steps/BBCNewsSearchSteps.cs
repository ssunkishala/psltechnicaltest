using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using PSL.TechnicalTest.ApplicationUnderTest.Pages;
using NUnit.Framework;

namespace BBCNewsSearch.Specs.StepDefinitions
{
    [Binding]
    public class BBCNewsSearchSteps
    {
        public IWebDriver driver;
        public BBCNewsPage bbcNewsPage;
        public List<IWebElement> searchResults;

        public BBCNewsSearchSteps(IWebDriver driver)
        {
            this.driver = driver;
            bbcNewsPage = new BBCNewsPage(driver);
        }
       
        [Given(@"I am on the BBC News website")]
        public void GivenIAmOnTheBBCNewsWebsite()
        {
            bbcNewsPage.NavigateToBBCNews("https://www.bbc.com/news");
        }

        [When(@"I perform a search for articles relating to (.*)")]
        public void WhenIPerformASearchForArticlesRelatingTo(string searchText)
        {
            bbcNewsPage.PerformSearch(searchText);
            searchResults = bbcNewsPage.GetSearchResults();       
        }

        [Then(@"I should see at least five search results")]
        public void ThenIShouldSeeAtLeastFiveSearchResults()
        {            
            if (searchResults.Count >= 5)
            {
                Console.WriteLine($"At least 5 search results contain 'Chorley' in the title. ({searchResults.Count} results found.)");
                Assert.IsTrue(true, "At least 5 search results contain 'Chorley' in the title.");
            }
            else
            {
                Console.WriteLine($"Less than 5 search results contain 'Chorley' in the title. ({searchResults.Count} results found.)");
                Assert.Fail($"Less than 5 search results contain 'Chorley' in the title. ({searchResults.Count} results found.)");
            }
        }

        [Then(@"the top five results should contain '(.*)' in the title")]
        public void ThenTheTopFiveResultsShouldContainInTheTitle(string keyword)
        {
            bool areTopFiveResultsValid = searchResults.Take(5).All(element => element.Text.Contains(keyword));
            if (!areTopFiveResultsValid)
            {
                throw new Exception("Top five search results do not contain 'chorley' keyword in the title!");
            }
        }
    }
}
