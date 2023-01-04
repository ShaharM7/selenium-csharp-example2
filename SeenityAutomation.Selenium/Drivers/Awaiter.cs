using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeenityAutomation.Selenium.Configuration;

namespace SeenityAutomation.Selenium.Drivers
{
    public class Awaiter : WebDriverWait
    {
        public Awaiter(IWebDriver driver, IOptions<AwaiterConfig> awaiterConfig)
            : base(driver, awaiterConfig.Value.Timeout)
        {
            Timeout = awaiterConfig.Value.Timeout;
            PollingInterval = awaiterConfig.Value.PollingInterval;

            driver.Manage().Timeouts().ImplicitWait = awaiterConfig.Value.ImplicitWait;
        }
    }
}