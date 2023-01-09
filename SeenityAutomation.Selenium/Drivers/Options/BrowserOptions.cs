using System.Collections.Generic;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using SeenityAutomation.Selenium.Configuration;

namespace SeenityAutomation.Selenium.Drivers.Options
{
    public sealed class BrowserOptions : ChromeOptions
    {
        public BrowserOptions(IOptions<BrowserOptionsConfig> chromeBrowserOptionsConfig,
            IOptions<RemoteBrowserConfig> remoteBrowserConfig)
        {
            AddArguments(chromeBrowserOptionsConfig.Value.Arguments);

            if (remoteBrowserConfig.Value.UseSeleniumGrid)
            {
                Dictionary<string, object> browserstackOptions = new()
                {
                    {"local", "false"},
                    // {"UserName", "shahar_yLMDKN"},
                    // {"AccessKey", "uptTLMfxMatqmnHyztp6"}
                };
                AddAdditionalOption("BstackOptions", browserstackOptions);

                BrowserName = remoteBrowserConfig.Value.BrowserName;
                BrowserVersion = remoteBrowserConfig.Value.BrowserVersion;
                PlatformName = remoteBrowserConfig.Value.PlatformName;
            }
        }
    }
}