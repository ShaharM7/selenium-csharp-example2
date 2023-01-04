using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeenityAutomation.Selenium.Elements;
using static SeenityAutomation.Selenium.TestData;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeenityAutomation.Selenium.Pages
{
    public class HomePage : Page
    {
        private const string CONFIRM_THE_REGULATION_ID = "btUploadDocumentsConfirm";
        private const string NEW_CASE_RADIO_BUTTON_ID = "Header1_CaseLocatorHeaderUC2_BamaCaseIdentifierOptionBoxHT";
        private const string CASE_MONTH_YEAR_INPUT_BOX_ID = "Header1_CaseLocatorHeaderUC2_BamaMonthYearTextBoxHT";
        private const string CASE_NUMBER_INPUT_BOX_ID = "Header1_CaseLocatorHeaderUC2_BamaCaseNumberTextBoxHT";
        private const string LOCATE_CASE_BUTTON_ID = "Header1_CaseLocatorHeaderUC2_SearchHeaderCaseButton";
        private const string CASES_TABLE_CLASS_NAME = "ag-center-cols-container";

        private IWebElement? _confirmTheRegulationsButton;
        private IWebElement? _newCaseRadioButton;
        private IWebElement? _caseMonthYearInputBox;
        private IWebElement? _caseNumberInputBox;
        private IWebElement? _locateCaseButton;
        private Table? _casesTable;

        public HomePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void ConfirmTheRegulations()
        {
            InitConfirmTheRegulationsButton();
            _confirmTheRegulationsButton!.Click();
        }

        public void ChooseNewCase()
        {
            InitNewCaseRadioButton();
            _newCaseRadioButton!.Click();
        }

        public void SearchForCaseMonthYear(string courtCaseNumber)
        {
            InitCaseMonthYearInputBox();
            _caseMonthYearInputBox!.SendKeys(GetCaseMonthYear(courtCaseNumber));
        }

        public void SearchForCaseNumber(string courtCaseNumber)
        {
            InitCaseNumberInputBox();
            _caseNumberInputBox!.SendKeys(GetCaeNumber(courtCaseNumber));
        }

        public void LocateCase()
        {
            InitLocateCaseButton();
            _locateCaseButton!.Click();
        }

        public bool IsCaseExistInTble()
        {
            InitCasesTable();
            var numberOfRows = _casesTable!.GetNumberOfRows();

            if (numberOfRows == 1)
            {
                return true;
            }

            return false;
        }

        private void InitConfirmTheRegulationsButton()
        {
            _confirmTheRegulationsButton = WebDriverWait.Until(ElementToBeClickable(By.Id(CONFIRM_THE_REGULATION_ID)));
        }

        private void InitNewCaseRadioButton()
        {
            _newCaseRadioButton = WebDriverWait.Until(ElementIsVisible(By.Id(NEW_CASE_RADIO_BUTTON_ID)));
        }

        private void InitCaseMonthYearInputBox()
        {
            _caseMonthYearInputBox = WebDriverWait.Until(ElementIsVisible(By.Id(CASE_MONTH_YEAR_INPUT_BOX_ID)));
        }

        private void InitCaseNumberInputBox()
        {
            _caseNumberInputBox = WebDriverWait.Until(ElementIsVisible(By.Id(CASE_NUMBER_INPUT_BOX_ID)));
        }

        private void InitLocateCaseButton()
        {
            _locateCaseButton = WebDriverWait.Until(ElementToBeClickable(By.Id(LOCATE_CASE_BUTTON_ID)));
        }

        private void InitCasesTable()
        {
            IWebElement element = WebDriverWait.Until(ElementIsVisible(By.ClassName(CASES_TABLE_CLASS_NAME)));
            _casesTable = new Table(WebDriver, WebDriverWait, element);
        }
    }
}