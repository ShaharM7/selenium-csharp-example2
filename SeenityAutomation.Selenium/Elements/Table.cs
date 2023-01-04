using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeenityAutomation.Selenium.Elements
{
    public class Table : AbstractElement
    {
        public Table(IWebDriver driver, WebDriverWait wait, IWebElement element) : base(driver, wait, element)
        {
        }

        public int GetNumberOfRows()
        {
            return Element.FindElements(By.CssSelector("[role='row']")).Count;
        }
    }
}