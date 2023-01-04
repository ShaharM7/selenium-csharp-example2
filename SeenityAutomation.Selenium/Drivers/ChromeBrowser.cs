using OpenQA.Selenium.Chrome;

namespace SeenityAutomation.Selenium.Drivers
{
    public class ChromeBrowser : ChromeDriver
    {
        public ChromeBrowser(ChromeOptions options) : base(options)
        {
        }
    }
}