using System;

namespace SeenityAutomation.Selenium.Configuration
{
    public class AwaiterConfig
    {
        public TimeSpan Timeout { get; set; }
        public TimeSpan PollingInterval { get; set; }
        public TimeSpan ImplicitWait { get; set; }
        public TimeSpan AsynchronousJavaScript { get; set; }
        public TimeSpan PageLoad { get; set; }
    }
}