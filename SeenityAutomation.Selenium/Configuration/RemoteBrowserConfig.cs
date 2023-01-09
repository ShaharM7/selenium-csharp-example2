namespace SeenityAutomation.Selenium.Configuration
{
    public class RemoteBrowserConfig
    {
        public BrowserStackConfig BrowserStackConfig { get; set; }
        public bool UseSeleniumGrid { get; set; }
        public string SeleniumGridUrl { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
        public string PlatformName { get; set; }
    }
}