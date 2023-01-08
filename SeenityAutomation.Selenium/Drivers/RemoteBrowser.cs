using System;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeenityAutomation.Selenium.Configuration;

namespace SeenityAutomation.Selenium.Drivers
{
    public class RemoteBrowser : RemoteWebDriver
    {
        public RemoteBrowser(Uri remoteAddress, ICapabilities options, IOptions<RemoteBrowserConfig> remoteBrowserConfig,
            DriverOptions browserOptions) : base(remoteAddress, options)
        {
            remoteAddress = new Uri(remoteBrowserConfig.Value.SeleniumGridUrl);
            options = browserOptions!.ToCapabilities();
        }
    }
}