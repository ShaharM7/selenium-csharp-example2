﻿using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using SeenityAutomation.Selenium.Configuration;

namespace SeenityAutomation.Selenium.Drivers
{
    public class BrowserOptions : ChromeOptions
    {
        public BrowserOptions(IOptions<ChromeBrowserOptionsConfig> chromeBrowserOptionsConfig, IOptions<RemoteBrowserConfig> remoteBrowserConfig)
        {
            AddArguments(chromeBrowserOptionsConfig.Value.Arguments);

            if (remoteBrowserConfig.Value.UseSeleniumGrid)
            {
                BrowserName = remoteBrowserConfig.Value.BrowserName;
                BrowserVersion = remoteBrowserConfig.Value.BrowserVersion;
                PlatformName = remoteBrowserConfig.Value.PlatformName;
            }
        }
    }
}