﻿using System.Collections.Generic;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using SeenityAutomation.Selenium.Configuration;

namespace SeenityAutomation.Selenium.Drivers.Options
{
    public sealed class BrowserOptions : ChromeOptions
    {
        public BrowserOptions(IOptions<BrowserOptionsConfig> chromeBrowserOptionsConfig,
            IOptions<RemoteBrowserConfig> remoteBrowserConfig, IOptions<BrowserStackConfig> browserStackConfig)
        {
            AddArguments(chromeBrowserOptionsConfig.Value.Arguments);

            if (remoteBrowserConfig.Value.UseSeleniumGrid)
            {
                // Dictionary<string, object> browserstackOptions = new();
                // browserstackOptions.Add("local", "false");
                // browserstackOptions.Add("userName", "shahar_yLMDKN");
                // browserstackOptions.Add("accessKey", "uptTLMfxMatqmnHyztp6");
                // AddAdditionalOption("bstack:options", browserstackOptions);

                BrowserName = remoteBrowserConfig.Value.BrowserName;
                BrowserVersion = remoteBrowserConfig.Value.BrowserVersion;
                PlatformName = remoteBrowserConfig.Value.PlatformName;
            }
        }
    }
}