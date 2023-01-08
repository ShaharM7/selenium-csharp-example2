using System;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SeenityAutomation.Selenium.Configuration;

namespace SeenityAutomation.Selenium.Drivers
{
    public class RemoteBrowser : RemoteWebDriver
    {
        public RemoteBrowser(IOptions<RemoteBrowserConfig> remoteBrowserConfig, ChromeOptions browserOptions)
            : base(new Uri(remoteBrowserConfig.Value.SeleniumGridUrl), browserOptions)
        {
        }
    }
}