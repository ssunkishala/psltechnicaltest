using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace PSL.TechnicalTest.Hooks
{
    [Binding]
    public class WebDriverHooks
    {
        private IObjectContainer objectContainer;
        private IWebDriver driver;

        public WebDriverHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver(); // You might want to adjust this based on your setup
            objectContainer.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}