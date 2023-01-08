using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeenityAutomation.Selenium.Configuration;
using SeenityAutomation.Selenium.Drivers;
using SeenityAutomation.Selenium.Navigation;
using SeenityAutomation.Selenium.Pages;

namespace SeenityAutomation.Selenium
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ------------------------------- Configuration -------------------------------------------
            services.Configure<NavigationConfig>(Configuration.GetSection(nameof(NavigationConfig)));
            services.Configure<AwaiterConfig>(Configuration.GetSection(nameof(AwaiterConfig)));
            services.Configure<ChromeBrowserOptionsConfig>(Configuration.GetSection(nameof(ChromeBrowserOptionsConfig)));
            services.Configure<RemoteBrowserConfig>(Configuration.GetSection(nameof(RemoteBrowserConfig)));

            // --------------------------------- Drivers -----------------------------------------------
            services.AddSingleton<WebDriverWait, Awaiter>();
            if (Configuration.Get<RemoteBrowserConfig>().UseSeleniumGrid)
            {
                services.AddSingleton<IWebDriver, RemoteBrowser>();
            }
            else if (!Configuration.Get<RemoteBrowserConfig>().UseSeleniumGrid)
            {
                services.AddSingleton<IWebDriver, ChromeBrowser>();
            }

            // ---------------------------------- Pages ------------------------------------------------
            services.AddSingleton<HomePage>();

            // ---------------------------------- Infra -------------------------------------------
            services.AddSingleton<PageNavigator>();
            services.AddSingleton<ChromeOptions, BrowserOptions>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}