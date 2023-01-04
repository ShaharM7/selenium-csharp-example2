using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenQA.Selenium;
using SeenityAutomation.Selenium.Navigation;
using SeenityAutomation.Selenium.Pages;
using static SeenityAutomation.Selenium.TestData;

namespace SeenityAutomation.Selenium
{
    public class Tests
    {
        protected IWebDriver? ChromeBrowser;
        protected PageNavigator? PageNavigator;

        [SetUp]
        public void SetUp()
        {
            IWebHost webHostBuilder = new WebHostBuilder().UseStartup<Startup>().Build();

            ChromeBrowser = webHostBuilder.Services.GetRequiredService<IWebDriver>();
            PageNavigator = webHostBuilder.Services.GetRequiredService<PageNavigator>();
        }

        [Test]
        public void Test1()
        {
            HomePage? homePage = PageNavigator?.NavigateToHomePage();
            homePage!.ConfirmTheRegulations();
            homePage!.ChooseNewCase();
            homePage!.SearchForCaseMonthYear(CorrectCaseNumber);
            homePage!.SearchForCaseNumber(CorrectCaseNumber);
            homePage.LocateCase();
            
            Assert.IsTrue(homePage!.IsCaseExistInTble());
        }

        [TearDown]
        public void ShutDown()
        {
            ChromeBrowser?.Quit();
        }
    }
}