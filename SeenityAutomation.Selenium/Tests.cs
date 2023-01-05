using Allure.Net.Commons;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using SeenityAutomation.Selenium.Navigation;
using SeenityAutomation.Selenium.Pages;
using static SeenityAutomation.Selenium.TestData;

namespace SeenityAutomation.Selenium
{
    [TestFixture]
    [AllureNUnit]
    public class Tests
    {
        private const string APP_SETTINGS_JSON_PATH = "appsettings.json";

        protected IWebDriver? ChromeBrowser;
        protected PageNavigator? PageNavigator;

        [SetUp]
        public void SetUp()
        {
            IWebHost webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(new ConfigurationBuilder().AddJsonFile(APP_SETTINGS_JSON_PATH).Build())
                .Build();

            ChromeBrowser = webHostBuilder.Services.GetRequiredService<IWebDriver>();
            PageNavigator = webHostBuilder.Services.GetRequiredService<PageNavigator>();
        }

        [Test]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        public void WhenSearchCorrectCaseNumber_ThenCaseAppearInCasesTable()
        {
            HomePage? homePage = PageNavigator?.NavigateToHomePage();
            homePage!.ConfirmTheRegulations();
            homePage!.ChooseNewCase();
            homePage!.SearchForCaseMonthYear(CorrectCaseNumber);
            homePage!.SearchForCaseNumber(CorrectCaseNumber);
            homePage.LocateCase();

            Assert.IsTrue(homePage!.IsCaseExistInTable());
        }

        [TearDown]
        public void ShutDown()
        {
            ChromeBrowser?.Quit();
        }
    }
}