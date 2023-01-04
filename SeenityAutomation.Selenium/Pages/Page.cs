using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeenityAutomation.Selenium.Pages
{
    public abstract class Page
    {
        protected IWebDriver WebDriver;
        protected WebDriverWait WebDriverWait;

        public Page(IWebDriver webDriver, WebDriverWait webDriverWait)
        {
            WebDriver = webDriver;
            WebDriverWait = webDriverWait;
        }
    }
}