namespace SeenityAutomation.Selenium
{
    public static class TestData
    {
        public const string CorrectCaseNumber = "467-02-19";

        public static string GetCaseMonthYear(string input)
        {
            string[] parts = input.Split('-');
            return parts[1] + "-" + parts[2];
        }

        public static string GetCaeNumber(string input)
        {
            return input.Split('-')[0];
        }
    }
}