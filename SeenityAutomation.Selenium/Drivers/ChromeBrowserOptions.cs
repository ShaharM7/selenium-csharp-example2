using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using SeenityAutomation.Selenium.Configuration;

namespace SeenityAutomation.Selenium.Drivers
{
    public class ChromeBrowserOptions : ChromeOptions
    {
        public ChromeBrowserOptions(IOptions<ChromeBrowserOptionsConfig> chromeBrowserOptionsConfig)
        {
            AddArguments(chromeBrowserOptionsConfig.Value.Arguments);
        }
    }
}