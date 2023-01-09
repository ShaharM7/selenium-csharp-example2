using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeenityAutomation.Selenium.Elements
{
    public abstract class AbstractElement
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        protected IWebElement Element;

        public AbstractElement(IWebDriver driver, WebDriverWait wait, IWebElement element)
        {
            Driver = driver;
            Wait = wait;
            Element = element;
        }
    }
}